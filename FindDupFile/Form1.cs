using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }

        private List<string> ScanPaths = new List<string>();
        private List<ScanFileInfo> ScanFiles = new List<ScanFileInfo>();

        private void btnAddPath_Click(object sender, EventArgs e)
        {
            if(this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                var selPath = this.folderBrowserDialog1.SelectedPath;
                if (Directory.Exists(selPath) && !this.ScanPaths.Exists(x => x.ToLower() == selPath.ToLower()))
                    this.ScanPaths.Add(selPath);
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                this.ScanFile();

                this.ComparisonFile();
            });
        }

        private void ScanFile()
        {
            this.ScanFiles.Clear();
            this.UpdateAction("查找文件中...");
        
            List<string> filePaths = new List<string>();
            foreach (var path in this.ScanPaths)
            {
                var filepaths = Directory
                    .GetFiles(path, "*.cs", SearchOption.AllDirectories);

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
                 var handlCount = this.ScanFiles.Count(y => !string.IsNullOrEmpty(y.MD5));

                 x.MD5 = GetMD5HashFromFile(x.Path);
                 this.UpdateAction($"生成MD5[{handlCount}/{this.ScanFiles.Count}]");
                 return x;
             }), 3);
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
    }
}
