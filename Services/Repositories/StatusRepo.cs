using Microsoft.EntityFrameworkCore;
using Models;
using Models.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public class StatusRepo : IStatus
    {
        private readonly AppDBContext _db;

        public StatusRepo(AppDBContext db)
        {
            _db = db;
        }

        public async Task<object> getAllStatus()
        {
            try
            {
                var statuses = await _db.Status.ToListAsync();
                return new { statuses };
            }
            catch (Exception ex)
            {
                return new { msg = ex.Message };
            }
        }

        public async Task<object> getStatusByID(int id)
        {
            try
            {
                var status = await _db.Status.Where(x => x.Id == id).FirstOrDefaultAsync();
                return new { status };
            }
            catch (Exception ex)
            {
                return new { msg = ex.Message };
            }
        }
        public async Task<object> createStatus(Status status)
        {
            try
            {
                await _db.AddAsync(status);
                await _db.SaveChangesAsync();
                return new
                {
                    msg = "Creado Correctamente"
                };
            }
            catch (Exception ex)
            {
                return new { msg = ex.Message };
            }
        }

        public async Task<object> updateStatus(Status status)
        {
            try
            {
                _db.Update(status);
                await _db.SaveChangesAsync();
                return new
                {
                    msg = "Actualizado Correctamente"
                };
            }
            catch (Exception ex)
            {
                return new { msg = ex.Message };
            }
        }

        public async Task<object> deleteStatus(int id)
        {
            try
            {
                var status = await _db.Status.FirstOrDefaultAsync(x => x.Id == id);

                if (status == null) return new
                {
                    msg = "Estatus no Existe"
                };

                _db.Remove(status);
                await _db.SaveChangesAsync();
                return new
                {
                    msg = "Eliminado Correctamente"
                };
            }
            catch (Exception ex)
            {
                return new { msg = ex.Message };
            }
        }
    }
}
