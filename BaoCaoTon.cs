using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyGara
{
    public partial class BaoCaoTon : Form
    {
        public string ten;
        public string vaitro;
        string str = string.Format(@"Data Source={0}\db.db;Version=3;", Application.StartupPath);
        private int selectedRowIndex = -1;
        public BaoCaoTon()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BaoCaoTon_Load(object sender, EventArgs e)
        {
            textBox6.Text = this.ten;
            textBox5.Text = this.vaitro;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            LoadDatabase();
        }

        void LoadDatabase()
        {
            string query = "SELECT STT, Thang, VatTuPhuTung, TonDau, PhatSinh, TonCuoi FROM BAOCAOTON";
            using (SQLiteConnection con = new SQLiteConnection(str))
            {
                con.Open();
                SQLiteDataAdapter da = new SQLiteDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            // sửa header datagridview sang tiếng việt
            dataGridView1.Columns[0].HeaderText = "STT";
            dataGridView1.Columns[1].HeaderText = "Tháng";
            dataGridView1.Columns[2].HeaderText = "Vật tư phụ tùng";
            dataGridView1.Columns[3].HeaderText = "Tồn đầu kì";
            dataGridView1.Columns[4].HeaderText = "Phát sinh";
            dataGridView1.Columns[5].HeaderText = "Tồn cuối kì";
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            this.Close();
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

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dx = MessageBox.Show("Bạn có chắc là muốn Đăng xuất?", "Quản Lý Gara", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dx == DialogResult.Yes)
            {

                DialogResult = DialogResult.Abort;
                this.Close();
            }
        }

        private void BaoCaoTon_FormClosing(object sender, FormClosingEventArgs e)
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
            else MessageBox.Show("Chỉ quản lý mới có thể thay đổi quy định");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem dataGridView có rỗng không
            if (dataGridView1 != null && dataGridView1.RowCount > 1)
            {
                // Lấy đường dẫn đến thư mục Documents của người dùng
                string filePath = @"D:\report.csv";


                // Mở stream để ghi dữ liệu
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Ghi tiêu đề cột
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        writer.Write(dataGridView1.Columns[i].HeaderText);
                        if (i < dataGridView1.Columns.Count - 1)
                        {
                            writer.Write(",");
                        }
                    }
                    writer.WriteLine();

                    // Ghi dữ liệu từng hàng
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            writer.Write(dataGridView1.Rows[i].Cells[j].Value.ToString());
                            if (j < dataGridView1.Columns.Count - 1)
                            {
                                writer.Write(",");
                            }
                        }
                        writer.WriteLine();
                    }
                }
                MessageBox.Show("Dữ liệu đã được xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRowIndex];
                int currentTonDau = Convert.ToInt32(row.Cells["TonDau"].Value);
                int additionalQuantity = (int)numericUpDown1.Value;
                row.Cells["TonDau"].Value = currentTonDau + additionalQuantity;

                // Optionally, update the database with the new quantity
                UpdateDatabase(row.Cells["STT"].Value.ToString(), currentTonDau + additionalQuantity);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRowIndex = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["VatTuPhuTung"].Value.ToString();
                numericUpDown1.Value = Convert.ToDecimal(row.Cells["TonDau"].Value);
            }
        }

        private void UpdateDatabase(string id, int newTonDau)
        {
            string query = "UPDATE BAOCAOTON SET TonDau = @TonDau WHERE STT = @STT";
            using (SQLiteConnection con = new SQLiteConnection(str))
            {
                con.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@TonDau", newTonDau);
                    cmd.Parameters.AddWithValue("@STT", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Lấy thông số: tháng
            string thang = dateTimePicker1.Value.Month.ToString();


            // Lệnh query để lọc ra database và chỉ lấy các cột cần thiết tương ứng với tháng
            // Tính toán và load dữ liệu mới vào datagridview
            string query = String.Format("SELECT STT, Thang, VatTuPhuTung, TonDau, PhatSinh, TonCuoi " +
            "FROM BAOCAOTON BCT " +
            "WHERE THANG = "  + thang + " ");
            using (SQLiteConnection con = new SQLiteConnection(str))
            {
                con.Open();
                SQLiteDataAdapter da = new SQLiteDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }

        }
    }
}
