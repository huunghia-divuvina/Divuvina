using Divuvina.Public;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Divuvina.Models.QuanLyXe
{
    public class SapLichBaoTriXeModel
    {
        public Xe ThongTinXeTimKiem { get; set; }

        public IList<Xe> ListXeChuaSapLich { get; set; }
        public IList<Xe> ListXeChoSapLich { get; set; }
        public IList<Xe> ListXeDaSapLich { get; set; }

        public SapLichBaoTriXeModel()
        {
            ThongTinXeTimKiem = new Xe();
        }//EndFunction
    }//EndClass
}//EndNamespace