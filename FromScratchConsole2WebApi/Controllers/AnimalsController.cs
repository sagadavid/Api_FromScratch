using FromScratchConsole2WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace FromScratchConsole2WebApi.Controllers
{
    [Route("api/[controller]")]
    //[Route("[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private List<Animal> _animals = null;
        public AnimalsController()
        {
            var animals = new List<Animal>()
            {
            new Animal(){ Id = 123, Name="horse"},
            new Animal(){ Id=34, Name="cat"}
            };
            _animals = animals;
        }


        //[Route("")]
        [Route("", Name = "callanimals")]//this route will called at
                                         //acceptedatroute return type of iactionresult
        public IActionResult GetAnimals()
        {
            //return Ok();//OkResult object !
            //Creates a Microsoft.AspNetCore.Mvc.OkResult object that produces
            //an empty Microsoft.AspNetCore.Http.StatusCodes.Status200OK response, below

            //return Ok("all animals on board");

            var animals = new List<Animal>()
            {
            new Animal(){ Id = 123, Name="horse"},
            new Animal(){ Id=34, Name="cat"}
            };
            return Ok(animals);//returns animals created in the method
            //could return ctor created animals as well

        }

        [Route("tellyanimals")]
        public IActionResult GetAcceptedAnimals()
        {
            //return Accepted();//AcceptedResult object!
            //Creates a Microsoft.AspNetCore.Mvc.AcceptedResult object that produces
            //an Microsoft.AspNetCore.Http.StatusCodes.Status202Accepted response.

            //return Accepted("~/api/animals");//response header location location: ~/api/animals


            //return AcceptedAtAction("GetAnimals");//response header
            //location: https://localhost:56957/Animals


            return AcceptedAtRoute("callanimals");//give a name to a route and call it !!
                                                  //response header location: https://localhost:56957/Animals
                                                  //request path: /api/animals/tellyanimals
        }

        [Route("{credit}")]//route should contain credited string to success204
        public IActionResult GetAnimalsByCredits(string credit)
        {
            if (!credit.Contains("hei"))
            { return BadRequest(); }//request path: /api/animals/cat.. response 400
            return Ok(_animals);//:request path: /api/animals/cathei.. response 200
                                //returns ctor created animals if request contains asd letters
        }

        //whollycommented for the sake of not found return line 130
        //this method will be called by post mehtod below !
        //[Route("{id:int}")]
        //public IActionResult AddedAnimalById(int id) 
        //{
        //if (id ==0) return BadRequest();
        //return Ok(_animals.FirstOrDefault(a=>a.Id==id));//bring id-matching animal
        //}


        //post/add a new animal via postman/post/body:{id,name}..get 201 created response
          [HttpPost("")]//can use http verb with route directly
        public IActionResult PostAnimals(Animal addedAnimal)
        {
            _animals.Add(addedAnimal);

            //--create method returns an action, thatswhy create an action above !
            
            //return Created("~/api/animals", new { id = addedAnimal.Id });//not best routing !
            //return Created("~/api/animals/"+addedAnimal.Id, addedAnimal);

            return CreatedAtAction("AddedAnimalById", 
                new { id=addedAnimal.Id}, addedAnimal);//postman/post/body:id,name and get 201

        }


        [Route("getatlocal")]
        public IActionResult GetAtLocal() 
        {
            
            //return LocalRedirect("~/api/animals");
            
            //Request URL: https://localhost:56957/api/animals/getatlocal
            //Request Method: GET
            //Status Code: 302(from disk cache)

            //Request URL: https://localhost:56957/api/animals
            //Request Method: GET
            //Status Code: 200


            return LocalRedirectPermanent("~/api/animals");

            //Request URL: https://localhost:56957/api/animals/getatlocal 
            //Request Method: GET
            ////Status Code: 301(from disk cache)

            //Request URL: https://localhost:56957/api/animals
            //Request Method: GET
            //Status Code: 200

        }

        [Route("{id:int}")]
        public IActionResult GetAnimalById(int id)
        {
            if (id == 0) return BadRequest();
            var askedAnimal = _animals.FirstOrDefault(a => a.Id == id);

            if (askedAnimal == null) return NotFound();//there is no animal, not found 404
                                                       //tere is.. found 200
                                                       // Request URL: https://localhost:56957/api/animals/2345
                                                       // Request Method: GET
                                                       // Status Code: 404

           // Request URL: https://localhost:56957/api/animals/123
           // Request Method: GET
           // Status Code: 200


            return Ok(askedAnimal);
        }


    }
}
