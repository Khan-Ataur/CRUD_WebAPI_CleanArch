namespace CRUDCoreWebApp.Models
{
    public class Product : CommonAPIResponse
    {
        public int ProductId { get; set; }
        public string PrdDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string Remarks { get; set; }
    }
}
