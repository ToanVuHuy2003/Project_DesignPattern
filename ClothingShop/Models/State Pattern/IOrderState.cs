using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingShop.Models.State_Pattern
{
    public interface IOrderState
    {
        void ApproveOrder(DonHang order);
    }
}