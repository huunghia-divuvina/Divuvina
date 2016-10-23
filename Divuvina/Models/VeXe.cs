namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VeXe")]
    public partial class VeXe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VeXe()
        {
            ThongTinDatVes = new HashSet<ThongTinDatVe>();
        }

        [Key]
        public int VeXeKey { get; set; }

        public int SapLichXeKey { get; set; }

        public int TrangThaiKey { get; set; }

        public decimal GiaVe { get; set; }

        public int SoGhe { get; set; }

        [StringLength(100)]
        public string CodeVe { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        public virtual SapLichXe SapLichXe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongTinDatVe> ThongTinDatVes { get; set; }

        public virtual TrangThai TrangThai { get; set; }
    }
}
