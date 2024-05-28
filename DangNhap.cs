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
    public partial class DangNhap : Form
    {
        List<TaiKhoan> tklist = new List<TaiKhoan>();
        public int vt = -1;// vi tri tai khoan
        public DangNhap()
        {
            InitializeComponent();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            tklist.Add(new TaiKhoan("admin", "123456", "Tuan", "0365819523", "admin"));
            tklist.Add(new TaiKhoan("nvtuan", "123456", "Triệu Minh Tuấn", "0365819523", "Nhân viên"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(kiemtratk(textBox1.Text.ToString(),textBox2.Text.ToString())==true)
            {
                ManHinhChinh mhc = new ManHinhChinh();
                this.Hide();
                mhc.ten = tklist[vt].Ten;
                mhc.vaitro = tklist[vt].Vaitro;
                mhc.ShowDialog();
                mhc = null;
                this.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu nhập sai");
            }   
        }

        private bool kiemtratk(string taikhoan,string matkhau)
        {
           for(int i = 0; i < tklist.Count; i++) 
           {
                if (tklist[i].Taikhoan == taikhoan && tklist[i].Matkhau == matkhau)
                {
                    vt = i;
                    return true;
                }
           }
           return false; 
        }

        
        private void DangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
    }
}
