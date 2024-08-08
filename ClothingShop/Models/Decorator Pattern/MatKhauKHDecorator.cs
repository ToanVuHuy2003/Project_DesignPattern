using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothingShop.Models.Decorator_Pattern
{
    public class MatKhauKHDecorator : AbstractDecorator
    {
        Customer kh1;
        public MatKhauKHDecorator(AbstractKhachHang kh, string matkhau, Customer kh1) : base(kh)
        {
            this.kh1 = kh1;
            Matkhau = matkhau;
        }

        public override Customer MakeKhachHang()
        {
            base.MakeKhachHang();
            Customer kh = kh1;
            kh.Password = Matkhau;
            return base.MakeKhachHang();
        }
    }
}