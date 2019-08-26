using Microsoft.EntityFrameworkCore;

namespace RGProject.Models
{
    public class RGProjectDbContext : DbContext
    {
        public RGProjectDbContext(DbContextOptions<RGProjectDbContext> options)
            : base(options)
        { }
        public DbSet<User> Users { get; set; }
    }
}