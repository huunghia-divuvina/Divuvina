using System;
using System.Collections.Generic;
using Divuvina.Models;
using Divuvina.Models.QuanLyXe;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using Divuvina.Business.Exceptions;
using Divuvina.Models.Public;

namespace Divuvina.Business.QuanLyXe
{
    public class SapLichBaoTriXeBll
    {
        Models.Entities _dbSp = new Models.Entities();
        Models.dbContext _db = new Models.dbContext();
        public string ThongBaoLoi { get; set; }

        #region Sắp lịch bảo trì xe
        public List<object> LayThongTinXe(string thongTinXe)
        {
            try
            {
                if (!String.IsNullOrEmpty(thongTinXe))
                {
                    //var ss = _dbSp.sp_LayThongTinXe(thongTinXe);

                    //var listThongTinXe = _db.Xes
                    //    .Where(xe => xe.BangSoXe.Contains(thongTinXe) || xe.SoSan.Contains(thongTinXe)
                    //    || xe.Mau.Contains(thongTinXe) || xe.GhiChu.Contains(thongTinXe))
                    //    .Select(xe => new { xe.XeKey, xe.BangSoXe, xe.SoSan, xe.NgayCapPhep, xe.Mau, xe.GiaMua, xe.CoCameraHanhTrinh, xe.CoTivi, xe.CoWifi, xe.GhiChu });
                    //var listThongTinXe = _db.Database.s
                    //return listThongTinXe.ToList(Object);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }//EndFunction

        public List<Models.sp_LayThongTinXeChuaSapLich_Result> GetThongTinXeChuaSapLich(SapLichBaoTriXeModel model)
        {
            try
            {
                if (model != null && model.ThongTinTimKiemSapLichBaoTri != null)//ModelState.IsValid && 
                {
                    var thongTinTimKiemSapLichBaoTri = model.ThongTinTimKiemSapLichBaoTri;

                    #region Cách 1: Bị hạn chế khi truyền tham số phải chuyển sang kiểu string.
                    //string storeParam = String.Format("[dbo].[sp_LayThongTinXeChuaSapLich] @HangSanXuatXeKey = {0}, @LoaiXeKey = {1}, @BangSoXe = N'{2}', @SoSan = N'{3}', @NgayCapPhep = {4}",
                    //    thongTinTimKiemSapLichBaoTri.HangSanXuatXeKey.ToString(),
                    //    thongTinTimKiemSapLichBaoTri.LoaiXeKey.ToString(),
                    //    thongTinTimKiemSapLichBaoTri.BangSoXe,
                    //    thongTinTimKiemSapLichBaoTri.SoSan,
                    //    thongTinTimKiemSapLichBaoTri.NgayCapPhep);
                    //thongTinTimKiemSapLichBaoTri.NgayCapPhep.ToString("yyyy/MM/dd"));
                    //model.ListXeChuaSapLich = _db.Database.SqlQuery<Models.sp_LayThongTinXeChuaSapLich_Result>(storeParam).ToList();
                    #endregion Cách 1: Bị hạn chế khi truyền tham số phải chuyển sang kiểu string.

                    string store = "[dbo].[sp_LayThongTinXeChuaSapLich] @HangSanXuatXeKey, @LoaiXeKey, @BangSoXe, @SoSan, @NgayCapPhep";

                    var ngayCapPhep = new SqlParameter { ParameterName = "NgayCapPhep", SqlDbType = SqlDbType.DateTime, Value = thongTinTimKiemSapLichBaoTri.NgayCapPhep };
                    if (!thongTinTimKiemSapLichBaoTri.TimTheoNgayCapPhep) ngayCapPhep = new SqlParameter { ParameterName = "NgayCapPhep", SqlDbType = SqlDbType.DateTime, Value = DBNull.Value };

                    var sqlParams = new SqlParameter[] {
                        new SqlParameter { ParameterName = "HangSanXuatXeKey", SqlDbType = SqlDbType.Int, Value = thongTinTimKiemSapLichBaoTri.HangSanXuatXeKey },
                        new SqlParameter { ParameterName = "LoaiXeKey", SqlDbType = SqlDbType.Int, Value = thongTinTimKiemSapLichBaoTri.LoaiXeKey },
                        new SqlParameter { ParameterName = "BangSoXe", SqlDbType = SqlDbType.VarChar, Value = (thongTinTimKiemSapLichBaoTri.BangSoXe == null ? string.Empty : thongTinTimKiemSapLichBaoTri.BangSoXe) },
                        new SqlParameter { ParameterName = "SoSan", SqlDbType = SqlDbType.VarChar, Value = (thongTinTimKiemSapLichBaoTri.SoSan == null ? string.Empty : thongTinTimKiemSapLichBaoTri.SoSan)},
                        ngayCapPhep
                    };
                    return _db.Database.SqlQuery<Models.sp_LayThongTinXeChuaSapLich_Result>(store, sqlParams).ToList();
                }
                return null;
            }
            catch (BusinessException ex)
            {
                throw (ex);
            }
        }
        
        public List<Models.sp_LayThongTinXeDaSapLich_Result> GetThongTinXeDaSapLich()
        {
            string store = "[dbo].[sp_LayThongTinXeDaSapLich]";
            return _db.Database.SqlQuery<Models.sp_LayThongTinXeDaSapLich_Result>(store).ToList();
        }

        public bool LuuThongTinSapLichBaoTriXe(string listXeKeyXML, int noiSuaChuaXeKey, DateTime ngaySapLich
            , int nhanVienSapLichKey, string ghiChu, ref string listXeKeyFailed)
        {
            listXeKeyFailed = string.Empty;
            #region Kiểm tra dữ liệu.
            if (string.IsNullOrEmpty(listXeKeyXML))
            {
                ThongBaoLoi = "Danh sách xe sắp lịch không hợp lệ.";
                return false;
            }
            if(noiSuaChuaXeKey <= 0)
            {
                ThongBaoLoi = "Nơi sửa chữa không hợp lệ.";
                return false;
            }
            if (ngaySapLich < DateTime.Today)
            {
                ThongBaoLoi = "Ngày sắp lịch không hợp lệ.";
                return false;
            }
            //if (nhanVienSapLichKey <= 0)
            //{
            //    ThongBaoLoi = "Nhân viên sắp lịch không hợp lệ.";
            //    return false;
            //}
            #endregion Kiểm tra dữ liệu.
            try
            {
                string store = "[dbo].[sp_LuuThongTinSapLichBaoTriXe] @ListXeKeyXML, @NoiSuaChuaXeKey, @NgaySapLich, @NhanVienSapLichKey, @GhiChu, @ListXeKeyFailed OUT";

                var ParListXeKeyFailed = new SqlParameter();
                ParListXeKeyFailed.ParameterName = "@ListXeKeyFailed";
                ParListXeKeyFailed.Direction = ParameterDirection.Output;
                ParListXeKeyFailed.SqlDbType = SqlDbType.VarChar;

                var sqlParams = new SqlParameter[] {
                        new SqlParameter { ParameterName = "ListXeKeyXML", SqlDbType = SqlDbType.Xml, Value = listXeKeyXML },
                        new SqlParameter { ParameterName = "NoiSuaChuaXeKey", SqlDbType = SqlDbType.Int, Value = noiSuaChuaXeKey },
                        new SqlParameter { ParameterName = "NgaySapLich", SqlDbType = SqlDbType.DateTime, Value = ngaySapLich },
                        new SqlParameter { ParameterName = "NhanVienSapLichKey", SqlDbType = SqlDbType.Int, Value = nhanVienSapLichKey},
                        new SqlParameter { ParameterName = "GhiChu", SqlDbType = SqlDbType.NVarChar, Value = ghiChu },
                        ParListXeKeyFailed
                    };
                var result = _db.Database.ExecuteSqlCommand(store, sqlParams);
                if (ParListXeKeyFailed.Value == null) return false;
                listXeKeyFailed = ParListXeKeyFailed.Value.ToString();
                return true;
            }
            catch(BusinessException ex)
            {
                throw (ex);
            }
            
            
        }
            
        #endregion Sắp lịch bảo trì xe
    }//EndClass
}//EndNamespace