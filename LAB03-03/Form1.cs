using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LAB03_03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public bool CheckId(string id)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows) 
            {
                if (row.Cells["Column2"].Value != null && row.Cells["Column2"].Value.ToString() == id) 
                {
                    return true;    
                }
            }
            return false;
        }

        private void AddDataToGrid(string mssv, string hoten, string khoa,double avgs)
        {
            int stt = dataGridView1.Rows.Count;
            dataGridView1.Rows.Add(stt, mssv, hoten, khoa, avgs);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.form1 = this;
            form2.addDataToGrid = new Form2.AddData(AddDataToGrid);
            form2.ShowDialog(); 
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var noti = MessageBox.Show("Bạn có muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (noti == DialogResult.Cancel) 
            {
                e.Cancel = true;    
            }
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var noti = MessageBox.Show("Bạn có muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(noti == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Column3"].Value != null)
                {
                    if (row.Cells["Column3"].Value.ToString().ToLower().Contains(toolStripTextBox1.Text.ToLower()))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
        }
    }
}
