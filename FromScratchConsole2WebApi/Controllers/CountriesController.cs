using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FromScratchConsole2WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {

        [BindProperty]
        public string Name { get; set; }
        
        [BindProperty]
        public int Population { get; set; }

        [BindProperty]
        public int Area { get; set; }

        [HttpPost("")]
        public IActionResult AddCountry()

        //on api/countries-->postman/post/formdata{key,value-->name,norge}//200
        
            //{ return Ok(this.Name); }
        { return Ok($"\nName={this.Name},\nPopulation={this.Population},\nArea={this.Area}"); }
        

    }
}
