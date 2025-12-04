using Microsoft.EntityFrameworkCore;
using Persistence;

namespace StudentDto
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> students { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

    }
}
