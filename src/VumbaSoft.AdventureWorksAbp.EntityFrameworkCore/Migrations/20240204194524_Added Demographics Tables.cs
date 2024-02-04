using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VumbaSoft.AdventureWorksAbp.Migrations
{
    /// <inheritdoc />
    public partial class AddedDemographicsTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Demographics");

            migrationBuilder.AddColumn<bool>(
                name: "Activated",
                table: "AbpTenants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ActivatedDate",
                table: "AbpTenants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ActivatedReason",
                table: "AbpTenants",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BillPaidDate",
                table: "AbpTenants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "BusinessName",
                table: "AbpTenants",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomCareTypeId",
                table: "AbpTenants",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "Disabled",
                table: "AbpTenants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DisabledReason",
                table: "AbpTenants",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Host",
                table: "AbpTenants",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsInTrial",
                table: "AbpTenants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "AbpTenants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPremium",
                table: "AbpTenants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVip",
                table: "AbpTenants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "LocalityId",
                table: "AbpTenants",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "LockedDate",
                table: "AbpTenants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LockedReason",
                table: "AbpTenants",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoPath",
                table: "AbpTenants",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NextBillingDate",
                table: "AbpTenants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte>(
                name: "NextBillingDiscount",
                table: "AbpTenants",
                type: "tinyint",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<DateTime>(
                name: "PaidEndDate",
                table: "AbpTenants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "PaidOut",
                table: "AbpTenants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaidStartDate",
                table: "AbpTenants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "PeriodPaidOutId",
                table: "AbpTenants",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "AbpTenants",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "AbpTenants",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenantConnectionString",
                table: "AbpTenants",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "TrialEndDate",
                table: "AbpTenants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TrialStartDate",
                table: "AbpTenants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Upgraded",
                table: "AbpTenants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpgradedDate",
                table: "AbpTenants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "AppContinents",
                schema: "Demographics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Population = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    Remarks = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppContinents", x => x.Id);
                },
                comment: "Continent  DataTable");

            migrationBuilder.CreateTable(
                name: "AppSubcontinents",
                schema: "Demographics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ContinentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Population = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    Remarks = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSubcontinents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppSubcontinents_AppContinents_ContinentId",
                        column: x => x.ContinentId,
                        principalSchema: "Demographics",
                        principalTable: "AppContinents",
                        principalColumn: "Id");
                },
                comment: "Subcontinents  DataTable");

            migrationBuilder.CreateTable(
                name: "AppCountries",
                schema: "Demographics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContinentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubcontinentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    FormalName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    NativeName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    IsoTreeCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    IsoTwoCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    CcnTreeCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    PhoneCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Capital = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Population = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    Emoji = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    EmojiU = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCountries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppCountries_AppSubcontinents_SubcontinentId",
                        column: x => x.SubcontinentId,
                        principalSchema: "Demographics",
                        principalTable: "AppSubcontinents",
                        principalColumn: "Id");
                },
                comment: "Countries  DataTable");

            migrationBuilder.CreateTable(
                name: "AppRegions",
                schema: "Demographics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Population = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    RegionCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRegions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppRegions_AppCountries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Demographics",
                        principalTable: "AppCountries",
                        principalColumn: "Id");
                },
                comment: "Regions  DataTable");

            migrationBuilder.CreateTable(
                name: "AppStateProvinces",
                schema: "Demographics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Population = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    RegionCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    StateProvinceCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppStateProvinces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppStateProvinces_AppRegions_RegionId",
                        column: x => x.RegionId,
                        principalSchema: "Demographics",
                        principalTable: "AppRegions",
                        principalColumn: "Id");
                },
                comment: "StateProvince  DataTable");

            migrationBuilder.CreateTable(
                name: "AppDistrictCities",
                schema: "Demographics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StateProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Population = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    StateProvinceCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(12,9)", nullable: false, defaultValue: 0m),
                    Longitude = table.Column<decimal>(type: "decimal(12,9)", nullable: false, defaultValue: 0m),
                    Remarks = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppDistrictCities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppDistrictCities_AppStateProvinces_StateProvinceId",
                        column: x => x.StateProvinceId,
                        principalSchema: "Demographics",
                        principalTable: "AppStateProvinces",
                        principalColumn: "Id");
                },
                comment: "DistrictCities  DataTable");

            migrationBuilder.CreateTable(
                name: "AppLocalities",
                schema: "Demographics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContinentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubcontinentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StateProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DistrictCityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Population = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    DistrictCityCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    LocalityCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(12,9)", nullable: false, defaultValue: 0m),
                    Longitude = table.Column<decimal>(type: "decimal(12,9)", nullable: false, defaultValue: 0m),
                    Remarks = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppLocalities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppLocalities_AppDistrictCities_DistrictCityId",
                        column: x => x.DistrictCityId,
                        principalSchema: "Demographics",
                        principalTable: "AppDistrictCities",
                        principalColumn: "Id");
                },
                comment: "Localities DataTable");

            migrationBuilder.CreateIndex(
                name: "AK_Continent_Name",
                schema: "Demographics",
                table: "AppContinents",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Continent_Subcontinente_CountryName",
                schema: "Demographics",
                table: "AppCountries",
                columns: new[] { "ContinentId", "SubcontinentId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppCountries_SubcontinentId",
                schema: "Demographics",
                table: "AppCountries",
                column: "SubcontinentId");

            migrationBuilder.CreateIndex(
                name: "AK_Country_Province_DistrictcityName",
                schema: "Demographics",
                table: "AppDistrictCities",
                columns: new[] { "Name", "CountryId", "StateProvinceId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppDistrictCities_StateProvinceId",
                schema: "Demographics",
                table: "AppDistrictCities",
                column: "StateProvinceId");

            migrationBuilder.CreateIndex(
                name: "AK_District_LocalityName",
                schema: "Demographics",
                table: "AppLocalities",
                columns: new[] { "Name", "StateProvinceId", "DistrictCityId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppLocalities_DistrictCityId",
                schema: "Demographics",
                table: "AppLocalities",
                column: "DistrictCityId");

            migrationBuilder.CreateIndex(
                name: "AK_Country_RegionName",
                schema: "Demographics",
                table: "AppRegions",
                columns: new[] { "Name", "CountryId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppRegions_CountryId",
                schema: "Demographics",
                table: "AppRegions",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "AK_Country_Region_StateprovinceName",
                schema: "Demographics",
                table: "AppStateProvinces",
                columns: new[] { "Name", "CountryId", "RegionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppStateProvinces_RegionId",
                schema: "Demographics",
                table: "AppStateProvinces",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "AK_Continent_SubcontinentName",
                schema: "Demographics",
                table: "AppSubcontinents",
                columns: new[] { "ContinentId", "Name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppLocalities",
                schema: "Demographics");

            migrationBuilder.DropTable(
                name: "AppDistrictCities",
                schema: "Demographics");

            migrationBuilder.DropTable(
                name: "AppStateProvinces",
                schema: "Demographics");

            migrationBuilder.DropTable(
                name: "AppRegions",
                schema: "Demographics");

            migrationBuilder.DropTable(
                name: "AppCountries",
                schema: "Demographics");

            migrationBuilder.DropTable(
                name: "AppSubcontinents",
                schema: "Demographics");

            migrationBuilder.DropTable(
                name: "AppContinents",
                schema: "Demographics");

            migrationBuilder.DropColumn(
                name: "Activated",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "ActivatedDate",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "ActivatedReason",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "BillPaidDate",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "BusinessName",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "CustomCareTypeId",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "Disabled",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "DisabledReason",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "Host",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "IsInTrial",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "IsPremium",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "IsVip",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "LocalityId",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "LockedDate",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "LockedReason",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "LogoPath",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "NextBillingDate",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "NextBillingDiscount",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "PaidEndDate",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "PaidOut",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "PaidStartDate",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "PeriodPaidOutId",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "TenantConnectionString",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "TrialEndDate",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "TrialStartDate",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "Upgraded",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "UpgradedDate",
                table: "AbpTenants");
        }
    }
}
