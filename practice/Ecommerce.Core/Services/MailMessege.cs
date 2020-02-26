using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Services
{
    public class MailMessege
    {
        public string Sender { get; set; }
        public string SenderName { get; set; }
        public string Receiver { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
    }
}
