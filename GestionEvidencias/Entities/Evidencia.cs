using GestionEvidencias.Enums;
using System.ComponentModel.DataAnnotations;

namespace GestionEvidencias.Entities
{
    public class Evidencia
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public TipoArchivo Tipo { get; set; }

        [Display(Name = "Archivo")]
        public string FileFullPath => FileSource == String.Empty
            ? $"https://localhost:7288/images/noimage.png"
            : FileSource;


        public string FileSource { get; set; }

        [Display(Name = "Archivo")]
        public string FileName { get; set; }

        public ICollection<EvidenciaEstudiante> EvidenciaEstudiantes { get; set; }

        [Display(Name = "Estudiantes")]
        public int EstudiantesNumber => EvidenciaEstudiantes == null ? 0 : EvidenciaEstudiantes.Count;

    }
}
