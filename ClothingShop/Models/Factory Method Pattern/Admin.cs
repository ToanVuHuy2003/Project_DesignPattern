﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothingShop.Models.Factory_Method_Pattern
{
    public class Admin : Controller, ILogin<admin>
    {
        public bool Login(string taiKhoan)
        {
            return taiKhoan != null;
        }
        public bool Login(admin x, ref object taikhoan)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(x.AdminName))
                    ModelState.AddModelError(string.Empty, "User name không được để trống");
                if (string.IsNullOrEmpty(x.PasswordAd))
                    ModelState.AddModelError(string.Empty, "Password không được để trống");
                //Kiểm tra có admin này hay chưa
                var adminDB = DBDatabase.Instance.admins.FirstOrDefault(ad => ad.AdminName == x.AdminName && ad.PasswordAd == x.PasswordAd);
                if (adminDB == null)
                    ModelState.AddModelError(string.Empty, "Tên đăng nhập hoặc mật khẩu không đúng");
                else
                {
                    taikhoan = adminDB;
                    ViewBag.ThongBao = "Đăng nhập admin thành công";
                    return true;
                }
            }
            return false;
        }
    }
}