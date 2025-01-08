using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using qlbida.Models;

namespace qlbida
{
    public partial class frmthongke : Form
    {

        public frmthongke()
        {
            InitializeComponent();

        }
        Qlybia qlybia = new Qlybia();
        private void frmthongke_Load(object sender, EventArgs e)
        {
            dtaNgay.Visible = true;
            txtThangThongKe.Visible = false;
            cbThongKe.Items.Clear();
            cbThongKe.Items.Add("Thống kê theo ngày");
            cbThongKe.Items.Add("Thống kê theo tháng");
            cbThongKe.SelectedIndex = 0;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            frmHoadon frmHoadon = new frmHoadon();
            frmHoadon.Show();
            Hide();
        }
        private void BindGrid(List<HoaDon> hoaDons)
        {
            dgvthongke.Rows.Clear();
            foreach (var hoaDon in hoaDons)
            {
                int index = dgvthongke.Rows.Add();
                dgvthongke.Rows[index].Cells[0].Value = hoaDon.mabill;
                dgvthongke.Rows[index].Cells[1].Value = hoaDon.tenkh;
                dgvthongke.Rows[index].Cells[2].Value = hoaDon.sogio;
                dgvthongke.Rows[index].Cells[3].Value = hoaDon.tongtien;
                dgvthongke.Rows[index].Cells[4].Value = hoaDon.ThoiGian.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        private void btthongke_Click_1(object sender, EventArgs e)
        {
            using (var db = new Qlybia())
            {
                if (cbThongKe.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn kiểu thống kê!");
                    return;
                }

                List<HoaDon> data = new List<HoaDon>();

                if (cbThongKe.SelectedItem.ToString() == "Thống kê theo ngày")
                {
                    DateTime selectedDate = dtaNgay.Value.Date;
                    //DbFunction: Loại bỏ phần thời gian (giờ/phút/giây) của một cột DateTime để chỉ lấy ngày.
                    data = db.HoaDons
                        .Where(hd => hd.ThoiGian.HasValue &&
                                     DbFunctions.TruncateTime(hd.ThoiGian.Value) == selectedDate)
                        .ToList();
                }
                else if (cbThongKe.SelectedItem.ToString() == "Thống kê theo tháng")
                {
                    if (int.TryParse(txtThangThongKe.Text, out int selectedMonth) && selectedMonth >= 1 && selectedMonth <= 12)
                    {
                        data = db.HoaDons
                            .Where(hd => hd.ThoiGian.HasValue && hd.ThoiGian.Value.Month == selectedMonth)
                            .ToList();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập đúng định dạng tháng (1-12)!");
                        return;
                    }
                }
                BindGrid(data);
            }
        }

        private void cbThongKe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbThongKe.SelectedItem.ToString() == "Thống kê theo ngày")
            {
                dtaNgay.Visible = true;
                txtThangThongKe.Visible = false;
            }
            else if (cbThongKe.SelectedItem.ToString() == "Thống kê theo tháng")
            {
                dtaNgay.Visible = false;
                txtThangThongKe.Visible = true;
            }
        }

        private void btTongTien_Click(object sender, EventArgs e)
        {
            decimal tongTien = 0;
            foreach (DataGridViewRow row in dgvthongke.Rows)
            {
                if (row.Cells[3].Value != null && decimal.TryParse(row.Cells[3].Value.ToString(), out decimal tien))
                {
                    tongTien += tien;
                }
            }
            txtTong.Text = tongTien.ToString("0.00");
        }
    }
}

