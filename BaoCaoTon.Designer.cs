namespace QuanLyGara
{
    partial class BaoCaoTon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VatTuPhuTung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TonDau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhatSinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TonCuoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tháng:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(178, 74);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 35);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.VatTuPhuTung,
            this.TonDau,
            this.PhatSinh,
            this.TonCuoi});
            this.dataGridView1.Location = new System.Drawing.Point(45, 157);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 92;
            this.dataGridView1.RowTemplate.Height = 37;
            this.dataGridView1.Size = new System.Drawing.Size(1219, 439);
            this.dataGridView1.TabIndex = 2;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 11;
            this.STT.Name = "STT";
            this.STT.Width = 225;
            // 
            // VatTuPhuTung
            // 
            this.VatTuPhuTung.HeaderText = "Vật tư phụ tùng";
            this.VatTuPhuTung.MinimumWidth = 11;
            this.VatTuPhuTung.Name = "VatTuPhuTung";
            this.VatTuPhuTung.Width = 225;
            // 
            // TonDau
            // 
            this.TonDau.HeaderText = "Tồn Đầu";
            this.TonDau.MinimumWidth = 11;
            this.TonDau.Name = "TonDau";
            this.TonDau.Width = 225;
            // 
            // PhatSinh
            // 
            this.PhatSinh.HeaderText = "Phát sinh";
            this.PhatSinh.MinimumWidth = 11;
            this.PhatSinh.Name = "PhatSinh";
            this.PhatSinh.Width = 225;
            // 
            // TonCuoi
            // 
            this.TonCuoi.HeaderText = "Tồn Cuối";
            this.TonCuoi.MinimumWidth = 11;
            this.TonCuoi.Name = "TonCuoi";
            this.TonCuoi.Width = 225;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(381, 667);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 71);
            this.button1.TabIndex = 3;
            this.button1.Text = "In";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(682, 667);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 66);
            this.button2.TabIndex = 4;
            this.button2.Text = "Thoát";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // BaoCaoTon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1328, 826);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Name = "BaoCaoTon";
            this.Text = "Báo cáo tồn";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn VatTuPhuTung;
        private System.Windows.Forms.DataGridViewTextBoxColumn TonDau;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhatSinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn TonCuoi;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}