using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace BaiduDiskSearcher
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        WebHandler handler;

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBoxKeyword.Text))
            {
                MessageBox.Show("关键字不能为空！请重新输入！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (textBoxKeyword.Text.CheckLegalFileName())
            {
                MessageBox.Show("关键字含有非法字符！请重新输入！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            handler = new WebHandler($"http://m.panduoduo.net/s/name/{textBoxKeyword.Text}");
            handler.PageShown += Handler_PageShown;
            handler.ItemShown += Handler_ItemShown;
            dataTable = new ItemDataTable();
            dataGridView.DataSource = dataTable.GetItems();
            labelCount.Text = "";
            progressBar.Value = 0;
            cts = new CancellationTokenSource();
            buttonSearch.Enabled = false;
            buttonStop.Enabled = true;
            Task.Factory.StartNew(() => 
            {
                handler.Handle();
                InvokeToForm(() =>
                {
                    if(!cts.IsCancellationRequested) labelCount.Text = "已完成";
                    buttonSearch.Enabled = true;
                    buttonStop.Enabled = false;
                });
            });
        }

        private void Handler_PageShown(object sender, PageEventArgs e)
        {
            InvokeToForm(() =>
            {
                progressBar.Maximum = e.Page.TotalNumber;
            });
        }
        ItemDataTable dataTable = new ItemDataTable();
        CancellationTokenSource cts ;
        int rowIndex;
        private void Handler_ItemShown(object sender, ItemEventArgs e)
        {
            InvokeToForm(() => 
            {
                rowIndex = dataTable.Add(e.Item);
                progressBar.Value = rowIndex;
                if (rowIndex != progressBar.Maximum)
                {
                    labelCount.Text = $"{rowIndex}/{progressBar.Maximum}";
                }
                e.Cancel = cts.IsCancellationRequested;
                if (e.Cancel)
                {
                    labelCount.Text = "已取消";
                }
            });
        }

        private void InvokeToForm(Action action)
        {
            this.Invoke(action);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            cts?.Cancel();
            buttonSearch.Enabled = true;
            buttonStop.Enabled = false;
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count == 0) return;
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "Excel文件(*.csv)|*.csv";
                dialog.FileName = textBoxKeyword.Text;
                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder temp = new StringBuilder();
                    for (int i = 0 ;i< this.dataGridView.Columns.Count - 1;i++)
                    {
                        if(i != this.dataGridView.Columns.Count - 2)
                        {
                            temp.Append(this.dataGridView.Columns[i].HeaderText + ",");
                        }
                        else
                        {
                            temp.Append(this.dataGridView.Columns[i].HeaderText + "\r\n");
                        }
                    }
                    Item[] items = dataTable.GetItems(out int[] counts);
                    for(int i = 0;i<items.Length; i++)
                    {
                        temp.Append(counts[i] + "," + items[i].FileName.Replace(",", "，") + "," + items[i].FileNameExt + "," +
                           items[i].Type + "," + items[i].Time+ "," + items[i].Size + "," + items[i].Sharer + "," + items[i].Site + "\r\n");
                    }
                    StreamWriter writer = new StreamWriter(dialog.FileName,false,Encoding.UTF8);
                    writer.Write(temp.ToString());
                    writer.Close();
                    MessageBox.Show("导出数据成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    
        private void 复制文件名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currItem.FileNameExt != null)
            {
                Clipboard.SetText(currItem.FileName + "." + currItem.FileNameExt);
            }
            else
            {
                Clipboard.SetText(currItem.FileName);
            }
        }

        Item currItem;
        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (this.dataGridView.CurrentRow != null && this.dataGridView.CurrentRow.Index != -1)
            {
                contextMenuStrip.Enabled = true;
                if(!buttonSearch.Enabled)
                {
                    清空ToolStripMenuItem.Enabled = false;
                }
                else
                {
                    清空ToolStripMenuItem.Enabled = true;
                }
                currItem = ((Item)((DataRowView)this.dataGridView.Rows[this.dataGridView.CurrentRow.Index].DataBoundItem).Row.ItemArray[8]);
            }
            else
            {
                contextMenuStrip.Enabled = false;
            }
        }

        private void 打开网盘地址ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currItem.Site != null)
            {
                Process.Start(currItem.Site);
            }
        }

        private void 复制网盘地址ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currItem.Site != null)
            {
                Clipboard.SetText(currItem.Site);
            }
        }

        private void 打开分享者主页ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currItem.SharerSite != null)
            {
                Process.Start(currItem.SharerSite);
            }
        }

        private void 复制分享者主页ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currItem.SharerSite != null)
            {
                Clipboard.SetText(currItem.SharerSite);
            }
        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for(int i= this.dataGridView.Rows.Count-1; i>=0; i--)
            {
                this.dataGridView.Rows.RemoveAt(i);
            }
            labelCount.Text = "";
            progressBar.Value = 0;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("确定要退出吗？","信息",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"百度网盘搜索工具\r\n版本：{Assembly.GetExecutingAssembly().GetName().Version.ToString()}\r\n作者WeChat：cnxycn\r\nEmail：cnc46@qq.com","信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void textBoxKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                buttonSearch.PerformClick();
            }
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                Item item = ((Item)((DataRowView)this.dataGridView.Rows[this.dataGridView.CurrentRow.Index].DataBoundItem).Row.ItemArray[8]);
                Process.Start(item.Site);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dataGridView.AutoGenerateColumns = false;
            labelVersion.Text = $"版本：{Assembly.GetExecutingAssembly().GetName().Version.ToString()}";
            textBoxKeyword.Focus();
        }
    }
}
