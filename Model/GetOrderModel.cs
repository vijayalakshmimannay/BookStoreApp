using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class GetOrderModel
    {
        public string OrderID { get; set; }
        public string OrderQty { get; set; }
        public string TotalPrice { get; set; }
        public string BookID { get; set; }
        public string AddressID { get; set; }
        public string ID { get; set; }
        public string OrderDate { get; set; }
    }
}
