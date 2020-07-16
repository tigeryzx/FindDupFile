namespace FindDupFile
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtPaths = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnAddPath = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tlbAction = new System.Windows.Forms.ToolStripStatusLabel();
            this.gvDupFileGroup = new System.Windows.Forms.DataGridView();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvDupFile = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtFileExt = new System.Windows.Forms.TextBox();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.btnReadConfig = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemDelSelFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDelNotSelFile = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pnPerview = new System.Windows.Forms.Panel();
            this.dupCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mD5DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dupFileInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pathDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mD5DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scanFileInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDupFileGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDupFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dupFileInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scanFileInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPaths
            // 
            this.txtPaths.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPaths.Location = new System.Drawing.Point(12, 12);
            this.txtPaths.Multiline = true;
            this.txtPaths.Name = "txtPaths";
            this.txtPaths.Size = new System.Drawing.Size(933, 107);
            this.txtPaths.TabIndex = 0;
            // 
            // btnAddPath
            // 
            this.btnAddPath.Location = new System.Drawing.Point(12, 125);
            this.btnAddPath.Name = "btnAddPath";
            this.btnAddPath.Size = new System.Drawing.Size(75, 23);
            this.btnAddPath.TabIndex = 1;
            this.btnAddPath.Text = "添加路径";
            this.btnAddPath.UseVisualStyleBackColor = true;
            this.btnAddPath.Click += new System.EventHandler(this.btnAddPath_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(93, 125);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "检查重复";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlbAction});
            this.statusStrip1.Location = new System.Drawing.Point(0, 520);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(957, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tlbAction
            // 
            this.tlbAction.Name = "tlbAction";
            this.tlbAction.Size = new System.Drawing.Size(31, 17);
            this.tlbAction.Text = "就绪";
            // 
            // gvDupFileGroup
            // 
            this.gvDupFileGroup.AllowUserToAddRows = false;
            this.gvDupFileGroup.AllowUserToDeleteRows = false;
            this.gvDupFileGroup.AllowUserToOrderColumns = true;
            this.gvDupFileGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvDupFileGroup.AutoGenerateColumns = false;
            this.gvDupFileGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDupFileGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dupCountDataGridViewTextBoxColumn,
            this.pathDataGridViewTextBoxColumn,
            this.Size,
            this.mD5DataGridViewTextBoxColumn});
            this.gvDupFileGroup.DataSource = this.dupFileInfoBindingSource;
            this.gvDupFileGroup.Location = new System.Drawing.Point(3, 3);
            this.gvDupFileGroup.Name = "gvDupFileGroup";
            this.gvDupFileGroup.ReadOnly = true;
            this.gvDupFileGroup.RowTemplate.Height = 24;
            this.gvDupFileGroup.Size = new System.Drawing.Size(701, 179);
            this.gvDupFileGroup.TabIndex = 4;
            this.gvDupFileGroup.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvDupFileGroup_RowEnter);
            this.gvDupFileGroup.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.gvDupFileGroup_RowPostPaint);
            // 
            // Size
            // 
            this.Size.DataPropertyName = "Size";
            this.Size.HeaderText = "大小";
            this.Size.Name = "Size";
            this.Size.ReadOnly = true;
            // 
            // gvDupFile
            // 
            this.gvDupFile.AllowUserToAddRows = false;
            this.gvDupFile.AllowUserToDeleteRows = false;
            this.gvDupFile.AllowUserToOrderColumns = true;
            this.gvDupFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvDupFile.AutoGenerateColumns = false;
            this.gvDupFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDupFile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pathDataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.mD5DataGridViewTextBoxColumn1});
            this.gvDupFile.DataSource = this.scanFileInfoBindingSource;
            this.gvDupFile.Location = new System.Drawing.Point(3, 3);
            this.gvDupFile.Name = "gvDupFile";
            this.gvDupFile.ReadOnly = true;
            this.gvDupFile.RowTemplate.Height = 24;
            this.gvDupFile.Size = new System.Drawing.Size(701, 156);
            this.gvDupFile.TabIndex = 5;
            this.gvDupFile.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.gvDupFileGroup_RowPostPaint);
            this.gvDupFile.SelectionChanged += new System.EventHandler(this.gvDupFile_SelectionChanged);
            this.gvDupFile.DoubleClick += new System.EventHandler(this.gvDupFile_DoubleClick);
            this.gvDupFile.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gvDupFile_MouseDown);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Size";
            this.dataGridViewTextBoxColumn1.HeaderText = "大小";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(783, 125);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(162, 22);
            this.txtSearch.TabIndex = 6;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // txtFileExt
            // 
            this.txtFileExt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileExt.Location = new System.Drawing.Point(336, 125);
            this.txtFileExt.Name = "txtFileExt";
            this.txtFileExt.Size = new System.Drawing.Size(441, 22);
            this.txtFileExt.TabIndex = 7;
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(174, 125);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(75, 23);
            this.btnSaveConfig.TabIndex = 8;
            this.btnSaveConfig.Text = "保存配置";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // btnReadConfig
            // 
            this.btnReadConfig.Location = new System.Drawing.Point(255, 125);
            this.btnReadConfig.Name = "btnReadConfig";
            this.btnReadConfig.Size = new System.Drawing.Size(75, 23);
            this.btnReadConfig.TabIndex = 9;
            this.btnReadConfig.Text = "读取配置";
            this.btnReadConfig.UseVisualStyleBackColor = true;
            this.btnReadConfig.Click += new System.EventHandler(this.btnReadConfig_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gvDupFileGroup);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gvDupFile);
            this.splitContainer1.Size = new System.Drawing.Size(709, 355);
            this.splitContainer1.SplitterDistance = 187;
            this.splitContainer1.TabIndex = 10;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemOpenFolder,
            this.MenuItemOpenFile,
            this.toolStripSeparator1,
            this.MenuItemDelSelFile,
            this.MenuItemDelNotSelFile});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(159, 98);
            // 
            // MenuItemOpenFolder
            // 
            this.MenuItemOpenFolder.Name = "MenuItemOpenFolder";
            this.MenuItemOpenFolder.Size = new System.Drawing.Size(158, 22);
            this.MenuItemOpenFolder.Text = "打开选择项目录";
            // 
            // MenuItemOpenFile
            // 
            this.MenuItemOpenFile.Name = "MenuItemOpenFile";
            this.MenuItemOpenFile.Size = new System.Drawing.Size(158, 22);
            this.MenuItemOpenFile.Text = "打开选择项";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(155, 6);
            // 
            // MenuItemDelSelFile
            // 
            this.MenuItemDelSelFile.Name = "MenuItemDelSelFile";
            this.MenuItemDelSelFile.Size = new System.Drawing.Size(158, 22);
            this.MenuItemDelSelFile.Text = "删除选择项";
            // 
            // MenuItemDelNotSelFile
            // 
            this.MenuItemDelNotSelFile.Name = "MenuItemDelNotSelFile";
            this.MenuItemDelNotSelFile.Size = new System.Drawing.Size(158, 22);
            this.MenuItemDelNotSelFile.Text = "删除未选择项";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Location = new System.Drawing.Point(12, 154);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.pnPerview);
            this.splitContainer2.Size = new System.Drawing.Size(933, 363);
            this.splitContainer2.SplitterDistance = 717;
            this.splitContainer2.TabIndex = 11;
            this.splitContainer2.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer2_SplitterMoved);
            // 
            // pnPerview
            // 
            this.pnPerview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnPerview.Location = new System.Drawing.Point(0, 0);
            this.pnPerview.Name = "pnPerview";
            this.pnPerview.Size = new System.Drawing.Size(210, 361);
            this.pnPerview.TabIndex = 0;
            // 
            // dupCountDataGridViewTextBoxColumn
            // 
            this.dupCountDataGridViewTextBoxColumn.DataPropertyName = "DupCount";
            this.dupCountDataGridViewTextBoxColumn.HeaderText = "重复次数";
            this.dupCountDataGridViewTextBoxColumn.Name = "dupCountDataGridViewTextBoxColumn";
            this.dupCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.dupCountDataGridViewTextBoxColumn.Width = 80;
            // 
            // pathDataGridViewTextBoxColumn
            // 
            this.pathDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pathDataGridViewTextBoxColumn.DataPropertyName = "Path";
            this.pathDataGridViewTextBoxColumn.HeaderText = "路径";
            this.pathDataGridViewTextBoxColumn.Name = "pathDataGridViewTextBoxColumn";
            this.pathDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mD5DataGridViewTextBoxColumn
            // 
            this.mD5DataGridViewTextBoxColumn.DataPropertyName = "MD5";
            this.mD5DataGridViewTextBoxColumn.HeaderText = "MD5";
            this.mD5DataGridViewTextBoxColumn.Name = "mD5DataGridViewTextBoxColumn";
            this.mD5DataGridViewTextBoxColumn.ReadOnly = true;
            this.mD5DataGridViewTextBoxColumn.Width = 200;
            // 
            // dupFileInfoBindingSource
            // 
            this.dupFileInfoBindingSource.DataSource = typeof(FindDupFile.DupFileInfo);
            // 
            // pathDataGridViewTextBoxColumn1
            // 
            this.pathDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pathDataGridViewTextBoxColumn1.DataPropertyName = "Path";
            this.pathDataGridViewTextBoxColumn1.HeaderText = "路径";
            this.pathDataGridViewTextBoxColumn1.Name = "pathDataGridViewTextBoxColumn1";
            this.pathDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // mD5DataGridViewTextBoxColumn1
            // 
            this.mD5DataGridViewTextBoxColumn1.DataPropertyName = "MD5";
            this.mD5DataGridViewTextBoxColumn1.HeaderText = "MD5";
            this.mD5DataGridViewTextBoxColumn1.Name = "mD5DataGridViewTextBoxColumn1";
            this.mD5DataGridViewTextBoxColumn1.ReadOnly = true;
            this.mD5DataGridViewTextBoxColumn1.Width = 200;
            // 
            // scanFileInfoBindingSource
            // 
            this.scanFileInfoBindingSource.DataSource = typeof(FindDupFile.ScanFileInfo);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 542);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.btnReadConfig);
            this.Controls.Add(this.btnSaveConfig);
            this.Controls.Add(this.txtFileExt);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnAddPath);
            this.Controls.Add(this.txtPaths);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "重复文件查找";
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDupFileGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDupFile)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dupFileInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scanFileInfoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPaths;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnAddPath;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tlbAction;
        private System.Windows.Forms.DataGridView gvDupFileGroup;
        private System.Windows.Forms.BindingSource dupFileInfoBindingSource;
        private System.Windows.Forms.DataGridView gvDupFile;
        private System.Windows.Forms.BindingSource scanFileInfoBindingSource;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn dupCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn mD5DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn mD5DataGridViewTextBoxColumn1;
        private System.Windows.Forms.TextBox txtFileExt;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.Button btnReadConfig;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemOpenFolder;
        private System.Windows.Forms.ToolStripMenuItem MenuItemOpenFile;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDelSelFile;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDelNotSelFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel pnPerview;
    }
}

