namespace qlbida
{
    partial class frmHoadon
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
            this.dgvbill = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bttaoHD = new System.Windows.Forms.Button();
            this.btthanhtoan = new System.Windows.Forms.Button();
            this.btinHD = new System.Windows.Forms.Button();
            this.btthoat = new System.Windows.Forms.Button();
            this.cbthanhtoan = new System.Windows.Forms.ComboBox();
            this.btncapnhap = new System.Windows.Forms.Button();
            this.btnThongke = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbill)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvbill
            // 
            this.dgvbill.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvbill.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvbill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvbill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvbill.Location = new System.Drawing.Point(-3, 93);
            this.dgvbill.Name = "dgvbill";
            this.dgvbill.RowHeadersWidth = 51;
            this.dgvbill.RowTemplate.Height = 24;
            this.dgvbill.Size = new System.Drawing.Size(711, 467);
            this.dgvbill.TabIndex = 0;
            this.dgvbill.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvbill_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Mã Hóa Đơn";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tên Khách Hàng";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Số Giờ";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Tổng Tiền";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Thời gian";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            // 
            // bttaoHD
            // 
            this.bttaoHD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bttaoHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttaoHD.ForeColor = System.Drawing.Color.White;
            this.bttaoHD.Location = new System.Drawing.Point(747, 112);
            this.bttaoHD.Name = "bttaoHD";
            this.bttaoHD.Size = new System.Drawing.Size(95, 63);
            this.bttaoHD.TabIndex = 11;
            this.bttaoHD.Text = "Tạo";
            this.bttaoHD.UseVisualStyleBackColor = false;
            this.bttaoHD.Click += new System.EventHandler(this.btthem_Click);
            // 
            // btthanhtoan
            // 
            this.btthanhtoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btthanhtoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btthanhtoan.ForeColor = System.Drawing.Color.White;
            this.btthanhtoan.Location = new System.Drawing.Point(745, 21);
            this.btthanhtoan.Name = "btthanhtoan";
            this.btthanhtoan.Size = new System.Drawing.Size(95, 61);
            this.btthanhtoan.TabIndex = 12;
            this.btthanhtoan.Text = "Thanh Toán";
            this.btthanhtoan.UseVisualStyleBackColor = false;
            this.btthanhtoan.Click += new System.EventHandler(this.btthanhtoan_Click_1);
            // 
            // btinHD
            // 
            this.btinHD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btinHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btinHD.ForeColor = System.Drawing.Color.White;
            this.btinHD.Location = new System.Drawing.Point(745, 294);
            this.btinHD.Name = "btinHD";
            this.btinHD.Size = new System.Drawing.Size(93, 66);
            this.btinHD.TabIndex = 13;
            this.btinHD.Text = "In";
            this.btinHD.UseVisualStyleBackColor = false;
            this.btinHD.Click += new System.EventHandler(this.btinHD_Click);
            // 
            // btthoat
            // 
            this.btthoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btthoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btthoat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btthoat.Location = new System.Drawing.Point(745, 475);
            this.btthoat.Name = "btthoat";
            this.btthoat.Size = new System.Drawing.Size(93, 58);
            this.btthoat.TabIndex = 14;
            this.btthoat.Text = "Thoát";
            this.btthoat.UseVisualStyleBackColor = false;
            this.btthoat.Click += new System.EventHandler(this.btthoat_Click);
            // 
            // cbthanhtoan
            // 
            this.cbthanhtoan.FormattingEnabled = true;
            this.cbthanhtoan.Location = new System.Drawing.Point(865, 41);
            this.cbthanhtoan.Name = "cbthanhtoan";
            this.cbthanhtoan.Size = new System.Drawing.Size(165, 24);
            this.cbthanhtoan.TabIndex = 15;
            this.cbthanhtoan.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btncapnhap
            // 
            this.btncapnhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btncapnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncapnhap.ForeColor = System.Drawing.Color.White;
            this.btncapnhap.Location = new System.Drawing.Point(747, 203);
            this.btncapnhap.Name = "btncapnhap";
            this.btncapnhap.Size = new System.Drawing.Size(93, 66);
            this.btncapnhap.TabIndex = 16;
            this.btncapnhap.Text = "Cập nhật";
            this.btncapnhap.UseVisualStyleBackColor = false;
            this.btncapnhap.Click += new System.EventHandler(this.btncapnhap_Click);
            // 
            // btnThongke
            // 
            this.btnThongke.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnThongke.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongke.ForeColor = System.Drawing.Color.White;
            this.btnThongke.Location = new System.Drawing.Point(745, 384);
            this.btnThongke.Name = "btnThongke";
            this.btnThongke.Size = new System.Drawing.Size(93, 61);
            this.btnThongke.TabIndex = 17;
            this.btnThongke.Text = "Thống kê";
            this.btnThongke.UseVisualStyleBackColor = false;
            this.btnThongke.Click += new System.EventHandler(this.btnThongke_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Font = new System.Drawing.Font("Broadway", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(215, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(241, 42);
            this.label5.TabIndex = 18;
            this.label5.Text = "TÀI KHOẢN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Mistral", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(932, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 408);
            this.label1.TabIndex = 19;
            this.label1.Text = "B\r\nI\r\nL\r\nL\r\nI\r\nA\r\nR\r\nD\r\n\r\nK\r\nD\r\nV";
            // 
            // frmHoadon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::qlbida.Properties.Resources.logo_bia;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1075, 557);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnThongke);
            this.Controls.Add(this.btncapnhap);
            this.Controls.Add(this.cbthanhtoan);
            this.Controls.Add(this.btthoat);
            this.Controls.Add(this.btinHD);
            this.Controls.Add(this.btthanhtoan);
            this.Controls.Add(this.bttaoHD);
            this.Controls.Add(this.dgvbill);
            this.DoubleBuffered = true;
            this.Name = "frmHoadon";
            this.Text = "HÓA ĐƠN";
            this.Load += new System.EventHandler(this.frmHoadon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvbill)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvbill;
        private System.Windows.Forms.Button bttaoHD;
        private System.Windows.Forms.Button btthanhtoan;
        private System.Windows.Forms.Button btinHD;
        private System.Windows.Forms.Button btthoat;
        private System.Windows.Forms.ComboBox cbthanhtoan;
        private System.Windows.Forms.Button btncapnhap;
        private System.Windows.Forms.Button btnThongke;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}