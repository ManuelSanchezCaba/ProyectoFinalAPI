using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IStatus
    {
        public Task<object> getAllStatus();
        public Task<object> getStatusByID(int id);
        public Task<object> createStatus(Status status);
        public Task<object> updateStatus(Status status);
        public Task<object> deleteStatus(int id);
    }
}
