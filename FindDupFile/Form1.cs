using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindDupFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.gvDupFile.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.gvDupFileGroup.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            this.MenuItemOpenFolder.Click += MenuItemOpenFolder_Click;
            this.MenuItemOpenFile.Click += MenuItemOpenFile_Click;
            this.MenuItemDelSelFile.Click += MenuItemDelSelFile_Click;
            this.MenuItemDelNotSelFile.Click += MenuItemDelNotSelFile_Click;

            this.LoadConfig();
        }

        private void MenuItemDelNotSelFile_Click(object sender, EventArgs e)
        {
            this.DeleteFile(this.GetNotSelFileInfo());
        }

        private void MenuItemDelSelFile_Click(object sender, EventArgs e)
        {
            this.DeleteFile(this.GetSelFileInfo());
        }

        private void MenuItemOpenFile_Click(object sender, EventArgs e)
        {
            this.OpenFile(this.GetSelFileInfo());
        }

        private void MenuItemOpenFolder_Click(object sender, EventArgs e)
        {
            this.OpenFileFolder(this.GetSelFileInfo());
        }

        private ScanFileInfo[] GetSelFileInfo()
        {
            if (this.gvDupFile.SelectedRows == null || this.gvDupFile.SelectedRows.Count <= 0)
                return null;

            List<ScanFileInfo> result = new List<ScanFileInfo>();
            for (var i = 0; i < this.gvDupFile.SelectedRows.Count; i++)
            {
                var row = this.gvDupFile.SelectedRows[i].DataBoundItem as ScanFileInfo;
                result.Add(row);
            }
            return result.ToArray();
        }

        private ScanFileInfo[] GetNotSelFileInfo()
        {
            if (this.gvDupFile.Rows == null || this.gvDupFile.Rows.Count <= 0)
                return null;
            
            List<ScanFileInfo> result = new List<ScanFileInfo>();
            for (var i = 0; i < this.gvDupFile.Rows.Count; i++)
            {
                var row = this.gvDupFile.Rows[i];

                if (row.Selected)
                    continue;

                result.Add(row.DataBoundItem as ScanFileInfo);
            }
            return result.ToArray();
        }

        private List<string> ScanPaths = new List<string>();
        private List<ScanFileInfo> ScanFiles = new List<ScanFileInfo>();
        private List<DupFileInfo> DupFileGroupList = new List<DupFileInfo>();
        private string SearchFileExt = "";

        private void LoadConfig()
        {
            this.txtFileExt.Text = AppSettings.GetValue("searchFileExt");
            this.txtPaths.Text = AppSettings.GetValue("searchPaths");

            var resultWindowHeightyPercent = Convert.ToDouble(AppSettings.GetValue("resultWindowHeightyPercent"));
            this.splitContainer1.SplitterDistance = Convert.ToInt32(this.splitContainer1.Height * resultWindowHeightyPercent);

            this.SearchFileExt = this.txtFileExt.Text;
            this.ScanPaths.AddRange(this.txtPaths.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));
        }

        private void SaveConfig()
        {
            AppSettings.SetValue("searchFileExt", this.txtFileExt.Text);
            AppSettings.SetValue("searchPaths", this.txtPaths.Text);

            var resultWindowHeightyPercent = Convert.ToDouble(this.splitContainer1.SplitterDistance) / Convert.ToDouble(this.splitContainer1.Height);
            AppSettings.SetValue("resultWindowHeightyPercent", resultWindowHeightyPercent.ToString());
        }

        private void btnAddPath_Click(object sender, EventArgs e)
        {
            if(this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                var selPath = this.folderBrowserDialog1.SelectedPath;
                if (Directory.Exists(selPath) && !this.ScanPaths.Exists(x => x.ToLower() == selPath.ToLower()))
                    this.txtPaths.AppendText(selPath + "\r\n");

                var paths = this.txtPaths.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                this.ScanPaths.Clear();
                this.ScanPaths.AddRange(paths);
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            this.DupFileGroupList.Clear();
            this.ScanFiles.Clear();
            this.ScanPaths.Clear();

            this.SearchFileExt = this.txtFileExt.Text;
            this.ScanPaths.AddRange(this.txtPaths.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));

            Task.Run(() =>
            {
                this.ScanFile();

                this.ComparisonFile();
            });
        }

        private void ScanFile()
        {
            string[] fileExts = this.SearchFileExt.ToLower().Split(';');

            this.UpdateAction("查找文件中...");

            List<string> filePaths = new List<string>();
            foreach (var path in this.ScanPaths)
            {
                var filepaths = Directory
                    .GetFiles(path, "*.*", SearchOption.AllDirectories)
                    .Where(x => fileExts.Contains(Path.GetExtension(x).ToLower()));

                foreach (var fp in filepaths)
                {
                    this.ScanFiles.Add(new ScanFileInfo()
                    {
                        Path = fp
                    });
                }
            }

            this.UpdateAction($"共查找{ScanFiles.Count}个文件");
        }

        private void ComparisonFile()
        {
            this.UpdateAction("開始生成MD5...");

            this.RunTask(this.ScanFiles, new Func<ScanFileInfo, ScanFileInfo>(x =>
             {
                 x.MD5 = GetMD5HashFromFile(x.Path);
                 this.UpdateCount();
                 return x;
             }), 5);

            this.UpdateCount();

            this.Invoke(new Action(() =>
            {

                var dupKeys = this
                    .ScanFiles.GroupBy(x => x.MD5).Where(x => x.Count() > 1)
                    .Select(x => x.Key);

                List<DupFileInfo> dupFileList = new List<DupFileInfo>();

                foreach (var dk in dupKeys)
                {
                    var dki = this.ScanFiles.Where(x => x.MD5 == dk).ToList();
                    dupFileList.Add(new DupFileInfo()
                    {
                        DupCount = dki.Count(),
                        MD5 = dk,
                        Path = dki[0].Path
                    });
                }
                this.DupFileGroupList = dupFileList;
                this.gvDupFileGroup.DataSource = this.DupFileGroupList;
            }));
        }

        private void UpdateCount()
        {
            var hc = this.ScanFiles.Count(y => !string.IsNullOrEmpty(y.MD5));
            this.UpdateAction($"生成MD5[{hc}/{this.ScanFiles.Count}]");
        }

        private void UpdateAction(string info)
        {
            this.Invoke(new Action(() => 
            {
                this.tlbAction.Text = info;
            }));
        }

        /// <summary>
        /// 多线程处理数据（返回处理后列表）
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="list">待处理数据</param>
        /// <param name="func">数据处理方法（有参数有返回值）</param>
        /// <param name="threadCount">处理线程数量</param>
        /// <returns>数据处理后结果</returns>
        private List<T> RunTask<T>(List<T> list, Func<T, T> func, int threadCount = 5)
        {
            var result = new List<T>();
            ConcurrentQueue<T> queue = new ConcurrentQueue<T>(list);
            Task<List<T>>[] tasks = new Task<List<T>>[threadCount];
            for (int i = 0; i < threadCount; i++)
            {
                tasks[i] = Task.Run<List<T>>(() =>
                {
                    var rList = new List<T>();
                    while (queue.TryDequeue(out T t))
                    {
                        rList.Add(func(t));
                    }
                    return rList;
                });
            }
            Task.WaitAll(tasks);
            for (int i = 0; i < threadCount; i++)
            {
                result.AddRange(tasks[i].Result);
            }
            return result;
        }

        /// <summary>
        /// 获取文件MD5值
        /// </summary>
        /// <param name="fileName">文件绝对路径</param>
        /// <returns>MD5值</returns>
        public static string GetMD5HashFromFile(string fileName)
        {
            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open);
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("GetMD5HashFromFile() fail,error:" + ex.Message);
            }
        }

        private void gvDupFileGroup_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            var ds = this.gvDupFileGroup.DataSource as List<DupFileInfo>;
            if (ds == null || ds.Count <= 0)
                return;

            var dfi = ds[e.RowIndex];
            var filelist = this.ScanFiles
                .Where(x => x.MD5 == dfi.MD5)
                .ToList();

            this.gvDupFile.DataSource = filelist;
        }

        private void gvDupFileGroup_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dataGrid = sender as DataGridView;
            if (dataGrid == null)
                return;

            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dataGrid.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
            dataGrid.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dataGrid.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void gvDupFile_DoubleClick(object sender, EventArgs e)
        {
            if (this.gvDupFile.CurrentRow == null)
                return;

            var selDupFile = this.gvDupFile.CurrentRow.DataBoundItem as ScanFileInfo;
            if (selDupFile == null)
                return;

            if (!File.Exists(selDupFile.Path))
            {
                MessageBox.Show($"[{selDupFile.Path}]文件不存在!");
                return;
            }

            var path = Path.GetDirectoryName(selDupFile.Path);
            Process.Start("explorer", "/select,\"" + selDupFile.Path + "\"");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var q = this.txtSearch.Text;
            if (string.IsNullOrEmpty(q))
            {
                this.gvDupFileGroup.DataSource = this.DupFileGroupList;

                return;
            }

            var keyword = q.Split(' ');
            if (keyword.Count() <= 0)
                return;

            List<DupFileInfo> source = this.DupFileGroupList;

            foreach (var key in keyword)
            {
                source = source
                    .Where(x => x.Path.ToLower().Contains(key.ToLower()))
                    .ToList();
            }

            if (source == null)
                return;

            this.gvDupFileGroup.DataSource = source;
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            this.SaveConfig();
        }

        private void btnReadConfig_Click(object sender, EventArgs e)
        {
            this.LoadConfig();
        }

        private void gvDupFile_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var selRows = gvDupFile.SelectedRows;
                var selCount = selRows.Count;
                var totalCount = gvDupFile.Rows.Count;
                var notSelCount = totalCount - selCount;

                if (selRows.Count <= 0)
                    return;

                this.MenuItemOpenFolder.Text = $"打开选择目录({selCount})";
                this.MenuItemOpenFile.Text = $"打开选择项({selCount})";
                this.MenuItemDelSelFile.Text = $"删除选择项({selCount})";
                this.MenuItemDelNotSelFile.Text = $"删除未选择项({notSelCount})";

                //弹出操作菜单
                contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
            }
        }


        private void OpenFileFolder(ScanFileInfo[] scanFileInfos)
        {
            if (scanFileInfos == null || scanFileInfos.Length<=0)
                return;

            foreach(var item in scanFileInfos)
            {
                if (!File.Exists(item.Path))
                    continue;

                var path = Path.GetDirectoryName(item.Path);
                Process.Start("explorer", "/select,\"" + item.Path + "\"");
            }
        }

        private void OpenFile(ScanFileInfo[] scanFileInfos)
        {
            if (scanFileInfos == null || scanFileInfos.Length <= 0)
                return;

            foreach (var item in scanFileInfos)
            {
                if (!File.Exists(item.Path))
                    continue;

                var path = Path.GetDirectoryName(item.Path);
                Process.Start(item.Path);
            }
        }

        private void DeleteFile(ScanFileInfo[] scanFileInfos)
        {
            if (scanFileInfos == null || scanFileInfos.Length <= 0)
                return;

            DialogResult result =
                MessageBox.Show($"确定删除[{scanFileInfos.Count()}项]吗？", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            foreach (var item in scanFileInfos)
            {
                if (!File.Exists(item.Path))
                    continue;
                File.Delete(item.Path);
            }
        }
    }
}
