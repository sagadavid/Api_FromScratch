using FromScratchConsole2WebApi.Models;
using System.Collections.Generic;

namespace FromScratchConsole2WebApi.Repository
{
 //this interface is extracted/created for singleton architecture
    public interface IProductRepository
    {
        int AddProduct(Product product);
        List<Product> GetProducts();
        string GetName();
    }
}