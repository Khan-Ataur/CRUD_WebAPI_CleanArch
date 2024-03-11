using CRUDCoreWebApp.Models;
using CRUDCoreWebApp.Models.ViewModels;
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
            List<Product> productList = null;

            HttpResponseMessage response = _client.GetAsync(baseAddress + "/Product").Result;
            //HttpResponseMessage response = _client.GetAsync(baseAddress + "/Product/GetAll").Result;

            if (response.IsSuccessStatusCode)
            {
                var Returnresult = response.Content.ReadAsStringAsync().Result;
                FinalResult = new ProductVM();
                FinalResult = JsonConvert.DeserializeObject<ProductVM>(Returnresult);
            }
            if (FinalResult != null)
            {
                productList = new List<Product>();
                productList = FinalResult.result;               
            }

            return View(productList);
        }





        [HttpGet]
        public IActionResult Edit(int? id)
        {
            Product objProduct=null;
            if (id ==null || id ==0)
            {
                return NotFound();
            }
            ProductIndividualVM objProductIndividual = null;
    
            //HttpResponseMessage response = _client.GetAsync(baseAddress + "/Product/GetById?id=" + id).Result;
            HttpResponseMessage response = _client.GetAsync(baseAddress + "/Product/GetById/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                var Returnresult = response.Content.ReadAsStringAsync().Result;
                objProductIndividual = new ProductIndividualVM();
                objProductIndividual = JsonConvert.DeserializeObject<ProductIndividualVM>(Returnresult);
            }
            if (objProductIndividual != null)
            {
                objProduct = new Product();
                objProduct.ProductId = objProductIndividual.result.ProductId;
                objProduct.PrdDescription = objProductIndividual.result.PrdDescription;
                objProduct.ProductPrice = objProductIndividual.result.ProductPrice;
                objProduct.Remarks = objProductIndividual.result.Remarks;
            }
  

            return View(objProduct);
        }

        [HttpPost]
        public IActionResult Edit(Product objProduct)
        {
            CommonAPIResponse commonAPIResponse = new CommonAPIResponse();
            if (objProduct != null)
            {                
                HttpResponseMessage response =_client.PutAsJsonAsync(baseAddress + "/Product/", objProduct).Result;
                if (response.IsSuccessStatusCode)
                {
                    var Returnresult = response.Content.ReadAsStringAsync().Result;

                    commonAPIResponse = JsonConvert.DeserializeObject<CommonAPIResponse>(Returnresult);
                }
            }

            if (commonAPIResponse.success == false)
            {
                ViewBag.Message = commonAPIResponse.message;
                return View();
            }


            return RedirectToAction("Index");
        }





        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]  
        public IActionResult Create(Product objProduct)
        {
            CommonAPIResponse commonAPIResponse = new CommonAPIResponse();
            if (objProduct != null) 
            {               
                HttpResponseMessage response = _client.PostAsJsonAsync(baseAddress + "/Product/", objProduct).Result;
                if (response.IsSuccessStatusCode)
                {
                    var Returnresult = response.Content.ReadAsStringAsync().Result;
                  
                    commonAPIResponse = JsonConvert.DeserializeObject<CommonAPIResponse>(Returnresult);
                }
            }

            if (commonAPIResponse.success==false)
            {
                ViewBag.Message = commonAPIResponse.message;
                return View();
            }
            

            return RedirectToAction("Index");
        }






    }
}
