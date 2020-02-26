using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Authorization;
using Amazon.SQS.Model;
using Amazon.SQS;

namespace Ecommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class UploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile profileImage)
        {
            var randomName = Path.GetRandomFileName().Replace(".", "");
            var fileName = System.IO.Path.GetFileName(profileImage.FileName);
            var newFileName = $"{ randomName }{ Path.GetExtension(profileImage.FileName)}";

            var path = $"wwwroot/imgup/{randomName}{Path.GetExtension(profileImage.FileName)}";

            if (!System.IO.File.Exists(path))
            {
                using (var imageFile = System.IO.File.OpenWrite(path))
                {
                    using (var uploadedfile = profileImage.OpenReadStream())
                    {
                        uploadedfile.CopyTo(imageFile);

                    }
                }
            }

            var client = new AmazonS3Client();

            var file = new FileInfo(path);
            var request = new PutObjectRequest
            {
                BucketName = "rakib1",
                FilePath = file.FullName,
                Key = newFileName
            };
            var response = await client.PutObjectAsync(request);
            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                var sqsClient = new AmazonSQSClient();
                var sqsRequest = new SendMessageRequest
                {
                    QueueUrl = "https://sqs.us-east-1.amazonaws.com/847888492411/rakib01",
                    MessageBody = $"name: '{newFileName}'"
                };

                var sqsResponse = await sqsClient.SendMessageAsync(sqsRequest);
                if (sqsResponse.HttpStatusCode == System.Net.HttpStatusCode.OK)
                {
                    file.Delete();
                }
            }
            return View();
        }
    }
}