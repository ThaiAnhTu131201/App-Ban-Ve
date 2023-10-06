using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppBanVe.BusinessTier;
using AppBanVe.DataContext;
using AppBanVe.PresentationTier;

namespace AppBanVe
{
    public partial class FromBanVe : Form
    {
        private int maHoaDon;
        private DataTable tblChiTietHoaDon;
        private GheBT gheBT;
        private HoaDonBT hoaDonBT;
        private CTHDBT cTHDBT;
        private KhachHangBT khachHangBT;
        public FromBanVe()
        {
            InitializeComponent();
            gheBT = new GheBT();
            hoaDonBT = new HoaDonBT();
            cTHDBT = new CTHDBT();
            khachHangBT = new KhachHangBT();
            maHoaDon = 1;
            tblChiTietHoaDon = new DataTable();
            tblChiTietHoaDon.Columns.Add("MaHoaDon",typeof(string));
            tblChiTietHoaDon.Columns.Add("SoGhe",typeof(int));
            tblChiTietHoaDon.Columns.Add("GiaTien",typeof(double));
            //Cài đặt thuộc tính cho  combobox khach hang
            // cài đặt thuộc tính hiện thị cho combobox? hiện thị cái gì
            cbxKhachHang.DisplayMember = "TenKhachHang";
            // cài đặt thuộc tính giá trị trả về khi lựa chọn giá trị 
            cbxKhachHang.ValueMember = "MaKhachHang";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KhoiTaoSoGhe(3, 5);
            TaiDanhSachHoaDon();
            TaiDanhSachKhachHang();
        }

        public void TaiDanhSachKhachHang()
        {
            cbxKhachHang.DataSource = khachHangBT.LayDanhSach();
        } 

        private void TaiDanhSachHoaDon()
        {
            dgvDanhSachHoaDon.DataSource = hoaDonBT.LayDanhSachHoaDon();
        }

        private void KhoiTaoSoGhe(int dong, int cot)
        {
            DateTime ngay = DateTime.Today;
            List<int> danhSachSoGheDaMuaTheoNgay = cTHDBT.LayDanhSachSoGheDaMuaTheoNgay(ngay);


            int x, y=8, khoangCachX= 95, khoangCachY=50,dem=1;
            Button btnGhe;
            for (int i = 0; i < dong; i++)
            {
                x = 26;
                for (int j = 0; j < cot; j++)
                {
                    btnGhe = new Button();
                    btnGhe.Location = new Point(x, y);
                    btnGhe.Size = new Size(80, 50);
                    if (danhSachSoGheDaMuaTheoNgay.Contains(dem))
                        btnGhe.BackColor = Color.Yellow;
                    else
                        btnGhe.BackColor = Color.White;
                    btnGhe.Text = dem++.ToString();
                    btnGhe.Click += btnGhe_Click;
                    pnlHangGhe.Controls.Add(btnGhe);
                    x += khoangCachX;
                }
                y += khoangCachY;
            }
        }

        private void btnGhe_Click(object sender, EventArgs e)
        {
            Button btnGhe = (Button)sender;
            if (btnGhe.BackColor == Color.Yellow)
            {
                MessageBox.Show("Ghe Nay Da Dc Mua");
                return;
            }
            btnGhe.BackColor = (btnGhe.BackColor == Color.White) ? Color.Blue : Color.White;
        }

