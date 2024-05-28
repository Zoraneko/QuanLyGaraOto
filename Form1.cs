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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e) // chỉ cho nhập số
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        
        private void button1_Click(object sender, EventArgs e) // thêm
        {
            
        }
       
        private void button2_Click(object sender, EventArgs e) // xóa
        {

        }

        private void button3_Click(object sender, EventArgs e) // sửa
        {

        }

        private void button4_Click(object sender, EventArgs e) // thoát
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e) // mở Phieu sua chua
        {
            if (textBox2.Text != "" && textBox1.Text != "" && textBox4.Text != "")
            {
                this.Hide();
                PhieuSuaChua phieuSuaChua = new PhieuSuaChua();
                phieuSuaChua.bienSo = textBox2.Text;
                phieuSuaChua.ngaSuaChua = dateTimePicker1.Text.ToString();
                phieuSuaChua.ShowDialog();
                phieuSuaChua = null;
                this.Show();
            }
        }
    }
}
