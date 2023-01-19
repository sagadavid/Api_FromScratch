using Microsoft.AspNetCore.Mvc;

namespace FromScratchConsole2WebApi.Controllers
{
    [ApiController]
    //[Route("/")]//routes main
    //[Route("test")]//routes test
    [Route("test/[action]")]//reuires action method name for routing, unless 400
    public class TestController:ControllerBase
    {
        public string Get() => "this is the resource to Get";

        //we need to get error, of get1():AmbiguousMatchException..
        //to get error add app.usedeveloperexceptionpage() under configure
        public string Get1() => "this is the resource to Get1";
    }
}
