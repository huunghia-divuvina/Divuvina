using Divuvina.Public;
using Divuvina.Models.QuanLyXe;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Divuvina.Controllers
{
    public class QuanLyXeController : Controller
    {
        Models.dbContext _db = new Models.dbContext();
        public ThongTinXeVaKhauHaoModel _ThongTinXeVaKhauHaoModel;
        //==================================================================Starts Defining View Functions.
        // GET: QuanLyXe
        public ActionResult Index()
        {
            _ThongTinXeVaKhauHaoModel = new ThongTinXeVaKhauHaoModel();
            _ThongTinXeVaKhauHaoModel.BangSoXe = string.Empty;
            _ThongTinXeVaKhauHaoModel.CoCameraHanhTrinh = false;
            _ThongTinXeVaKhauHaoModel.CoTivi = false;
            _ThongTinXeVaKhauHaoModel.CoWifi = false;
            _ThongTinXeVaKhauHaoModel.GhiChuKhauHaoXe = string.Empty;
            _ThongTinXeVaKhauHaoModel.GhiChuThongTinXe = string.Empty;
            _ThongTinXeVaKhauHaoModel.GiaMua = 0;
            _ThongTinXeVaKhauHaoModel.LoaiXeKey = 0;
            _ThongTinXeVaKhauHaoModel.Mau = string.Empty;
            _ThongTinXeVaKhauHaoModel.NgayBatDauKhauHao = DateTime.Today;
            _ThongTinXeVaKhauHaoModel.NgayCapPhep = DateTime.Today;
            _ThongTinXeVaKhauHaoModel.NgayKetThucKhauHao = DateTime.Today.AddMonths(12);
            _ThongTinXeVaKhauHaoModel.SoSan = string.Empty;
            _ThongTinXeVaKhauHaoModel.SoThangKhauHao = 12;
            _ThongTinXeVaKhauHaoModel.TienKhauHaoHangThang = 0;
            _ThongTinXeVaKhauHaoModel.TongTienKhauHao = 0;
            return View(_ThongTinXeVaKhauHaoModel);
        }

        #region Nhập thông tin xe.
        public ActionResult NhapThongTinXe()
        {

            return View();
        }

        #endregion Nhập thông tin xe.

        #region Bảo trì sửa chữa xe
        public ActionResult BaoTriSuaChuaXe()
        {
            return View();
        }

        public JsonResult LayDanhMucXe()
        {
            var rs = _db.Xes.Select(r => new { id = r.XeKey, text = r.BangSoXe });
            return Json(rs, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LayLichBaoTri(string XeKey)
        {
            if (XeKey == null)
                XeKey = "-1";
            var rs = _db.LichBaoTriXes
                .Where(r => r.XeKey.ToString() == XeKey)
                .Select(r => new { Key = r.LichBaoTriXeKey, r.Xe.BangSoXe, r.Xe.SoSan, r.NgaySapLich });

            return Json(rs, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LayLichBaoTriChiTiet(string LbtctKey)
        {
            if (LbtctKey == null)
                LbtctKey = "-1";

            var rs = _db.LichBaoTriXeChiTiets
                .Where(r => r.LichBaoTriXeKey.ToString() == LbtctKey)
                .Select(r => new { Key = r.LichBaoTriXeChiTietKey, r.ThietBiLinhKien.Ten, r.SoLuong, r.TongTien });

            return Json(rs, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LayThietBiLinhKien()
        {
            var rs = _db.ThietBiLinhKiens
                .Select(r => new { id = r.ThietBiLinhKienKey, text = r.Ten });

            return Json(rs, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ThemLichBaoTriSuaChuaChiTiet(string LscbtKey, string TblkKey, decimal SoLuong, decimal TongTien)
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


    }//EndClass
}//EndNamespace