using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ILicense
    {
        public Task<object> getLicenseByID(string id);
        public Task<object> deleteLicense(string id);
    }
}
