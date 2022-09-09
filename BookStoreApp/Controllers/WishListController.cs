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
    public class WishListController : Controller
    {
        private readonly IWishListBL wishBL;
        public WishListController(IWishListBL wishBL)
        {
            this.wishBL = wishBL;
        }

        [Authorize]
        [HttpPost("AddWishList")]
        public ActionResult AddWishList(WishListModel wishList)
        {
            try
            {
                var currentUser = HttpContext.User;
                int UserId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(c => c.Type == "ID").Value);

                var list = this.wishBL.AddWishList(wishList, UserId);

                if (list != null)
                {
                    return this.Ok(new { success = true, message = "Added to your WishList", data = list });
                }
                return this.BadRequest(new { success = false, message = "Failed to add in WishList", data = list });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
