using Microsoft.EntityFrameworkCore;

namespace CityInfoAPI.Entities
{
    public class CityInfoContext : DbContext
    {
        public CityInfoContext(DbContextOptions<CityInfoContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Spot> Spots { get; set; }
        public DbSet<SpotType> SpotTypes { get; set; }
    }
}
