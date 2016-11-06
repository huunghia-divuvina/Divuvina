using Divuvina.Public;
using Divuvina.Models.QuanLyXe;
using System;
using System.Linq;
using System.Web.Mvc;
using Divuvina.Business.DanhMuc;
using Divuvina.Models.Public;

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
            //Kiểm tra thông tin đầu vào.
            var keyHangSanXuatXe = Request.Form["KeyHangSanXuatXe"];
            var keyLoaiXe = Request.Form["KeyLoaiXe"];
            var xeKey = Request.Form["XeKey"];
            if (String.IsNullOrEmpty(keyHangSanXuatXe) || String.IsNullOrEmpty(keyLoaiXe)
                || String.IsNullOrEmpty(thongTinXeVaKhauHaoModel.BangSoXe) || String.IsNullOrEmpty(thongTinXeVaKhauHaoModel.SoSan))
            {
                return Json(new { Result = false, Message = Message.DataIsNullOrEmpty, Title = TitleMessageBox.ErrorTitle });
            }
            if (String.IsNullOrEmpty(xeKey)) xeKey = "0";
            thongTinXeVaKhauHaoModel.HangSanXuatXeKey = int.Parse(keyHangSanXuatXe);
            thongTinXeVaKhauHaoModel.LoaiXeKey = int.Parse(keyLoaiXe);
            thongTinXeVaKhauHaoModel.XeKey = int.Parse(xeKey);

            if (thongTinXeVaKhauHaoModel.NgayBatDauKhauHao < thongTinXeVaKhauHaoModel.NgayCapPhep)
            {
                return Json(new { Result = false, Message = "Ngày bắt đầu khấu hao phải lớn hơn ngày cấp phép.", Title = TitleMessageBox.ErrorTitle });
            }

            if (thongTinXeVaKhauHaoModel.NgayBatDauKhauHao > thongTinXeVaKhauHaoModel.NgayKetThucKhauHao)
            {
                return Json(new { Result = false, Message = "Ngày kết thúc khấu hao phải lớn hơn ngày bắt đầu khấu hao.", Title = TitleMessageBox.ErrorTitle });
            }

            //Kiểm tra xe có tồn tại trong hệ thống hay chưa?
            var xeTonTai = _db.Xes.FirstOrDefault(r => r.BangSoXe == thongTinXeVaKhauHaoModel.BangSoXe && r.SoSan == thongTinXeVaKhauHaoModel.SoSan);
            if(xeTonTai != null && xeTonTai.XeKey > 0)
            {
                return Json(new { Result = false, Message = "Xe này đã tồn tại trong hệ thống.", Title = TitleMessageBox.ErrorTitle });
            }

            //Kiểm tra thêm mới hay chỉnh sửa.
            var row = _db.Xes.FirstOrDefault(r => r.XeKey == thongTinXeVaKhauHaoModel.XeKey);
            if (row == null)
            {
                row = new Models.Xe();
                row.XeAlternateKey = thongTinXeVaKhauHaoModel.XeKey.ToString();
                _db.Xes.Add(row);
            }
            row.BangSoXe = thongTinXeVaKhauHaoModel.BangSoXe;
            row.CoCameraHanhTrinh = thongTinXeVaKhauHaoModel.CoCameraHanhTrinh;
            row.CoTivi = thongTinXeVaKhauHaoModel.CoTivi;
            row.CoWifi = thongTinXeVaKhauHaoModel.CoWifi;
            row.GhiChu = thongTinXeVaKhauHaoModel.GhiChuThongTinXe;
            row.GiaMua = thongTinXeVaKhauHaoModel.GiaMua;
            row.LoaiXeKey = thongTinXeVaKhauHaoModel.LoaiXeKey;
            row.Mau = thongTinXeVaKhauHaoModel.Mau;
            row.NgayCapPhep = thongTinXeVaKhauHaoModel.NgayCapPhep;
            row.SoSan = thongTinXeVaKhauHaoModel.SoSan;
            _db.SaveChanges();

            var dongMoiThem = _db.Xes.FirstOrDefault(r => r.BangSoXe == thongTinXeVaKhauHaoModel.BangSoXe && r.SoSan == thongTinXeVaKhauHaoModel.SoSan);
            if(dongMoiThem != null && dongMoiThem.XeKey > 0)
            {
                var dongKhauHao = _db.KhauHaos.FirstOrDefault(r => r.XeKey == dongMoiThem.XeKey );
                if(dongKhauHao == null)
                {
                    dongKhauHao = new Models.KhauHao();
                    dongKhauHao.KhauHaoAlternateKey = dongKhauHao.KhauHaoKey.ToString();
                    _db.KhauHaos.Add(dongKhauHao);
                }
                dongKhauHao.GhiChu = thongTinXeVaKhauHaoModel.GhiChuKhauHaoXe;
                dongKhauHao.NgayBatDauKhauHao = thongTinXeVaKhauHaoModel.NgayBatDauKhauHao;
                dongKhauHao.NgayKetThucKhauHao = thongTinXeVaKhauHaoModel.NgayKetThucKhauHao;
                dongKhauHao.SoThangKhauHao = thongTinXeVaKhauHaoModel.SoThangKhauHao;
                dongKhauHao.TienKhauHaoHangThang = thongTinXeVaKhauHaoModel.TienKhauHaoHangThang;
                dongKhauHao.TongTienKhauHoa = thongTinXeVaKhauHaoModel.TongTienKhauHao;
                dongKhauHao.XeKey = dongMoiThem.XeKey;
                _db.SaveChanges();
            }

            return Json(new { Result = true, Message = Message.SuccessDataAction, Title = TitleMessageBox.CompleteTitle });
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

                return Json(new { Result = true, Title = TitleMessageBox.SuccessTitle, Message = Message.SuccessDataAction }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Result = false, Title = TitleMessageBox.FailureTitle, Message = Message.FailureDataAction }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion


    }//EndClass
}//EndNamespace