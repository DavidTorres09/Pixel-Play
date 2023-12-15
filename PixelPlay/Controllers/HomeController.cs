using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PixelPlay.Models;
using System.Diagnostics;
using System.Linq;

namespace PixelPlay.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PixelPlayContext _dbContext;

        public HomeController(ILogger<HomeController> logger, PixelPlayContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ValidarUsuario(string correo, string contraseña)
        {
            if (ModelState.IsValid)
            {
                var user = _dbContext.Usuarios.FirstOrDefault(u => u.CorreoElectronico == correo && u.Contraseña == contraseña);

                if (user != null)
                {
                    if (user.CorreoElectronico == "admin1@example.com" && user.Contraseña == "contraseña3"){
                        return RedirectToAction("Index", "Admin");
                    }
                    return RedirectToAction("Index", "User");
                }

                ModelState.AddModelError(string.Empty, "Correo electrónico o contraseña incorrectos");
            }

            return RedirectToAction("Error", "Home");
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
