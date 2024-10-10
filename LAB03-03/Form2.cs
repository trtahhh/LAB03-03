using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB03_03
{
    public partial class Form2 : Form
    {
        public Form1 form1;
        public delegate void AddData(string mssv, string hoten, string khoa, double avgs);
        public AddData addDataToGrid;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "Công nghệ thông tin";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mssv = textBox1.Text;
            string hoten = textBox2.Text;
            string avgtext = textBox3.Text; 
            double avgs;
            string khoa = comboBox1.SelectedItem.ToString();
            if(string.IsNullOrEmpty(mssv) || string.IsNullOrEmpty(hoten) || string.IsNullOrEmpty(avgtext))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
           
            if (form1.CheckId(mssv))
            {
                MessageBox.Show("Mã số sinh viên đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if(!double.TryParse(avgtext, out avgs) || avgs < 0 || avgs > 10)
            {
                MessageBox.Show("Điểm phải nằm trong khoảng từ 0 đến 10!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    
           
            addDataToGrid(mssv, hoten, khoa, avgs);
            this.Close();
            MessageBox.Show("Thêm thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var noti = MessageBox.Show("Bạn có muốn thoát chương trình", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (noti == DialogResult.Yes) 
            {
                this.Close();
            }
        }
    }
}
