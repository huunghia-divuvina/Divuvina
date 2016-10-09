namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TuyenDuong")]
    public partial class TuyenDuong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TuyenDuong()
        {
            SapLichXes = new HashSet<SapLichXe>();
        }

        [Key]
        public int TuyenDuongKey { get; set; }

        [StringLength(250)]
        public string NoiDi { get; set; }

        public int? NoiDiQuocGiaKey { get; set; }

        public int? NoiDiTinhThanhKey { get; set; }

        public int? NoiDiQuanHuyenKey { get; set; }

        public int? NoiDiPhuongXaKey { get; set; }

        public int? NoiDiDuongKey { get; set; }

        [StringLength(20)]
        public string NoiDiSoNha { get; set; }

        [StringLength(250)]
        public string NoiDen { get; set; }

        public int? NoiDenQuocGiaKey { get; set; }

        public int? NoiDenTinhThanhKey { get; set; }

        public int? NoiDenQuanHuyenKey { get; set; }

        public int? NoiDenPhuongXaKey { get; set; }

        public int? NoiDenDuongKey { get; set; }

        [StringLength(20)]
        public string NoiDenSoNha { get; set; }

        public decimal? SoKm { get; set; }

        [StringLength(4000)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SapLichXe> SapLichXes { get; set; }
    }
}
