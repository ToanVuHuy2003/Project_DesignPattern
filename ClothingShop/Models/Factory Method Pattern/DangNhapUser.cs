using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothingShop.Models.Factory_Method_Pattern
{
    public class DangNhapUser : DangNhapFactory<Customer>
    {
        public override ILogin<Customer> CreateLogin()
        {
            return new User();
        }
    }
}