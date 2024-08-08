using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothingShop.Models.State_Pattern
{
    public class Order
    {
        private IOrderState _orderState;
        public  Order(IOrderState state)
        {
            _orderState = state;
        }
        public void SetState(IOrderState state)
        {
            _orderState = state;
        }
        public void ApproveOrder(DonHang order)
        {
            _orderState.ApproveOrder(order);
        }
    }
}