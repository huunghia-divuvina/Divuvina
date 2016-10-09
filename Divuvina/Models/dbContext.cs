namespace Divuvina.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class dbContext : DbContext
    {
        public dbContext()
            : base("name=dbContext")
        {
        }

        public virtual DbSet<BaoTriSuaChua> BaoTriSuaChuas { get; set; }
        public virtual DbSet<BaoTriSuaChuaChiTiet> BaoTriSuaChuaChiTiets { get; set; }
        public virtual DbSet<DanhMucChiPhi> DanhMucChiPhis { get; set; }
        public virtual DbSet<DanhMucChucNang> DanhMucChucNangs { get; set; }
        public virtual DbSet<DanhMucDaiLy> DanhMucDaiLies { get; set; }
        public virtual DbSet<DanhMucModule> DanhMucModules { get; set; }
        public virtual DbSet<DanhMucViTri> DanhMucViTris { get; set; }
        public virtual DbSet<Duong> Duongs { get; set; }
        public virtual DbSet<HopDongLaoDong> HopDongLaoDongs { get; set; }
        public virtual DbSet<KhauHao> KhauHaos { get; set; }
        public virtual DbSet<LichBaoTriXe> LichBaoTriXes { get; set; }
        public virtual DbSet<LichBaoTriXeChiTiet> LichBaoTriXeChiTiets { get; set; }
        public virtual DbSet<LoaiDiaChi> LoaiDiaChis { get; set; }
        public virtual DbSet<LoaiGhe> LoaiGhes { get; set; }
        public virtual DbSet<LoaiHopDong> LoaiHopDongs { get; set; }
        public virtual DbSet<LoaiTroCap> LoaiTroCaps { get; set; }
        public virtual DbSet<LoaiXe> LoaiXes { get; set; }
        public virtual DbSet<LoTrinh> LoTrinhs { get; set; }
        public virtual DbSet<LoTrinhChiPhi> LoTrinhChiPhis { get; set; }
        public virtual DbSet<LoTrinhChiTiet> LoTrinhChiTiets { get; set; }
        public virtual DbSet<LuongNhanVien> LuongNhanViens { get; set; }
        public virtual DbSet<LuongNhanVienLichSu> LuongNhanVienLichSus { get; set; }
        public virtual DbSet<NgayNghiPhep> NgayNghiPheps { get; set; }
        public virtual DbSet<NgayNghiPhepChiTiet> NgayNghiPhepChiTiets { get; set; }
        public virtual DbSet<Nguoi> Nguois { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<NhomNguoiDung> NhomNguoiDungs { get; set; }
        public virtual DbSet<NhomNguoiDungChiTiet> NhomNguoiDungChiTiets { get; set; }
        public virtual DbSet<NoiSuaChuaXe> NoiSuaChuaXes { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }
        public virtual DbSet<PhongBan> PhongBans { get; set; }
        public virtual DbSet<PhuongXa> PhuongXas { get; set; }
        public virtual DbSet<QuanHuyen> QuanHuyens { get; set; }
        public virtual DbSet<QuocGia> QuocGias { get; set; }
        public virtual DbSet<SapLichNhanVienTheoXe> SapLichNhanVienTheoXes { get; set; }
        public virtual DbSet<SapLichXe> SapLichXes { get; set; }
        public virtual DbSet<ThietBiLinhKien> ThietBiLinhKiens { get; set; }
        public virtual DbSet<ThongTinDatVe> ThongTinDatVes { get; set; }
        public virtual DbSet<TinhThanh> TinhThanhs { get; set; }
        public virtual DbSet<TrangThai> TrangThais { get; set; }
        public virtual DbSet<TroCapNhanVien> TroCapNhanViens { get; set; }
        public virtual DbSet<TroCapNhanVienChiTietHangThang> TroCapNhanVienChiTietHangThangs { get; set; }
        public virtual DbSet<TuyenDuong> TuyenDuongs { get; set; }
        public virtual DbSet<VeXe> VeXes { get; set; }
        public virtual DbSet<ViTriNhanVien> ViTriNhanViens { get; set; }
        public virtual DbSet<Xe> Xes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaoTriSuaChua>()
                .Property(e => e.BaoTriSuaChuaAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<BaoTriSuaChua>()
                .HasMany(e => e.BaoTriSuaChuaChiTiets)
                .WithRequired(e => e.BaoTriSuaChua)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaoTriSuaChuaChiTiet>()
                .Property(e => e.BaoTriSuaChuaChiTietAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<DanhMucChiPhi>()
                .Property(e => e.DanhMucChiPhiAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<DanhMucChiPhi>()
                .HasMany(e => e.LoTrinhChiPhis)
                .WithRequired(e => e.DanhMucChiPhi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DanhMucChucNang>()
                .Property(e => e.DanhMucChucNangAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<DanhMucDaiLy>()
                .Property(e => e.DanhMucDaiLyAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<DanhMucModule>()
                .Property(e => e.DanhMucModuleAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<DanhMucModule>()
                .HasMany(e => e.DanhMucChucNangs)
                .WithRequired(e => e.DanhMucModule)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DanhMucViTri>()
                .Property(e => e.DanhMucViTriAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<DanhMucViTri>()
                .HasMany(e => e.ViTriNhanViens)
                .WithRequired(e => e.DanhMucViTri)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Duong>()
                .Property(e => e.DuongAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<Duong>()
                .Property(e => e.TenKhongDau)
                .IsUnicode(false);

            modelBuilder.Entity<Duong>()
                .HasMany(e => e.LoTrinhChiTiets)
                .WithRequired(e => e.Duong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HopDongLaoDong>()
                .Property(e => e.HopDongLaoDongAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<HopDongLaoDong>()
                .Property(e => e.DienThoaiBenSuDungLaoDong)
                .IsUnicode(false);

            modelBuilder.Entity<HopDongLaoDong>()
                .Property(e => e.SoLaoDong)
                .IsUnicode(false);

            modelBuilder.Entity<KhauHao>()
                .Property(e => e.KhauHaoAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<LichBaoTriXe>()
                .Property(e => e.LichBaoTriXeAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<LichBaoTriXe>()
                .HasMany(e => e.LichBaoTriXeChiTiets)
                .WithRequired(e => e.LichBaoTriXe)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiDiaChi>()
                .Property(e => e.LoaiDiaChiAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiDiaChi>()
                .Property(e => e.TenKhongDau)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiHopDong>()
                .Property(e => e.LoaiHopDongAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiHopDong>()
                .HasMany(e => e.HopDongLaoDongs)
                .WithRequired(e => e.LoaiHopDong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiTroCap>()
                .Property(e => e.LoaiTroCapAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiTroCap>()
                .HasMany(e => e.TroCapNhanViens)
                .WithRequired(e => e.LoaiTroCap)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiXe>()
                .Property(e => e.LoaiXeAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiXe>()
                .Property(e => e.LoaiGhe)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiXe>()
                .HasMany(e => e.Xes)
                .WithRequired(e => e.LoaiXe)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoTrinh>()
                .Property(e => e.LoTrinhAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<LoTrinh>()
                .HasMany(e => e.LoTrinhChiPhis)
                .WithRequired(e => e.LoTrinh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoTrinh>()
                .HasMany(e => e.LoTrinhChiTiets)
                .WithRequired(e => e.LoTrinh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoTrinhChiPhi>()
                .Property(e => e.LoTrinhChiPhiAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<LoTrinhChiTiet>()
                .Property(e => e.LoTrinhChiTietAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<LuongNhanVien>()
                .Property(e => e.LuongNhanVienAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<LuongNhanVien>()
                .HasMany(e => e.LuongNhanVienLichSus)
                .WithRequired(e => e.LuongNhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LuongNhanVienLichSu>()
                .Property(e => e.LuongNhanVienLichSuAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<NgayNghiPhep>()
                .Property(e => e.NgayNghiPhepAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<NgayNghiPhep>()
                .HasMany(e => e.NgayNghiPhepChiTiets)
                .WithRequired(e => e.NgayNghiPhep)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NgayNghiPhepChiTiet>()
                .Property(e => e.NgayNghiPhepChiTietAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<Nguoi>()
                .Property(e => e.CMND)
                .IsUnicode(false);

            modelBuilder.Entity<Nguoi>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.NguoiDungAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.NhomNguoiDungChiTiets)
                .WithRequired(e => e.NguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.NhanVienAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.DienThoaiLienLac)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.BaoTriSuaChuas)
                .WithRequired(e => e.NhanVien)
                .HasForeignKey(e => e.NhanVienThucHienKey)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.HopDongLaoDongs)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.LichBaoTriXes)
                .WithOptional(e => e.NhanVien)
                .HasForeignKey(e => e.NhanVienSapLichKey);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.LichBaoTriXes1)
                .WithOptional(e => e.NhanVien1)
                .HasForeignKey(e => e.NhanVienThucHienKey);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.LuongNhanViens)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.NgayNghiPheps)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.SapLichNhanVienTheoXes)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.SapLichXes)
                .WithRequired(e => e.NhanVien)
                .HasForeignKey(e => e.NguoiNhapKey)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.TroCapNhanViens)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.ViTriNhanViens)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhomNguoiDung>()
                .Property(e => e.NhomNguoiDungAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<NhomNguoiDung>()
                .HasMany(e => e.NhomNguoiDungChiTiets)
                .WithRequired(e => e.NhomNguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhomNguoiDungChiTiet>()
                .Property(e => e.NhomNguoiDungChiTietAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<NoiSuaChuaXe>()
                .Property(e => e.NoiSuaChuaXeAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<PhanQuyen>()
                .Property(e => e.PhanQuyenAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<PhongBan>()
                .Property(e => e.PhongBanAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<PhongBan>()
                .HasMany(e => e.ViTriNhanViens)
                .WithRequired(e => e.PhongBan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhuongXa>()
                .Property(e => e.PhuongXaAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<PhuongXa>()
                .Property(e => e.TenKhongDau)
                .IsUnicode(false);

            modelBuilder.Entity<PhuongXa>()
                .HasMany(e => e.LoTrinhChiTiets)
                .WithRequired(e => e.PhuongXa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuanHuyen>()
                .Property(e => e.QuanHuyenAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<QuanHuyen>()
                .Property(e => e.TenKhongDau)
                .IsUnicode(false);

            modelBuilder.Entity<QuanHuyen>()
                .HasMany(e => e.LoTrinhChiTiets)
                .WithRequired(e => e.QuanHuyen)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuocGia>()
                .Property(e => e.QuocGiaAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<QuocGia>()
                .Property(e => e.TenKhongDau)
                .IsUnicode(false);

            modelBuilder.Entity<QuocGia>()
                .Property(e => e.CountryCode)
                .IsUnicode(false);

            modelBuilder.Entity<SapLichNhanVienTheoXe>()
                .Property(e => e.SapLichNhanVienTheoXeAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<SapLichXe>()
                .Property(e => e.MaTai)
                .IsUnicode(false);

            modelBuilder.Entity<SapLichXe>()
                .HasMany(e => e.LoTrinhs)
                .WithRequired(e => e.SapLichXe)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SapLichXe>()
                .HasMany(e => e.SapLichNhanVienTheoXes)
                .WithRequired(e => e.SapLichXe)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SapLichXe>()
                .HasMany(e => e.VeXes)
                .WithRequired(e => e.SapLichXe)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThietBiLinhKien>()
                .Property(e => e.ThietBiLinhKienAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<ThietBiLinhKien>()
                .HasMany(e => e.BaoTriSuaChuaChiTiets)
                .WithRequired(e => e.ThietBiLinhKien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThietBiLinhKien>()
                .HasMany(e => e.LichBaoTriXeChiTiets)
                .WithRequired(e => e.ThietBiLinhKien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThongTinDatVe>()
                .Property(e => e.ThongTinDatVeAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinDatVe>()
                .Property(e => e.HoTenKhachHang)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinDatVe>()
                .Property(e => e.CMND)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinDatVe>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinDatVe>()
                .Property(e => e.DiemDon)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinDatVe>()
                .Property(e => e.DiemDonSoNha)
                .IsUnicode(false);

            modelBuilder.Entity<TinhThanh>()
                .Property(e => e.TinhThanhAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<TinhThanh>()
                .Property(e => e.TenKhongDau)
                .IsUnicode(false);

            modelBuilder.Entity<TinhThanh>()
                .HasMany(e => e.LoTrinhChiTiets)
                .WithRequired(e => e.TinhThanh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TrangThai>()
                .HasMany(e => e.SapLichXes)
                .WithRequired(e => e.TrangThai)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TrangThai>()
                .HasMany(e => e.ThongTinDatVes)
                .WithRequired(e => e.TrangThai)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TrangThai>()
                .HasMany(e => e.VeXes)
                .WithRequired(e => e.TrangThai)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TroCapNhanVien>()
                .Property(e => e.TroCapNhanVienAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<TroCapNhanVien>()
                .HasMany(e => e.TroCapNhanVienChiTietHangThangs)
                .WithRequired(e => e.TroCapNhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TroCapNhanVienChiTietHangThang>()
                .Property(e => e.TroCapNhanVienChiTietHangThangAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<TuyenDuong>()
                .Property(e => e.NoiDiSoNha)
                .IsUnicode(false);

            modelBuilder.Entity<TuyenDuong>()
                .Property(e => e.NoiDenSoNha)
                .IsUnicode(false);

            modelBuilder.Entity<TuyenDuong>()
                .HasMany(e => e.SapLichXes)
                .WithRequired(e => e.TuyenDuong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VeXe>()
                .Property(e => e.CodeVe)
                .IsUnicode(false);

            modelBuilder.Entity<VeXe>()
                .HasMany(e => e.ThongTinDatVes)
                .WithRequired(e => e.VeXe)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ViTriNhanVien>()
                .Property(e => e.ViTriNhanVienAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<Xe>()
                .Property(e => e.XeAlternateKey)
                .IsUnicode(false);

            modelBuilder.Entity<Xe>()
                .Property(e => e.BangSoXe)
                .IsUnicode(false);

            modelBuilder.Entity<Xe>()
                .Property(e => e.SoSan)
                .IsUnicode(false);

            modelBuilder.Entity<Xe>()
                .HasMany(e => e.KhauHaos)
                .WithRequired(e => e.Xe)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Xe>()
                .HasMany(e => e.LichBaoTriXes)
                .WithRequired(e => e.Xe)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Xe>()
                .HasMany(e => e.SapLichXes)
                .WithRequired(e => e.Xe)
                .WillCascadeOnDelete(false);
        }
    }
}
