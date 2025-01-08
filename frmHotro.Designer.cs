namespace qlbida
{
    partial class frmHotro
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
            this.lbHotro = new System.Windows.Forms.Label();
            this.lbHotro3 = new System.Windows.Forms.Label();
            this.lbHotro2 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbHotro
            // 
            this.lbHotro.AutoSize = true;
            this.lbHotro.BackColor = System.Drawing.Color.Black;
            this.lbHotro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHotro.ForeColor = System.Drawing.Color.Red;
            this.lbHotro.Location = new System.Drawing.Point(63, 158);
            this.lbHotro.Name = "lbHotro";
            this.lbHotro.Size = new System.Drawing.Size(70, 25);
            this.lbHotro.TabIndex = 0;
            this.lbHotro.Text = "label1";
            // 
            // lbHotro3
            // 
            this.lbHotro3.AutoSize = true;
            this.lbHotro3.BackColor = System.Drawing.Color.Black;
            this.lbHotro3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHotro3.ForeColor = System.Drawing.Color.Red;
            this.lbHotro3.Location = new System.Drawing.Point(63, 358);
            this.lbHotro3.Name = "lbHotro3";
            this.lbHotro3.Size = new System.Drawing.Size(70, 25);
            this.lbHotro3.TabIndex = 1;
            this.lbHotro3.Text = "label1";
            // 
            // lbHotro2
            // 
            this.lbHotro2.AutoSize = true;
            this.lbHotro2.BackColor = System.Drawing.Color.Black;
            this.lbHotro2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHotro2.ForeColor = System.Drawing.Color.Red;
            this.lbHotro2.Location = new System.Drawing.Point(63, 253);
            this.lbHotro2.Name = "lbHotro2";
            this.lbHotro2.Size = new System.Drawing.Size(70, 25);
            this.lbHotro2.TabIndex = 2;
            this.lbHotro2.Text = "label1";
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnThoat.Location = new System.Drawing.Point(845, 517);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(107, 32);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmHotro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackgroundImage = global::qlbida.Properties.Resources.undefined_image;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(964, 561);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.lbHotro2);
            this.Controls.Add(this.lbHotro3);
            this.Controls.Add(this.lbHotro);
            this.DoubleBuffered = true;
            this.Name = "frmHotro";
            this.Text = "HỖ TRỢ";
            this.Load += new System.EventHandler(this.frmHotro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbHotro;
        private System.Windows.Forms.Label lbHotro3;
        private System.Windows.Forms.Label lbHotro2;
        private System.Windows.Forms.Button btnThoat;
    }
}