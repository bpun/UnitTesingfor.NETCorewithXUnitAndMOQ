using BasicCRUDwith.NETCore.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicCRUDwith.NETCore.DbContexts
{
    public class StudentContext :DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
