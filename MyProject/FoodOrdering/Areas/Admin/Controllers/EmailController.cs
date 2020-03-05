using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodOrdering.Areas.Admin.Models;
using Microsoft.Extensions.Configuration;

namespace FoodOrdering.Areas.Admin.Controllers
{
    public class EmailController : Controller
    {
        private readonly IConfiguration _config;
        public EmailController(IConfiguration config)
        {
            _config = config;
        }
        public void Index()
        {
            var model = new EmailModel(_config);
            model.MailSending();
            
        }
    }
}