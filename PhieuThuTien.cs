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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyGara
{
    public partial class PhieuThuTien : Form
    {
        public int tienno;
        public string bienSo;
        public string hoTenChuXe;
        string str = string.Format(@"Data Source={0}\db.db;Version=3;", Application.StartupPath);
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

        
        private void PhieuThuTien_Load(object sender, EventArgs e)
        {
            textBox3.Text = tienno.ToString();
            label9.Text = bienSo;
            label8.Text = hoTenChuXe;
        }

        private void button2_Click(object sender, EventArgs e) // in
        {
            // insert into db
            string query = String.Format("INSERT INTO HOADON (idHoaDon,BienSo,NgayThuTien,SoTienThu,Email) VALUES(null,'{0}','{1}','{2}','{3}');"
            , bienSo, dateTimePicker1.Value.ToString("dd/MM/yyyy"), int.Parse(textBox3.Text), textBox2.Text) ;
            using (SQLiteConnection con = new SQLiteConnection(str))
            {
                con.Open();              
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Thanh toán thành công");                
                }
            }
            // In hoa don ra
            // Kiểm tra xem dataGridView có rỗng không
            if (textBox1.Text!=null&&textBox2.Text!=null&textBox3.Text!=null)
            {
                // Lấy đường dẫn đến thư mục Documents của người dùng
                string filePath = @"D:\bill.txt";


                // Mở stream để ghi dữ liệu
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Ghi dữ liệu
                    writer.Write(label2.Text.ToString() + " " + label8.Text.ToString());
                    writer.WriteLine();

                    writer.Write(label3.Text.ToString() + " " + label9.Text.ToString());
                    writer.WriteLine();

                    writer.Write(label4.Text.ToString() + " " + textBox1.Text.ToString());
                    writer.WriteLine();

                    writer.Write(label5.Text.ToString() + " " + textBox2.Text.ToString());
                    writer.WriteLine();

                    writer.Write(label6.Text.ToString() + " " + dateTimePicker1.Value.ToString());
                    writer.WriteLine();

                    writer.Write(label7.Text.ToString() + " " + textBox3.Text.ToString());
                    writer.WriteLine();
                }
                MessageBox.Show("Dữ liệu đã được xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
