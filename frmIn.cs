using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlbida
{
    public partial class frmIn : Form
    {
        public string MaHoaDon { get; set; }
        public string TenKhachHang { get; set; }
        public string TenBan { get; set; }
        public string TenMon { get; set; }
        public string ThoiGianBatDau { get; set; }
        public string ThoiGianKetThuc { get; set; }
        public string SoGio { get; set; }
        public string TongTien { get; set; }
        public frmIn()
        {
            InitializeComponent();
        }

        private void frmIn_Load(object sender, EventArgs e)
        {
            lbIn.Text = $"               Mã Hóa Đơn: {MaHoaDon}\n" +
                             $"\n" +
                             $"--------------------------------------------------\n\n" +
                             $"--------------------------------------------------\n\n" +
                             $"Tên Khách Hàng: {TenKhachHang}\n" +
                             $"\n" +
                             $"Tên Bàn: {TenBan}\n" +
                             $"\n" +
                             $"Tên Món: {TenMon}\n" +
                             $"\n" +
                             $"Thời Gian Bắt Đầu: {ThoiGianBatDau}\n" +
                             $"\n" +
                             $"Thời Gian Kết Thúc: {ThoiGianKetThuc}\n" +
                             $"--------------------------------------------------\n\n" +
                             $"--------------------------------------------------\n\n" +
                             $"Số Giờ: {SoGio}           Tổng Tiền: {TongTien}";
                             
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += PrintDocument_PrintPage;
                PrintPreviewDialog printPreview = new PrintPreviewDialog
                {
                    Document = printDocument
                };
                printPreview.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi in: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(lbIn.Text, new Font("Arial", 12), Brushes.Black, new PointF(100, 100));
        }

    }
}
   
