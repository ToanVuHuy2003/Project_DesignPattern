﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothingShop.Models.Factory_Method_Pattern
{
    public interface ILogin<T>
    {
        //Get
        bool Login(string taiKhoan);
        //Post
        bool Login(T x, ref object taikhoan);
    }
}