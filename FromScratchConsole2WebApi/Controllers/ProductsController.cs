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
        private readonly ProductRepository _productRepository;

        public ProductsController()
        {
            _productRepository= new ProductRepository();
        }
        
        [HttpPost("")]
        public IActionResult AddProduct([FromBody] Product product ) 
        {
        _productRepository.AddProduct(product); 
            var products = _productRepository.GetProducts();
            return Ok(products);
        }

    }
}
