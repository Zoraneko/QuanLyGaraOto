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
    public partial class BaoCaoTon : Form
    {
        public string ten;
        public string vaitro;
        public BaoCaoTon()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BaoCaoTon_Load(object sender, EventArgs e)
        {
            textBox6.Text = this.ten;
            textBox5.Text = this.vaitro;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dx = MessageBox.Show("Bạn có chắc là muốn Đăng xuất?", "Quản Lý Gara", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dx == DialogResult.Yes)
            {

                DialogResult = DialogResult.Abort;
                this.Close();
            }
        }

        private void BaoCaoTon_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (DialogResult)
            {
                case DialogResult.Yes: // Tiep Nhan Sua Chua
                    break;
                case DialogResult.No: // Tra Cuu Xe
                    break;
                case DialogResult.OK: // Bao Cao Doanh So
                    break;
                case DialogResult.Ignore: // Bao Cao Ton
                    break;
                case DialogResult.Abort: // Dang Xuat
                    break;
                default:
                    e.Cancel = true;
                    MessageBox.Show("Vui lòng đăng xuất trước khi thoát.", "Quản Lý Gara", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }
    }
}
