namespace CRUDWebAPICleanArch.Application.Interfaces
{
    public interface IUnitOfWork
    {
        // IContactRepository Contacts { get; }
        IProductRepository ProductRepo { get; }
        //  IItemMstRepository ItemMstRepo { get; }
    }
}
