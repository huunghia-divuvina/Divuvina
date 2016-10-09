namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            BaoTriSuaChuas = new HashSet<BaoTriSuaChua>();
            HopDongLaoDongs = new HashSet<HopDongLaoDong>();
            LichBaoTriXes = new HashSet<LichBaoTriXe>();
            LichBaoTriXes1 = new HashSet<LichBaoTriXe>();
            LuongNhanViens = new HashSet<LuongNhanVien>();
            NgayNghiPheps = new HashSet<NgayNghiPhep>();
            SapLichNhanVienTheoXes = new HashSet<SapLichNhanVienTheoXe>();
            SapLichXes = new HashSet<SapLichXe>();
            TroCapNhanViens = new HashSet<TroCapNhanVien>();
            ViTriNhanViens = new HashSet<ViTriNhanVien>();
        }

        [Key]
        public int NhanVienKey { get; set; }

        [Required]
        [StringLength(50)]
        public string NhanVienAlternateKey { get; set; }

        public int? NguoiKey { get; set; }

        [StringLength(15)]
        public string DienThoaiLienLac { get; set; }

        [StringLength(20)]
        public string TinhTrangGiaDinh { get; set; }

        [StringLength(30)]
        public string TrinhDoVanHoa { get; set; }

        [StringLength(30)]
        public string TrinhDoChuyenMon { get; set; }

        [StringLength(350)]
        public string DiaChiThuongTru { get; set; }

        [StringLength(350)]
        public string DiaChiTamTru { get; set; }

        [StringLength(4000)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaoTriSuaChua> BaoTriSuaChuas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HopDongLaoDong> HopDongLaoDongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichBaoTriXe> LichBaoTriXes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichBaoTriXe> LichBaoTriXes1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LuongNhanVien> LuongNhanViens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NgayNghiPhep> NgayNghiPheps { get; set; }

        public virtual Nguoi Nguoi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SapLichNhanVienTheoXe> SapLichNhanVienTheoXes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SapLichXe> SapLichXes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TroCapNhanVien> TroCapNhanViens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ViTriNhanVien> ViTriNhanViens { get; set; }
    }
}
