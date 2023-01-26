using Microsoft.AspNetCore.Mvc;

namespace FromScratchConsole2WebApi.Controllers
{
    [ApiController]
    //[Route("/")]//routes main
    //[Route("test")]//routes test
    [Route("test/[action]")]//reuires action method name for routing, unless 404
    public class TestController:ControllerBase
    {
        public string Get1() => "this is the resource to Get1";

        //we need to get error, of get1():AmbiguousMatchException..
        //to get error add app.usedeveloperexceptionpage() under configure
        public string Get2() => "this is the resource to Get2";
    }
}
