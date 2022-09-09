using Manager.Interface;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace BookStoreApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminBL iAdminBL;

        public AdminController(IAdminBL iAdminBL)
        {
            this.iAdminBL = iAdminBL;
        }
        [HttpPost]
        [Route("AdminLogin")]
        public IActionResult Login(LoginModel loginModel)
        {
            try
            {
                var result = this.iAdminBL.AdminLogin(loginModel);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Admin Login Successfull", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Admin Login UnSuceessfull" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
