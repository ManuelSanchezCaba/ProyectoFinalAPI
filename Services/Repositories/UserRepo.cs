using Microsoft.EntityFrameworkCore;
using Models;
using Models.Models;
using Services.Common;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public class UserRepo : IUser
    {
        private readonly AppDBContext _db;

        public UserRepo(AppDBContext db)
        {
            _db = db;
        }

        public async Task<object> getAllUser()
        {
            try
            {
                var users = await _db.User.ToListAsync();
                return new { users };
            }
            catch (Exception ex)
            {
                return new { msg = ex.Message };
            }
        }

        public async Task<object> getUserByID(int id)
        {
            try
            {
                var user = await _db.User.Where(x => x.Id == id).FirstOrDefaultAsync();
                return new { user };
            }
            catch (Exception ex)
            {
                return new { msg = ex.Message };
            }
        }

        public async Task<object> createUser(User user)
        {
            try
            {
                user.Password = CommonMethods.EncryptPassword(user.Password);
                await _db.AddAsync(user);
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

        public async Task<object> updateUser(User user)
        {
            try
            {
                _db.Update(user);
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

        public async Task<object> deleteUser(int id)
        {
            try
            {
                var user = await _db.User.FirstOrDefaultAsync(x => x.Id == id);

                if (user == null) return new
                {
                    msg = "Estatus no Existe"
                };

                _db.Remove(user);
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
