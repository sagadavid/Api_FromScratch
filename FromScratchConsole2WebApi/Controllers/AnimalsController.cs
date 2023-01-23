using FromScratchConsole2WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FromScratchConsole2WebApi.Controllers
{
    //[Route("api/[controller]")]
    [Route("[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private List<Animal> _animals=null;
        public AnimalsController()
        {
            var animals = new List<Animal>()
            {
            new Animal(){ Id = 123, Name="paleotorus"},
            new Animal(){ Id=34, Name="zerotus"}
            };
        }
       

        //[Route("")]
        [Route("", Name="virgil")]//this route will called at
                                  //acceptedatroute return type of iactionresult
        public IActionResult GetAnimals() 
        {
            //return Ok();//OkResult object !
            //Creates a Microsoft.AspNetCore.Mvc.OkResult object that produces
            //an empty Microsoft.AspNetCore.Http.StatusCodes.Status200OK response, below

            //return Ok("all animals on board");
            return Ok(_animals);
        }

        [Route("accepted")]
        public IActionResult GetAcceptedAnimals() 
        {
            //return Accepted();//AcceptedResult object!
            //Creates a Microsoft.AspNetCore.Mvc.AcceptedResult object that produces
            //an Microsoft.AspNetCore.Http.StatusCodes.Status202Accepted response.

            //return Accepted("~/api/animals");//response header location location: ~/api/animals
            //return AcceptedAtAction("GetAnimals");//response header location: https://localhost:56957/Animals
            return AcceptedAtRoute("virgil");//route for getanimals renamed and called here
                                             //response header location: https://localhost:56957/Animals
        }

        [Route("{credited}")]//route should contain credited string to success
        public IActionResult GetCreditedAnimals(string credited) 
        {
            if (!credited.Contains("xyz")) 
            { return BadRequest(); }
            return Ok(_animals);
        }



    }
}
