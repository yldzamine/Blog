using Blog.Entity.Config;
using Microsoft.EntityFrameworkCore;
using Blog.Entity.Models;

namespace Blog.DataAccess.Concrete
{
    public class DBEFContext : DbContext
    {
        private readonly ConnectionStrings _connectionStrings;

        public DBEFContext(ConnectionStrings connectionStrings)
        {
            _connectionStrings = connectionStrings;
        }

        public DBEFContext(DbContextOptions<DBEFContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionStrings.DbConnection);
        }

        public DbSet<Blogs>? Blogs { get; set; }
        public DbSet<Category>? Category { get; set; }

    }
}
