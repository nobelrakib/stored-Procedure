using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
namespace StockApi.Client
{
    class GetObject
    {
        public void GetData(string ControllerName)
        {
            string url = "https://localhost:44388/api/" + ControllerName;
            var request = WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            using (var response = request.GetResponse())
            {
                using (var streamItem = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(streamItem))
                    {
                        var result = reader.ReadToEnd();
                        Console.WriteLine(result);
                        dynamic item = JsonConvert.DeserializeObject(result);

                        // Console.WriteLine($"Item1: {item[0]}");
                        // Console.WriteLine($"Item2: {item[1]}");
                        //Console.WriteLine($"Item2: {item[2]}");
                        //Console.WriteLine($"Item2: {item[3]}");
                    }
                }
            }
        }
    }
}