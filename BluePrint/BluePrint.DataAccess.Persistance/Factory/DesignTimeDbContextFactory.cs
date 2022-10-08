namespace BluePrint.DataAccess.Persistance.Factory
{
    using BluePrint.DataAccess.Persistance.Context;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;
    using System.IO;

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BluePrintContext>
    {
        
        public BluePrintContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                                                 .SetBasePath(Directory.GetCurrentDirectory())
                                                 .AddJsonFile("appsettings.json")
                                                 .AddJsonFile("appsettings.Development.json", optional: true)
                                                 .AddJsonFile("appsettings.Production.json", optional: true)
                                                 .AddJsonFile("appsettings.Staging.json", optional: true)
                                                 .Build();

            var builder = new DbContextOptionsBuilder<BluePrintContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseNpgsql(connectionString);

            return new BluePrintContext(builder.Options);
        }
    }
}
