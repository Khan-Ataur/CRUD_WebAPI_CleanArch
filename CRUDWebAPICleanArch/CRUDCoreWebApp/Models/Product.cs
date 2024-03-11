using System.ComponentModel;

namespace CRUDCoreWebApp.Models
{
    public class Product : CommonAPIResponse
    {
        public int ProductId { get; set; }

        [DisplayName("Product Description")]
        public string PrdDescription { get; set; }

        [DisplayName("Price")]
        public decimal ProductPrice { get; set; }
        public string Remarks { get; set; }
    }
}
