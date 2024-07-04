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
    public partial class PhieuThuTien : Form
    {
        public int tienno;
        public string bienSo;
        public string hoTenChuXe;
        public PhieuThuTien()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if(int.Parse(textBox3.Text.ToString()) <= tienno)
            {

            }    
        }

        private void button1_Click(object sender, EventArgs e)//thoát
        {
            this.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)//chỉ nhập số
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void PhieuThuTien_Load(object sender, EventArgs e)
        {
            textBox3.Text = tienno.ToString();
            label9.Text = bienSo;
            label8.Text = hoTenChuXe;
        }
    }
}
