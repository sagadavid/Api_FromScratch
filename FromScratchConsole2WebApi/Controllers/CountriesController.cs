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

        //[HttpPost("{name}/{area}/{populus}")]
        //[HttpGet("{name}/{area}/{populus}")]
        //public IActionResult DataViaQueryOrUrl(string name, int populus, int area) 
        //{
        //    return Ok($"DATA VIA QUERYSTRING" +
        //        $"\n  name={name}, populus={populus}, area={area}");
        //}

        //PASS COMPLEX TYPES VIA BODY 

        //besides type, names should match (fx, pupulus vs population)
        //[HttpGet("")]
        //[HttpPost("")]
        ////https://localhost:56957/api/countries/ //200
        ////postman body/raw/json:
        ////{ "NAME":"danmark", "Population":34523,"AREA":23423}
        //public IActionResult PassComplexData(Country country) 
        //{
        //    return Ok($"PASSED COMPLEX DATA" +
        //        $"\nname={country.Name}," +
        //        $"population={country.Population}, " +
        //        $"area={country.Area}");
        //}

        //PASS DATA FROM QUERY STRING

        //[HttpGet("{name}")]//QUERY YIELDS URL.. NOTICE THAT IN POSTMAN
        ////postman get: https://localhost:56957/api/countries/ENGLAND?name=USA
        ////here on postman, england passed via url, but usa passed via fromquery !!!
        ////and passed value/result is//200 : name=USA
        //public IActionResult PassData([FromQuery] string name) 
        //{
        //    return Ok($"name={name}");
        //}

        //pass data from query for complex type

        //    [HttpPost("")]//can post data via post/body,
        //                  //however from query yields on url data passing again
        //    //postman/post query: https://localhost:56957/api/countries?Name=danmark&Population=89&Area=67 //200
        //    //postman/post body : {"name":"finland","population":23,"area":45}
        //public IActionResult PostComplexData([FromQuery] Country country)//in the query, capital letter matters
        //    {
        //        return Ok($"posted fromquery" +
        //            $"\nname={country.Name}" +
        //            $"\npop={country.Population}" +
        //            $"\narea={country.Area}");
        //    }

        //PASSDATA FROMROUTE
        //url:switzerland, query:germany
        //https://localhost:56957/api/countries/switzerland?Name=germany
        //body:{"name":"finland"}
        //response is : switzerland// [FROMROUTE] YIELDS !
        //[HttpPost("{name}")]
        //    public IActionResult PostViaRoute([FromRoute] string name) 
        //    {
        //        return Ok($"name={name}");
        //    }

        //symulteneous USE OF MULTIPLE ATTRIBUTES AND TYPES

        //    [HttpPost("{brand}")]
        //    //post: https://localhost:56957/api/countries/TESLA?id=99
        //    //body: {"name":"china is coming}
        //    //response:name=TESLA id=99 name=china is coming
        //public IActionResult PostViaRoute(
        //        [FromRoute] string brand, 
        //        [FromQuery] int id, 
        //        Country model)
        //    {
        //        return Ok(
        //            $"\nname={brand}" +
        //            $"\nid={id}" +
        //            $"\nname={model.Name}");
        //    }

        //[HttpPost("{id}")]//data from body yields now
        ////query: https://localhost:56957/api/countries/9?id=8
        ////body:7
        ////response:7
        //public IActionResult PostBody([FromBody] int id) 
        //{ return Ok($"id={id}"); }


        //fromform
        //[HttpPost("{id}")]
        //public IActionResult PostBody(
        //    [FromRoute] int id, 
        //    [FromForm] string color)
        //{ return Ok($"id={id}" +
        //    $"color={color}"); }
        //post: https://localhost:56957/api/countries/765
        //from-form:key-color, value-bronze
        //response:id=765color=bronze


        //fromheader
        //[HttpPost("{id}")]
        //public IActionResult PostHeader(
        //    [FromRoute] int id,
        //    [FromHeader] string developer)
        //{
        //    return Ok($"id={id}" +
        //    $"developer={developer}");
        //    //header key,value --> developer,davidsaga
        //    //response: id=71developer=davidsaga
        //}

        /******** CUSTOM MODEL BINDING*******/

        //[HttpGet("search")]
        [HttpGet("enquire")]//go with ? in the route
        //as if we decoreate any attirbure --[FromRoute] int id--,
        //decorate we stringcountries with our ModelBinder which names Custommodelbinder(class) 
        public IActionResult SearchCountries
            ([ModelBinder(typeof(CustomModelBinder))]string[] countries) 
        {
            return Ok(countries);
            //postman get/send query: https://localhost:56957/api/countries/search?countries=norge|sverige|danmark|iceland //200
            //query is visible in params as well
            //response body:["norge","sverige","danmark","iceland"]
        }


    }
}
