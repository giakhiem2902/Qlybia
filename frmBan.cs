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
using qlbida.Models;

namespace qlbida
{
    public partial class frmBan : Form
    {
        public frmBan()
        {
        InitializeComponent();
        }
        Qlybia qlybia = new Qlybia();
        public static string ThoiGianBatDau;
        private void LoadBanInfo(int maBan)
        {
            try
            {
                var ban = qlybia.Bans.FirstOrDefault(b => b.ID == maBan);
                if (ban != null)
                {
                    // Hiển thị thông tin lên các TextBox
                    txtID.Text = ban.ID.ToString();
                    txttenban.Text = ban.TenBan;
                    cbtrangthai.Text = ban.TrangThai;

                    // Hiển thị thời gian bắt đầu lên TextBox (Chuyển đổi thành chuỗi thời gian)
                    txtthoigianbatdau.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin bàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtID.Text = string.Empty;
                    txttenban.Text = string.Empty;
                    cbtrangthai.SelectedIndex = -1;
                    txtthoigianbatdau.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form2 fr = new Form2();
            fr.Show();
            Hide();

        }
        private void toolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy ToolStripButton được nhấn
                ToolStripButton btn = sender as ToolStripButton;

                if (btn != null && btn.Tag != null)
                {
                    // Lấy ID bàn từ thuộc tính Tag
                    int banID = (int)btn.Tag;

                    // Truy vấn thông tin bàn từ cơ sở dữ liệu
                    var selectedBan = qlybia.Bans.FirstOrDefault(b => b.ID == banID);

                    if (selectedBan != null)
                    {
                        // Hiển thị thông tin lên các TextBox và ComboBox
                        txtID.Text = selectedBan.ID.ToString();
                        txttenban.Text = selectedBan.TenBan;
                        cbtrangthai.SelectedItem = selectedBan.TrangThai;

                        // Hiển thị thời gian bắt đầu nếu có
                        if (selectedBan.ThoiGianBatDau.HasValue)
                        {
                            txtthoigianbatdau.Text = selectedBan.ThoiGianBatDau.ToString();
                        }
                        else
                        {
                            txtthoigianbatdau.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin bàn.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        

        }
        private void SaveBanInfo(int maBan)
        {
            try
            {
                using (var context = new Qlybia())
                {
                    var ban = context.Bans.FirstOrDefault(b => b.ID == maBan);
                    if (ban != null)
                    {
                        ban.TenBan = txttenban.Text.Trim();
                        ban.TrangThai = cbtrangthai.Text.Trim();
                        ban.ThoiGianBatDau = DateTime.Parse(txtthoigianbatdau.Text);

                        context.SaveChanges();

                        var btn = toolStrip1.Items.OfType<ToolStripButton>().FirstOrDefault(b => (int)b.Tag == maBan);
                        if (btn != null)
                        {
                            UpdateBanColor(btn, ban.TrangThai);
                        }

                        MessageBox.Show("Lưu thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy bàn để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu thông tin bàn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadToolStripButtons()
        {
            toolStrip1.Items.Clear();
            toolStrip1.LayoutStyle = ToolStripLayoutStyle.Table; 
            var layoutSettings = toolStrip1.LayoutSettings as TableLayoutSettings;
            if (layoutSettings != null)
            {
                layoutSettings.ColumnCount = 3;
                layoutSettings.RowCount = 0;
            }
            foreach (var ban in qlybia.Bans.ToList())
            {
                ToolStripButton btnBan = new ToolStripButton
                {
                    Name = $"btnBan{ban.ID}",
                    Text = $"Bàn {ban.ID}", 
                    Tag = ban.ID,
                    AutoSize = false,
                    Size = new Size(100, 80),
                    Padding = new Padding(5),
                    Image = Properties.Resources._1,
                    ImageAlign = ContentAlignment.MiddleCenter,
                    ImageScaling = ToolStripItemImageScaling.None,
                    TextImageRelation = TextImageRelation.ImageAboveText, 
                    BackColor = Color.Transparent
                };
                UpdateBanColor(btnBan, ban.TrangThai);
                btnBan.Click += toolStripButton_Click;
                toolStrip1.Items.Add(btnBan);
            }
        }


        private void UpdateBanColor(ToolStripButton btn, string trangThai)
        {
            if (trangThai == "Đang sử dụng")
            {
                btn.BackColor = Color.Red;
                btn.ForeColor = Color.Black;
            }
            else if (trangThai == "Trống")
            {
                btn.BackColor = Color.Green;
                btn.ForeColor = Color.Black;
            }
            else
            {
                btn.BackColor = SystemColors.Control;
                btn.ForeColor = SystemColors.ControlText;
            }
        }

        private void frmBan_Load(object sender, EventArgs e)
        {
            try
            {
                LoadToolStripButtons(); // Gọi hàm để tải các nút lên ToolStrip
                cbtrangthai.Items.Clear();
                cbtrangthai.Items.Add("Trống");
                cbtrangthai.Items.Add("Đang sử dụng");
                cbtrangthai.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtID.Text, out int maBan))
            {
                SaveBanInfo(maBan); // Gọi phương thức để lưu thông tin
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bàn hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ThoiGianBatDau = txtthoigianbatdau.Text; // Gán giá trị vào biến tĩnh
            frmThongTinHD thongtinHD = new frmThongTinHD();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
