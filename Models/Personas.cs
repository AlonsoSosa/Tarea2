using SQLite;

namespace Tarea2.Models
{
    public class Personas
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [MaxLength(100)]
        public string nombres { get; set; }
        [MaxLength(100)]
        public string apellidos { get; set; } = string.Empty;
        public DateTime fechanac { get; set; }
        [MaxLength(30), Unique]
        public string telefono { get; set; }
        [MaxLength(100)]
        public byte[] foto { get; set; }

    }
}