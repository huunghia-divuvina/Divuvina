using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Divuvina.Business.DanhMuc
{
    public class NoiSuaChuaXeBll
    {
        Models.dbContext _db = new Models.dbContext();

        /// <summary>
        /// Get Data for The DataSource of Select
        /// </summary>
        /// <param name="noiSuaChuaXeKey"></param>
        /// <returns></returns>
        public object LayNoiSuaChuaXeChoSelect(short noiSuaChuaXeKey = 0)
        {
            if (noiSuaChuaXeKey > 0)
            {
                var listNoiSuaChuaXes = _db.NoiSuaChuaXes.Where(r => r.NoiSuaChuaXeKey == noiSuaChuaXeKey)
                  .Select(r => new { id = r.NoiSuaChuaXeKey, text = r.Ten });
                return listNoiSuaChuaXes;
            }
            else
            {
                var listNoiSuaChuaXes = _db.NoiSuaChuaXes.Select(r => new { id = r.NoiSuaChuaXeKey, text = r.Ten });
                return listNoiSuaChuaXes;
            }
        }//EndFunction
    }//EndClass
}//EndNamespace