using GestionEvidencias.Enums;

namespace GestionEvidencias.Entities
{
    public class Temporal
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string NombreCompleto => $"{Nombre} {Apellido1} {Apellido2}";
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public TipoDocumento Tipo { get; set; }
        public string Documento { get; set; }
        public string Carnet { get; set; }
    }
}
