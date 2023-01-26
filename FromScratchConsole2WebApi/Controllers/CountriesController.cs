using FromScratchConsole2WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FromScratchConsole2WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        //bind inside the controller

        //[BindProperty]//needed for each prop
        //public string Name { get; set; }

        //[BindProperty]
        //public int Population { get; set; }

        //[BindProperty]
        //public int Area { get; set; }


        //[BindProperty]//bind to the model, no need for each prop
        [BindProperty(SupportsGet =true)]//bind enabled for get requests
        public Country Country { get; set; }

        [HttpPost("")]
        public IActionResult AddCountry()

        //on api/countries-->
        //postman/post/formdata-->
        //{key,value-->name,norge}//200


        //Binded in the controller

        //{ return Ok(this.Name); }

        //{ return Ok($"\nName={this.Name},
        //\nPopulation={this.Population},
        //\nArea={this.Area}"); }//200


        //Binded to the model
        {
            return Ok($"\nName={this.Country.Name}," +
            $"\nPopulation={this.Country.Population}," +
            $"\nArea={this.Country.Area}");//200
        }

        [HttpGet("")]//bind attribute is mutated for getrequest
        public IActionResult GetCountry()
        {
            return Ok($"\nName={this.Country.Name}," +
            $"\nPopulation={this.Country.Population}, " +
            $"Area={this.Country.Area}");
        }
    }
}
