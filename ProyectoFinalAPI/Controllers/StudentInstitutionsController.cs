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
    public class StudentInstitutionsController : Controller
    {
        private readonly StudentInstitutionRepo _db;

        public StudentInstitutionsController(StudentInstitutionRepo db)
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
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var role = await _db.getByID(id);
                return Ok(role);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentInstitution studentInstitution)
        {
            try
            {
                var res = await _db.create(studentInstitution);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] StudentInstitution studentInstitution)
        {
            try
            {
                var res = await _db.update(studentInstitution);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var res = await _db.delete(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
