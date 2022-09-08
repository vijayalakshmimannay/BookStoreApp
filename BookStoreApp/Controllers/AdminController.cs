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
        [Route("Login")]
        public IActionResult Login(LoginModel loginModel)
        {
            try
            {
                var result = this.iAdminBL.AdminLogin(loginModel);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Login Successfull" });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Login UnSuceessfull" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
