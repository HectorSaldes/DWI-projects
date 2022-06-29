namespace escuela
{
    public class Carrera
    {
        private int id;
        private string nombre;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string? Nombre
        {
            get;
            set;
        }

        public Carrera()
        {
            Nombre = "";
        }
    }
}