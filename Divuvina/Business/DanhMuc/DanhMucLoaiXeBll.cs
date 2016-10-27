using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Divuvina.Business.DanhMuc
{
    public class DanhMucLoaiXeBll
    {
        Models.dbContext _db = new Models.dbContext();

        //public IDictionary<int, string> LayDanhMucLoaiXe(short hangSanXuatXeKey = 0)
        //{
        //    if(hangSanXuatXeKey > 0)
        //    {
        //        var listLoaiXes = _db.LoaiXes.Where(r => r.HangSanXuatXeKey == hangSanXuatXeKey)
        //          .Select(r => new { id = r.LoaiXeKey, text = r.Ten });
        //        return listLoaiXes.ToDictionary(r => r.id, r => r.text);
        //    }
        //    else {
        //        var listLoaiXes = _db.LoaiXes.Select(r => new { id = r.LoaiXeKey, text = r.Ten });
        //        return listLoaiXes.ToDictionary(r => r.id, r => r.text);
        //    }
        //}//EndFunction

        /// <summary>
        /// Get Data for The DataSource of Select
        /// </summary>
        /// <param name="hangSanXuatXeKey"></param>
        /// <returns></returns>
        public object LayDanhMucLoaiXe(short hangSanXuatXeKey = 0)
        {
            if (hangSanXuatXeKey > 0)
            {
                var listLoaiXes = _db.LoaiXes.Where(r => r.HangSanXuatXeKey == hangSanXuatXeKey)
                  .Select(r => new { id = r.LoaiXeKey, text = r.Ten });
                return listLoaiXes;
            }
            else
            {
                var listLoaiXes = _db.LoaiXes.Select(r => new { id = r.LoaiXeKey, text = r.Ten });
                return listLoaiXes;
            }
        }//EndFunction

    }//EndClass
}//EndNamespace