using System.ComponentModel.DataAnnotations;

namespace EasyClinic.Server.Model
{
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
