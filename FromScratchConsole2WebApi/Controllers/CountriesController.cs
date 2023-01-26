using FromScratchConsole2WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FromScratchConsole2WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    //[BindProperties(SupportsGet =true)]//used controller level BUT ALSO FOR MODELS..
                    //no decoration for each props..
                    //wont work for get UNLESS ENABLED
          
    public class CountriesController : ControllerBase
    {
        //bind inside the controller

        //[BindProperty]//needed for each prop
        //public string Name { get; set; }

        //[BindProperty]
        //public int Population { get; set; }

        //[BindProperty]
        //public int Area { get; set; }

        /****************************************************/

        //[BindProperty]//bind to the model, no need for each prop
        //[BindProperty(SupportsGet =true)]//binding enabled for get requests

        //public Country Country { get; set; }

        /***********************************************/

        //[HttpPost("")]
        //public IActionResult AddCountry()

        //on api/countries-->
        //postman/post/formdata-->
        //{key,value-->name,norge}//200


        //Binded in the controller

        //{ return Ok(this.Name); }

        //{ 
        //return Ok($"POSTED " +
        //    $"\nName={this.Name}," +
        //    $"\nPopulation ={ this.Population}," +
        //    $"\nArea ={ this.Area}");
        //}

        //Binded to the model
        //{
        //    return Ok($"POSTED " +
        //        $"\nName={this.Country.Name}," +
        //    $"\nPopulation={this.Country.Population}," +
        //    $"\nArea={this.Country.Area}");//200
        //}

        /************************************************/

        //[HttpGet("")]//bind attribute is mutated for getrequest
        //public IActionResult GetCountry()
        //{
        //    return Ok($"GOT " +
        //        $"\nName={this.Country.Name}," +
        //    $"\nPopulation={this.Country.Population}, " +
        //    $"\nArea={this.Country.Area}");
        //}

        /*****************************************/
        //PASS DATA VIA QUERY..NOT BINDING..

        //comment out all bind attributes and properties etc
        //(note that we wont use property to hold/bind data,
        //we'll pass in via query)

        //[HttpPost("")]
        //[HttpGet("")]
        //same method works fine with two attributes 
        //data order doesnt count
        //postman post: https://localhost:56957/api/countries?area=3454&populus=567&name=polanis
        //postman get: https://localhost:56957/api/countries?area=34&populus=123&name=patagonia //200

        //PASS SIMPLE TYPES VIA URL

        //[HttpPost("{name}/{area}/{populus}")]
        //[HttpGet("{name}/{area}/{populus}")]
        //postman get: https://localhost:56957/api/countries/caprika/34/234 
        //200 //data type counts so the order.. according to url
        //postman post: https://localhost:56957/api/countries/galaktika/234/134 
        //200 //data type counts

        [HttpPost("{name}/{area}/{populus}")]
        [HttpGet("{name}/{area}/{populus}")]
        public IActionResult DataViaQueryOrUrl(string name, int populus, int area) 
        {
            return Ok($"DATA VIA QUERYSTRING" +
                $"\n  name={name}, populus={populus}, area={area}");
        }

        //PASS COMPLEX TYPES VIA BODY 

        [HttpGet("")]
        [HttpPost("")]
        public IActionResult PassComplexData(Country country) 
        {
            return Ok($"PASSED COMPLEX DATA" +
                $"\nname={country.Name}," +
                $"pop={country.Population}, " +
                $"area={country.Area}");
        }



    }
}
