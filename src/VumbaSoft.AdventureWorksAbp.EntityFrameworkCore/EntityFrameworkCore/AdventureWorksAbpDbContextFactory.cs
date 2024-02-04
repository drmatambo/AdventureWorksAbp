using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace VumbaSoft.AdventureWorksAbp.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class AdventureWorksAbpDbContextFactory : IDesignTimeDbContextFactory<AdventureWorksAbpDbContext>
{
    public AdventureWorksAbpDbContext CreateDbContext(string[] args)
    {
        AdventureWorksAbpEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<AdventureWorksAbpDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new AdventureWorksAbpDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../VumbaSoft.AdventureWorksAbp.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
