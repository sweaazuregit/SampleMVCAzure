using SampleMVCAzure.Models;
using Microsoft.EntityFrameworkCore;

namespace SampleMVCAzure.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Users> Users { get; set; } 
    }
}