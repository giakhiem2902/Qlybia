using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using qlbida.Models;

namespace qlbida
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Qlybia qlybia=new Qlybia();
        private void tHOÁTToolStripMenuItem_Click(object sender, EventArgs e)
        {
          Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }

        private void tHÔNGTINKHÁCHHÀNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmkhachhang frm3 = new frmkhachhang();
            frm3.Show();
            Hide();
        }

        private void dỊCHVỤToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMenu frm4 = new frmMenu();
            frm4.Show();
            Hide();
        }

        private void bÀNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBan frm5 = new frmBan();
            frm5.Show();
            Hide();
        }

        private void hÓAĐƠNToolStripMenuItem_Click(object sender, EventArgs e)
        {  
            frmHoadon frm6 = new frmHoadon();
            frm6.Show();
            Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void nHÂNVIÊNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTaikhoan frm7 = new frmTaikhoan();
            frm7.Show();
            Hide();
        }

        private void aDMINToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void hỖTRỢToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHotro frmHotro = new frmHotro();
            frmHotro.Show();
            Hide();
        }
    }
}
