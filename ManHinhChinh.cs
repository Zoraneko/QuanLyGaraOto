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

     
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dx = MessageBox.Show("Bạn có chắc là muốn Đăng xuất?", "Quản Lý Gara", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dx == DialogResult.Yes)
            {
                this.Close();
            }    
        }

        private void ManHinhChinh_Load(object sender, EventArgs e)
        {
            textBox1.Text = this.ten;
            textBox2.Text = this.vaitro;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
            form1 = null;
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DanhSachXe form2 = new DanhSachXe();
            this.Hide();
            form2.ShowDialog();
            form2 = null;
            this.Show();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            BaoCaoDoanhSo bcds = new BaoCaoDoanhSo();
            this.Hide();
            bcds.ShowDialog();
            bcds = null;
            this.Show();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            BaoCaoTon bct = new BaoCaoTon();
            this.Hide();
            bct.ShowDialog();
            bct = null;
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ThayDoiQuyDinh tdqd = new ThayDoiQuyDinh();
            this.Hide();
            tdqd.ShowDialog();
            tdqd = null;
            this.Show();
        }
    }
}
