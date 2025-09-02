using Microsoft.EntityFrameworkCore;
using LojaBrinquedos.Models;

namespace LojaBrinquedos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Brinquedo> Brinquedos { get; set; }
    }
}
