using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Services.Repositories;
using System;
using System.Threading.Tasks;

namespace ProyectoFinalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LicenseController : Controller
    {
        private readonly LicenseRepo _db;

        public LicenseController(LicenseRepo db)
        {
            _db = db;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var roles = await _db.getAll();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("{code}")]
        public async Task<IActionResult> Get(string code)
        {
            try
            {
                var role = await _db.getLicenseByID(code);
                return Ok(role);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] License license)
        {
            try
            {
                var res = await _db.create(license);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] License license)
        {
            try
            {
                var res = await _db.update(license);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            try
            {
                var res = await _db.deleteLicense(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
