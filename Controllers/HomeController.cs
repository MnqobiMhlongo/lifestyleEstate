using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace lifestyleEstate.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Home()
        {
            return View();
        }

        public ActionResult ViewPdf(string fileName)
        {
            string filePath = Server.MapPath("~/Content/PDFs/" + fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/pdf");
        }



        [HttpPost]
        public ActionResult SendEmail(string name, string email, string subject, string message)
        {
            try
            {
                // Set up the email
                MailMessage mail = new MailMessage();
                mail.To.Add("engomesite@gmail.com"); // Destination email
                mail.From = new MailAddress(email); // Sender's email
                mail.Subject = $"General Inquiry From {name}"; // Dynamic subject
                mail.Body = $"<p>{message}</p>"; // Message from form
                mail.IsBodyHtml = true; // Enable HTML content

                // Configure SMTP client
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential("engomesite@gmail.com", "mhiv ucld hxnj gred"), // Secure this part
                    EnableSsl = true
                };

                // Send the email
                smtp.Send(mail);

                // Redirect to success or homepage after sending
                return RedirectToAction("Home", "Home", new { successMessage = "Email Sent, Agent Will Be In Contact Soon" });

            }
            catch (Exception ex)
            {
                // Handle exception (log it, show a message, etc.)
                return RedirectToAction("Home", "Home", new { successMessage = "Error Sending Email, Please check email or try again later" });

            }
        }

    }
}