using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUser
    {
        public Task<object> getAllUser();
        public Task<object> getUserByID(int id);
        public Task<object> createUser(User user);
        public Task<object> updateUser(User user);
        public Task<object> deleteUser(int id);
    }
}
