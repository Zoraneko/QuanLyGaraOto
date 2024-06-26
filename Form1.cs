﻿using System;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox6.Text = this.ten;
            textBox5.Text = this.vaitro;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        void LoadDatabase()
        {
            string query = "SELECT * FROM XE";
            using (SQLiteConnection con = new SQLiteConnection(str))
            {
                con.Open();
                SQLiteDataAdapter da = new SQLiteDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;  
            }
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e) // chỉ cho nhập số
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        
        private void button1_Click(object sender, EventArgs e) // thêm
        {
            string query = String.Format("INSERT INTO TIEPNHANXESUA (TenChuXe,BienSo,HieuXe,DiaChi,DienThoai,NgayTiepNhan) VALUES('{0}','{1}','{2}','{3}','{4}','{5}');"
                ,textBox1.Text,textBox2.Text,comboBox1.Text,textBox3.Text,int.Parse(textBox4.Text),dateTimePicker1.Value.ToString("dd/MM/yyyy"));
            Execute(query);
        }
       
        void Execute(string query)
        {
            using (SQLiteConnection con = new SQLiteConnection(str)) 
            { 
                con.Open(); 
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                int result = cmd.ExecuteNonQuery();
                if(result == 1)
                {
                    MessageBox.Show("Successfull");
                    LoadDatabase();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e) // xóa
        {
            string query = String.Format("DELETE FROM TIEPNHANXESUA WHERE BienSo='{0}' and NgayTiepNhan = '{1}' ;",textBox2.Text,dateTimePicker1.Value.ToString("dd/MM/yyyy"));
            Execute(query);
        }

        private void button3_Click(object sender, EventArgs e) // sửa
        {
            string query = String.Format("UPDATE TIEPNHANXESUA SET TenChuXe='{0}',HieuXe='{2}',DiaChi='{3}',DienThoai='{4}',NgayTiepNhan='{5}' WHERE BienSo='{1}';"
                , textBox1.Text, textBox2.Text, comboBox1.Text, textBox3.Text, int.Parse(textBox4.Text), dateTimePicker1.Value.ToString("dd/MM/yyyy"));
            Execute(query);
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
                phieuSuaChua.ngaSuaChua = dateTimePicker1.Text.ToString();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
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

            }
        }
    }
}
