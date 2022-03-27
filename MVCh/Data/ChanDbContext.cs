using Microsoft.EntityFrameworkCore;
using MVCh.Models;

namespace MVCh.Data
{
    public class ChanDbContext : DbContext
    {
        public ChanDbContext(DbContextOptions<ChanDbContext> options) : base(options)
        {

        }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Models.Thread> Threads { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
