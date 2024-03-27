using Microsoft.EntityFrameworkCore;
using YappaDevChallenge.Model;

namespace YappaDevChallenge.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clientes { get; set; }
    }
}
