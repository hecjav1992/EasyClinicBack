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

        public async Task<IActionResult> Get([FromQuery] string? filtro)
        {
            // Empezamos con la query base
            var query = _context.Pacientes.AsQueryable();

            if (!string.IsNullOrEmpty(filtro))
            {
                // Verificamos si el filtro es numérico
                bool esNumero = int.TryParse(filtro, out int idBuscado);

                query = query.Where(u =>
                    (esNumero && u.Id_pacientes_data == idBuscado) || // búsqueda por número exacto
                    u.nombre.ToLower().Contains(filtro.ToLower())      // búsqueda por nombre
                );
            }

            var pacientes = await query
                .OrderBy(u => u.Id_pacientes_data)
                .Select(u => new
                {
                    u.Id_pacientes_data,
                    u.cedula,
                    u.nombre,
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
