using EasyClinic.Server.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EasyClinic.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : Controller
    {
        private readonly AppDbContext _context;

        public ConsultaController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> get([FromQuery] string? minId)
        {
            var query = _context.Pacientes.AsQueryable();

            if (int.TryParse(minId, out int idBuscado))
            {
                query = query.Where(u => u.Id_pacientes_data == idBuscado);
            }
            else if (!string.IsNullOrEmpty(minId))
            {
                query = query.Where(u => u.nombre.Contains(minId));
            }
            var pacientes = await query
                .OrderBy(u => u.Id_pacientes_data)
                .Select(u => new
                {
                    u.Id_pacientes_data,
                    u.cedula,
                    u.nombre,
                    u.FN_paciente,
                    u.genero_paciente,
                    u.Alergias_paciente,
                    u.Apf_paciente,
                    u.App_paciente,
                   

                })
                .Take(10)
                .ToListAsync();
            return Ok(new
            {
                message = pacientes
            });
        }

        [HttpGet("getpaciente")]
        public async Task<IActionResult> getpaciente([FromQuery] int? minId)
        {

            var pacientes = await _context.Pacientes
                .Where(u => u.Id_pacientes_data == minId)
                .Select(u => new
                {
                    u.Id_pacientes_data,
                    u.cedula,
                    u.nombre
                })
                .ToListAsync();
            if (!pacientes.Any())
                return NotFound(new { message = "Paciente no encontrado" });

            return Ok(new
            {
                message = pacientes

            });
        }

        [HttpGet("historialpaciente")]
        public async Task<IActionResult> gethistorial([FromQuery] int? minId)
        {
            var atenciones = await _context.Atencion
                .Where(u=> u.Id_pacientes_data==minId)
                .Select(u => new
                {
                    u.Id_atencion,
                    u.cedula,
                    u.Id_pacientes_data,
                    u.nombre,
                    u.hra,
                    u.peso,
                    u.talla_atencion,
                    u.Fecha_atencion,
                    u.Examenfisico_paciente,
                    u.tratamiento_paciente
                })
                .Distinct()
                .OrderByDescending(u => u.Id_atencion)
                .Take(4)
                .ToListAsync();
            if (!atenciones.Any())
                return NotFound(new { message = "Atencion no encontrado" });

            return Ok(new
            {
                message = atenciones

            });
        }

        [HttpPost("crearPaciente")]
        public async Task<IActionResult> postCrearPaciente([FromBody] Pacientes? datos)
        {
         
            var idP = await _context.Pacientes
           .OrderByDescending(u => u.Id_pacientes_data)
           .Select(u => new
           {
               u.Id_pacientes_data,
           })
           .FirstOrDefaultAsync();
            var nuevo = new Pacientes
            {
                Id_pacientes_data=idP.Id_pacientes_data+1,
                nombre= datos?.nombre,
                apellido_paciente = datos?.apellido_paciente,
                genero_paciente = datos?.genero_paciente,
                cedula = datos?.cedula,
                FN_paciente = DateTime.SpecifyKind((DateTime)datos?.FN_paciente,
                DateTimeKind.Utc),
                telefono_paciente = datos?.telefono_paciente
            };
            bool existeCedula = await _context.Pacientes
                .AnyAsync(u => u.cedula == datos.cedula);
            if (existeCedula)
                return Ok(new { success = false, mensaje = "Cédula ya registrada" });
            await _context.Pacientes.AddAsync(nuevo);
            await _context.SaveChangesAsync();

            return Ok(new { success = true, mensaje = nuevo });



        }
    }
}
