using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothingShop.Models.Factory_Method_Pattern
{
    public class User : Controller, ILogin<Customer>
    {
        [HttpGet]
        public bool Login(string taiKhoan)
        {
            //if (taiKhoan != null)
            return taiKhoan != null;
        }
        [HttpPost]
        public bool Login(Customer x, ref object taikhoan)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(x.EmailCus))
                    ModelState.AddModelError(string.Empty, "Tên đăng nhập không được để trống");
                if (string.IsNullOrEmpty(x.Password))
                    ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                if (ModelState.IsValid)
                {
                    //Tìm khách hàng có tên đăng nhập và password hợp lệ trong CSDL
                    var khach = DBDatabase.Instance.Customers.FirstOrDefault(k => k.EmailCus == x.EmailCus && k.Password == x.Password);
                    if (khach != null)
                    {
                        // lưu vào session
                        taikhoan = khach;
                        return true;
                    }
                    else
                    {
                        ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
                        return false;
                    }
                }
            }
            return false;
        }
    }
}