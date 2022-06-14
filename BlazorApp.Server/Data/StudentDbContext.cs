using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Server.Data
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Students => Set<Student>();

        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }
    }
}