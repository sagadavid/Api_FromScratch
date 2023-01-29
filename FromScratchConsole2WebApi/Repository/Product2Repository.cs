using FromScratchConsole2WebApi.Models;
using System.Collections.Generic;

namespace FromScratchConsole2WebApi.Repository
{
    public class Product2Repository : IProductRepository
    {
        public int AddProduct(Product product)
        {
            throw new System.NotImplementedException();
        }

        public string GetName()
        {
            return "name in secondrepo";
        }

        public List<Product> GetProducts()
        {
            throw new System.NotImplementedException();
        }
    }
}
