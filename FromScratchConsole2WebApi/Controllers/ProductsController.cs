using FromScratchConsole2WebApi.Models;
using FromScratchConsole2WebApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FromScratchConsole2WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        /**services,WITHOUT DEPENDENCY INJECTION -CREATE NEW INSTANSES METHOD- 
         * has some drawbacks
         * repository here is re-created each time added a product 
         * THAT MEANS WHENEVER YOU POST NEW PRODUCT DATA
         * its alway one pruduct in the list, renews and renews the insatanse which holds data
         * firs solution against drawback is using SINGLETON !! ***/
        //private readonly ProductRepository _productRepository;

        //to use singleton architecure, use interface of respository
        private readonly IProductRepository _productRepository;
        private readonly IProductRepository _productRepository11;

        //public ProductsController()

        //to use singleton, inject interface to controller, set up it in services as well
        public ProductsController
            (
            IProductRepository productRepository,
            IProductRepository productRepository11
            )
        {

            //_productRepository= new ProductRepository();

            _productRepository= productRepository;
            _productRepository11 = productRepository11;
            //evenif there is new instances of interface, 
            //all posts from these instances of interface would still summon
            //inthe same productslist, either.. in same single instance 
        }

        [HttpPost("")]
        public IActionResult AddProduct([FromBody] Product product ) 
        {
        _productRepository.AddProduct(product);
            //var products = _productRepository.GetProducts();
            var products = _productRepository11.GetProducts();//notice here !
            return Ok(products);
        }

        [HttpGet("namy")]
        public IActionResult GetName()
        {
            //this getname is implemented in two different repos..
            //so which repos will give the name ???
            //see startup comments
            var name = _productRepository.GetName;
            return Ok(name);
        }







    }
}
