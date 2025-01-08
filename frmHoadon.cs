using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using qlbida.Models;

namespace qlbida
{
    public partial class frmHoadon : Form
    {
        public frmHoadon()
        {
            InitializeComponent();
        }
        Qlybia Qlybia = new Qlybia();
        List<HoaDon> hOADONs = new List<HoaDon>();
        public void AddToDataGridView(string maHoaDon, string tenKhachHang, string soGio, string tongTien)
        {

            dgvbill.Rows.Add(maHoaDon, tenKhachHang, soGio, tongTien);
        }

        private void btthoat_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            Hide();
        }
        private void btthem_Click(object sender, EventArgs e)
        {
            frmThongTinHD frmThongTinHD = new frmThongTinHD();
            frmThongTinHD.Show();

        }
        private void BindGrid(List<HoaDon> listHD)
        {
            dgvbill.Rows.Clear();
            foreach (var item in listHD)
            {
                int index = dgvbill.Rows.Add();
                dgvbill.Rows[index].Cells[0].Value = item.mabill;
                dgvbill.Rows[index].Cells[1].Value = item.tenkh;
                dgvbill.Rows[index].Cells[2].Value = item.sogio;
                dgvbill.Rows[index].Cells[3].Value = item.tongtien;
                
            }
        }
        private void LoadCSDL(List<HoaDon> listHD)
        {
            dgvbill.Rows.Clear();
            foreach (var item in listHD)
            {
                int index = dgvbill.Rows.Add();
                dgvbill.Rows[index].Cells[0].Value = item.mabill;
                dgvbill.Rows[index].Cells[1].Value = item.tenkh;
                dgvbill.Rows[index].Cells[2].Value = item.sogio;
                dgvbill.Rows[index].Cells[3].Value = item.tongtien;
                dgvbill.Rows[index].Cells[4].Value = item.ThoiGian;
                dgvbill.Rows[index].Cells[5].Value = item.thanhtoan;
               

            }
        }
        private void AddThanhToanColumn()
        {
            if (!dgvbill.Columns.Contains("ThanhToan"))
            {
                DataGridViewTextBoxColumn thanhToanColumn = new DataGridViewTextBoxColumn
                {
                    HeaderText = "Thanh Toán",
                    Name = "ThanhToan",
                    Width = 150
                };
                dgvbill.Columns.Add(thanhToanColumn);
            }
        }

        private void frmHoadon_Load(object sender, EventArgs e)
        {
                cbthanhtoan.Items.Clear();
                cbthanhtoan.Items.Add("Chưa thanh toán");
                cbthanhtoan.Items.Add("Đã thanh toán");
                List<HoaDon> listHD = Qlybia.HoaDons.ToList();
                cbthanhtoan.SelectedIndex = -1;
                AddThanhToanColumn();
                BindGrid(listHD);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvbill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void btthanhtoan_Click_1(object sender, EventArgs e)
        {

            try
            {

                if (dgvbill.SelectedRows.Count > 0)
                {

                    string trangThaiThanhToan = cbthanhtoan.SelectedItem?.ToString();

                    if (string.IsNullOrEmpty(trangThaiThanhToan))
                    {
                        MessageBox.Show("Vui lòng chọn trạng thái thanh toán từ ComboBox!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    foreach (DataGridViewRow row in dgvbill.SelectedRows)
                    {
                        string maHoaDon = row.Cells[0].Value?.ToString();
                        if (!string.IsNullOrEmpty(maHoaDon))
                        {
                            var hoaDon = Qlybia.HoaDons.FirstOrDefault(hd => hd.mabill == maHoaDon);
                            if (hoaDon != null)
                            {
                                hoaDon.thanhtoan = trangThaiThanhToan;
                                row.Cells["ThanhToan"].Value = trangThaiThanhToan;
                            }
                        }
                    }

                    Qlybia.SaveChanges();

                    MessageBox.Show("Cập nhật trạng thái thanh toán thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một hàng trong DataGridView để cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật trạng thái thanh toán: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btncapnhap_Click(object sender, EventArgs e)
        {
            List<HoaDon> listHD = Qlybia.HoaDons.ToList();
            AddThanhToanColumn();
            LoadCSDL(listHD);

        }

        private void btinHD_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvbill.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn sau khi in?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                    var selectedRow = dgvbill.SelectedRows[0];
                    string maHoaDon = selectedRow.Cells[0].Value?.ToString();
                    string tenKhachHang = selectedRow.Cells[1].Value?.ToString();
                    string tenBan = "Bàn 1";
                    string tenMon = "Món 1";
                    string thoiGianBatDau = DateTime.Now.AddHours(-1).ToString("HH:mm:ss");
                    string thoiGianKetThuc = DateTime.Now.ToString("HH:mm:ss");
                    string soGio = selectedRow.Cells[2].Value?.ToString();
                    string tongTien = selectedRow.Cells[3].Value?.ToString();
                    frmIn frmIn = new frmIn
                    {
                        MaHoaDon = maHoaDon,
                        TenKhachHang = tenKhachHang,
                        TenBan = tenBan,
                        TenMon = tenMon,
                        ThoiGianBatDau = thoiGianBatDau,
                        ThoiGianKetThuc = thoiGianKetThuc,
                        SoGio = soGio,
                        TongTien = tongTien
                    };
                    frmIn.Show();
                    if (!string.IsNullOrEmpty(maHoaDon))
                    {
                        var hoaDon = Qlybia.HoaDons.FirstOrDefault(hd => hd.mabill == maHoaDon);
                        if (hoaDon != null)
                        {
                            Qlybia.HoaDons.Remove(hoaDon);
                            Qlybia.SaveChanges();
                        }
                        dgvbill.Rows.Remove(selectedRow);

                        MessageBox.Show("In hóa đơn Thành Công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một Hóa Đơn để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThongke_Click(object sender, EventArgs e)
        {
            frmthongke frmTK = new frmthongke();
            frmTK.Show();
            Hide();
        }
    }
}
