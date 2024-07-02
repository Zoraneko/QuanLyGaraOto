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
        private void KiemTraButton(DialogResult d)
        {
            switch (d)
            {
                case DialogResult.Yes: // Tiep Nhan Sua Chua
                    button1.PerformClick();
                    break;
                case DialogResult.No: // Tra Cuu Xe
                    button2.PerformClick();
                    break;
                case DialogResult.OK: // Bao Cao Doanh So
                    button3.PerformClick();
                    break;
                case DialogResult.Ignore: // Bao Cao Ton
                    button6.PerformClick();
                    break;
                case DialogResult.Abort: // Dang Xuat
                    DialogResult = DialogResult.Abort;
                    this.Close();
                    break;
            }
        }

     
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dx = MessageBox.Show("Bạn có chắc là muốn Đăng xuất?", "Quản Lý Gara", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dx == DialogResult.Yes)
            {
                DialogResult = DialogResult.Abort;
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

            form1.ten = this.ten;
            form1.vaitro = this.vaitro;
            form1.Size = this.Size;
            DialogResult d = form1.ShowDialog();
            this.Size = form1.Size;
            form1 = null;
            this.Show();
            KiemTraButton(d);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DanhSachXe form2 = new DanhSachXe();
            this.Hide();

            form2.ten = this.ten;
            form2.vaitro = this.vaitro;
            form2.Size = this.Size;
            DialogResult d = form2.ShowDialog();
            this.Size = form2.Size;
            form2 = null;
            this.Show();
            KiemTraButton(d);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            BaoCaoDoanhSo bcds = new BaoCaoDoanhSo();
            this.Hide();

            bcds.ten = this.ten;
            bcds.vaitro = this.vaitro;
            bcds.Size = this.Size;
            DialogResult d = bcds.ShowDialog();
            this.Size = bcds.Size;
            bcds = null;
            this.Show();
            KiemTraButton(d);
        }


        private void button6_Click(object sender, EventArgs e)
        {
            BaoCaoTon bct = new BaoCaoTon();
            this.Hide();

            bct.ten = this.ten;
            bct.vaitro = this.vaitro;
            bct.Size = this.Size;
            DialogResult d = bct.ShowDialog();
            this.Size = bct.Size;
            bct = null;
            this.Show();
            KiemTraButton(d);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(vaitro == "admin")
            {
                ThayDoiQuyDinh tdqd = new ThayDoiQuyDinh();
                this.Hide();
                tdqd.ShowDialog();
                tdqd = null;
                this.Show();
            }
        }

        private void ManHinhChinh_FormClosing(object sender, FormClosingEventArgs e)
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
