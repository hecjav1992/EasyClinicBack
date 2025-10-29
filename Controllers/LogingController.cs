using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyClinic.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogingController : ControllerBase
    {

        private readonly AppDbContext _context;

        public LogingController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Post([FromBody]  LoginRequest request)
        {
            var user = await _context.Usuarios
            .Where(u => u.usuario == request.usuario && u.contrasena == request.contrasena)
            .Select(u => new {
                u.id_usuario,
                u.usuario,
                u.contrasena,
                u.rol
            })
             .FirstOrDefaultAsync();

            if (user != null)
            {

                return Ok(new { success = true, token = "token_generado_123", message = user.rol,nombre=user.usuario });
            }

            return Unauthorized(new { success = false, message = "Credenciales inválidas" });

           

        }

        public class LoginRequest
        {
            public string? usuario { get; set; }
            public string? contrasena { get; set; }
            public string? rol { get; set; }
        }


    }
}
