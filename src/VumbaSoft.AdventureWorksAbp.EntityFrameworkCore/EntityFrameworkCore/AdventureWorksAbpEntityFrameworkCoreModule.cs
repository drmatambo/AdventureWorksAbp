using VumbaSoft.AdventureWorksAbp.Demographics.Localities;
using VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities;
using VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces;
using VumbaSoft.AdventureWorksAbp.Demographics.Regions;
using VumbaSoft.AdventureWorksAbp.Demographics.Countries;
using VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents;
using VumbaSoft.AdventureWorksAbp.Demographics.Continents;
using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Uow;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace VumbaSoft.AdventureWorksAbp.EntityFrameworkCore;

[DependsOn(
    typeof(AdventureWorksAbpDomainModule),
    typeof(AbpIdentityEntityFrameworkCoreModule),
    typeof(AbpOpenIddictEntityFrameworkCoreModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCoreSqlServerModule),
    typeof(AbpBackgroundJobsEntityFrameworkCoreModule),
    typeof(AbpAuditLoggingEntityFrameworkCoreModule),
    typeof(AbpTenantManagementEntityFrameworkCoreModule),
    typeof(AbpFeatureManagementEntityFrameworkCoreModule)
    )]
public class AdventureWorksAbpEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        AdventureWorksAbpEfCoreEntityExtensionMappings.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<AdventureWorksAbpDbContext>(options =>
        {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
            options.AddDefaultRepositories(includeAllEntities: true);
            options.AddRepository<Continent, ContinentRepository>();
            options.AddRepository<Subcontinent, SubcontinentRepository>();
            options.AddRepository<Country, CountryRepository>();
            options.AddRepository<Region, RegionRepository>();
            options.AddRepository<StateProvince, StateProvinceRepository>();
            options.AddRepository<DistrictCity, DistrictCityRepository>();
            options.AddRepository<Locality, LocalityRepository>();
        });

        Configure<AbpDbContextOptions>(options =>
        {
                /* The main point to change your DBMS.
                 * See also AdventureWorksAbpMigrationsDbContextFactory for EF Core tooling. */
            options.UseSqlServer();
        });

    }
}
