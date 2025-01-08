using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using qlbida.Models;


namespace qlbida
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        private bool ValidateInput(string username, string password)
        {
            // Kiểm tra tài khoản hoặc mật khẩu để trống
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Tài khoản không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Mật khẩu không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra độ dài tài khoản và mật khẩu
            if (username.Length <= 5)
            {
                MessageBox.Show("Tài khoản phải lớn hơn 5 ký tự!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (password.Length <= 5)
            {
                MessageBox.Show("Mật khẩu phải lớn hơn 5 ký tự!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra mật khẩu có ít nhất một chữ in hoa
            if (!Regex.IsMatch(password, "[A-Z]"))
            {
                MessageBox.Show("Mật khẩu phải có ít nhất một chữ cái in hoa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private bool ValidateLogin(string username, string password)
        {
            try
            {
                using (var context = new Qlybia())
                {
                    var user = context.ADMINs.FirstOrDefault(u => u.taikhoan == username && u.matkhau == password);

                    return user != null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            string username = txttaikhoan.Text;
            string password = txtmatkhau.Text;
            if (!ValidateInput(username, password))
            {
                return;
            }

            if (ValidateLogin(username, password))
            {
                Form2 frm = new Form2();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
