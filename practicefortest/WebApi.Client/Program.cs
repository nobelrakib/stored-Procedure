using WebApi.Core;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace WebApi.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string []updateObject = { "3", "jjj" };
            string url = "https://localhost:44373/api/ReturnBook" ;
            var request = WebRequest.Create(url);
            request.Method = "PUT";
            request.ContentType = "application/json";

            var requestContent = JsonConvert.SerializeObject(updateObject);
            var data = Encoding.UTF8.GetBytes(requestContent);
            request.ContentLength = data.Length;
            try
            {
                using (var requestStream = request.GetRequestStream())
                {
                    requestStream.Write(data, 0, data.Length);
                    requestStream.Flush();

                    using (var response = request.GetResponse())
                    {
                        using (var streamItem = response.GetResponseStream())
                        {
                            using (var reader = new StreamReader(streamItem))
                            {
                                var result = reader.ReadToEnd();
                                Console.WriteLine(result);
                            }
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                string message = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                Console.WriteLine(message);
            }
        }
    }
}
