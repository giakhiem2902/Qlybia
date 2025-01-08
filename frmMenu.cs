using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using qlbida.Models;

namespace qlbida
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }
        Qlybia context=new Qlybia();
        private void button4_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            Hide();
        }
        private void BindGrid(List<MENU> listMN)
        {
            dgvmenu.Rows.Clear();
            foreach (var item in listMN)
            {
                int index = dgvmenu.Rows.Add();
                dgvmenu.Rows[index].Cells[0].Value = item.id;
                dgvmenu.Rows[index].Cells[1].Value = item.tenmon;
                dgvmenu.Rows[index].Cells[2].Value = item.gia;
            }
        }
        private void frmMenu_Load(object sender, EventArgs e)
        {
            try
            {
                List<MENU> listMN = context.MENUs.ToList();

                BindGrid(listMN);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btthem_Click(object sender, EventArgs e)
        {
            try
            {
                List<MENU> studentList = context.MENUs.ToList();
                if (studentList.Any(s => s.id == txtmaso.Text))
                {
                    MessageBox.Show("Mã MENU đã tồn tại! BẠN VUI LÒNG NHẬP LẠI!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var newMN = new MENU
                {
                    id= txtmaso.Text,
                    tenmon = txttenmon.Text,
                    gia = double.Parse(txtgia.Text),
                };
                context.MENUs.Add(newMN);
                context.SaveChanges();
                BindGrid(context.MENUs.ToList());
                MessageBox.Show("Thêm MENU thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            try
            {

                List<MENU> menu = context.MENUs.ToList();
                var menus = menu.FirstOrDefault(s => s.id == txtmaso.Text);

                if (menus != null)
                {

                    if (menu.Any(s => s.id == txtmaso.Text && s.id != menus.id))
                    {
                        MessageBox.Show("Mã món ăn đã tồn tại! BẠN VUI LONG NHẬP LẠI!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    menus.tenmon = txttenmon.Text;
                    menus.gia = double.Parse(txtgia.Text);
                    context.SaveChanges();
                    BindGrid(context.MENUs.ToList());

                    MessageBox.Show("Chỉnh sửa món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    MessageBox.Show("Không tìm thấy món ăn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            try
            {

                List<MENU> menu = context.MENUs.ToList();
                var menus = menu.FirstOrDefault(s => s.id == txtmaso.Text);
                if (menus != null)
                {
                    var result = MessageBox.Show("Bạn chắc chắn muốn xóa món ăn này Không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        context.MENUs.Remove(menus);
                        context.SaveChanges();
                        BindGrid(context.MENUs.ToList());
                        MessageBox.Show("Đã xóa món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy món ăn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"lỗi khi cập nhật dữ liệu: {ex.Message}", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvmenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                    DataGridViewRow selectRow = dgvmenu.Rows[e.RowIndex];
                    txtmaso.Text = selectRow.Cells[0].Value?.ToString();
                    txttenmon.Text = selectRow.Cells[1].Value?.ToString();
                    txtgia.Text = selectRow.Cells[2].Value?.ToString();
            }
        }

      
    }
}
