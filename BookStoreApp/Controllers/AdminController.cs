using Manager.Interface;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
                var result = iAdminBL.AdminLogin(loginModel);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Admin Login Successfull", data = result});
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
