namespace GestionEvidencias.Entities
{
    public class EvidenciaEstudiante
    {
        public int Id { get; set; }

        public Evidencia Evidencia { get; set; }

        public Estudiante Estudiante { get; set; }
    }
}
