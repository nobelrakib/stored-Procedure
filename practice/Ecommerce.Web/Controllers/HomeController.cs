using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Web.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Ecommerce.Core.Services;
using System.Net.Mail;
using Microsoft.AspNetCore.Authorization;

namespace Ecommerce.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }
       
        public IActionResult Test()
        {
            return View();
        }
        public IActionResult Index()
        {
            //using (var mailsender = new MailSender(_config))
            //{
            //    mailsender.Send(new List<MailMessege>
            //    {
            //        new MailMessege
            //        {
            //            Body = "This is test",
            //            Receiver = "nobelrakib03@gmail.com",
            //            Sender = "nobelrakib03@gmail.com",
            //            SenderName = "Rakib Hasan",
            //            Subject = "Testing"
            //        }
            //    });
           // }
            return View();
        }
        [Authorize(Roles = "Customer,Support,Admin")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Authorize(Roles ="collector")]
        public IActionResult Testing()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Log()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Log(Test model)
        {
            try
            {
                var status = false;
                if (ModelState.IsValid)
                {
                    status = true;
                }
                throw new Exception("Fake Error");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Test failed");
            }
            return View();
        }
    }
}
