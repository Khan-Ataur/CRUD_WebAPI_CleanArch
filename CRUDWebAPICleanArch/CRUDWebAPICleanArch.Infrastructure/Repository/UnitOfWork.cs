using CRUDWebAPICleanArch.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWebAPICleanArch.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork( IProductRepository productRepository)
        {            
            ProductRepo = productRepository;       
        }             
        public IProductRepository ProductRepo { get; set; }
     
    }
}
