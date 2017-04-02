using Divuvina.Business.Exceptions;
using Divuvina.Models.Public;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Divuvina.Controllers
{
    public class TestComponentsController : Controller
    {
        Models.dbContext _db = new Models.dbContext();

        // GET: TestComponents
        public ActionResult Index()
        {
            return View();
        }

        #region dataTable
        public ActionResult dataTable()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult GetThongTinXeChuaSapLich()
        {
            var message = new RMessage { ErrorMessage = "Tìm thông tin xe chưa sắp lịch sửa chữa không thành công.", Result = false };
            try
            {
                //if (model != null && model.ThongTinTimKiemSapLichBaoTri != null)//ModelState.IsValid && 
                {
                    string store = "[dbo].[sp_LayThongTinXeChuaSapLich] @HangSanXuatXeKey, @LoaiXeKey, @BangSoXe, @SoSan, @NgayCapPhep";

                    var ngayCapPhep = new SqlParameter { ParameterName = "NgayCapPhep", SqlDbType = SqlDbType.DateTime, Value = DBNull.Value };

                    var sqlParams = new SqlParameter[] {
                        new SqlParameter { ParameterName = "HangSanXuatXeKey", SqlDbType = SqlDbType.Int, Value = 0 },
                        new SqlParameter { ParameterName = "LoaiXeKey", SqlDbType = SqlDbType.Int, Value = 0 },
                        new SqlParameter { ParameterName = "BangSoXe", SqlDbType = SqlDbType.VarChar, Value = string.Empty },
                        new SqlParameter { ParameterName = "SoSan", SqlDbType = SqlDbType.VarChar, Value = string.Empty},
                        ngayCapPhep
                    };
                    var ListXeChuaSapLich = _db.Database.SqlQuery<Models.sp_LayThongTinXeChuaSapLich_Result>(store, sqlParams).ToList();
                    return Json(ListXeChuaSapLich, JsonRequestBehavior.AllowGet);
                }
                //return Json(message, JsonRequestBehavior.AllowGet);
            }
            catch (BusinessException ex)
            {
                message.Result = false;
                message.MessageId = ex.getExceptionId();
                message.SystemMessage = ex.ToString();
                ViewData["RMessage"] = message;
                return Json(message, JsonRequestBehavior.AllowGet);
            }
        }//EndFunction

        #endregion dataTable
    }
}