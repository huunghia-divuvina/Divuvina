namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Xe")]
    public partial class Xe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Xe()
        {
            BaoTriSuaChuas = new HashSet<BaoTriSuaChua>();
            KhauHaos = new HashSet<KhauHao>();
            LichBaoTriXes = new HashSet<LichBaoTriXe>();
            SapLichXes = new HashSet<SapLichXe>();
        }

        [Key]
        public int XeKey { get; set; }

        [Required]
        [StringLength(50)]
        public string XeAlternateKey { get; set; }

        public int LoaiXeKey { get; set; }

        [Required]
        [StringLength(15)]
        public string BangSoXe { get; set; }

        [Required]
        [StringLength(20)]
        public string SoSan { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayCapPhep { get; set; }

        public decimal GiaMua { get; set; }

        [StringLength(50)]
        public string Mau { get; set; }

        public bool CoWifi { get; set; }

        public bool CoTivi { get; set; }

        public bool CoCameraHanhTrinh { get; set; }

        [StringLength(500)]
        public string ChiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaoTriSuaChua> BaoTriSuaChuas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhauHao> KhauHaos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichBaoTriXe> LichBaoTriXes { get; set; }

        public virtual LoaiXe LoaiXe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SapLichXe> SapLichXes { get; set; }
    }
}
