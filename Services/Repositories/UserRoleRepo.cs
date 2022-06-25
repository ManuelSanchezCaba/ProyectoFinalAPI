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
    public class UserRoleRepo : IUserRole
    {
        private readonly AppDBContext _db;

        public UserRoleRepo(AppDBContext db)
        {
            _db = db;
        }

        public async Task<object> getAllUserRole()
        {
            try
            {
                var userRoles = await _db.UserRole.ToListAsync();
                return new { userRoles };
            }
            catch (Exception ex)
            {
                return new { msg = ex.Message };
            }
        }

        public async Task<object> getUserRoleByID(int id)
        {
            try
            {
                var userRole = await _db.UserRole.Where(x => x.Id == id).FirstOrDefaultAsync();
                return new { userRole };
            }
            catch (Exception ex)
            {
                return new { msg = ex.Message };
            }
        }

        public async Task<object> createUserRole(UserRole userRole)
        {
            try
            {
                await _db.AddAsync(userRole);
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

        public async Task<object> updateUserRole(UserRole userRole)
        {
            try
            {
                _db.Update(userRole);
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

        public async Task<object> deleteUserRole(int id)
        {
            try
            {
                var userRole = await _db.UserRole.FirstOrDefaultAsync(x => x.Id == id);

                if (userRole == null) return new
                {
                    msg = "Estatus no Existe"
                };

                _db.Remove(userRole);
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
