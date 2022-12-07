using GestionEvidencias.Data;
using GestionEvidencias.Entities;
using GestionEvidencias.Helpers;
using GestionEvidencias.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;
using System.Security.Policy;

namespace GestionEvidencias.Controllers
{
    public class EvidenciasController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;

        public EvidenciasController(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Evidencias
                .Include(p => p.EvidenciaEstudiantes)
                .ThenInclude(pc => pc.Estudiante)
                .ToListAsync());
        }

        public async Task<IActionResult> Create()
        {
            CreateEvidenciaViewModel model = new()
            {
                Estudiantes = await _combosHelper.GetComboEstudiantesAsync(),
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEvidenciaViewModel model)
        {
            if (ModelState.IsValid)
            {
                string filePath = String.Empty;

                if (model.File != null)
                {

                    string nombre = model.File.FileName;
                    string directory = "wwwroot\\Archivos";
                    filePath = await _combosHelper.UploadImageAsync(nombre, directory, model.File);


                }

                Evidencia evidencia = new()
                {
                    Titulo = model.Titulo,
                    Descripcion = model.Descripcion,
                    Tipo = model.Tipo,
                    FileSource = filePath,
                    FileName = model.File.FileName

                };

                //List temporales = await _context.Temporales.ToListAsync();
                

                //foreach (var item in temporales)
                //{
                //    evidencia.EvidenciaEstudiantes = new List<EvidenciaEstudiante>()
                //    {
                //        new EvidenciaEstudiante
                //        {
                //            Estudiante = await _context.Estudiantes.FindAsync(id)
                //        }

                //    };
                //}


                try
                {
                    _context.Add(evidencia);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un producto con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            model.Estudiantes = await _combosHelper.GetComboEstudiantesAsync();
            return View(model);
        }

        public async Task<PartialViewResult> llenarTablaAsync(int estudianteId)
        {
            Estudiante estudiante = _context.Estudiantes.Find(estudianteId);
            if (estudiante == null)
            {
                return null;
            }



            Temporal temporal = new()
            {
                Nombre = estudiante.Nombre,
                Apellido1 = estudiante.Apellido1,
                Apellido2 = estudiante.Apellido2,
                Direccion = estudiante.Direccion,
                Telefono = estudiante.Telefono,
                Email = estudiante.Email,
                Tipo = estudiante.Tipo,
                Documento = estudiante.Documento,
                Carnet = estudiante.Carnet,
            };

            try
            {
                _context.Add(temporal);
                await _context.SaveChangesAsync();
                return PartialView("_Estudiantes", temporal);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                {
                    ModelState.AddModelError(string.Empty, "Ya existe el mismo estudiante.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
            }

            //return null;
            return null;
        }


    }
}
