using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DangKiNgayLaoDong.Areas.Admin.Controllers
{
    public class TrangNguoiQuanLyController : Controller
    {
        // GET: Admin/TrangNguoiQuanLy
  
        public ActionResult Trangnguoiquanly()
        {
            return View();
        }
        public ActionResult Trangthongtinquanly()
        {
            return View();
        }

    }
}