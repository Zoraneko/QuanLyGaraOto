using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyGara
{
    public partial class DanhSachXe : Form
    {
        public DanhSachXe()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            PhieuThuTien p1 = new PhieuThuTien();
            if (listView1.SelectedItems.Count > 0)
            {
                this.Hide();
                p1.ShowDialog();
                p1 = null;
                this.Show();
            }
                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
