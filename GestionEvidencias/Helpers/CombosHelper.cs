using GestionEvidencias.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GestionEvidencias.Helpers
{
    public class CombosHelper : ICombosHelper
    {

        private readonly DataContext _context;

        public CombosHelper(DataContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<SelectListItem>> GetComboEstudiantesAsync()
        {
            List<SelectListItem> list = await _context.Estudiantes.Select(x => new SelectListItem
            {
                Text = x.Nombre+" "+x.Apellido1,
                Value = $"{x.Id}"
            })
                .OrderBy(x => x.Text)
                .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un estudiante...]",
                Value = "0"
            });

            return list;
        }

        public Task<string> UploadImageAsync(string nombre, string directory, IFormFile file)
        {
            string path = Path.Combine($"{Environment.CurrentDirectory}\\{directory}\\{nombre}");
            if (File.Exists(path))
            {
                File.Delete(path);
            }


            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return Task.FromResult(path);
        }

    }
}
