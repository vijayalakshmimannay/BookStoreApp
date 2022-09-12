using Manager.Interface;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Linq;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackBL ifeedbackBL;
        public FeedbackController(IFeedbackBL ifeedbackML)
        {
            this.ifeedbackBL = ifeedbackML;
        }

        [HttpPost]
        [Route("AddFeedback")]
        public IActionResult AddFeedback(FeedbackModel feedbackModel)
        {
            try
            {
                int UserID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "ID").Value);
                var result = ifeedbackBL.AddFeedback(feedbackModel, UserID);
                if (result)
                {
                    return Ok(new { success = true, message = "Feedback added successfully." });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Cannot add feedback." });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("GetFeedback")]
        public IActionResult GetFeedback()
        {
            try
            {
                int UserID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "ID").Value);
                var result = ifeedbackBL.GetFeedback(UserID);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Feedback got successfully.", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Cannot get feedback." });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
