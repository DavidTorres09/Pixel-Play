using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PixelPlay.Models;
using System.Linq;

public class Admin : Controller
{
    private readonly PixelPlayContext _context;

    public Admin(PixelPlayContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var productosConCategoria = _context.Productos
        .Include(p => p.Categoria)
        .ToList();


        return View(productosConCategoria);
    }
}
