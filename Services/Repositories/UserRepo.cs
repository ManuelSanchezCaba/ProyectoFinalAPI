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
    public class UserRepo : GenericCRUD<User>, IUser
    {
        private readonly AppDBContext _db;

        public UserRepo(AppDBContext db) : base(db) { _db = db; }

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
    }
}
