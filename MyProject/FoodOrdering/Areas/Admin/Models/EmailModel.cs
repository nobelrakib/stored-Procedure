using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodOrdering.Core.Services;
using Microsoft.Extensions.Configuration;

namespace FoodOrdering.Areas.Admin.Models
{
    public class EmailModel
    {
        public string Body { get; set; }
        public string Sender { get; set; }
        public string Reciver { get; set; }
        public string SenderName { get; set; }
        public string Subject { get; set; }

        
        private readonly IConfiguration _config;

        public EmailModel( IConfiguration config)
        {
            _config = config;
        }
        public void MailSending()
        {
            using (var mailsender = new MailSender(_config))
            {
                mailsender.Send(new List<MailMessage>
                {
                    new MailMessage
                    {
                        Body = "Hellow your product is on the way",
                        Receiver = "nobelrakib03@gmail.com",
                        Sender = "nobelrakib03@gmail.com",
                        SenderName = "Rakib Hasan",
                        Subject = "food delivery"
                    }
                });
            }
        }
    }
}
