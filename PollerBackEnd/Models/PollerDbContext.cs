using Microsoft.EntityFrameworkCore;
using PollerBackEnd.Models.Content;
using PollerBackEnd.Models.Core;

namespace PollerBackEnd.Models
{
    public class PollerDbContext : DbContext
    {
        public PollerDbContext(DbContextOptions<PollerDbContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Space> Space { get; set; }
    }

}