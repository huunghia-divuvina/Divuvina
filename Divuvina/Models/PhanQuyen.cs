namespace Divuvina.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhanQuyen")]
    public partial class PhanQuyen
    {
        [Key]
        public long PhanQuyenKey { get; set; }

        [Required]
        [StringLength(50)]
        public string PhanQuyenAlternateKey { get; set; }

        public long? NguoiDungKey { get; set; }

        public long? NhomNguoiDungChiTietKey { get; set; }

        public long? DanhMucChucNangKey { get; set; }

        public byte? Doc { get; set; }

        public byte? Ghi { get; set; }

        public byte? Sua { get; set; }

        public byte? Xoa { get; set; }

        public byte? TrangThai { get; set; }

        public virtual DanhMucChucNang DanhMucChucNang { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        public virtual NhomNguoiDungChiTiet NhomNguoiDungChiTiet { get; set; }
    }
}
