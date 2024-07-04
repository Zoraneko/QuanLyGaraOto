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
            donGia = GetDonGia(vattu);// cập nhật đơn giá tu DB
            int tienCong = int.Parse(this.comboBox2.Text);  
            int thanhTien = 0;         
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
            string vattu = this.comboBox1.Text;
            int donGia = 0;           
            donGia = GetDonGia(vattu);
            int soLuong = int.Parse(numericUpDown1.Value.ToString());
            int tienCong = int.Parse(comboBox2.Text.ToString());
            int thanhTien = donGia * soLuong + tienCong;
            if(textBox3.Text.ToString() != "")
            {
                string query = String.Format("UPDATE PHIEUSUACHUA SET TenVatTu = '{0}',DonGia = '{1}',SoLuong = '{2}',TienCong = '{3}',ThanhTien = '{4}' WHERE NoiDung = '{5}'; ",comboBox1.Text.ToString(),donGia,soLuong,tienCong,thanhTien,textBox3.Text);
                Execute(query);
            }
        }

        private void button4_Click(object sender, EventArgs e)//hoàn thành
        {
            
            string query = "SELECT PHIEUSUACHUA.BienSo,HieuXe,TenChuXe,SUM(ThanhTien) AS TienNo FROM PHIEUSUACHUA,TIEPNHANXESUA WHERE PHIEUSUACHUA.BienSo = TIEPNHANXESUA.BienSo AND PHIEUSUACHUA.NgaySua = TIEPNHANXESUA.NgayTiepNhan  GROUP BY TIEPNHANXESUA.BienSo; ";
            using (SQLiteConnection con = new SQLiteConnection(str))
            {
                con.Open();
                SQLiteDataAdapter da = new SQLiteDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                
                dataGridView2.DataSource = dt;

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    string query1 = String.Format("INSERT OR REPLACE INTO XE(BienSo,HieuXe,HoTenChuXe,TienNo) VALUES('{0}','{1}','{2}','{3}');",
                        row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), int.Parse(row.Cells[3].Value.ToString()));
                    using (SQLiteConnection con1 = new SQLiteConnection(str))
                    {
                        con1.Open();
                        SQLiteCommand cmd = new SQLiteCommand(query1, con1);
                        int result = cmd.ExecuteNonQuery();
                       
                    }
                }    
                        
            }
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
                dataGridView1.Columns[0].HeaderText = "STT";
                dataGridView1.Columns[1].HeaderText = "Biển số";
                dataGridView1.Columns[2].HeaderText = "Nội dung";
                dataGridView1.Columns[3].HeaderText = "Ngày sửa chữa";
                dataGridView1.Columns[4].HeaderText = "Tên Vật Tư";
                dataGridView1.Columns[5].HeaderText = "Đơn giá";
                dataGridView1.Columns[6].HeaderText = "Số lượng";
                dataGridView1.Columns[7].HeaderText = "Tiền Công";
                dataGridView1.Columns[8].HeaderText = "Thành tiền";
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null   ) 
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
        int GetDonGia(string vattu)
        {
            int donGia = 0;
            string query = String.Format("SELECT DonGia FROM VATTU WHERE TenVatTu = '{0}';", vattu);
            using (SQLiteConnection con = new SQLiteConnection(str))
            {
                con.Open();
                SQLiteDataAdapter da = new SQLiteDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                donGia = int.Parse(dt.Rows[0][0].ToString()); ;
            }
            return donGia;
        }
    }
}
