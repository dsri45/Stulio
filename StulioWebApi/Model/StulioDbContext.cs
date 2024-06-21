using Microsoft.EntityFrameworkCore;

namespace StulioWebAPI.Model
{
    public class StulioDbContext : DbContext
    {
        public StulioDbContext() {}
        public StulioDbContext(DbContextOptions<StulioDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                // optionsBuilder.UseSqlServer("Server=tcp:stulio.database.windows.net,1433;Initial Catalog=stuliodb;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication=Active Directory Default;");
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-FQBIBJN\\STULIO;Initial Catalog=stuliodb;User Id=sa;Password=Dhanasri7*;;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");
            }
             
        }

        

public DbSet<Users> Users { get; set; } = null!;
        // Add DbSet properties for other entities as needed
    }
   
    
}
