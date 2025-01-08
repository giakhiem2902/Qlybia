using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using qlbida.Models;

namespace qlbida
{
    public partial class frmkhachhang : Form
    {
        public frmkhachhang()
        {
            InitializeComponent();
        }
        Qlybia context = new Qlybia();
        private void button5_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            Hide();
        }
          private void BindGrid(List<KHACHHANG> listKH)
        {
            dgvkhachhang.Rows.Clear();
            foreach (var item in listKH)
            {
                int index = dgvkhachhang.Rows.Add();
                dgvkhachhang.Rows[index].Cells[0].Value = item.makh;
                dgvkhachhang.Rows[index].Cells[1].Value = item.tenkh;
                dgvkhachhang.Rows[index].Cells[2].Value = item.diachi;
                dgvkhachhang.Rows[index].Cells[3].Value = item.SDT;
                dgvkhachhang.Rows[index].Cells[4].Value=item.checkin;
            }
        }

        private void frmkhachhang_Load(object sender, EventArgs e)
        {
            try
            {
                List<KHACHHANG> listKH = context.KHACHHANGs.ToList();
            
                BindGrid(listKH);
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
                List<KHACHHANG> studentList = context.KHACHHANGs.ToList();
                if (studentList.Any(s => s.makh == txtmakh.Text))
                {
                    MessageBox.Show("Mã KHÁCH HÀNG đã tồn tại! BẠN VUI LÒNG NHẬP LẠI!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var newKH = new KHACHHANG
                {
                    makh = txtmakh.Text,
                    tenkh = txtname.Text,
                    diachi = txtdiachi.Text,
                    SDT = txtsdt.Text,
                    checkin=dateTimePicker1.Value,
                };
                context.KHACHHANGs.Add(newKH);
                context.SaveChanges();
                BindGrid(context.KHACHHANGs.ToList());
                MessageBox.Show("Thêm Khách Hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                
                List<KHACHHANG> khachhang = context.KHACHHANGs.ToList();
                var khachhangs = khachhang.FirstOrDefault(s => s.makh == txtmakh.Text);

                if (khachhangs != null)
                {

                    if (khachhang.Any(s => s.makh == txtmakh.Text && s.makh != khachhangs.makh))
                    {
                        MessageBox.Show("Mã khách hàng đã tồn tại! BẠN VUI LONG NHẬP LẠI!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    khachhangs.tenkh = txtname.Text;
                    khachhangs.diachi = txtdiachi.Text;
                    khachhangs.SDT = txtsdt.Text;
                    khachhangs.checkin=dateTimePicker1.Value;
                    context.SaveChanges();

                    BindGrid(context.KHACHHANGs.ToList());

                    MessageBox.Show("Chỉnh sửa thông tin Khách Hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    MessageBox.Show("Không tìm thấy khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                
                List<KHACHHANG> khachhang = context.KHACHHANGs.ToList();
                var khachangs = khachhang.FirstOrDefault(s => s.makh == txtmakh.Text);
                if (khachangs != null)
                {
                    var result = MessageBox.Show("Bạn chắc chắn muốn xóa Khách Hàng này Không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        context.KHACHHANGs.Remove(khachangs);
                        context.SaveChanges();
                        BindGrid(context.KHACHHANGs.ToList());
                        MessageBox.Show("Đã xóa Khách Hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Khách Hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"lỗi khi cập nhật dữ liệu: {ex.Message}", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvkhachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow selectRow = dgvkhachhang.Rows[e.RowIndex];
                    txtmakh.Text = selectRow.Cells[0].Value?.ToString();
                    txtname.Text = selectRow.Cells[1].Value?.ToString();
                    txtdiachi.Text = selectRow.Cells[2].Value?.ToString();
                    txtsdt.Text = selectRow.Cells[3].Value?.ToString();
                    if (selectRow.Cells[4].Value != null && DateTime.TryParse(selectRow.Cells[4].Value.ToString(), out DateTime checkinDate))
                    {
                        dateTimePicker1.Value = checkinDate;
                    }
                    else
                    {
                        dateTimePicker1.Value = DateTime.Now;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xử lý dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string searchName = txtsearch.Text.Trim();

                if (string.IsNullOrWhiteSpace(searchName))
                {
                    MessageBox.Show("Vui lòng nhập Tên khách hàng cần tìm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
               
                var khachhang = context.KHACHHANGs.FirstOrDefault(s => s.tenkh == searchName);

                if (khachhang != null)
                {
                    txtmakh.Text = khachhang.makh;
                    txtname.Text = khachhang.tenkh;
                    txtdiachi.Text = khachhang.diachi;
                    txtsdt.Text=khachhang.SDT;
                    dateTimePicker1.Value= (DateTime)khachhang.checkin;
                    BindGrid(new List<KHACHHANG> { khachhang });

                    MessageBox.Show("Tìm thấy khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tên khách hàng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm khách hàng: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
