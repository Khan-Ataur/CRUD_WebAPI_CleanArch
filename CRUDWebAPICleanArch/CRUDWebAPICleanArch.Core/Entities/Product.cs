using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWebAPICleanArch.Core.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string PrdDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string Remarks { get; set; }
    }
}