        private void btnMua_Click(object sender, EventArgs e)
        {
            //tinh tien
            double tongTien = 0;
            double giaGhe = 0;
            int soGhe;
            List<int> danhSachGheDaMua = new List<int>();
            Ghe gheDaMua;
            foreach  (Button ghe in pnlHangGhe.Controls)
            {
                if (ghe.BackColor == Color.Blue)
                {
                    soGhe = int.Parse(ghe.Text);
                    gheDaMua = gheBT.LayGheTuSoGhe(soGhe);

                    //giaGhe = TinhTien(soGhe);//Lấy giá tiền từ database
                    //giaGhe = gheBT.LayGiaGheTheoSoGhe(soGhe);
                    tongTien += gheDaMua.HangGhe.GiaTien;
                    ghe.BackColor = Color.Yellow;
                    //tblChiTietHoaDon.Rows.Add("HD" + maHoaDon,soGhe,giaGhe);
                    danhSachGheDaMua.Add(gheDaMua.MaGhe);
                }
            }
            txtSoTien.Text = tongTien.ToString();

            //ThemHoaDon(tongTien,maHoaDon++);
            HoaDon hoaDon = new HoaDon();
            hoaDon.NgayMua = DateTime.Now;
            hoaDon.TongTien = tongTien;
            hoaDon.MaKhachHang = int.Parse(cbxKhachHang.SelectedValue.ToString());
            string error;   
            if (hoaDonBT.LuuHoaDon(hoaDon,out error))
            {
                //Them Chi Tiet Hoa Don
                CTHD cTHD;
                foreach (int  maGhe  in danhSachGheDaMua)
                {
                    cTHD = new CTHD();
                    cTHD.MaHoaDon = hoaDon.MaHoaDon;
                    cTHD.MaGhe = maGhe;
                    if (!cTHDBT.LuuChiTietHoaDon(cTHD,out error))
                    {
                        MessageBox.Show("Luu ko luu dc chi tiet hoa don!!! Loi Day ne {0}", error);
                        return;
                    }
                }
                TaiDanhSachHoaDon();    

            }
            else
            {
                MessageBox.Show("Co loi xay ra roi!!!, loi o day ne!!!!!!");
                return;
            }
        }

        //private void ThemHoaDon(double tongTien,int maHoaDon)
        //{
        //    var rowIndex = dgvDanhSachHoaDon.Rows.Add();
        //    dgvDanhSachHoaDon.Rows[rowIndex].Cells[0].Value = "HD" + maHoaDon;
        //    dgvDanhSachHoaDon.Rows[rowIndex].Cells[1].Value = tongTien;
        //    dgvDanhSachHoaDon.Rows[rowIndex].Cells[2].Value = DateTime.Now.ToString("dd/MM/yyyy");
        //}

        //private double TinhTien(int viTriGhe)
        //{
        //    if (viTriGhe <= 5)
        //        return 5000;
        //    else if (viTriGhe <= 10)
        //        return 6500;
        //    return 8000;

            
        //}

        

        private void btnHuy_Click(object sender, EventArgs e)
        {
            foreach (Button ghe in pnlHangGhe.Controls)
            {
                if (ghe.BackColor == Color.Blue)
                    ghe.BackColor = Color.White;

            }
            txtSoTien.Text = " ";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Ban co muon thoat", "Thong Bao", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                MessageBox.Show("You have clicked Yes Button");
                this.Close();
                //Some task… 
            }
        }

        private void dgvDanhSachHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            if (rowIndex < 0)
                return;
            int maHoaDon = int.Parse(dgvDanhSachHoaDon.Rows[rowIndex].Cells[0].Value.ToString());
            //Lay Danh sach chi tiet hoa don tu database theo ma hoa don
            dgvDanhSachChiTietHoaDon.DataSource = cTHDBT.LayDanhSachChiTietTheoMaHoaDon(maHoaDon);
            //DataTable tblChiTietTheoMaHoaDon = tblChiTietHoaDon.AsEnumerable()
            //    .Where(row => row.Field<String>("maHoaDon") == maHoaDon)
            //    .CopyToDataTable();
            //dgvDanhSachChiTietHoaDon.DataSource = tblChiTietTheoMaHoaDon;

        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            FormKhachHang formKhachHang = new FormKhachHang();
            formKhachHang.StartPosition = FormStartPosition.CenterScreen;
            formKhachHang.capNhatKhachHangEvent += FormKhachHang_CapNhatKhachHangEvent;
            formKhachHang.ShowDialog();
        }

        private void FormKhachHang_CapNhatKhachHangEvent()
        {
            TaiDanhSachKhachHang();
        }

        private void pnlHangGhe_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
