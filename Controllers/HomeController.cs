using Microsoft.AspNetCore.Mvc;

namespace DownloadApp.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Registration")]
        public string get()
        {
            return "test";
        }
    }
}