using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Status> Status { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Institution> Institution { get; set; }
        public DbSet<TeacherInstitution> TeacherInstitution { get; set; }
        public DbSet<StudentInstitution> StudentInstitution { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<SectionHeader> SectionHeader { get; set; }
        public DbSet<SectionDetail> SectionDetail { get; set; }
        public DbSet<PiServer> PiServer { get; set; }
        public DbSet<License> License { get; set; }
        public DbSet<File> File { get; set; }
        public DbSet<Exercise> Exercise { get; set; }
    }
}
