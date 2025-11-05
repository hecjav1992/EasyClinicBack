using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                    u.genero_paciente
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
                    u.hra
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
    }
}
