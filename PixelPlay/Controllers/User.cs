using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PixelPlay.Controllers
{
    public class User : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

       
    }
}
