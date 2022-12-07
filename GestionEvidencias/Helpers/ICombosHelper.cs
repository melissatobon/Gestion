using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionEvidencias.Helpers
{
    public interface ICombosHelper
    {
        Task<IEnumerable<SelectListItem>> GetComboEstudiantesAsync();
        Task<string> UploadImageAsync(string nombre, string directory, IFormFile image);
    }
}
