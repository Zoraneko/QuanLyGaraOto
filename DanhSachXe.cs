using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyGara
{
    public partial class DanhSachXe : Form
    {
        public string ten;
        public string vaitro;
        public int tienno;
        string str = string.Format(@"Data Source={0}\db.db;Version=3;", Application.StartupPath);
        public DanhSachXe()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tienno = int.Parse(dataGridView1.SelectedCells[3].Value.ToString());
            PhieuThuTien p1 = new PhieuThuTien();
            this.Hide();
            p1.tienno = tienno;
            p1.hoTenChuXe = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            p1.bienSo = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            p1.ShowDialog();
            p1 = null;
            this.Show();
            
                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DanhSachXe_Load(object sender, EventArgs e)
        {
            textBox6.Text = this.ten;
            textBox5.Text = this.vaitro;
            LoadDatabase();
        }

        void LoadDatabase()
        {
            string query = "SELECT PHIEUSUACHUA.BienSo,HieuXe,TenChuXe,SUM(ThanhTien) FROM PHIEUSUACHUA,TIEPNHANXESUA WHERE PHIEUSUACHUA.BienSo = TIEPNHANXESUA.BienSo GROUP BY PHIEUSUACHUA.BienSo; ";
            using (SQLiteConnection con = new SQLiteConnection(str))
            {
                con.Open();
                SQLiteDataAdapter da = new SQLiteDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "Biển số";
                dataGridView1.Columns[1].HeaderText = "Hiệu xe";
                dataGridView1.Columns[2].HeaderText = "Tên chủ xe";
                dataGridView1.Columns[3].HeaderText = "Tiền nợ";
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
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

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dx = MessageBox.Show("Bạn có chắc là muốn Đăng xuất?", "Quản Lý Gara", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dx == DialogResult.Yes)
            {
                DialogResult = DialogResult.Abort;
                this.Close();
            }
        }

        private void DanhSachXe_FormClosing(object sender, FormClosingEventArgs e)
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

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (vaitro == "admin")
            {
                ThayDoiQuyDinh tdqd = new ThayDoiQuyDinh();
                this.Hide();
                tdqd.ShowDialog();
                tdqd = null;
                this.Show();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value.ToString().Contains(textBox1.Text.ToString()))
                        row.Selected = true;
                    else row.Selected = false;
                }
            }    
        }
    }
}
