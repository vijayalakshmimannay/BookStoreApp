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

        //[Authorize(Roles = Role.Users)]
        //[HttpPost]
        // [Route("AddWishList")]
        [HttpPost]
        [Route("AddWishList")]
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

        // [Authorize(Roles = Role.Users)]
        //[HttpPost]
        // [Route("DeleteWishList")]
        [HttpPost]
        [Route("DeleteWishList")]
        public ActionResult RemoveWishList(int WishListId)
        {
            try
            {
                var currentUser = HttpContext.User;
                int UserId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(c => c.Type == "ID").Value);

                var list = this.wishBL.DeleteWishList(WishListId, UserId);

                if (list != null)
                {
                    return this.Ok(new { success = true, message = "Deleting your WishList", data = list });
                }
                return this.BadRequest(new { success = false, message = "Failed to delete WishList", data = list });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        [HttpGet("GetWishList")]
        public IActionResult GetWishList(int UserId)
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "ID").Value);
                var result = wishBL.GetWishList(UserId);
                if (result != null)
                {
                    return Ok(new { Success = true, Message = "Wishlist Retrieved", Data = result });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "Retrieve Unsuccessful" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }


}

