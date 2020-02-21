using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using finalpractice2.Models;
using finalproject2.Core.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace finalpractice2.Controllers
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

        public IActionResult Index()
        {
            using (var mailsender = new MailSender(_config))
            {
                mailsender.Send(new List<MailMessege>
                {
                    new MailMessege
                    {
                        Body = "This is test",
                        Receiver = "nobelrakib03@gmail.com",
                        Sender = "nobelrakib03@gmail.com",
                        SenderName = "rakib hasan",
                        Subject = "Testing"
                    }
                });
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
