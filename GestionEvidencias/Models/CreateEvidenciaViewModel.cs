using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GestionEvidencias.Models
{
    public class CreateEvidenciaViewModel : EditEvidenciaViewModel
    {
        [Display(Name = "Estudiante")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un estudiante.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int EstudianteId { get; set; }

        public IEnumerable<SelectListItem> Estudiantes { get; set; }

        [Display(Name = "Archivo")]
        public IFormFile? File { get; set; }

    }
}
