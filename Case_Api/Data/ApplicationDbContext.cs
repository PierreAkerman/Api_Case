using Case_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Case_Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Advertizer> Ads { get; set; }
    }
}
