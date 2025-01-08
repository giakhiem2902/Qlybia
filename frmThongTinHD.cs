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
    public partial class frmThongTinHD : Form
    {
        public frmThongTinHD()
        {
            InitializeComponent();
            
        }
        Qlybia qlybia = new Qlybia();
        
        private void LoadComboBoxData()
        {
            try
            {
                using (var context = new Qlybia())
                {
                    var khachHangList = context.KHACHHANGs.ToList();
                    cbkhachhang.DataSource = khachHangList;
                    cbkhachhang.DisplayMember = "tenkh";
                    cbkhachhang.ValueMember = "makh";
                    var menuList = context.MENUs.ToList();
                    cbtenmon.DataSource = menuList;
                    cbtenmon.DisplayMember = "tenmon";
                    cbtenmon.ValueMember = "id";
                    var banList = context.Bans.ToList();
                    cbtenban.DataSource = banList;
                    cbtenban.DisplayMember = "TenBan";
                    cbtenban.ValueMember = "ID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu ComboBox: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private double GetGiaMon(string maMon)
        {
            using (var context = new Qlybia())
            {
                var menu = context.MENUs.FirstOrDefault(m => m.id == maMon);
                if (menu != null && menu.gia.HasValue)
                {
                    return menu.gia.Value;
                }
                else
                {
                    throw new Exception("Không tìm thấy món ăn hoặc giá không hợp lệ!");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime thoiGianBatDau = DateTime.Parse(txtthoigianbatdau.Text);
            DateTime thoiGianKetThuc = DateTime.Parse(txtthoigianketthuc.Text);
            TimeSpan soGio = thoiGianKetThuc - thoiGianBatDau;
            txtsogio.Text = soGio.TotalHours.ToString("0.00");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra giá trị số giờ
                if (string.IsNullOrEmpty(txtsogio.Text) || !double.TryParse(txtsogio.Text, out double soGio))
                {
                    MessageBox.Show("Vui lòng tính số giờ trước hoặc nhập đúng định dạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cbtenmon.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn món ăn từ danh sách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string idMon = cbtenmon.SelectedValue.ToString();
                double giaMon = GetGiaMon(idMon);
                // 60.000VND/h
                int tienMotGio = 60000;
                double tongTien = (tienMotGio * soGio) + giaMon;
                txttinhtien.Text = tongTien.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string maHoaDon = txtmaHD.Text;
                string tenKhachHang = cbkhachhang.Text;
                if (string.IsNullOrEmpty(maHoaDon) || string.IsNullOrEmpty(tenKhachHang))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!DateTime.TryParse(txtthoigianbatdau.Text, out DateTime thoiGianBatDau) ||
                    !DateTime.TryParse(txtthoigianketthuc.Text, out DateTime thoiGianKetThuc))
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng thời gian!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (thoiGianKetThuc <= thoiGianBatDau)
                {
                    MessageBox.Show("Thời gian kết thúc phải lớn hơn thời gian bắt đầu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                TimeSpan thoiGianSuDung = thoiGianKetThuc - thoiGianBatDau;
                decimal soGio = (decimal)thoiGianSuDung.TotalHours;
                if (!decimal.TryParse(txttinhtien.Text, out decimal tongTien) || tongTien <= 0)
                {
                    MessageBox.Show("Tổng tiền không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                HoaDon hoaDon = new HoaDon
                {
                    mabill = maHoaDon,
                    tenkh = tenKhachHang,
                    sogio = soGio,
                    tongtien = tongTien,
                    ThoiGian=thoiGianBatDau,
                    
                };
                qlybia.HoaDons.Add(hoaDon);
                qlybia.SaveChanges();
                frmHoadon frm = Application.OpenForms.OfType<frmHoadon>().FirstOrDefault();
                if (frm != null)
                {
                    frm.AddToDataGridView(maHoaDon, tenKhachHang, soGio.ToString("0.00"), tongTien.ToString("0.00"));
                }
                else
                {
                    MessageBox.Show("Không tìm thấy form Hóa Đơn đang mở!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtmaKH_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmThongTinHD_Load(object sender, EventArgs e)
        {
            try
            {
                txtthoigianketthuc.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                txttinhtien.Text = "0.00";
                LoadComboBoxData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải form: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmHoadon frmHoadon = new frmHoadon();
            frmHoadon.Show();
            Hide();
        }

        private void txtthoigianketthuc_TextChanged(object sender, EventArgs e)
        {
            txtthoigianketthuc.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int banID = Convert.ToInt32(cbtenban.SelectedValue);
                using (var context = new Qlybia())
                {
                    var ban = context.Bans.FirstOrDefault(b => b.ID == banID);
                    if (ban != null && ban.ThoiGianBatDau.HasValue)
                    {
                        txtthoigianbatdau.Text = ban.ThoiGianBatDau.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thời gian bắt đầu cho bàn này.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}");
            }
        }

        private void txtsogio_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
