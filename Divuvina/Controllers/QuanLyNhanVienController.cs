using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Divuvina.Business;
using Divuvina.Public;

namespace Divuvina.Controllers
{
    //Test github
    public class QuanLyNhanVienController : Controller
    {
        Models.dbContext _db = new Models.dbContext();

        #region Danh mục Loại hợp đồng
        public ActionResult DanhMucLoaiHopDong()
        {
            return View();
        }
        public JsonResult GetDataDanhMucLoaiHopDong()
        {
            var rs = _db.LoaiHopDongs.Select(r => new { Key = r.LoaiHopDongKey, r.Ten, r.DienGiai, r.GhiChu });
            return Json(rs, JsonRequestBehavior.AllowGet);
            //return Json(new { employee = rs }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteDanhMucLoaiHopDong(int Key)
        {
            try
            {
                var row = _db.LoaiHopDongs.FirstOrDefault(r => r.LoaiHopDongKey == Key);
                if (row != null)
                {
                    _db.LoaiHopDongs.Remove(row);
                    _db.SaveChanges();
                }

                return Json(new { Result = true, Title = TitleMessageBox.SuccessTitle, Message = Message.SuccessDataAction }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = TitleMessageBox.FailureTitle, Message = Message.FailureDataAction }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult SaveDanhMucLoaiHopDong(int Key, string Ten, string DienGiai, string GhiChu)
        {
            try
            {
                var row = _db.LoaiHopDongs.FirstOrDefault(r => r.LoaiHopDongKey == Key);
                if (row == null)
                {
                    row = new Models.LoaiHopDong();
                    row.LoaiHopDongAlternateKey = Key.ToString();
                    _db.LoaiHopDongs.Add(row);
                }
                row.Ten = Ten;
                row.DienGiai = DienGiai;
                row.GhiChu = GhiChu;

                _db.SaveChanges();

                return Json(new { Result = true, Title = TitleMessageBox.SuccessTitle, Message = Message.SuccessDataAction }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = TitleMessageBox.FailureTitle, Message = Message.FailureDataAction }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region Danh mục Loại trợ cấp
        public ActionResult DanhMucLoaiTroCap()
        {
            return View();
        }
        public JsonResult GetDataDanhMucLoaiTroCap()
        {
            var rs = _db.LoaiTroCaps.Select(r => new { Key = r.LoaiTroCapKey, r.Ten, r.DienGiai, r.GhiChu });
            return Json(rs, JsonRequestBehavior.AllowGet);
            //return Json(new { employee = rs }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteDanhMucLoaiTroCap(int Key)
        {
            try
            {
                var row = _db.LoaiTroCaps.FirstOrDefault(r => r.LoaiTroCapKey == Key);
                if (row != null)
                {
                    _db.LoaiTroCaps.Remove(row);
                    _db.SaveChanges();
                }

                return Json(new { Result = true, Title = TitleMessageBox.SuccessTitle, Message = Message.SuccessDataAction }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = TitleMessageBox.FailureTitle, Message = Message.FailureDataAction }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult SaveDanhMucLoaiTroCap(int Key, string Ten, string DienGiai, string GhiChu)
        {
            try
            {
                var row = _db.LoaiTroCaps.FirstOrDefault(r => r.LoaiTroCapKey == Key);
                if (row == null)
                {
                    row = new Models.LoaiTroCap();
                    row.LoaiTroCapAlternateKey = Key.ToString();
                    _db.LoaiTroCaps.Add(row);
                }
                row.Ten = Ten;
                row.DienGiai = DienGiai;
                row.GhiChu = GhiChu;

                _db.SaveChanges();

                return Json(new { Result = true, Title = TitleMessageBox.SuccessTitle, Message = Message.SuccessDataAction }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = TitleMessageBox.FailureTitle, Message = Message.FailureDataAction }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region Danh mục Phòng ban
        public ActionResult DanhMucPhongBan()
        {
            return View();
        }
        public JsonResult GetDanhMucPhongBan()
        {
            var rs = _db.PhongBans.Select(r => new { Key = r.PhongBanKey, r.Ten, r.DienGiai });
            return Json(rs, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteDanhMucPhongBan(int Key)
        {
            try
            {
                var row = _db.PhongBans.FirstOrDefault(r => r.PhongBanKey == Key);
                if (row != null)
                {
                    _db.PhongBans.Remove(row);
                    _db.SaveChanges();
                }

                return Json(new { Result = true, Title = TitleMessageBox.SuccessTitle, Message = Message.SuccessDataAction }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = TitleMessageBox.FailureTitle, Message = Message.FailureDataAction }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult SaveDanhMucPhongBan(int Key, string Ten, string DienGiai)
        {
            try
            {
                var row = _db.PhongBans.FirstOrDefault(r => r.PhongBanKey == Key);
                if (row == null)
                {
                    row = new Models.PhongBan();
                    row.PhongBanAlternateKey = Key.ToString();
                    _db.PhongBans.Add(row);
                }
                row.Ten = Ten;
                row.DienGiai = DienGiai;

                _db.SaveChanges();

                return Json(new { Result = true, Title = TitleMessageBox.SuccessTitle, Message = Message.SuccessDataAction }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = TitleMessageBox.FailureTitle, Message = Message.FailureDataAction }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Danh mục Vị trí
        public ActionResult DanhMucViTri()
        {
            return View();
        }
        public JsonResult GetDanhMucDanhMucViTri()
        {
            var rs = _db.DanhMucViTris.Select(r => new { Key = r.DanhMucViTriKey, r.Ten, r.DienGiai });
            return Json(rs, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteDanhMucDanhMucViTri(int Key)
        {
            try
            {
                var row = _db.DanhMucViTris.FirstOrDefault(r => r.DanhMucViTriKey == Key);
                if (row != null)
                {
                    _db.DanhMucViTris.Remove(row);
                    _db.SaveChanges();
                }

                return Json(new { Result = true, Title = TitleMessageBox.SuccessTitle, Message = Message.SuccessDataAction }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = TitleMessageBox.FailureTitle, Message = Message.FailureDataAction }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult SaveDanhMucDanhMucViTri(int Key, string Ten, string DienGiai)
        {
            try
            {
                var row = _db.DanhMucViTris.FirstOrDefault(r => r.DanhMucViTriKey == Key);
                if (row == null)
                {
                    row = new Models.DanhMucViTri();
                    row.DanhMucViTriAlternateKey = Key.ToString();
                    _db.DanhMucViTris.Add(row);
                }
                row.Ten = Ten;
                row.DienGiai = DienGiai;

                _db.SaveChanges();

                return Json(new { Result = true, Title = TitleMessageBox.SuccessTitle, Message = Message.SuccessDataAction }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = TitleMessageBox.FailureTitle, Message = Message.FailureDataAction }, JsonRequestBehavior.AllowGet);
            }
        } 
        #endregion
    }
}
