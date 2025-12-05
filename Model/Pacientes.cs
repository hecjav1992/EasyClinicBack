using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel.DataAnnotations;

namespace EasyClinic.Server.Model
{
    [Table("PACIENTES_DATA")]
    public class Pacientes
    {
        [Key]
       // public int Id_pacientes_data {  get; set; }
        [Column("nombres_paciente")]
        public  string? nombre { get; set; }
        public string? apellido_paciente { get; set; }
        public string? genero_paciente {  get; set; }
        [Column("cedula_paciente")]
        public string? cedula { get; set; }
        public string? telefono { get; set; }
        public string? telefono_paciente { get;set; }    
        public string? Ocupacion_paciente { get; set; }
        public DateTime?  FN_paciente { get; set; }
        public int? edad_paciente { get; set; }
        public string? Direccion_paciente { get; set; }
        public string? Email_paciente { get; set; }
        public string? App_paciente { get; set; }
        public string? Alergias_paciente { get; set; }
        public string? Apf_paciente { get; set; }
    }
}
