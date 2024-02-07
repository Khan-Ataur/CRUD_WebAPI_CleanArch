using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWebAPICleanArch.Application.Interfaces
{
    public interface IUnitOfWork
    {
       // IContactRepository Contacts { get; }
        IProductRepository ProductRepo { get; }
      //  IItemMstRepository ItemMstRepo { get; }
    }
}
