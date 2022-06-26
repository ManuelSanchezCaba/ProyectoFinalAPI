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
    public class LicenseRepo : GenericCRUD<License>, ILicense
    {
        private readonly AppDBContext _db;

        public LicenseRepo(AppDBContext db) : base(db) { _db = db; }

        public async Task<object> getLicenseByID(string id)
        {
            try
            {
                var entity = await _db.License.FindAsync(id);
                return new { entity };
            }
            catch (Exception ex)
            {
                return new { msg = ex.Message };
            }
        }

        public async Task<object> deleteLicense(string id)
        {
            try
            {
                var entity = await _db.License.FindAsync(id);

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
