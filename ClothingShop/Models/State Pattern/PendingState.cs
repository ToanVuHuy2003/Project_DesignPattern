using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothingShop.Models.State_Pattern
{
    public class PendingState : IOrderState
    {
        public void ApproveOrder(DonHang order)
        {
            order.Status = 1;
        }
    }
}