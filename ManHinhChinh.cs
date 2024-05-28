using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyGara
{
    public partial class ManHinhChinh : Form
    {
        public string ten;
        public string vaitro;

        public ManHinhChinh()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dx = MessageBox.Show("Bạn có chắc là muốn Đăng xuất?", "Quản Lý Gara", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dx == DialogResult.OK)
            {
                this.Close();
            }    
              
        }

        private void ManHinhChinh_Load(object sender, EventArgs e)
        {
            label2.Text = this.ten;
            label4.Text = this.vaitro;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
            form1 = null;
            this.Show();
        }
    }
}
