using Divuvina.Public;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Divuvina.Controllers
{
    public class DanhMucXeController : Controller
    {
        Models.dbContext _db = new Models.dbContext();

        // GET: QuanLyXe
        public ActionResult Index()
        {
            return View();
        }

        #region Bảo trì sửa chữa xe
        public ActionResult BaoTriSuaChuaXe()
        {
            return View();
        }

        public JsonResult GetDanhMucXe()
        {
            var rs = _db.Xes.Select(r => new { id = r.XeKey, text = r.BangSoXe });
            return Json(rs, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLichBaoTri(string XeKey)
        {
            if (XeKey == null)
                XeKey = "-1";
            var rs = _db.LichBaoTriXes
                .Where(r => r.XeKey.ToString() == XeKey)
                .Select(r => new { Key = r.LichBaoTriXeKey, r.Xe.BangSoXe, r.Xe.SoSan, r.NgaySapLich });

            return Json(rs, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLichBaoTriChiTiet(string LbtctKey)
        {
            if (LbtctKey == null)
                LbtctKey = "-1";

            var rs = _db.LichBaoTriXeChiTiets
                .Where(r => r.LichBaoTriXeKey.ToString() == LbtctKey)
                .Select(r => new { Key = r.LichBaoTriXeChiTietKey, r.ThietBiLinhKien.Ten, r.SoLuong, r.TongTien });

            return Json(rs, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetThietBiLinhKien()
        {
            var rs = _db.ThietBiLinhKiens
                .Select(r => new { id = r.ThietBiLinhKienKey, text = r.Ten });

            return Json(rs, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddLbtscct(string LscbtKey, string TblkKey, decimal SoLuong, decimal TongTien)
        {
            try
            {
                var row = new Models.LichBaoTriXeChiTiet();
                row.LichBaoTriXeKey = Convert.ToInt32(LscbtKey);
                row.ThietBiLinhKienKey = Convert.ToInt32(TblkKey);
                row.SoLuong = SoLuong;
                row.TongTien = TongTien;
                _db.LichBaoTriXeChiTiets.Add(row);

                _db.SaveChanges();

                return Json(new { Result = true, Title = TitleMessageBox.Notification, Message = Message.SuccessfulDataAction }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = TitleMessageBox.Notification, Message = Message.UnsuccessfulDataAction }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region DanhMucLoaiXe
        public ActionResult DanhMucLoaiXe()
        {
            return View();
        }

        public JsonResult GetDataDanhMucLoaiXe()//(string LoaiXeKey)
        {
            //if (LoaiXeKey == null)
            //    LoaiXeKey = "-1";
            var rs = _db.LoaiXes
                //.Where(r => r.LoaiXeKey.ToString() == LoaiXeKey)
                .Select(r => new { Key = r.LoaiXeKey, r.Ten, r.MoTa, r.HangSanXuat, r.Model,
                    r.MayChayDau, r.MayChayXang, r.SoGhe,
                    LoaiGhe = r.LoaiGhe.Ten ,
                    r.GhiChu });

            return Json(rs, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteDanhMucLoaiXe(int Key)
        {
            try
            {
                var row = _db.LoaiXes.FirstOrDefault(r => r.LoaiXeKey == Key);
                if (row != null)
                {
                    _db.LoaiXes.Remove(row);
                    _db.SaveChanges();
                }

                return Json(new { Result = true, Title = TitleMessageBox.Notification, Message = Message.SuccessfulDataAction }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = TitleMessageBox.Notification, Message = Message.UnsuccessfulDataAction}, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult SaveDanhMucLoaiXe(int Key, string Ten, string MoTa, string HangSanXuat, string Model
            , bool MayChayDau
            , bool MayChayXang
            , short SoGhe
            , short LoaiGheKey
            , string GhiChu)
        {
            try
            {
                var row = _db.LoaiXes.FirstOrDefault(r => r.LoaiXeKey == Key);
                if (row == null)
                {
                    row = new Models.LoaiXe();
                    row.LoaiXeAlternateKey = Key.ToString();
                    _db.LoaiXes.Add(row);
                }
                row.Ten = Ten;
                row.MoTa = MoTa;
                row.HangSanXuat = HangSanXuat;
                row.Model = Model;
                row.MayChayDau = MayChayDau;
                row.MayChayXang = MayChayXang;
                row.SoGhe = SoGhe;
                row.LoaiGheKey = LoaiGheKey;
                row.GhiChu = GhiChu;

                _db.SaveChanges();

                return Json(new { Result = true, Title = TitleMessageBox.Notification, Message = Message.SuccessfulDataAction }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, Title = TitleMessageBox.Notification, Message = Message.UnsuccessfulDataAction }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetDanhMucLoaiGhe()
        {
            var listLoaiGhes = _db.LoaiGhes.Select(r => new { id = r.LoaiGheKey, text = r.Ten });
            return Json(listLoaiGhes, JsonRequestBehavior.AllowGet);
        }

        #endregion DanhMucLoaiXe

        #region DanhMucNoiSuaChuaXe
        public ActionResult DanhMucNoiSuaChuaXe()
        {
            return View();
        }

        public JsonResult GetDataDanhMucNoiSuaChuaXe()
        {
            var rs = _db.NoiSuaChuaXes.Select(r => new { Key = r.NoiSuaChuaXeKey, r.Ten, r.DiaChi, r.GhiChu });
            return Json(rs, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteDanhMucNoiSuaChuaXe(int Key)
        {
            try
            {
                var row = _db.NoiSuaChuaXes.FirstOrDefault(r => r.NoiSuaChuaXeKey == Key);
                if (row != null)
                {
                    _db.NoiSuaChuaXes.Remove(row);
                    _db.SaveChanges();
                }

                return Json(new { Result = true, Title = "Thông báo !", Message = "Thao tác dữ liệu thành công !" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = "Thông báo !", Message = "Thao tác dữ liệu không thành công !" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult SaveDanhMucNoiSuaChuaXe(int Key, string Ten, string DiaChi, string GhiChu)
        {
            try
            {
                var row = _db.NoiSuaChuaXes.FirstOrDefault(r => r.NoiSuaChuaXeKey == Key);
                if (row == null)
                {
                    row = new Models.NoiSuaChuaXe();
                    row.NoiSuaChuaXeAlternateKey = Key.ToString();
                    _db.NoiSuaChuaXes.Add(row);
                }
                row.Ten = Ten;
                row.DiaChi = DiaChi;
                row.GhiChu = GhiChu;

                _db.SaveChanges();

                return Json(new { Result = true, Title = TitleMessageBox.Notification, Message = Message.SuccessfulDataAction }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = TitleMessageBox.Notification, Message = Message.UnsuccessfulDataAction }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion DanhMucNoiSuaChuaXe

        #region DanhMucThietBiLinhKien
        public ActionResult DanhMucThietBiLinhKien()
        {
            return View();
        }

        public JsonResult GetDataDanhMucThietBiLinhKien()
        {
            var rs = _db.ThietBiLinhKiens.Select(r => new { Key = r.ThietBiLinhKienKey, r.Ten, r.HangSanXuat, r.DienGiai, r.GhiChu });
            return Json(rs, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteDanhMucThietBiLinhKien(int Key)
        {
            try
            {
                var row = _db.ThietBiLinhKiens.FirstOrDefault(r => r.ThietBiLinhKienKey == Key);
                if (row != null)
                {
                    _db.ThietBiLinhKiens.Remove(row);
                    _db.SaveChanges();
                }

                return Json(new { Result = true, Title = "Thông báo !", Message = "Thao tác dữ liệu thành công !" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = "Thông báo !", Message = "Thao tác dữ liệu không thành công !" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult SaveDanhMucThietBiLinhKien(int Key, string Ten, string HangSanXuat, string DienGiai, string GhiChu)
        {
            try
            {
                var row = _db.ThietBiLinhKiens.FirstOrDefault(r => r.ThietBiLinhKienKey == Key);
                if (row == null)
                {
                    row = new Models.ThietBiLinhKien();
                    row.ThietBiLinhKienAlternateKey = Key.ToString();
                    _db.ThietBiLinhKiens.Add(row);
                }
                row.Ten = Ten;
                row.HangSanXuat = HangSanXuat;
                row.DienGiai = DienGiai;
                row.GhiChu = GhiChu;

                _db.SaveChanges();

                return Json(new { Result = true, Title = TitleMessageBox.Notification, Message = Message.SuccessfulDataAction }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = TitleMessageBox.Notification, Message = Message.UnsuccessfulDataAction }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion DanhMucThietBiLinhKiend

        #region DanhMucChiPhi
        public ActionResult DanhMucChiPhi()
        {
            return View();
        }

        public JsonResult GetDataDanhMucChiPhi()
        {
            var rs = _db.DanhMucChiPhis.Select(r => new { Key = r.DanhMucChiPhiKey, r.DienGiai, r.GhiChu });
            return Json(rs, JsonRequestBehavior.AllowGet);
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
        public ActionResult SaveDanhMucChiPhi(int Key, string DienGiai, string GhiChu)
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
                row.DienGiai = DienGiai;
                row.GhiChu = GhiChu;

                _db.SaveChanges();

                return Json(new { Result = true, Title = TitleMessageBox.Notification, Message = Message.SuccessfulDataAction }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = TitleMessageBox.Notification, Message = Message.UnsuccessfulDataAction }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion DanhMucChiPhi
    }//EndClass
}//EndNamespace