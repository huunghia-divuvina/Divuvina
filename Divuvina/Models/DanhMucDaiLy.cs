namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMucDaiLy")]
    public partial class DanhMucDaiLy
    {
        [Key]
        public long DanhMucDaiLyKey { get; set; }

        [Required]
        [StringLength(50)]
        public string DanhMucDaiLyAlternateKey { get; set; }

        [StringLength(150)]
        public string Ten { get; set; }
    }
}
