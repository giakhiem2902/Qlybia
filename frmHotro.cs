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
    public partial class frmHotro : Form
    {
        public frmHotro()
        {
            InitializeComponent();
        }

        private void frmHotro_Load(object sender, EventArgs e)
        {

            lbHotro.Text = "Người 1:\nTên: Vũ Văn Vương\nSĐT: 0867799328\nEmail: vuvanvuong2004@gmail.com";
            lbHotro2.Text = "Người 2:\nTên: Trần Hoàng Thế Đăng \nSĐT: 0932033202\nEmail: tranhoangthedang2004@gmail.com";
            lbHotro3.Text = "Người 3:\nTên: Lê Trần Gia Khiêm\nSĐT: 0919801499 \nEmail: letrangiakhiem2004@gmail.com";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            Hide();
        }
    }
}
