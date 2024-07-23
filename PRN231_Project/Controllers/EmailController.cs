using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Share.DTO.EmailDTO;
using Share.EmailService;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private IEmailSender _emailSender;

        public EmailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost("Welcome")]
        public IActionResult SendWelcomeEmail(SendEmailDTO request)
        {
            try
            {
                string subject = "Welcome to Our Billiard Shop!";
                string message = $"Thank you for registering at our billiard shop! We are excited to have you as a new member.\n\nBest regards,\nThe TTD Team";
                _emailSender.SendEmailAsync(request.Email, subject, message);
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost("Newsletter")]
        public IActionResult SendNewsletterEmail(SendEmailDTO request)
        {
            try
            {
                // Define subject and message for the newsletter
                string subject = "Welcome to Our Billiard Shop Newsletter!";
                string message = $"Dear {request.Email},\n\nThank you for subscribing to our newsletter! We're thrilled to have you on board and can't wait to share the latest updates, promotions, and news from our billiard shop.\n\nStay tuned for exciting content and exclusive offers.\n\nBest regards,\nThe TTD Team";

                // Send the email
                _emailSender.SendEmailAsync(request.Email, subject, message);

                return Ok("Newsletter subscription successful.");
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }

        }
    }
}
