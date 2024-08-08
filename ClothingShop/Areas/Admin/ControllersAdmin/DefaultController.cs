using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothingShop.Areas.Admin.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Admin/Default
        public ActionResult Index()
        {
            if (Session["Admin"] == null)
                return RedirectToAction("Login");
            return View();
        }

        public ActionResult Logout()
        {
            Session["Admin"] = null;
            Session["GioHang"] = null;
            return Redirect("~/Home/Index");
        }
    }
}