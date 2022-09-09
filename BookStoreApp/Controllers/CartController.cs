﻿using Manager.Interface;
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
        [Authorize]
        [HttpPut("UpdateCart")]
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
        [Authorize]
        [HttpDelete("DeleteItemInCart")]
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


    }
}
