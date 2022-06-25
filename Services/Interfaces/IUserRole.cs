using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserRole
    {
        public Task<object> getAllUserRole();
        public Task<object> getUserRoleByID(int id);
        public Task<object> createUserRole(UserRole userRole);
        public Task<object> updateUserRole(UserRole userRole);
        public Task<object> deleteUserRole(int id);
    }
}
