using GestionEvidencias.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionEvidencias.Controllers
{
    public class EstudiantesController : Controller
    {

        private readonly DataContext _context;


        public EstudiantesController(DataContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estudiantes
                //.Include(c => c.ProductCategories)
                .ToListAsync());
        }
    }
}
