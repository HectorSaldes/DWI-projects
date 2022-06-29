namespace escuela
{
    public class Estudiante
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public bool Estatus { get; set; }

        public Carrera? Carrera { get; set; }

        public Estudiante()
        {
            Estatus = true;
        }
    }
}