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
    public partial class BaoCaoDoanhSo : Form
    {
        public string ten;
        public string vaitro;
        string str = string.Format(@"Data Source={0}\db.db;Version=3;", Application.StartupPath);

        public BaoCaoDoanhSo()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // Button IN Báo cáo
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

        private void BaoCaoDoanhSo_Load(object sender, EventArgs e)
        {
            textBox6.Text = this.ten;
            textBox5.Text = this.vaitro;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            LoadData();
            

        }

        void LoadData()
        {
            // Tính toán và load dữ liệu mới vào datagridview
            string query = "SELECT HD.NgayThuTien AS Thang, TNXS.HieuXe, COUNT(*) AS SoLuotSuaChua, SUM(HD.SoTienThu) AS ThanhTien " +
            "FROM HOADON HD " +
            "JOIN TIEPNHANXESUA TNXS ON HD.BienSo=TNXS.BienSo " +
            "GROUP BY TNXS.HieuXe";
            using (SQLiteConnection con = new SQLiteConnection(str))
            {
                con.Open();
                SQLiteDataAdapter da = new SQLiteDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            // Tạo mới cột tỉ lệ 
            if (!dataGridView1.Columns.Contains("Tile"))
            {

                dataGridView1.Columns.Add("TiLe", "TiLe");
            }
            // sửa header datagridview sang tiếng việt
            dataGridView1.Columns[0].HeaderText = "Tháng";
            dataGridView1.Columns[1].HeaderText = "Hiệu xe";
            dataGridView1.Columns[2].HeaderText = "Số lượt sửa chữa";
            dataGridView1.Columns[3].HeaderText = "Thành tiền";
            dataGridView1.Columns[4].HeaderText = "Tỉ lệ";
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            // Insert dữ liệu datagridview vào lại database DOANHSO để tính toán tỉ lệ sau này
            using (SQLiteConnection con1 = new SQLiteConnection(str))
            {
                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                    string update = String.Format("UPDATE DOANHSO SET SoLuotSuaChua = '{0}', ThanhTien = '{1}' WHERE HieuXe = '{2}' AND Thang = '{3}';", int.Parse(row.Cells["SoLuotSuaChua"].Value.ToString()), int.Parse(row.Cells["ThanhTien"].Value.ToString()), row.Cells["HieuXe"].Value, int.Parse(row.Cells["Thang"].Value.ToString().Substring(3, 2)));
                    con1.Open();
                    SQLiteCommand cmd = new SQLiteCommand(update, con1);
                    int a = cmd.ExecuteNonQuery();
                }
            }
            
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

        private void BaoCaoDoanhSo_FormClosing(object sender, FormClosingEventArgs e)
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
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) // CODE BỊ BUG, CỨU BÉ, NGUYÊN ĐOẠN CCODE Ở DƯỚI LUÔN Á
        {
            
            // Lấy thông số: tháng
            string thang = dateTimePicker1.Value.Month.ToString("D2");
            

            // Lệnh query để lọc ra database và chỉ lấy các cột cần thiết tương ứng với tháng
            // Tính toán và load dữ liệu mới vào datagridview
            string query = String.Format("SELECT SUBSTRING(HD.  NgayThuTien, 4, 7) AS Thang, TNXS.HieuXe, COUNT(*) AS SoLuotSuaChua, SUM(HD.SoTienThu) AS ThanhTien " +
            "FROM HOADON HD " +
            "JOIN TIEPNHANXESUA TNXS ON HD.BienSo=TNXS.BienSo " +
            "WHERE SUBSTRING(Thang, 4, 2) = '{0}' " +
            "GROUP BY SUBSTRING(HD.NgayThuTien, 4, 7), TNXS.HieuXe;", thang);
            using (SQLiteConnection con = new SQLiteConnection(str))
            {
                con.Open();
                SQLiteDataAdapter da = new SQLiteDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }

            
            // Trong trường hợp datagridView không rỗng
            /*int tien = 0;
            if (dataGridView1 != null && dataGridView1.RowCount>1)
            {
                // vòng lặp để tính tiền
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    try
                    {
                        tien += int.Parse(dataGridView1.Rows[i].Cells["ThanhTien"].Value.ToString());

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                textBox1.Text=tien.ToString();

                // vòng lặp để tính tỉ lệ
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    try
                    {
                        dataGridView1.Rows[j].Cells["TiLe"].Value = Math.Round((double.Parse(dataGridView1.Rows[j].Cells["ThanhTien"].Value.ToString()) * 100) / (double) tien, 2);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }*/
            
        }
    }
}
