using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FromScratchConsole2WebApi.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [Route("api/getall")]
        [Route("getall")]
        public string GetAll()
        {
            return "return of getall action";
        }
        
        [Route("api/getallauthors")]
        [Route("getallauthors")]
        public string GetAllAuthors()
        { 
            return "return of getallauthors action"; 
        }
    }
}
