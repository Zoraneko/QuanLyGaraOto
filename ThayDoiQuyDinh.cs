using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyGara
{
    public partial class ThayDoiQuyDinh : Form
    {
        public ThayDoiQuyDinh()
        {
            InitializeComponent();
        }
        public int soluongxegioihan;
        public int soluonghieuxe;
        public int soluongvattu;
        public int soloaitiencong;
        string str = string.Format(@"Data Source={0}\db.db;Version=3;", Application.StartupPath);
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)//lưu
        {
            soluongxegioihan = int.Parse(textBox2.Text);
            soluonghieuxe = int.Parse(textBox1.Text);
            soluongvattu = int.Parse(textBox3.Text);
            soloaitiencong = int.Parse(textBox4.Text);
            string query = String.Format("UPDATE QUYDINH SET SoLuongHieuXe='{0}',SoLuongXeGioiHan='{1}',SoLuongVatTU='{2}',SoLoaiTienCong='{3}' WHERE id='{4}' ;"
                ,soluonghieuxe,soluongxegioihan,soluongvattu,soloaitiencong,1);
            Execute(query, "Lưu thành công");
            this.Close();
        }

        void Execute(string query, string ms)
        {
            using (SQLiteConnection con = new SQLiteConnection(str))
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show(ms);                 
                }
            }
        }

        void LoadQuyDinh()
        {
            string query = String.Format("SELECT SoLuongHieuXe,SoLuongXeGioiHan,SoLuongVatTu,SoLoaiTienCong FROM QUYDINH WHERE id='{0}';", 1);
            using (SQLiteConnection con = new SQLiteConnection(str))
            {
                con.Open();
                SQLiteDataAdapter da = new SQLiteDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                soluonghieuxe = int.Parse(dt.Rows[0][0].ToString());
                soluongxegioihan = int.Parse(dt.Rows[0][1].ToString());
                soluongvattu = int.Parse(dt.Rows[0][2].ToString());
                soloaitiencong = int.Parse(dt.Rows[0][3].ToString());
            }
        }
        private void ThayDoiQuyDinh_Load(object sender, EventArgs e)
        {
            LoadQuyDinh();
            textBox1.Text = soluonghieuxe.ToString();
            textBox2.Text = soluongxegioihan.ToString();
            textBox3.Text = soluongvattu.ToString();
            textBox4.Text = soloaitiencong.ToString();
        }
    }
}
