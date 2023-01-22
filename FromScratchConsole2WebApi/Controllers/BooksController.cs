using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FromScratchConsole2WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        //type validation in routing against ambigious route call
        //:int and :min are route constrains
        //int which are less than 10 is evaluated as string(next method )
        //[Route("{ident:int:min(10):max(20)}")]
        //[Route("{ident:int:range(10,15)")]
        [Route("{ident:int}")]
        public string GetBookId(int ident)
        { return "\nbookID# " + ident; }

        //[Route("{ident:length(3):alpha}")]//alpha means letters only, no other characters
        //[Route("{ident:minlength(5):maxlength(8)}")]
        [Route("{ident}")]
        public string GetBookName(string ident)
        { return "\nbookNAME# " + ident; }

        //check if regex is not conflicting with previous routes
        //[Route("{ident:regex(a(b|f))}")]
        //public string GetBookByRegex(string ident)
        //{ return "\nregex bookNAME# " + ident; }
    }
} 
