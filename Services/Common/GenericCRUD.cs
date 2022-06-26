using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common
{
    public class GenericCRUD<T> where T : class
    {
        private readonly AppDBContext _db;

        public GenericCRUD(AppDBContext db)
        {
            _db = db;
        }

        public virtual async Task<object> getAll()
        {
            try
            {
                var list = await _db.Set<T>().ToListAsync();
                return new { list };
            }
            catch (Exception ex)
            {
                return new { msg = ex.Message };
            }
        }

        public virtual async Task<object> getByID(int id)
        {
            try
            {
                var entity = await _db.Set<T>().FindAsync(id);
                return new { entity };
            }
            catch (Exception ex)
            {
                return new { msg = ex.Message };
            }
        }

        public virtual async Task<object> create(T entity)
        {
            try
            {
                await _db.Set<T>().AddAsync(entity);
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

        public virtual async Task<object> update(T entity)
        {
            try
            {
                _db.Set<T>().Update(entity);
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

        public virtual async Task<object> delete(int id)
        {
            try
            {
                var entity = await _db.Set<T>().FindAsync(id);

                if (entity == null) return new
                {
                    msg = "Entidad no Existe"
                };

                _db.Remove(entity);
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
