using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DangKiNgayLaoDong.Models;
using System.Data.Entity;

namespace DangKiNgayLaoDong.Controllers
{
    public class LoginController : Controller
    {
        QuanLyNgayLaoDongEntities db = new QuanLyNgayLaoDongEntities();

        public ActionResult Dangnhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Dangnhap(LoginModel model)
        {
            if (ModelState.IsValid) // Kiểm tra validation
            {
                var user = db.TaiKhoans
                            .Include(x => x.VaiTro)
                            .FirstOrDefault(x => x.username == model.tendangnhap && x.password == model.pass);

                if (user != null)
                {
                    Session["TaiKhoan"] = user;
                    Session["TenDangNhap"] = user.username;

                    if (user.VaiTro != null)
                    {
                        Session["VaiTro"] = user.VaiTro.vaitro1;
                        switch (user.VaiTro.vaitro1.ToLower())
                        {
                            case "admin":
                                string url = Url.Action("Trangnguoiquanly", "Admin", new { area = "Admin" });
                                return Redirect(url);

                            case "sinhvien":
                                return RedirectToAction("Index", "SinhVien");
                            case "quanly":
                                return RedirectToAction("Index", "NhanVien");
                            default:
                                return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ViewBag.ThongBao = "Tài khoản không có vai trò hợp lệ!";
                        return View(model);
                    }
                }
            }

            ViewBag.ThongBao = "Sai tên đăng nhập hoặc mật khẩu!";
            return View(model);
        }

        public ActionResult DangXuat()
        {
            Session.Clear();
            return RedirectToAction("Dangnhap");
        }
    }
}