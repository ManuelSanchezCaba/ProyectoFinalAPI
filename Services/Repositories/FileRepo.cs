using Models;
using Models.Models;
using Services.Common;
using Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public class FileRepo : GenericCRUD<File>, IFile
    {
        private readonly AppDBContext _db;

        public FileRepo(AppDBContext db) : base(db) { _db = db; }

        public async Task<File> getFile(int id)
        {
            try
            {
                var file = await _db.File.FindAsync(id);
                return file;
            }
            catch (Exception ex)
            {
                return new File();
            }
        }
    }
}
