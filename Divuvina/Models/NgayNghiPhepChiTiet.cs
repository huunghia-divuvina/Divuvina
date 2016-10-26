namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NgayNghiPhepChiTiet")]
    public partial class NgayNghiPhepChiTiet
    {
        [Key]
        public int NgayNghiPhepChiTietKey { get; set; }

        [Required]
        [StringLength(50)]
        public string NgayNghiPhepChiTietAlternateKey { get; set; }

        public int NgayNghiPhepKey { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayLamDon { get; set; }

        public decimal? SoNgayXinNghi { get; set; }

        [StringLength(200)]
        public string NoiDungXinNghi { get; set; }

        public virtual NgayNghiPhep NgayNghiPhep { get; set; }
    }
}
