using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        #endregion Danh mục chi phí
    }//EndClass
}//EndNamespace