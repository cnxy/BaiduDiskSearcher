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
            list.Clear();
            dataGridView.Rows.Clear();
            rowIndex = 0;
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
                    labelCount.Text = "已完成";
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

       List <Item> list = new List<Item>();
        CancellationTokenSource cts ;
        int rowIndex;
        private void Handler_ItemShown(object sender, ItemEventArgs e)
        {
            InvokeToForm(() => 
            {
                list.Add(e.Item);
                try
                {
                    this.dataGridView.Rows.Add();
                    this.dataGridView.Rows[rowIndex].Cells[0].Value = rowIndex + 1;
                    this.dataGridView.Rows[rowIndex].Cells[1].Value = e.Item.FileName;
                    this.dataGridView.Rows[rowIndex].Cells[2].Value = e.Item.FileNameExt;
                    this.dataGridView.Rows[rowIndex].Cells[3].Value = e.Item.Type;
                    this.dataGridView.Rows[rowIndex].Cells[4].Value = e.Item.Time;
                    this.dataGridView.Rows[rowIndex].Cells[5].Value = e.Item.Size;
                    this.dataGridView.Rows[rowIndex].Cells[6].Value = e.Item.Sharer;
                    this.dataGridView.Rows[rowIndex].Cells[7].Value = e.Item.Site;
                    rowIndex++;
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
                }
                catch { }
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
                    for (int i=0;i< this.dataGridView.Columns.Count;i++)
                    {
                        if(i != this.dataGridView.Columns.Count -1)
                        {
                            temp.Append(this.dataGridView.Columns[i].HeaderText + ",");
                        }
                        else
                        {
                            temp.Append(this.dataGridView.Columns[i].HeaderText + "\r\n");
                        }
                    }
                    
                    for (int i=0;i<dataGridView.Rows.Count;i++)
                    {
                        temp.Append(this.dataGridView.Rows[i].Cells[0].Value + "," +
                            this.dataGridView.Rows[i].Cells[1].Value.ToString().Replace(",", "，") + "," +
                            this.dataGridView.Rows[i].Cells[2].Value + "," +
                            this.dataGridView.Rows[i].Cells[3].Value + "," +
                            this.dataGridView.Rows[i].Cells[4].Value + "," +
                            this.dataGridView.Rows[i].Cells[5].Value + "," +
                            this.dataGridView.Rows[i].Cells[6].Value + "," +
                            this.dataGridView.Rows[i].Cells[7].Value + "\r\n");
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
            if (list[currIndex].FileNameExt != null)
            {
                Clipboard.SetText(list[currIndex].FileName + "." + list[currIndex].FileNameExt);
            }
            else
            {
                Clipboard.SetText(list[currIndex].FileName);
            }
        }

        int currIndex;
        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (this.dataGridView.CurrentRow != null && this.dataGridView.CurrentRow.Index != -1)
            {
                contextMenuStrip.Enabled = true;
                currIndex = (int)this.dataGridView.Rows[this.dataGridView.CurrentRow.Index].Cells[0].Value - 1;
            }
            else
            {
                contextMenuStrip.Enabled = false;
            }
        }

        private void 打开网盘地址ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list[currIndex].Site != null)
            {
                Process.Start(list[currIndex].Site);
            }
        }

        private void 复制网盘地址ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(list[currIndex].Site != null)
            {
                Clipboard.SetText(list[currIndex].Site);
            }
        }

        private void 打开分享者主页ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list[currIndex].SharerSite != null)
            {
                Process.Start(list[currIndex].SharerSite);
            }
        }

        private void 复制分享者主页ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list[currIndex].SharerSite != null)
            {
                Clipboard.SetText(list[currIndex].SharerSite);
            }
        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dataGridView.Rows.Clear();
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
                Process.Start(list[(int)this.dataGridView.Rows[e.RowIndex].Cells[0].Value - 1].Site);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            labelVersion.Text = $"版本：{Assembly.GetExecutingAssembly().GetName().Version.ToString()}";
        }
    }
}
