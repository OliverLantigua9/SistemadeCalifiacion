using Microsoft.AspNetCore.Mvc;

namespace SistemadeCalifiacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (model.Username == "admin" && model.Password == "1234")
            {
                return Ok(new { token = "login completado" });
            }
            return Unauthorized("Credenciales inválidas");
        }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}