using Microsoft.EntityFrameworkCore;

namespace Model{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options): base(options)
        {
        }
        public DbSet<Topscorer> Topscorers {get; set;}
        public DbSet<Coach> Coaches {get; set;}
    }

}