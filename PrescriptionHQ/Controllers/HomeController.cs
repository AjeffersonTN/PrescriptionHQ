using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrescriptionHQ.Models;
using MailKit.Net.Smtp;
using MailKit;
using MailKit.Security;
using MimeKit;

namespace PrescriptionHQ.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact(string patientName, string patientEmail)
            
        {
            ViewData["Message"] = "Contact";
            //Instantiate Mimemessage
            var message = new MimeMessage();
            //From address
            message.From.Add(new MailboxAddress("Natural Pharmacy", "akjeff025@gmail.com"));
            //To address
            message.To.Add(new MailboxAddress(patientName, patientEmail));
            //Subject
            message.Subject = "Prescription Update.";
            message.Body = new TextPart("plain")
            {
                Text = "Your prescription is availble for pickup."
            };

            //Configure and send email
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);

                client.Authenticate("akjeff025@gmail.com", "JEnesis1208");

                client.Send(message);

                client.Disconnect(true);
                
            }
            if(2 == 2)
            {
            ViewBag.Message = "Your email has been sent.";

            return RedirectToAction("PharmacyRequest", "Prescriptions");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
