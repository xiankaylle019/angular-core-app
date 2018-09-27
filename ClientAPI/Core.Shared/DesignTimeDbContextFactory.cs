using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ClientAPI.Core.Shared
{
    public class DesignTimeDbContextFactory<TContext> : IDesignTimeDbContextFactory<TContext>
       where TContext : DbContext
    {

        public TContext CreateDbContext(string[] args)

        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(System.IO.Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var builder = new DbContextOptionsBuilder<TContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            var dbContext = (TContext)System.Activator.CreateInstance(typeof(TContext),builder.Options);

            return dbContext;
        }
    }
}