using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace LibraryWithWebApi.Client.WebRequestProcess
{
    public class CheckFine
    {
        public double GetFine(int Id)
        {
            var webRequest = new WebClient();
            webRequest.BaseAddress = "https://localhost:44317";
            var result = webRequest.DownloadString("/api/students/"+ Id);
            return double.Parse(result);
        }
    }
}
