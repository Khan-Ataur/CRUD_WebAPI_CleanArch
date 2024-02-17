namespace CRUDCoreWebApp.Models
{
    public class ProductVM
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<Product> result { get; set; }
    }
}
