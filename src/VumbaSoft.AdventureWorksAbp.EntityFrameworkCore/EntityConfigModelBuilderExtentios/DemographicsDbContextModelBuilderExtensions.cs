using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using VumbaSoft.AdventureWorksAbp.Demographics.Continents;
using VumbaSoft.AdventureWorksAbp.Demographics.Countries;
using VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities;
using VumbaSoft.AdventureWorksAbp.Demographics.Localities;
using VumbaSoft.AdventureWorksAbp.Demographics.Regions;
using VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces;
using VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents;

namespace VumbaSoft.AdventureWorksAbp.EntitiesConfigBuilderExtentions
{
    public static class DemographicsDbContextModelBuilderExtensions
    {
        public static void ConfigureDemographics([NotNull] this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<Continent>(b =>
            {
                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "Continents", 
                    AdventureWorksAbpSharedConsts.DemographicsDbSchema, 
                    table => table.HasComment("Continent  DataTable")
                );

                b.ConfigureByConvention();

                b.HasIndex(x => x.Name, "AK_Continent_Name").IsUnique();
                b.Property(x => x.Name).HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength);
                b.Property(x => x.Population).HasColumnType("bigint").HasDefaultValue(((0)));
                b.HasMany(x => x.Subcontinents).WithOne().HasForeignKey(x => x.ContinentId).IsRequired().OnDelete(DeleteBehavior.NoAction);
                b.Property(x => x.Remarks).HasMaxLength(AdventureWorksAbpSharedConsts.NotesMaxLength);
            });

