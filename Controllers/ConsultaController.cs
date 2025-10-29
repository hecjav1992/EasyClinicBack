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

        public async Task<IActionResult>get()
        {
            var pacientes = await _context.Pacientes
                .Where(u => u.Id_pacientes_data == 1)
                .Select(u => new {
                    u.Id_pacientes_data,
                    u.genero_paciente,
                    u.FN_paciente,
                    u.Ocupacion_paciente
      
                })
                .FirstOrDefaultAsync();
            return Ok(pacientes);
        }
     
    }
}
