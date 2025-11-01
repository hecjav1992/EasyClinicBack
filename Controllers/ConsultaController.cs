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

        public ConsultaController( AppDbContext context ) {
        _context = context;
        }

        public async Task<IActionResult>get([FromQuery] int? minId)
        {
            var pacientes = await _context.Pacientes
                .Where(u => (u.Id_pacientes_data.ToString().Contains(minId.Value.ToString())))
                .OrderBy(u => u.Id_pacientes_data)
                .Select(u => new {
                    u.Id_pacientes_data,
                    u.nombre,
                    u.genero_paciente,
                    u.Ocupacion_paciente
      
                })
                .Take(10)
                .ToListAsync();
            return Ok(new
            {
                message = pacientes
            });
        }
     
    }
}
