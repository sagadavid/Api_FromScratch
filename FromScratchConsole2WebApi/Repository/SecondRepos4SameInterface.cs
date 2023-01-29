using FromScratchConsole2WebApi.Models;
using System.Collections.Generic;

namespace FromScratchConsole2WebApi.Repository
{
    public class SecondRepos4SameInterface : IProductRepository
    {
        public int AddProduct(Product product)
        {
            throw new System.NotImplementedException();
        }

        public string GetName()
        {
            return "name from secondrepo";
        }

        public List<Product> GetProducts()
        {
            throw new System.NotImplementedException();
        }
    }
}
