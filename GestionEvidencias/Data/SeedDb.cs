using GestionEvidencias.Entities;

namespace GestionEvidencias.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckEstudiantesAsync();
        }

        private async Task CheckEstudiantesAsync()
        {
            if (!_context.Estudiantes.Any())
            {
                _context.Estudiantes.Add(

                new Estudiante
                {

                    Nombre = "Andres",
                    Apellido1 = "Perez",
                    Apellido2 = "Cano",
                    Direccion = "Cl. 30a #30-01",
                    Telefono = "604123456",
                    Tipo = Enums.TipoDocumento.CedulaCiudadania,
                    Documento = "123456789",
                    Email = "kuheufeiquauje-4099@yopmail.com",
                    Carnet = "123456789"
                });

                _context.Estudiantes.Add(
                    new Estudiante
                    {

                        Nombre = "Carlos",
                        Apellido1 = "Perez",
                        Apellido2 = "Cano",
                        Direccion = "Cl. 31a #30-01",
                        Telefono = "604123456",
                        Tipo = Enums.TipoDocumento.CedulaCiudadania,
                        Documento = "11554548",
                        Email = "rexaquemmeifroi-207@yopmail.com",
                        Carnet = "44556622"
                    });

                _context.Estudiantes.Add(

                new Estudiante
                {

                    Nombre = "Angie",
                    Apellido1 = "Restrepo",
                    Apellido2 = "Tobon",
                    Direccion = "Cl. 30a #30-01",
                    Telefono = "604123456",
                    Tipo = Enums.TipoDocumento.CedulaCiudadania,
                    Documento = "423423434",
                    Email = "meli@yopmail.com",
                    Carnet = "19234234"
                });

                _context.Estudiantes.Add(

                new Estudiante
                {

                    Nombre = "Emily",
                    Apellido1 = "Sanchez",
                    Apellido2 = "Restrepo",
                    Direccion = "Cl. 30a #30-01",
                    Telefono = "604123456",
                    Tipo = Enums.TipoDocumento.TarjetaIdentidad,
                    Documento = "45345343",
                    Email = "emily@yopmail.com",
                    Carnet = "14524353"
                });

            }

            await _context.SaveChangesAsync();
        }


    }
}
