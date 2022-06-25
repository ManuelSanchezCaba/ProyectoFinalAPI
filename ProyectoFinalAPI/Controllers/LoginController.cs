using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace ProyectoFinalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly IAuth _db;

        public LoginController(IAuth db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            try
            {
                var token = await _db.getToken(login.username, login.password);

                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
