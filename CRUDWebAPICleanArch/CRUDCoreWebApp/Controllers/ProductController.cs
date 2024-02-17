using CRUDCoreWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CRUDCoreWebApp.Controllers
{
    public class ProductController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44327/api");
        private readonly HttpClient _client;
        public ProductController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
            _client.DefaultRequestHeaders.Add("Authorization", "04577BA6-3E32-456C-B528-E41E20D28D79");
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        [HttpGet]
        public IActionResult Index()
        {
            List<Product> productList = new List<Product>();
            HttpResponseMessage response = _client.GetAsync(baseAddress + "/Product").Result;
            //ProductVM res = JsonConvert.DeserializeObject<ProductVM>(link);
            if (response.IsSuccessStatusCode)
            {
                var resResult = response.Content;
               
                //ProductVM ss = JsonConvert.DeserializeObject<Product>(resResult);

            }
            return View(productList);
        }




    }
}
