using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClothingShop.Models;
using ClothingShop.Models.Decorator_Pattern;
using ClothingShop.Models.Factory_Method_Pattern;

namespace ClothingShop.Controllers
{
    public class UsersController : Controller
    {
        /*ClothingStore1Entities db = new ClothingStore1Entities();*/
        // GET: Users

        DangNhapFactory<Customer> dangNhapFactory;
        ILogin<Customer> user;
        void CreateLogin()
        {
            dangNhapFactory = new DangNhapUser();
            user = dangNhapFactory.CreateLogin();
        }

        [HttpGet]
        public ActionResult Login()
        {
            String account = Session["Account"] as String;
            CreateLogin();
            if (user.Login(account))
            {
                return Redirect("/Home/Index");
            }
            else
                return View();
        }
        object account;
        [HttpPost]
        public ActionResult Login( Customer x)
        {
            CreateLogin();
            if (user.Login(x, ref account))
            {
                Session["Account"] = account;
                return Redirect("/");
            }
            else if(x.EmailCus == "admin@gmail.com" && x.Password == "12345")
                return RedirectToAction("Index", "Admin/Orders");
            else
                return View();
            /*if (ModelState.IsValid)
            {
                if (x.EmailCus == "admin@gmail.com" && x.Password == "12345")
                    return RedirectToAction("Index", "Admin/Orders");
                if (ModelState.IsValid)
                {
                    var account = DBDatabase.Instance.Customers.FirstOrDefault(k => k.EmailCus == x.EmailCus && k.Password == x.Password);
                    if (account != null)
                    {
                        Session["Account"] = account;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {

                        ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
                    }
                }
            }
            return View();*/
        }

        public ActionResult Logout()
        {
            Session["Account"] = null;
            Session["GioHang"] = null ;
            return RedirectToAction("Login", "Users");
        }
        [HttpGet]

        public ActionResult SignUp()
        {
            String taiKhoan = Session["TaiKhoan"] as String;
            if (taiKhoan != null)
                return Redirect("/Home/Index");
            return View();
        }
        [HttpPost]

        public ActionResult SignUp(Customer kh)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(kh.CustomerName))
                    ModelState.AddModelError(string.Empty, "Họ tên không được để trống");
                if (string.IsNullOrEmpty(kh.EmailCus))
                    ModelState.AddModelError(string.Empty, "Email không được để trống");
                if (string.IsNullOrEmpty(kh.Password))
                    ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");

                var khachhang = DBDatabase.Instance.Customers.FirstOrDefault(k => k.EmailCus == kh.EmailCus);
                if (khachhang != null)
                    ModelState.AddModelError(string.Empty, "Đã có người đăng ký tên này");

                if (ModelState.IsValid)
                {
                    Customer khg = new Customer();
                    AbstractKhachHang khachHang = new ConcreteKhachHang();
                    khachHang.MakeKhachHang();

                    // Họ và tên
                    khachHang = new HoTenKHDecorator(khachHang, kh.CustomerName, khg);
                    khg = khachHang.MakeKhachHang();

                    // Email
                    khachHang = new EmailKHDecorator(khachHang, kh.EmailCus, khg);
                    khg = khachHang.MakeKhachHang();

                    // Mật khẩu
                    khachHang = new MatKhauKHDecorator(khachHang, kh.Password, khg);
                    khg = khachHang.MakeKhachHang();

                    DBDatabase.Instance.Customers.Add(khg);
                    DBDatabase.Instance.SaveChanges();
                }
                else
                {
                    return View();
                }
            }
            return RedirectToAction("Login");
            /*string pass = account["PassCus"].ToString();
            string rePass = account["Repass"].ToString();
            string emailCus = account["EmailCus"].ToString();
            if(pass != rePass)
            {
                ViewBag.Notif = "Mật khẩu không khớp";
                return View();
            }

            var cus = DBDatabase.Instance.Customers.FirstOrDefault(k => k.EmailCus == emailCus);
            if (cus != null)
            {
                ViewBag.Warning = "Đã có người đăng ký bằng email này";
                return View();

            }
            else
            {
                Customer customer = new Customer();
                customer.CustomerName = account["NameCus"].ToString() ;
                customer.EmailCus = account["EmailCus"].ToString();
                customer.Password = account["PassCus"].ToString();
                DBDatabase.Instance.Customers.Add(customer);
                DBDatabase.Instance.SaveChanges();
                return RedirectToAction("Login","Users");

            }*/

        }
    }
}