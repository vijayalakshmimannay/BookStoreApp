using Manager.Interface;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Service
{
    public class OrderBL : IOrderBL
    {
        private IOrderRL orderRL;

        public OrderBL(IOrderRL orderRL)
        {
            this.orderRL = orderRL;
        }
        public bool AddOrder(OrderModel order, int UserId)
        {
            try
            {
                return this.orderRL.AddOrder(order, UserId);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public bool CancelOrder(int OrderID)
        {
            try
            {
                return orderRL.CancelOrder(OrderID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<GetOrderModel> GetAllOrders()
        {
            try
            {
                return orderRL.GetAllOrders();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }



}
