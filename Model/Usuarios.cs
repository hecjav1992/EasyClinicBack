using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyClinic.Server.Model
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Key]
        public int id_usuario { get; set; }
        public string usuario { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string rol { get; set; }
        public string contrasena { get; set; }
    }
}
