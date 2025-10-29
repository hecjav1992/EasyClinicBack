using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel.DataAnnotations;

namespace EasyClinic.Server.Model
{
    [Table("PACIENTES_DATA")]
    public class Pacientes
    {
        public int Id_pacientes_data {  get; set; }
        public string genero_paciente {  get; set; }
        public string cedula { get; set; }
        public string telefono { get; set; }
        public string telefono_paciente { get;set; }    
        public string Ocupacion_paciente { get; set; }
        public string FN_paciente { get; set; }
        public int edad_paciente { get; set; }
        public string Direccion_paciente { get; set; }
    }
}
