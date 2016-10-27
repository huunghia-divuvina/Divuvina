using Divuvina.Public;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

namespace Divuvina.Business.DanhMuc
{
    public class DanhMucHangSanXuatXeBll
    {
        Models.dbContext _db = new Models.dbContext();

        //public IDictionary<short, string> LayDanhMucHangSanXuatXe(short hangSanXuatXeKey = 0)
        //{
        //    if (hangSanXuatXeKey > 0)
        //    {
        //        var listHangSanXuatXes = _db.HangSanXuatXes.Where(r => r.HangSanXuatXeKey == hangSanXuatXeKey)
        //          .Select(r => new { id = r.HangSanXuatXeKey, text = r.Ten });
        //        return listHangSanXuatXes.ToDictionary(r => r.id, r => r.text);
        //    }
        //    else
        //    {
        //        var listHangSanXuatXes = _db.HangSanXuatXes.Select(r => new { id = r.HangSanXuatXeKey, text = r.Ten });
        //        return listHangSanXuatXes.ToDictionary(r => r.id, r => r.text);
        //    }
        //}//EndFunction

        /// <summary>
        /// Get Data for The DataSource of Select
        /// </summary>
        /// <param name="hangSanXuatXeKey"></param>
        /// <returns></returns>
        public object LayDanhMucHangSanXuatXe(short hangSanXuatXeKey = 0)
        {
            if (hangSanXuatXeKey > 0)
            {
                var listHangSanXuatXes = _db.HangSanXuatXes.Where(r => r.HangSanXuatXeKey == hangSanXuatXeKey)
                  .Select(r => new { id = r.HangSanXuatXeKey, text = r.Ten });
                return listHangSanXuatXes;
            }
            else
            {
                var listHangSanXuatXes = _db.HangSanXuatXes.Select(r => new { id = r.HangSanXuatXeKey, text = r.Ten });
                return listHangSanXuatXes;
            }
        }//EndFunction
    }//EndClass
}//EndNamespace