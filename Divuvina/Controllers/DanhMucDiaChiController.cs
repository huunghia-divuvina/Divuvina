using Divuvina.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Divuvina.Controllers
{
    public class DanhMucDiaChiController : Controller
    {
        Models.dbContext _db = new Models.dbContext();

        #region Loại Địa Chỉ
        public ActionResult DanhMucLoaiDiaChi()
        {
            return View();
        }
        public JsonResult GetDataDanhMucLoaiDiaChi()
        {
            var rs = _db.LoaiDiaChis.Select(r => new { Key = r.LoaiDiaChiKey, r.TenCoDau, r.GhiChu });
            return Json(rs, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteDanhMucLoaiDiaChi(int Key)
        {
            try
            {
                var row = _db.LoaiDiaChis.FirstOrDefault(r => r.LoaiDiaChiKey == Key);
                if (row != null)
                {
                    _db.LoaiDiaChis.Remove(row);
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
        public ActionResult SaveDanhMucLoaiDiaChi(int Key, string Ten, string GhiChu)
        {
            try
            {
                var row = _db.LoaiDiaChis.FirstOrDefault(r => r.LoaiDiaChiKey == Key);
                if (row == null)
                {
                    row = new Models.LoaiDiaChi();
                    row.LoaiDiaChiAlternateKey = Key.ToString();
                    _db.LoaiDiaChis.Add(row);
                }
                row.TenCoDau = Ten;
                row.TenKhongDau = Ten;
                row.GhiChu = GhiChu;

                _db.SaveChanges();

                return Json(new { Result = true, Title = TitleMessageBox.SuccessTitle, Message = Message.SuccessDataAction }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = TitleMessageBox.FailureTitle, Message = Message.FailureDataAction }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion Loại Địa Chỉ

        #region Danh mục Đường
        public ActionResult DanhMucDuong()
        {
            return View();
        }

        public JsonResult GetDataDanhMucDuong()
        {
            var rs = _db.Duongs.Select(r => new { Key = r.DuongKey, r.TenCoDau, r.GhiChu });
            return Json(rs, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteDanhMucDuong(int Key)
        {
            try
            {
                var row = _db.Duongs.FirstOrDefault(r => r.DuongKey == Key);
                if (row != null)
                {
                    _db.Duongs.Remove(row);
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
        public ActionResult SaveDanhMucDuong(int Key, string Ten, string GhiChu)
        {
            try
            {
                var row = _db.Duongs.FirstOrDefault(r => r.DuongKey == Key);
                if (row == null)
                {
                    row = new Models.Duong();
                    row.DuongAlternateKey = Key.ToString();
                    _db.Duongs.Add(row);
                }
                row.TenCoDau = Ten;
                row.TenKhongDau = Ten;
                row.GhiChu = GhiChu;

                _db.SaveChanges();

                return Json(new { Result = true, Title = TitleMessageBox.SuccessTitle, Message = Message.SuccessDataAction }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = TitleMessageBox.FailureTitle, Message = Message.FailureDataAction }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion Danh mục Đường

        #region Danh mục Phường Xã
        public ActionResult DanhMucPhuongXa()
        {
            return View();
        }

        public JsonResult GetDataDanhMucPhuongXa()
        {
            var rs = _db.PhuongXas.Select(r => new { Key = r.PhuongXaKey, r.TenCoDau, r.GhiChu });
            return Json(rs, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteDanhMucPhuongXa(int Key)
        {
            try
            {
                var row = _db.PhuongXas.FirstOrDefault(r => r.PhuongXaKey == Key);
                if (row != null)
                {
                    _db.PhuongXas.Remove(row);
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
        public ActionResult SaveDanhMucPhuongXa(int Key, string Ten, string GhiChu)
        {
            try
            {
                var row = _db.PhuongXas.FirstOrDefault(r => r.PhuongXaKey == Key);
                if (row == null)
                {
                    row = new Models.PhuongXa();
                    row.PhuongXaAlternateKey = Key.ToString();
                    _db.PhuongXas.Add(row);
                }
                row.TenCoDau = Ten;
                row.TenKhongDau = Ten;
                row.GhiChu = GhiChu;

                _db.SaveChanges();

                return Json(new { Result = true, Title = TitleMessageBox.SuccessTitle, Message = Message.SuccessDataAction }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = TitleMessageBox.FailureTitle, Message = Message.FailureDataAction }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion Danh mục Phường Xã

        #region Danh mục Quận Huyện
        public ActionResult DanhMucQuanHuyen()
        {
            return View();
        }

        public JsonResult GetDataDanhMucQuanHuyen()
        {
            var rs = _db.QuanHuyens.Select(r => new { Key = r.QuanHuyenKey, r.TenCoDau, r.GhiChu });
            return Json(rs, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteDanhMucQuanHuyen(int Key)
        {
            try
            {
                var row = _db.QuanHuyens.FirstOrDefault(r => r.QuanHuyenKey == Key);
                if (row != null)
                {
                    _db.QuanHuyens.Remove(row);
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
        public ActionResult SaveDanhMucQuanHuyen(int Key, string Ten, string GhiChu)
        {
            try
            {
                var row = _db.QuanHuyens.FirstOrDefault(r => r.QuanHuyenKey == Key);
                if (row == null)
                {
                    row = new Models.QuanHuyen();
                    row.QuanHuyenAlternateKey = Key.ToString();
                    _db.QuanHuyens.Add(row);
                }
                row.TenCoDau = Ten;
                row.TenKhongDau = Ten;
                row.GhiChu = GhiChu;

                _db.SaveChanges();

                return Json(new { Result = true, Title = TitleMessageBox.SuccessTitle, Message = Message.SuccessDataAction }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = TitleMessageBox.FailureTitle, Message = Message.FailureDataAction }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion Danh mục Quận Huyện

        #region Danh mục Tỉnh Thành
        public ActionResult DanhMucTinhThanh()
        {
            return View();
        }

        public JsonResult GetDataDanhMucTinhThanh()
        {
            var rs = _db.TinhThanhs.Select(r => new { Key = r.TinhThanhKey, r.TenCoDau, r.GhiChu });
            return Json(rs, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteDanhMucTinhThanh(int Key)
        {
            try
            {
                var row = _db.TinhThanhs.FirstOrDefault(r => r.TinhThanhKey == Key);
                if (row != null)
                {
                    _db.TinhThanhs.Remove(row);
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
        public ActionResult SaveDanhMucTinhThanh(int Key, string Ten, string GhiChu)
        {
            try
            {
                var row = _db.TinhThanhs.FirstOrDefault(r => r.TinhThanhKey == Key);
                if (row == null)
                {
                    row = new Models.TinhThanh();
                    row.TinhThanhAlternateKey = Key.ToString();
                    _db.TinhThanhs.Add(row);
                }
                row.TenCoDau = Ten;
                row.TenKhongDau = Ten;
                row.GhiChu = GhiChu;

                _db.SaveChanges();

                return Json(new { Result = true, Title = TitleMessageBox.SuccessTitle, Message = Message.SuccessDataAction }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = TitleMessageBox.FailureTitle, Message = Message.FailureDataAction }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion Danh mục Tỉnh Thành

        #region Danh mục Quốc Gia
        public ActionResult DanhMucQuocGia()
        {
            return View();
        }

        public JsonResult GetDataDanhMucQuocGia()
        {
            var rs = _db.QuocGias.Select(r => new { Key = r.QuocGiaKey, r.TenCoDau, r.TenKhongDau, r.CountryCode, r.GhiChu });//, r.Culture
            return Json(rs, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteDanhMucQuocGia(int Key)
        {
            try
            {
                var row = _db.QuocGias.FirstOrDefault(r => r.QuocGiaKey == Key);
                if (row != null)
                {
                    _db.QuocGias.Remove(row);
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
        public ActionResult SaveDanhMucQuocGia(int Key, string TenCoDau, string TenKhongDau, string CountryCode, string GhiChu)//, byte[] Culture
        {
            try
            {
                var row = _db.QuocGias.FirstOrDefault(r => r.QuocGiaKey == Key);
                if (row == null)
                {
                    row = new Models.QuocGia();
                    row.QuocGiaAlternateKey = Key.ToString();
                    _db.QuocGias.Add(row);
                }
                row.TenCoDau = TenCoDau;
                row.TenKhongDau = TenKhongDau;
                row.CountryCode = CountryCode;
                //row.Culture = Culture;
                row.GhiChu = GhiChu;

                _db.SaveChanges();

                return Json(new { Result = true, Title = TitleMessageBox.SuccessTitle, Message = Message.SuccessDataAction }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = TitleMessageBox.FailureTitle, Message = Message.FailureDataAction }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion Danh mục Quốc Gia
    }
}