            builder.Entity<Subcontinent>(b =>
            {
                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "Subcontinents", 
                    AdventureWorksAbpSharedConsts.DemographicsDbSchema, 
                    table => table.HasComment("Subcontinents  DataTable")
                );

                b.ConfigureByConvention(); //auto configure for the base class props

                b.HasIndex(x => new {x.ContinentId, x.Name }, "AK_Continent_SubcontinentName" ).IsUnique();
                b.Property(x => x.Name).HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength);
                b.Property(x => x.ContinentId);
                b.Property(x => x.Population).HasColumnType("bigint").HasDefaultValue(((0)));
                b.HasMany(x => x.Countries).WithOne().HasForeignKey(x => x.SubcontinentId).IsRequired().OnDelete(DeleteBehavior.NoAction);
                b.Property(x => x.Remarks).HasMaxLength(AdventureWorksAbpSharedConsts.NotesMaxLength);
            });

            builder.Entity<Country>(b =>
            {
                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "Countries", 
                    AdventureWorksAbpSharedConsts.DemographicsDbSchema, 
                    table => table.HasComment("Countries  DataTable")
                );

                b.ConfigureByConvention(); //auto configure for the base class props

                b.HasIndex(x => new {x.ContinentId, x.SubcontinentId, x.Name }, "AK_Continent_Subcontinente_CountryName").IsUnique();
                b.Property(x => x.ContinentId);
                b.Property(x => x.SubcontinentId);
                b.Property(x => x.Name).HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength);
                b.Property(x => x.FormalName).HasMaxLength(AdventureWorksAbpSharedConsts.StringDefaultMaxLength);
                b.Property(x => x.NativeName).HasMaxLength(AdventureWorksAbpSharedConsts.StringDefaultMaxLength);
                b.Property(x => x.IsoTreeCode).HasMaxLength(AdventureWorksAbpSharedConsts.ISO3MaxLength);
                b.Property(x => x.IsoTwoCode).HasMaxLength(AdventureWorksAbpSharedConsts.ISO2MaxLength);
                b.Property(x => x.CcnTreeCode).HasMaxLength(AdventureWorksAbpSharedConsts.ISO3MaxLength);
                b.Property(x => x.PhoneCode).HasMaxLength(AdventureWorksAbpSharedConsts.PhoneMaxLength);
                b.Property(x => x.Capital).HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength);
                b.Property(x => x.Currency).HasMaxLength(AdventureWorksAbpSharedConsts.ISO3MaxLength);
                b.Property(x => x.Population).HasColumnType("bigint").HasDefaultValue(((0)));
                b.Property(x => x.Emoji).HasMaxLength(AdventureWorksAbpSharedConsts.EmojiMaxLength);
                b.Property(x => x.EmojiU).HasMaxLength(AdventureWorksAbpSharedConsts.EmojiMaxLength);
                b.HasMany(x => x.Regions).WithOne().HasForeignKey(x => x.CountryId).IsRequired().OnDelete(DeleteBehavior.NoAction);
                b.Property(x => x.Remarks).HasMaxLength(AdventureWorksAbpSharedConsts.NotesMaxLength);
            });

            builder.Entity<Region>(b =>
            {
                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "Regions", 
                    AdventureWorksAbpSharedConsts.DemographicsDbSchema, 
                    table => table.HasComment("Regions  DataTable")
                );

                b.ConfigureByConvention(); //auto configure for the base class props

                b.HasIndex(x => new { x.Name, x.CountryId}, "AK_Country_RegionName").IsUnique();
                b.Property(x => x.Name).HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength);
                b.Property(x => x.Population).HasColumnType("bigint").HasDefaultValue(((0)));
                b.Property(x => x.CountryId);
                b.Property(x => x.CountryCode).HasMaxLength(AdventureWorksAbpSharedConsts.ISO3MaxLength);
                b.Property(x => x.RegionCode).HasMaxLength(AdventureWorksAbpSharedConsts.ISO3MaxLength);
                b.HasMany(x => x.StateProvinces).WithOne().HasForeignKey(x => x.RegionId).IsRequired().OnDelete(DeleteBehavior.NoAction);
                b.Property(x => x.Remarks).HasMaxLength(AdventureWorksAbpSharedConsts.NotesMaxLength);
            });
            builder.Entity<StateProvince>(b =>
            {
                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "StateProvinces", 
                    AdventureWorksAbpSharedConsts.DemographicsDbSchema, 
                    table => table.HasComment("StateProvince  DataTable")
                );

                b.ConfigureByConvention(); //auto configure for the base class props

                b.HasIndex(x => new {x.Name, x.CountryId, x.RegionId}, "AK_Country_Region_StateprovinceName").IsUnique();
                b.Property(x => x.CountryId);
                b.Property(x => x.RegionId);
                b.Property(x => x.Name).HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength);
                b.Property(x => x.Population).HasColumnType("bigint").HasDefaultValue(((0)));
                b.Property(x => x.RegionCode).HasMaxLength(AdventureWorksAbpSharedConsts.ISO3MaxLength);
                b.Property(x => x.StateProvinceCode).HasMaxLength(AdventureWorksAbpSharedConsts.ISO3MaxLength);
                b.HasMany(x => x.DistrictCities).WithOne().HasForeignKey(x => x.StateProvinceId).IsRequired().OnDelete(DeleteBehavior.NoAction);
                b.Property(x => x.Remarks).HasMaxLength(AdventureWorksAbpSharedConsts.NotesMaxLength);
            });

            builder.Entity<DistrictCity>(b =>
            {
                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "DistrictCities", 
                    AdventureWorksAbpSharedConsts.DemographicsDbSchema, 
                    table => table.HasComment("DistrictCities  DataTable")
                );

                b.ConfigureByConvention(); //auto configure for the base class props

                b.HasIndex(x => new { x.Name, x.CountryId, x.StateProvinceId }, "AK_Country_Province_DistrictcityName").IsUnique();
                b.Property(x => x.CountryId);
                b.Property(x => x.StateProvinceId);
                b.Property(x => x.Name).HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength);
                b.Property(x => x.Population).HasColumnType("bigint").HasDefaultValue(((0)));
                b.Property(x => x.StateProvinceCode).HasMaxLength(AdventureWorksAbpSharedConsts.ISO3MaxLength);
                b.Property(x => x.CountryCode).HasMaxLength(AdventureWorksAbpSharedConsts.ISO3MaxLength);
                b.Property(x => x.Latitude).HasColumnType("decimal (12, 9)").HasDefaultValue(((0.000000000)));
                b.Property(x => x.Longitude).HasColumnType("decimal(12, 9)").HasDefaultValue(((0.000000000))); ;
                b.HasMany(x => x.Localities).WithOne().HasForeignKey(x => x.DistrictCityId).IsRequired().OnDelete(DeleteBehavior.NoAction);
                b.Property(x => x.Remarks).HasMaxLength(AdventureWorksAbpSharedConsts.NotesMaxLength);
            });

            builder.Entity<Locality>(b =>
            {
                b.ToTable(AdventureWorksAbpSharedConsts.DbTablePrefix + "Localities", 
                    AdventureWorksAbpSharedConsts.DemographicsDbSchema, 
                    table => table.HasComment("Localities DataTable")
                );

                b.ConfigureByConvention(); //auto configure for the base class props

                b.HasIndex(x => new { x.Name, x.StateProvinceId, x.DistrictCityId}, "AK_District_LocalityName").IsUnique();
                b.Property(x => x.ContinentId).IsRequired();
                b.Property(x => x.SubcontinentId).IsRequired();
                b.Property(x => x.CountryId).IsRequired();
                b.Property(x => x.RegionId).IsRequired();
                b.Property(x => x.StateProvinceId).IsRequired();
                b.Property(x => x.DistrictCityId).IsRequired();
                b.Property(x => x.Name).HasMaxLength(AdventureWorksAbpSharedConsts.NameMaxLength);
                b.Property(x => x.Population).HasColumnType("bigint").HasDefaultValue(((0)));
                b.Property(x => x.DistrictCityCode).HasMaxLength(AdventureWorksAbpSharedConsts.ISO3MaxLength);
                b.Property(x => x.LocalityCode).HasMaxLength(AdventureWorksAbpSharedConsts.ISO3MaxLength);
                b.Property(x => x.Latitude).HasColumnType("decimal(12, 9)").HasDefaultValue(((0.000000000))); ;
                b.Property(x => x.Longitude).HasColumnType("decimal(12, 9)").HasDefaultValue(((0.000000000))); ;
                b.Property(x => x.Remarks).HasMaxLength(AdventureWorksAbpSharedConsts.NotesMaxLength);
            });
        }
    }
}
