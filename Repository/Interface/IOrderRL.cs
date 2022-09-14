﻿using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IOrderRL
    {
        public bool AddOrder(OrderModel order, int UserId);
        public bool CancelOrder(int OrderID);
       public IEnumerable<GetOrderModel> GetAllOrders();


    }
}
