using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Services.Repositories;
using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace ProyectoFinalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : Controller
    {
        private readonly FileRepo _db;
        private IHostEnvironment _hosting;

        public FileController(FileRepo db, IHostEnvironment hosting)
        {
            _db = db;
            _hosting = hosting;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int ID)
        {
            try
            {
                string ruta = null;
                var file = await _db.getFile(ID);

                using (var memoryStream = new MemoryStream())
                {
                    using (var ziparchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                    {
                        ruta = Path.Combine(_hosting.ContentRootPath, "Files") + "\\" + file.Path;
                        ziparchive.CreateEntryFromFile(ruta, file.Path);
                    }

                    return File(memoryStream.ToArray(), "application/zip", "Archivos.zip");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] IFormFile Input)
        {
            Models.Models.File file = new Models.Models.File();
            string fichero = null, guidFile = null, ruta = null;
            double tamano;

            try
            {
                if (Input != null)
                {
                    fichero = Path.Combine(_hosting.ContentRootPath, "Files");
                    guidFile = Guid.NewGuid().ToString() + "_" + Input.FileName;
                    ruta = Path.Combine(fichero, guidFile);
                    Input.CopyTo(new FileStream(ruta, FileMode.Create));
                    tamano = Input.Length;

                    file = new Models.Models.File();
                    file.Extension = Path.GetExtension(Input.FileName).Substring(1);
                    file.Name = Input.FileName;
                    file.Size = Math.Round((tamano / 1000000), 2);
                    file.Path = guidFile;

                    await _db.create(file);
                }

                return Ok(file.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
