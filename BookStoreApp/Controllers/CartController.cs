using Manager.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Linq;

namespace BookStoreApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly ICartBL cartBL;
        public CartController(ICartBL cartBL)
        {
            this.cartBL = cartBL;
        }

        //[Authorize(Roles = Role.Users)]
        // [HttpPost]
        // [Route("AddToCart")]

        [Authorize]
        [HttpPost("AddToCart")]
        public ActionResult AddtoCart(CartModel cart)
        {
            try
            {
                var currentUser = HttpContext.User;
                int UserId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(c => c.Type == "ID").Value);

                var res = this.cartBL.AddCart(cart, UserId);

                if (res != null)
                {
                    return this.Ok(new { success = true, message = "Book added to the cart successfully", data = res });
                }
                return this.BadRequest(new { success = false, message = "Failed to add book in cart", data = res });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //[Authorize(Roles = Role.Users)]
        // [HttpPost]
        // [Route("UpdateCart")]
        [Authorize]
        [HttpPost("UpdateCart")]
        public ActionResult UpdateCart(int cartId, CartModel cart)
        {
            try
            {
                var currentUser = HttpContext.User;
                int UserId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(c => c.Type == "ID").Value);

                var res = this.cartBL.UpdateCart(cartId, cart, UserId);

                if (res != null)
                {
                    return this.Ok(new { success = true, message = "Updated cart successfully", data = res });
                }
                return this.BadRequest(new { success = false, message = "Failed update cart", data = res });

            }
            catch (Exception e)
            {

                throw e;
            }
        }
        //[Authorize(Roles = Role.Users)]
        // [HttpPost]
        //[Route("DeleteItemInCart")]

        [Authorize]
        [HttpPost("DeleteItemInCart")]
        public ActionResult RemoveCart(int cartId)
        {
            try
            {
                var res = this.cartBL.RemoveCart(cartId);

                if (res != null)
                {
                    return this.Ok(new { success = true, message = "Deleted Books from Cart", data = res });
                }
                return this.BadRequest(new { success = false, message = "Failed to Delete Cart Items", data = res });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet("GetItemsInCart")]
        public IActionResult GetAllCart(int UserId)
        {
            try
            {
                int UserID = Convert.ToInt32(User.Claims.FirstOrDefault(g => g.Type == "ID").Value);
                var result = cartBL.GetAllCart(UserId);

                if (result != null)
                {
                    return Ok(new { Success = true, Message = "Successful ", Data = result });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "Unsuccessful " });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
