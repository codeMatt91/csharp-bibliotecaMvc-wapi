using csharp_bibliotecaMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace csharp_bibliotecaMvc.Data
{
    public class AutoriContext : DbContext
    {
        public AutoriContext(DbContextOptions<AutoriContext> options) : base(options)
        {
        }

        public DbSet<Autori> Autoris { get; set; }
    }
}
