using GestionEvidencias.Enums;

namespace GestionEvidencias.Models
{
    public class EditEvidenciaViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public TipoArchivo Tipo { get; set; }
        
    }
}
