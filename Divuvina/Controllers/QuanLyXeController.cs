using Divuvina.Public;
using Divuvina.Models.QuanLyXe;
using System;
using System.Linq;
using System.Web.Mvc;
using Divuvina.Business.DanhMuc;
using Divuvina.Models.Public;
using Divuvina.Business.QuanLyXe;
using System.Data.Entity.Core.Objects;
using System.Data;
using System.Data.SqlClient;
using Divuvina.Business.Exceptions;
using System.Xml;

namespace Divuvina.Controllers
{
    public class QuanLyXeController : Controller
    {
        Models.dbContext _db = new Models.dbContext();
        //Models.dbStoredProcedure _dbSp = new Models.dbStoredProcedure();
        public ThongTinXeVaKhauHaoModel _ThongTinXeVaKhauHaoModel = new ThongTinXeVaKhauHaoModel();
        public SapLichBaoTriXeModel _SapLichBaoTriXeModel;
        //==================================================================Starts Defining View Functions.
        // GET: QuanLyXe
        public ActionResult Index()
        {
            return View();
        }

        #region Nhập thông tin xe.
        public ActionResult NhapThongTinXe()
        {
            _ThongTinXeVaKhauHaoModel = new ThongTinXeVaKhauHaoModel();
            _ThongTinXeVaKhauHaoModel.XeKey = 0;
            _ThongTinXeVaKhauHaoModel.BangSoXe = string.Empty;
            _ThongTinXeVaKhauHaoModel.CoCameraHanhTrinh = true;
            _ThongTinXeVaKhauHaoModel.CoTivi = true;
            _ThongTinXeVaKhauHaoModel.CoWifi = true;
            _ThongTinXeVaKhauHaoModel.GhiChuKhauHaoXe = string.Empty;
            _ThongTinXeVaKhauHaoModel.GhiChuThongTinXe = string.Empty;
            _ThongTinXeVaKhauHaoModel.GiaMua = 0;
            _ThongTinXeVaKhauHaoModel.LoaiXeKey = 0;
            _ThongTinXeVaKhauHaoModel.HangSanXuatXeKey = 0;
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

        public JsonResult LayHangSanXuatXeChoSelect()
        {
            return Json(new DanhMucHangSanXuatXeBll().LayDanhMucHangSanXuatXe(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult LayLoaiXeChoSelect(short hangSanXuatXeKey)
        {
            return Json(new DanhMucLoaiXeBll().LayDanhMucLoaiXe(hangSanXuatXeKey), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult LuuThongTinXe(ThongTinXeVaKhauHaoModel thongTinXeVaKhauHaoModel)
        {
            var message = new RMessage { ErrorMessage = "Lưu thông tin xe không thành công.", Result = false };
            try
            {
                //if (ModelState.IsValid)
                {
                    //Kiểm tra thông tin đầu vào.
                    var keyHangSanXuatXe = Request.Form["KeyHangSanXuatXe"];
                    var keyLoaiXe = Request.Form["KeyLoaiXe"];
                    var xeKey = Request.Form["XeKey"];
                    var coWifi = Request.Form["hdCoWifi"];
                    var coTivi = Request.Form["hdCoTivi"];
                    var coCameraHanhTrinh = Request.Form["hdCoCameraHanhTrinh"];
                    if (String.IsNullOrEmpty(keyHangSanXuatXe) || String.IsNullOrEmpty(keyLoaiXe)
                        || String.IsNullOrEmpty(thongTinXeVaKhauHaoModel.BangSoXe) || String.IsNullOrEmpty(thongTinXeVaKhauHaoModel.SoSan))
                    {
                        return Json(new { Result = false, Message = Message.DataIsNullOrEmpty, Title = TitleMessageBox.ErrorTitle });
                    }
                    if (String.IsNullOrEmpty(xeKey)) xeKey = "0";
                    thongTinXeVaKhauHaoModel.HangSanXuatXeKey = DefaultValueWhenNull.ConvertShort(keyHangSanXuatXe);
                    thongTinXeVaKhauHaoModel.LoaiXeKey = int.Parse(keyLoaiXe);
                    thongTinXeVaKhauHaoModel.XeKey = int.Parse(xeKey);
                    if (coWifi.ToUpper().Equals("TRUE")) thongTinXeVaKhauHaoModel.CoWifi = true;
                    else thongTinXeVaKhauHaoModel.CoWifi = false;
                    if (coTivi.ToUpper().Equals("TRUE")) thongTinXeVaKhauHaoModel.CoTivi = true;
                    else thongTinXeVaKhauHaoModel.CoTivi = false;
                    if (coCameraHanhTrinh.ToUpper().Equals("TRUE")) thongTinXeVaKhauHaoModel.CoCameraHanhTrinh = true;
                    else thongTinXeVaKhauHaoModel.CoCameraHanhTrinh = false;

                    //Kiểm tra xe có tồn tại trong hệ thống hay chưa?
                    if (thongTinXeVaKhauHaoModel.XeKey <= 0)
                    {
                        var xeTonTai = _db.Xes.FirstOrDefault(r => r.BangSoXe == thongTinXeVaKhauHaoModel.BangSoXe && r.SoSan == thongTinXeVaKhauHaoModel.SoSan);
                        if (xeTonTai != null && xeTonTai.XeKey > 0)
                        {
                            return Json(new { Result = false, Message = "Xe này đã tồn tại trong hệ thống.", Title = TitleMessageBox.ErrorTitle });
                        }
                    }

                    if (thongTinXeVaKhauHaoModel.NgayBatDauKhauHao < thongTinXeVaKhauHaoModel.NgayCapPhep)
                    {
                        return Json(new { Result = false, Message = "Ngày bắt đầu khấu hao phải lớn hơn ngày cấp phép.", Title = TitleMessageBox.ErrorTitle });
                    }

                    if (thongTinXeVaKhauHaoModel.NgayBatDauKhauHao > thongTinXeVaKhauHaoModel.NgayKetThucKhauHao)
                    {
                        return Json(new { Result = false, Message = "Ngày kết thúc khấu hao phải lớn hơn ngày bắt đầu khấu hao.", Title = TitleMessageBox.ErrorTitle });
                    }

                    new ThongTinXeVaKhauHaoBll().LuuThongTinXeVaKhauHao(thongTinXeVaKhauHaoModel);
                    return Json(new { Result = true, Message = Message.SuccessDataAction, Title = TitleMessageBox.CompleteTitle });
                }
                //else { return Json(new { Result = false, Message = ".", Title = TitleMessageBox.ErrorTitle }); }
            }
            catch (Exception) { return Json(new { Result = false, Title = TitleMessageBox.FailureTitle, Message = Message.FailureDataAction }, JsonRequestBehavior.AllowGet); }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult XoaThongTinXeVaKhauHao(int xeKey)
        {
            try
            {
                new ThongTinXeVaKhauHaoBll().XoaThongTinXeVaKhauHao(xeKey);
                return Json(new { Result = true, Title = TitleMessageBox.SuccessTitle, Message = Message.SuccessDataAction }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = TitleMessageBox.FailureTitle, Message = Message.FailureDataAction }, JsonRequestBehavior.AllowGet);
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult LayThongTinXe()
        {
            return Json(new ThongTinXeVaKhauHaoBll().LayThongTinXeVaKhauHao(), JsonRequestBehavior.AllowGet);
        }
        #endregion Nhập thông tin xe.

        #region Bảo trì sửa chữa xe
        public ActionResult BaoTriSuaChuaXe()
        {
            return View();
        }
        
        public JsonResult LayDanhMucXe()
        {
            //SqlParameter param1 = new SqlParameter("@ThongTinXe", "");
            //var employee = _db.Database.SqlQuery<Models.sp_LayThongTinXe_Result>("[sp_LayThongTinXe] @ThongTinXe", new SqlParameter[] { param1 }).ToList();

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

                return Json(new { Result = true, Title = TitleMessageBox.SuccessTitle, Message = Message.SuccessDataAction }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = TitleMessageBox.FailureTitle, Message = Message.FailureDataAction }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Sắp lịch bảo trì xe.
        //public ActionResult SapLichBaoTriXe()
        //{
        //    _SapLichBaoTriXeModel = new SapLichBaoTriXeModel();
        //    _SapLichBaoTriXeModel.ThongTinTimKiemSapLichBaoTri = new SapLichBaoTriXe();
        //    _SapLichBaoTriXeModel.ThongTinTimKiemSapLichBaoTri.BangSoXe = string.Empty;
        //    _SapLichBaoTriXeModel.ThongTinTimKiemSapLichBaoTri.HangSanXuatXeKey = 0;
        //    _SapLichBaoTriXeModel.ThongTinTimKiemSapLichBaoTri.LoaiXeKey = 0;
        //    _SapLichBaoTriXeModel.ThongTinTimKiemSapLichBaoTri.NgayCapPhep = DateTime.Today;
        //    _SapLichBaoTriXeModel.ThongTinTimKiemSapLichBaoTri.SoSan = string.Empty;
        //    _SapLichBaoTriXeModel.ThongTinTimKiemSapLichBaoTri.XeKey = 0;
        //    _SapLichBaoTriXeModel.ThongTinTimKiemSapLichBaoTri.TimTheoNgayCapPhep = true;
        //    ViewBag.Title = "Sắp lịch bảo trì xe";
        //    return View(_SapLichBaoTriXeModel);
        //}
        public ActionResult SapLichBaoTriSuaChuaXe()
        {
            _SapLichBaoTriXeModel = new SapLichBaoTriXeModel();
            _SapLichBaoTriXeModel.ThongTinTimKiemSapLichBaoTri = new SapLichBaoTriXe();
            _SapLichBaoTriXeModel.ThongTinTimKiemSapLichBaoTri.BangSoXe = string.Empty;
            _SapLichBaoTriXeModel.ThongTinTimKiemSapLichBaoTri.HangSanXuatXeKey = 0;
            _SapLichBaoTriXeModel.ThongTinTimKiemSapLichBaoTri.LoaiXeKey = 0;
            _SapLichBaoTriXeModel.ThongTinTimKiemSapLichBaoTri.NgayCapPhep = DateTime.Today;
            _SapLichBaoTriXeModel.ThongTinTimKiemSapLichBaoTri.SoSan = string.Empty;
            _SapLichBaoTriXeModel.ThongTinTimKiemSapLichBaoTri.XeKey = 0;
            _SapLichBaoTriXeModel.ThongTinTimKiemSapLichBaoTri.TimTheoNgayCapPhep = true;

            _SapLichBaoTriXeModel.NoiSuaChuaXeKey = 0;
            _SapLichBaoTriXeModel.NgaySapLich = DateTime.Today;
            ViewBag.Title = "Sắp lịch bảo trì xe";
            return View(_SapLichBaoTriXeModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult GetThongTinXeChuaSapLich(SapLichBaoTriXeModel model)
        {
            var message = new RMessage { ErrorMessage = "Tìm thông tin xe chưa sắp lịch sửa chữa không thành công.", Result = false };
            try
            {
                return Json(new SapLichBaoTriXeBll().GetThongTinXeChuaSapLich(model), JsonRequestBehavior.AllowGet);
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

        [AcceptVerbs(HttpVerbs.Post)]
        //public JsonResult SaveThongTinSapLichBaoTri(SapLichBaoTriXeModel model
        public JsonResult SaveThongTinSapLichBaoTri(int noiSuaChuaXeKey, DateTime ngaySapLich, string ghiChu
            , Models.sp_LayThongTinXeChuaSapLich_Result[] listThongTinXeChuaSapLich
            , Models.sp_LayThongTinXeChuaSapLich_Result[] listThongTinXeChoSapLich)
        {
            var message = new RMessage { ErrorMessage = "Lưu thông tin sắp lịch sửa chữa bảo trì xe thành công.", Result = true };
            try
            {
                // Tạo XML danh sách xe chờ sắp lịch.
                //---------------------------
                var docListXeSapLich = new XmlDocument();

                var DanhSachXe = docListXeSapLich.CreateElement("DanhSachXe");
                docListXeSapLich.AppendChild(DanhSachXe);
                foreach (var xeChoSapLich in listThongTinXeChoSapLich)
                {

                    var row = docListXeSapLich.CreateElement("Row");
                    DanhSachXe.AppendChild(row);

                    var xeKey = docListXeSapLich.CreateElement("XeKey");
                    xeKey.InnerText = xeChoSapLich.XeKey.ToString();
                    row.AppendChild(xeKey);

                }
                //---------------------------
                string listXeKeyFailed = string.Empty;
                var nhanVienSapLichKey = 1;
                var resultSapLichBaoTriXe = new SapLichBaoTriXeBll().LuuThongTinSapLichBaoTriXe(docListXeSapLich.InnerXml, noiSuaChuaXeKey
                    , ngaySapLich, nhanVienSapLichKey, ghiChu,ref listXeKeyFailed);
                
                if(!resultSapLichBaoTriXe)
                {
                    message = new RMessage { ErrorMessage = "Lưu thông tin sắp lịch sửa chữa bảo trì xe không thành công.", Result = false };
                }

                return Json(message, JsonRequestBehavior.AllowGet);
            }
            catch(BusinessException ex)
            {
                message.Result = false;
                message.MessageId = ex.getExceptionId();
                message.SystemMessage = ex.ToString();
                ViewData["RMessage"] = message;
                return Json(message, JsonRequestBehavior.AllowGet);
            }
        }//EndFunction

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult LayNoiSuaChuaXeChoSelect()
        {
            return Json(new NoiSuaChuaXeBll().LayNoiSuaChuaXeChoSelect(), JsonRequestBehavior.AllowGet);
        }
        #endregion Sắp lịch bảo trì xe.
    }//EndClass
}//EndNamespaced