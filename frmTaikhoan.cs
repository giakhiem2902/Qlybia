using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using qlbida.Models;

namespace qlbida
{
    public partial class frmTaikhoan : Form
    {
        public frmTaikhoan()
        {
            InitializeComponent();
        }
        Qlybia context = new Qlybia();
        private void BindGrid(List<ADMIN> listAD)
        {
            dgvtaikhoan.Rows.Clear();
            foreach (var item in listAD)
            {
                int index = dgvtaikhoan.Rows.Add();
                dgvtaikhoan.Rows[index].Cells[0].Value = item.maAD;
                dgvtaikhoan.Rows[index].Cells[1].Value = item.tenAD;
                dgvtaikhoan.Rows[index].Cells[2].Value=item.taikhoan;
                dgvtaikhoan.Rows[index].Cells[3].Value = item.matkhau;
               
            }
        }
        private void frmTaikhoan_Load(object sender, EventArgs e)
        {
            try
            {
                List<ADMIN> listAD = context.ADMINs.ToList();

                BindGrid(listAD);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            Hide();
        }

        private void dgvtaikhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectRow = dgvtaikhoan.Rows[e.RowIndex];
                txtmaAD.Text = selectRow.Cells[0].Value?.ToString();
                txttenAD.Text = selectRow.Cells[1].Value?.ToString();
                txttk.Text = selectRow.Cells[2].Value?.ToString();
                txtmk.Text = selectRow.Cells[3].Value?.ToString();

               
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<ADMIN> ADList = context.ADMINs.ToList();
                if (ADList.Any(s => s.maAD == txtmaAD.Text))
                {
                    MessageBox.Show("ADMIN đã tồn tại! BẠN VUI LÒNG NHẬP LẠI!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var newAD = new ADMIN
                {
                    maAD= txtmaAD.Text,
                    tenAD = txttenAD.Text,
                    taikhoan = txttk.Text,
                    matkhau = txtmk.Text,
                   
                };
                context.ADMINs.Add(newAD);
                context.SaveChanges();
                BindGrid(context.ADMINs.ToList());
                MessageBox.Show("Thêm ADMIN thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                List<ADMIN> ADList = context.ADMINs.ToList();
                var admins = ADList.FirstOrDefault(s => s.maAD == txtmaAD.Text);

                if (admins != null)
                {

                    if (ADList.Any(s => s.maAD == txtmaAD.Text && s.maAD != admins.maAD))
                    {
                        MessageBox.Show("ADMIN đã tồn tại! BẠN VUI LONG NHẬP LẠI!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    admins.tenAD = txttenAD.Text;
                    admins.taikhoan = txttk.Text;
                    admins.matkhau = txtmk.Text;
                    context.SaveChanges();
                    BindGrid(context.ADMINs.ToList());

                    MessageBox.Show("Chỉnh sửa thông tin ADMIN thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy ADMIN!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                List<ADMIN> ADList = context.ADMINs.ToList();
                var admins= ADList.FirstOrDefault(s => s.maAD == txtmaAD.Text);
                if (admins != null)
                {
                    var result = MessageBox.Show("Bạn chắc chắn muốn xóa ADMIN này Không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        context.ADMINs.Remove(admins);
                        context.SaveChanges();
                        BindGrid(context.ADMINs.ToList());
                        MessageBox.Show("Xóa ADMIN thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy ADMIN!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"lỗi khi cập nhật dữ liệu: {ex.Message}", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}

