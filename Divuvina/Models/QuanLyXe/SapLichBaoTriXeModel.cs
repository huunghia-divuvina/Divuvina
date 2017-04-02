using Divuvina.Public;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Divuvina.Models.QuanLyXe
{
    public class SapLichBaoTriXeModel
    {
        public SapLichBaoTriXe ThongTinTimKiemSapLichBaoTri { get; set; }

        public int NoiSuaChuaXeKey { get; set; }
        public DateTime NgaySapLich { get; set; }

        //public IList<Models.sp_LayThongTinXeChuaSapLich_Result> ListXeChuaSapLich { get; set; }
        //public IList<Models.sp_LayThongTinXeChuaSapLich_Result> ListXeChoSapLich { get; set; }
        //public IList<Models.sp_LayThongTinXeChuaSapLich_Result> ListXeDaSapLich { get; set; }

        public SapLichBaoTriXeModel()
        {
            ThongTinTimKiemSapLichBaoTri = new SapLichBaoTriXe();
        }//EndFunction
    }//EndClass

    public class SapLichBaoTriXe
    {
        public int XeKey { get; set; }
        public int LoaiXeKey { get; set; }
        public int HangSanXuatXeKey { get; set; }

        [StringLength(15)]
        public string BangSoXe { get; set; }

        [StringLength(20)]
        public string SoSan { get; set; }

        //[Column(TypeName = "date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "(0:dd/MM/yyyy HH:mm)",ApplyFormatInEditMode =true)]
        public DateTime? NgayCapPhep { get; set; }

        public bool TimTheoNgayCapPhep { get; set; }
    }//EndClass
}//EndNamespace