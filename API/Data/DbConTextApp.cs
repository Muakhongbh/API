using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DbConTextApp : DbContext
    {
        public DbConTextApp() { }
        public DbConTextApp(DbContextOptions<DbConTextApp> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-1T27T93I\\SQLEXPRESS01;Database=Demo_C6;Trusted_Connection=True;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Strudent> Strudents { get; set; }

    }
}
