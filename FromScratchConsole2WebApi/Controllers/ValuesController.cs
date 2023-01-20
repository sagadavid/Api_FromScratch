using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

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

        /* VARIABLES/DYNAMIC VALUES IN ROUTING */

        [Route("/{bookId}")]//variable in {}
        [Route("/book/{bookId}")]
        public string GetBookById(int bookId)
        { return "you get \nbook#" + bookId; }

        [Route("/{bookId}/{citationId}")]
        [Route("/book/{bookId}/citation/{citationId}")]
        public string GetCitedInBookById(int bookId, int citationId) 
        { return "you get \nbook#" + bookId + "\ncitation#" + citationId; }

        /* QUERY SEARCH IN ROUTE */

        [Route("search")]
        [Route("kearch")]
        public string SearchBooks(int bookId, string bookName) 
        {
            return "seach result " +
                "\nbookId="+bookId+"\nbookName="+bookName;
        }


    }
}
