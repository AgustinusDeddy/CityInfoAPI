using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CityInfoAPI.Entities
{
    public class BloggingContextFactory : IDesignTimeDbContextFactory<CityInfoContext>
    {
        public CityInfoContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var options = new DbContextOptionsBuilder<CityInfoContext>();
            options.UseSqlServer(config.GetConnectionString("cityInfoDBConnectionString"));

            return new CityInfoContext(options.Options);
        }
    }
}
