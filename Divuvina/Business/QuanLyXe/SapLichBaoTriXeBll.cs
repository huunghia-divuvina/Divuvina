using System;
using System.Collections.Generic;
using Divuvina.Models;

namespace Divuvina.Business.QuanLyXe
{
    public class SapLichBaoTriXeBll
    {
        Models.dbSp _dbSp = new Models.dbSp();

        #region Sắp lịch bảo trì xe
        public List<object> LayThongTinXe(string thongTinXe)
        {
            try
            {
                if (!String.IsNullOrEmpty(thongTinXe))
                {
                    //var ss = _dbSp.sp_LayThongTinXe(thongTinXe);

                    //var listThongTinXe = _db.Xes
                    //    .Where(xe => xe.BangSoXe.Contains(thongTinXe) || xe.SoSan.Contains(thongTinXe)
                    //    || xe.Mau.Contains(thongTinXe) || xe.GhiChu.Contains(thongTinXe))
                    //    .Select(xe => new { xe.XeKey, xe.BangSoXe, xe.SoSan, xe.NgayCapPhep, xe.Mau, xe.GiaMua, xe.CoCameraHanhTrinh, xe.CoTivi, xe.CoWifi, xe.GhiChu });
                    //var listThongTinXe = _db.Database.s
                    //return listThongTinXe.ToList(Object);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }//EndFunction

        #endregion Sắp lịch bảo trì xe
    }//EndClass
}//EndNamespace