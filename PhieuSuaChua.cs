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
            string str1 = this.textBox3.Text;
            string str2 = this.comboBox1.Text;
            string str3 = this.numericUpDown1.Value.ToString();
            int donGia = 0;
            int tienCong = 0;
            int thanhTien = 0;
            // cập nhật đơn giá, tien cong tu DB
            thanhTien = donGia * int.Parse(numericUpDown1.Value.ToString()) + tienCong;
           
            //
            /*if (str1 != "" && str2 != "")
            {
                ListViewItem item = new ListViewItem(new[] { (listView1.Items.Count + 1).ToString(), str1, str2, str3, donGia.ToString(), tienCong.ToString(), thanhTien.ToString() });
                listView1.Items.Add(item);
            }*/
        }

        private void button2_Click(object sender, EventArgs e) //xóa
        {
            /*if (listView1.SelectedItems.Count > 0)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }*/

            // cap nhat lai STT...
        }

        private void button3_Click(object sender, EventArgs e)//sửa
        {
            /*if (listView1.SelectedItems.Count > 0)
            {
                listView1.SelectedItems[0].SubItems[1].Text = textBox3.Text.ToString();
                listView1.SelectedItems[0].SubItems[2].Text = comboBox1.Text.ToString();
                listView1.SelectedItems[0].SubItems[3].Text = numericUpDown1.Value.ToString();
                
                // sửa lại đơn giá, tien cong, thanh tien

                //
            }*/
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
            LoadDatabase();
        }

        private void LoadDatabase()
        {
            string query = "SELECT * FROM PHIEUSUACHUA";
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
