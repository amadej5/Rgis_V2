using Microsoft.EntityFrameworkCore;

namespace Rgis_V2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Definirajte DbSet za entitete, ki jih želite shranjevati v bazo
        public DbSet<Letalo> Letalo { get; set; }
    }
}
