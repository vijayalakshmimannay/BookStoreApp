using Manager.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Linq;

namespace BookStoreApp.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderBL orderBL;
        public OrderController(IOrderBL orderBL)
        {
            this.orderBL = orderBL;
        }

        [HttpPost]
        [Route("PlaceOrder")]
        public IActionResult AddOrder(OrderModel order)
        {
            try
            {
                int UserId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "ID").Value);
                var result = this.orderBL.AddOrder(order, UserId);
                if (result != null)
                {
                    return Ok(new { Success = true, Message = "Order placed Successfully", Data = result });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "Order failed" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("GetAllOrders")]

        public IActionResult GetOrder()
        {
            try
            {
                var result = orderBL.GetAllOrders();
                if (result != null)
                {
                    return Ok(new { success = true, message = "Orders got successfully.", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Cannot get order." });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("DeleteOrder")]
        public IActionResult DeleteOrder(int OrderID)
        {
            try
            {
                var result = orderBL.CancelOrder(OrderID);
                if (result)
                {
                    return Ok(new { success = true, message = "Order cancelled successfully." });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Cannot cancel order." });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}

