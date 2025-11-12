using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyClinic.Server.Model
{
    [Table("ATENCIONES")]
    public class Atencion
    {
        [Key]
        public int Id_atencion { get; set; }
        public int Id_pacientes_data { get; set; }
        [Column("nombres_paciente")]
        public string? nombre { get; set; }
        public string? genero_paciente { get; set; }
        [Column("cedula_paciente")]
        public string? cedula { get; set; }
        public string? telefono { get; set; }
        public string? telefono_paciente { get; set; }
        public string? Ocupacion_paciente { get; set; }
        public DateTime? FN_paciente { get; set; }
        public int edad_paciente { get; set; }
        public string? Direccion_paciente { get; set; }
        [Column("HEA")]
        public string? hra { get; set; }

        public DateTime? Fecha_atencion { get;set; }
        public float? peso { get; set; }
        public float? talla_atencion { get; set; }

        public string? Examenfisico_paciente { get; set; }
    }
}
