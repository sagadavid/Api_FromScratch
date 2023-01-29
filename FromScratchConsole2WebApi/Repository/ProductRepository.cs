 using FromScratchConsole2WebApi.Models;
using System.Collections.Generic;

namespace FromScratchConsole2WebApi.Repository
{
    //public class ProductRepository

    //to implement singleton, extract interface !
    public class ProductRepository : IProductRepository
    {
        public List<Product> products = new List<Product>();
        public int AddProduct(Product product)
        {
            product.Id = products.Count + 1;
            products.Add(product);
            return product.Id;
        }

        public string GetName()
        {
            return "name from product repo";
        }

        public List<Product> GetProducts() { return products; }

    }
}
