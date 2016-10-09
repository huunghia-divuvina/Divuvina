namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SapLichXe")]
    public partial class SapLichXe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SapLichXe()
        {
            LoTrinhs = new HashSet<LoTrinh>();
            SapLichNhanVienTheoXes = new HashSet<SapLichNhanVienTheoXe>();
            VeXes = new HashSet<VeXe>();
        }

        [Key]
        public int SapLichXeKey { get; set; }

        public int TuyenDuongKey { get; set; }

        public int XeKey { get; set; }

        [StringLength(20)]
        public string MaTai { get; set; }

        public int NhanVienSapLichKey { get; set; }

        public int TrangThaiKey { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayXuatBen { get; set; }

        public TimeSpan GioXuatBen { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayDen { get; set; }

        public TimeSpan GioDen { get; set; }

        public TimeSpan ThoiDiemXuatBen { get; set; }

        public int NguoiNhapKey { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoTrinh> LoTrinhs { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SapLichNhanVienTheoXe> SapLichNhanVienTheoXes { get; set; }

        public virtual TrangThai TrangThai { get; set; }

        public virtual TuyenDuong TuyenDuong { get; set; }

        public virtual Xe Xe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VeXe> VeXes { get; set; }
    }
}
