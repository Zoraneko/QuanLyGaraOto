using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyGara
{
    public partial class PhieuSuaChua : Form
    {
        public PhieuSuaChua()
        {
            InitializeComponent();
        }

        public string bienSo;
        public string ngaySuaChua;
        // duong dan csdl
        string str = string.Format(@"Data Source={0}\db.db;Version = 3;",Application.StartupPath);
                      
        private void button1_Click(object sender, EventArgs e)// nút thêm
        {
            string noidung = this.textBox3.Text;
            string vattu = this.comboBox1.Text;
            int soluong = int.Parse(this.numericUpDown1.Value.ToString());
            int donGia = 0;
            int tienCong = int.Parse(this.comboBox2.Text);
            int thanhTien = 0;
            // cập nhật đơn giá tu DB
            thanhTien = donGia * soluong + tienCong;

            string query = String.Format("INSERT INTO PHIEUSUACHUA (STT,BienSo,NoiDung,NgaySua,TenVatTu,DonGia,SoLuong,TienCong,ThanhTien) VALUES(null,'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}');"
                , textBox1.Text, noidung, textBox2.Text, comboBox1.Text,donGia, soluong, tienCong, thanhTien);
            Execute(query);
        }

        void Execute(string query)
        {
            using (SQLiteConnection con = new SQLiteConnection(str))
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Thành công");
                    LoadDatabase();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e) //xóa
        {
            string query = String.Format("DELETE FROM PHIEUSUACHUA WHERE NoiDung = '{0}' ;",textBox3.Text.ToString());
            Execute(query);
        }

        private void button3_Click(object sender, EventArgs e)//sửa
        {
            int donGia = 0;// chưa tính đơn giá
            int soLuong = int.Parse(numericUpDown1.Value.ToString());
            int tienCong = int.Parse(comboBox2.Text.ToString());
            int thanhTien = donGia * soLuong + tienCong;// chưa tính tiền
            if(textBox3.Text.ToString() != "")
            {
                string query = String.Format("UPDATE PHIEUSUACHUA SET TenVatTu = '{0}',DonGia = '{1}',SoLuong = '{2}',TienCong = '{3}',ThanhTien = '{4}' WHERE NoiDung = '{5}'; ",comboBox1.Text.ToString(),donGia,soLuong,tienCong,thanhTien,textBox3.Text);
                Execute(query);
            }
        }

        private void button4_Click(object sender, EventArgs e)//hoàn thành
        {
            // add dư lieu vao DB

            this.Close();
        }

        private void PhieuSuaChua_Load(object sender, EventArgs e)
        {
            textBox1.Text = bienSo;
            textBox2.Text = ngaySuaChua;
            LoadVatTu();
            LoadDatabase();           
        }

       
        private void LoadDatabase()
        {
            string query = String.Format("SELECT * FROM PHIEUSUACHUA WHERE BienSo =  '{0}' AND NgaySua = '{1}';", bienSo, ngaySuaChua);
            using (SQLiteConnection con = new SQLiteConnection(str))
            {
                con.Open();
                SQLiteDataAdapter da = new SQLiteDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        void LoadVatTu()
        {
            string query = "SELECT TenVatTu  FROM VATTU";
            using (SQLiteConnection con = new SQLiteConnection(str))
            {
                con.Open();
                SQLiteDataAdapter da = new SQLiteDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "TenVatTu";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {                         
                textBox3.Text = row.Cells[2].Value.ToString();
                comboBox1.Text = row.Cells[4].Value.ToString();
                numericUpDown1.Value = int.Parse(row.Cells[6].Value.ToString());
                comboBox2.Text = row.Cells[7].Value.ToString();
            }
        }
    }
}
