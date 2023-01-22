using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FromScratchConsole2WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [Route("{ident:int}")]//type validation in routing against ambigious route call
        public string GetBookId(int ident)
        { return "\nbookID# " + ident; }

        [Route("{ident}")]
        public string GetBookName(string ident)
        { return "\nbookNAME# " + ident; }
    }
}
