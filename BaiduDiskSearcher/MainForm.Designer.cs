namespace BaiduDiskSearcher
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.labelKeyword = new System.Windows.Forms.ToolStripLabel();
            this.textBoxKeyword = new System.Windows.Forms.ToolStripTextBox();
            this.buttonSearch = new System.Windows.Forms.ToolStripButton();
            this.buttonStop = new System.Windows.Forms.ToolStripButton();
            this.buttonExport = new System.Windows.Forms.ToolStripButton();
            this.buttonAbout = new System.Windows.Forms.ToolStripButton();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.复制文件名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.打开网盘地址ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制网盘地址ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开分享者主页ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制分享者主页ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.清空ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.labelProcess = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.labelCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.ColumnNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFileNameExt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSharer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelKeyword,
            this.textBoxKeyword,
            this.buttonSearch,
            this.buttonStop,
            this.buttonExport,
            this.buttonAbout});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1044, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.TabStop = true;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // labelKeyword
            // 
            this.labelKeyword.Name = "labelKeyword";
            this.labelKeyword.Size = new System.Drawing.Size(44, 22);
            this.labelKeyword.Text = "关键字";
            // 
            // textBoxKeyword
            // 
            this.textBoxKeyword.Name = "textBoxKeyword";
            this.textBoxKeyword.Size = new System.Drawing.Size(400, 25);
            this.textBoxKeyword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxKeyword_KeyDown);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Image = ((System.Drawing.Image)(resources.GetObject("buttonSearch.Image")));
            this.buttonSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(52, 22);
            this.buttonSearch.Text = "搜索";
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Image = ((System.Drawing.Image)(resources.GetObject("buttonStop.Image")));
            this.buttonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(52, 22);
            this.buttonStop.Text = "停止";
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.Image = ((System.Drawing.Image)(resources.GetObject("buttonExport.Image")));
            this.buttonExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(52, 22);
            this.buttonExport.Text = "导出";
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonAbout
            // 
            this.buttonAbout.Image = ((System.Drawing.Image)(resources.GetObject("buttonAbout.Image")));
            this.buttonAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(52, 22);
            this.buttonAbout.Text = "关于";
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNumber,
            this.ColumnFileName,
            this.ColumnFileNameExt,
            this.ColumnType,
            this.ColumnTime,
            this.ColumnSize,
            this.ColumnSharer,
            this.ColumnSite});
            this.dataGridView.ContextMenuStrip = this.contextMenuStrip;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 25);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1044, 514);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复制文件名ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.打开网盘地址ToolStripMenuItem,
            this.复制网盘地址ToolStripMenuItem,
            this.打开分享者主页ToolStripMenuItem,
            this.复制分享者主页ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.清空ToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(161, 148);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // 复制文件名ToolStripMenuItem
            // 
            this.复制文件名ToolStripMenuItem.Name = "复制文件名ToolStripMenuItem";
            this.复制文件名ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.复制文件名ToolStripMenuItem.Text = "复制文件名";
            this.复制文件名ToolStripMenuItem.Click += new System.EventHandler(this.复制文件名ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(157, 6);
            // 
            // 打开网盘地址ToolStripMenuItem
            // 
            this.打开网盘地址ToolStripMenuItem.Name = "打开网盘地址ToolStripMenuItem";
            this.打开网盘地址ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.打开网盘地址ToolStripMenuItem.Text = "打开网盘地址";
            this.打开网盘地址ToolStripMenuItem.Click += new System.EventHandler(this.打开网盘地址ToolStripMenuItem_Click);
            // 
            // 复制网盘地址ToolStripMenuItem
            // 
            this.复制网盘地址ToolStripMenuItem.Name = "复制网盘地址ToolStripMenuItem";
            this.复制网盘地址ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.复制网盘地址ToolStripMenuItem.Text = "复制网盘地址";
            this.复制网盘地址ToolStripMenuItem.Click += new System.EventHandler(this.复制网盘地址ToolStripMenuItem_Click);
            // 
            // 打开分享者主页ToolStripMenuItem
            // 
            this.打开分享者主页ToolStripMenuItem.Name = "打开分享者主页ToolStripMenuItem";
            this.打开分享者主页ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.打开分享者主页ToolStripMenuItem.Text = "打开分享者主页";
            this.打开分享者主页ToolStripMenuItem.Click += new System.EventHandler(this.打开分享者主页ToolStripMenuItem_Click);
            // 
            // 复制分享者主页ToolStripMenuItem
            // 
            this.复制分享者主页ToolStripMenuItem.Name = "复制分享者主页ToolStripMenuItem";
            this.复制分享者主页ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.复制分享者主页ToolStripMenuItem.Text = "复制分享者主页";
            this.复制分享者主页ToolStripMenuItem.Click += new System.EventHandler(this.复制分享者主页ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(157, 6);
            // 
            // 清空ToolStripMenuItem
            // 
            this.清空ToolStripMenuItem.Name = "清空ToolStripMenuItem";
            this.清空ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.清空ToolStripMenuItem.Text = "清空";
            this.清空ToolStripMenuItem.Click += new System.EventHandler(this.清空ToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelProcess,
            this.progressBar,
            this.labelCount,
            this.labelVersion});
            this.statusStrip.Location = new System.Drawing.Point(0, 517);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1044, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // labelProcess
            // 
            this.labelProcess.Name = "labelProcess";
            this.labelProcess.Size = new System.Drawing.Size(32, 17);
            this.labelProcess.Text = "进度";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(200, 16);
            // 
            // labelCount
            // 
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(0, 17);
            // 
            // labelVersion
            // 
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(795, 17);
            this.labelVersion.Spring = true;
            this.labelVersion.Text = "版本";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ColumnNumber
            // 
            this.ColumnNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnNumber.DataPropertyName = "ID";
            this.ColumnNumber.HeaderText = "序号";
            this.ColumnNumber.MinimumWidth = 60;
            this.ColumnNumber.Name = "ColumnNumber";
            this.ColumnNumber.ReadOnly = true;
            this.ColumnNumber.Width = 60;
            // 
            // ColumnFileName
            // 
            this.ColumnFileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnFileName.DataPropertyName = "FileName";
            this.ColumnFileName.HeaderText = "文件名";
            this.ColumnFileName.MinimumWidth = 300;
            this.ColumnFileName.Name = "ColumnFileName";
            this.ColumnFileName.ReadOnly = true;
            this.ColumnFileName.Width = 300;
            // 
            // ColumnFileNameExt
            // 
            this.ColumnFileNameExt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnFileNameExt.DataPropertyName = "FileNameExt";
            this.ColumnFileNameExt.HeaderText = "拓展名";
            this.ColumnFileNameExt.MinimumWidth = 70;
            this.ColumnFileNameExt.Name = "ColumnFileNameExt";
            this.ColumnFileNameExt.ReadOnly = true;
            this.ColumnFileNameExt.Width = 70;
            // 
            // ColumnType
            // 
            this.ColumnType.DataPropertyName = "Type";
            this.ColumnType.HeaderText = "类别";
            this.ColumnType.MinimumWidth = 60;
            this.ColumnType.Name = "ColumnType";
            this.ColumnType.ReadOnly = true;
            this.ColumnType.Width = 60;
            // 
            // ColumnTime
            // 
            this.ColumnTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnTime.DataPropertyName = "Time";
            this.ColumnTime.HeaderText = "时间";
            this.ColumnTime.MinimumWidth = 120;
            this.ColumnTime.Name = "ColumnTime";
            this.ColumnTime.ReadOnly = true;
            this.ColumnTime.Width = 120;
            // 
            // ColumnSize
            // 
            this.ColumnSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnSize.DataPropertyName = "Size";
            this.ColumnSize.HeaderText = "大小";
            this.ColumnSize.MinimumWidth = 100;
            this.ColumnSize.Name = "ColumnSize";
            this.ColumnSize.ReadOnly = true;
            // 
            // ColumnSharer
            // 
            this.ColumnSharer.DataPropertyName = "Sharer";
            this.ColumnSharer.HeaderText = "分享者";
            this.ColumnSharer.MinimumWidth = 120;
            this.ColumnSharer.Name = "ColumnSharer";
            this.ColumnSharer.ReadOnly = true;
            this.ColumnSharer.Width = 120;
            // 
            // ColumnSite
            // 
            this.ColumnSite.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnSite.DataPropertyName = "Site";
            this.ColumnSite.HeaderText = "地址";
            this.ColumnSite.MinimumWidth = 200;
            this.ColumnSite.Name = "ColumnSite";
            this.ColumnSite.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 539);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "百度网盘搜索工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel labelKeyword;
        private System.Windows.Forms.ToolStripTextBox textBoxKeyword;
        private System.Windows.Forms.ToolStripButton buttonSearch;
        private System.Windows.Forms.ToolStripButton buttonStop;
        private System.Windows.Forms.ToolStripButton buttonExport;
        private System.Windows.Forms.ToolStripButton buttonAbout;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel labelProcess;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripStatusLabel labelCount;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 复制文件名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 打开网盘地址ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制网盘地址ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开分享者主页ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制分享者主页ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 清空ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel labelVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFileNameExt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSharer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSite;
    }
}

