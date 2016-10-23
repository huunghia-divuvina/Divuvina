using System;
using System.Linq;
using System.Web.Mvc;
using Divuvina.Public;


namespace Divuvina.Controllers
{
    public class DanhMucXepLichXeController : Controller
    {
        Models.dbContext _db = new Models.dbContext();

        // GET: DanhMucXepLichXe
        public ActionResult Index()
        {
            return View();
        }

        #region Danh mục chi phí
        public ActionResult DanhMucChiPhi()
        {
            return View();
        }

        public JsonResult GetDataDanhMucChiPhi()
        {
            var listDanhMucChiPhis = _db.DanhMucChiPhis.Select(r => new { Key = r.DanhMucChiPhiKey, r.DienGiai, r.GhiChu });
            return Json(listDanhMucChiPhis, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteDanhMucChiPhi(int Key)
        {
            try
            {
                var row = _db.DanhMucChiPhis.FirstOrDefault(r => r.DanhMucChiPhiKey == Key);
                if (row != null)
                {
                    _db.DanhMucChiPhis.Remove(row);
                    _db.SaveChanges();
                }

                return Json(new { Result = true, Title = TitleMessageBox.Notification, Message = Message.SuccessfulDataAction }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = TitleMessageBox.Notification, Message = Message.UnsuccessfulDataAction }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult SaveDanhMucChiPhi(int Key, string dienGiai, string ghiChu)
        {
            try
            {
                var row = _db.DanhMucChiPhis.FirstOrDefault(r => r.DanhMucChiPhiKey == Key);
                if (row == null)
                {
                    row = new Models.DanhMucChiPhi();
                    row.DanhMucChiPhiAlternateKey = Key.ToString();
                    _db.DanhMucChiPhis.Add(row);
                }
                row.DienGiai = dienGiai;
                row.GhiChu = ghiChu;

                _db.SaveChanges();

                return Json(new { Result = true, Title = TitleMessageBox.Notification, Message = Message.SuccessfulDataAction }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = TitleMessageBox.Notification, Message = Message.UnsuccessfulDataAction }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion Danh mục chi phí
    }//EndClass
}//EndNamespace