using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace StockApi.Client
{
    public class PostObject
    {
        public void Create(object updateObject, string ControllerName)
        {

            string url = "https://localhost:44388/api/" + ControllerName;
            var request = WebRequest.Create(url);
            request.Method = "POST";
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