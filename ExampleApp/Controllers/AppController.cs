using Microsoft.AspNetCore.Mvc;

namespace ExampleApp
{
    public class AppController : Controller
    {

            public IActionResult Index(){ // archivo Index.cshtml en Views/App
                return View();
            }

             public IActionResult Info(){          
                return View();
            }
    }
}