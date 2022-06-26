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
    public class StudentInstitutionRepo : GenericCRUD<StudentInstitution>, IStudentInstitution
    {
        private readonly AppDBContext _db;

        public StudentInstitutionRepo(AppDBContext db) : base(db) { _db = db; }
    }
}
