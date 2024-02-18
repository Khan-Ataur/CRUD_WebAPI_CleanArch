using CRUDCoreWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;

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
            ProductVM FinalResult = null;
            List<Product> productList = new List<Product>();

            HttpResponseMessage response = _client.GetAsync(baseAddress + "/Product").Result;

            if (response.IsSuccessStatusCode)
            {
                var Returnresult = response.Content.ReadAsStringAsync().Result;
                FinalResult = new ProductVM();
                FinalResult = JsonConvert.DeserializeObject<ProductVM>(Returnresult);
            }
            if (FinalResult != null)
            {
                productList = FinalResult.result;               
            }

            return View(FinalResult);
        }




    }
}
