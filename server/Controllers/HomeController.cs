using Microsoft.AspNetCore.Mvc;

namespace poptwit.Controllers
{
    // HACK Couldn't get default files to work with the custom static dir
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("/")]
        public IActionResult Get()
        {
            return RedirectPermanent("/index.html");
        }
    }
}