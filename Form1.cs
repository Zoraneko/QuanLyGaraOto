using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
namespace QuanLyGara
{
    public partial class Form1 : Form
    {
        public string ten;
        public string vaitro;
        string str = string.Format(@"Data Source={0}\db.db;Version=3;", Application.StartupPath);
        public int soluongxegioihan = 30;
        public int soluonghieuxe = 10;
        public int soluongvattu = 200;
        public int soloaitiencong = 100;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox6.Text = this.ten;
            textBox5.Text = this.vaitro;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            LoadDatabase();
            LoadQuyDinh();
        }

        void LoadDatabase()
        {
            string query = "SELECT TenChuXe,BienSo,HieuXe,DiaChi,DienThoai,NgayTiepNhan FROM TIEPNHANXESUA";
            using (SQLiteConnection con = new SQLiteConnection(str))
            {
                con.Open();
                SQLiteDataAdapter da = new SQLiteDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                // sửa header datagridview sang tiếng việt
                dataGridView1.Columns[0].HeaderText = "Tên chủ xe";
                dataGridView1.Columns[1].HeaderText = "Biển số";
                dataGridView1.Columns[2].HeaderText = "Hiệu xe";
                dataGridView1.Columns[3].HeaderText = "Địa chỉ";
                dataGridView1.Columns[4].HeaderText = "Điện thoại";
                dataGridView1.Columns[5].HeaderText = "Ngày tiếp nhận";
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        void LoadQuyDinh()
        {
            string query = String.Format("SELECT SoLuongHieuXe,SoLuongXeGioiHan,SoLuongVatTu,SoLoaiTienCong FROM QUYDINH WHERE id='{0}';",1);
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
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e) // chỉ cho nhập số
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        int GetSoLuongXe(string ngayTiepNhan)
        {
            int soluongxe = 0;
            string query = String.Format("SELECT COUNT(BienSo) FROM TIEPNHANXESUA WHERE NgayTiepNhan = '{0}';", ngayTiepNhan);
            using (SQLiteConnection con = new SQLiteConnection(str))
            {
                con.Open();
                SQLiteDataAdapter da = new SQLiteDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows[0][0].ToString() != "")
                    soluongxe = int.Parse(dt.Rows[0][0].ToString()); ;
            }
            return soluongxe;
        }
        
        private void button1_Click(object sender, EventArgs e) // thêm
        {
            if (GetSoLuongXe(dateTimePicker1.Value.ToString("dd/MM/yyyy")) < soluongxegioihan)
            {
                string query = String.Format("INSERT INTO TIEPNHANXESUA (TenChuXe,BienSo,HieuXe,DiaChi,DienThoai,NgayTiepNhan) VALUES('{0}','{1}','{2}','{3}','{4}','{5}');"
                , textBox1.Text, textBox2.Text, comboBox1.Text, textBox3.Text, textBox4.Text, dateTimePicker1.Value.ToString("dd/MM/yyyy"));
                Execute(query,"Thêm thành công");
            } else MessageBox.Show("Số lượng xe ngày " + dateTimePicker1.Value.ToString("dd/MM/yyyy")+" đã đạt giới hạn");            
        }
       
        void Execute(string query,string ms)
        {
            using (SQLiteConnection con = new SQLiteConnection(str)) 
            { 
                con.Open(); 
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                int result = cmd.ExecuteNonQuery();
                if(result == 1)
                {
                    MessageBox.Show(ms);
                    LoadDatabase();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) // xóa
        {
            string query = String.Format("DELETE FROM TIEPNHANXESUA WHERE BienSo='{0}' and NgayTiepNhan = '{1}' ;",textBox2.Text,dateTimePicker1.Value.ToString("dd/MM/yyyy"));
            Execute(query,"Xóa thành công");
        }

        private void button3_Click(object sender, EventArgs e) // sửa
        {
            string query = String.Format("UPDATE TIEPNHANXESUA SET TenChuXe='{0}',HieuXe='{2}',DiaChi='{3}',DienThoai='{4}' WHERE BienSo='{1}' AND NgayTiepNhan='{5}';"
                , textBox1.Text, textBox2.Text, comboBox1.Text, textBox3.Text,textBox4.Text, dateTimePicker1.Value.ToString("dd/MM/yyyy"));
            Execute(query, "Sửa thành công");
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
                phieuSuaChua.ngaySuaChua = dateTimePicker1.Text.ToString();
                phieuSuaChua.ShowDialog();
                phieuSuaChua = null;
                this.Show();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

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

        private void button11_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Ignore;
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (vaitro == "admin")
            {
                ThayDoiQuyDinh tdqd = new ThayDoiQuyDinh();
                this.Hide();                
                tdqd.ShowDialog();
                LoadQuyDinh();
                tdqd = null;
                this.Show();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
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

        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                comboBox1.Text = row.Cells[2].Value.ToString();
                textBox3.Text = row.Cells[3].Value.ToString();
                textBox4.Text = row.Cells[4].Value.ToString();
                dateTimePicker1.Value = DateTime.ParseExact(row.Cells[5].Value.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
               
            }
        }
    }
}
