using VumbaSoft.AdventureWorksAbp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace VumbaSoft.AdventureWorksAbp.Permissions;

public class AdventureWorksAbpPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        /******************************************************************
        * Crear grupo de los permisos para mantenerlos agrupados en la gestion de permisos del grupo
        ******************************************************************/

        var DemographicsGroup = context.AddGroup(AdventureWorksAbpPermissions.DemographicsGroupName);
        //var HumanResourcesGroup = context.AddGroup(AdventureWorksAbpPermissions.HumanResourcesGroupName);
        //var PersonsGroupGroup = context.AddGroup(AdventureWorksAbpPermissions.PersonsGroupName);
        //var ProductionGroup = context.AddGroup(AdventureWorksAbpPermissions.ProductionGroupName);
        //var PurchasingGroup = context.AddGroup(AdventureWorksAbpPermissions.PurchasingGroupName);
        //var SalesGroup = context.AddGroup(AdventureWorksAbpPermissions.SalesGroupName);

        var continentPermission = DemographicsGroup.AddPermission(AdventureWorksAbpPermissions.Continent.Default, L("Permission:Continent"));
        continentPermission.AddChild(AdventureWorksAbpPermissions.Continent.Create, L("Permission:Create"));
        continentPermission.AddChild(AdventureWorksAbpPermissions.Continent.Update, L("Permission:Update"));
        continentPermission.AddChild(AdventureWorksAbpPermissions.Continent.Delete, L("Permission:Delete"));

        var subcontinentPermission = DemographicsGroup.AddPermission(AdventureWorksAbpPermissions.Subcontinent.Default, L("Permission:Subcontinent"));
        subcontinentPermission.AddChild(AdventureWorksAbpPermissions.Subcontinent.Create, L("Permission:Create"));
        subcontinentPermission.AddChild(AdventureWorksAbpPermissions.Subcontinent.Update, L("Permission:Update"));
        subcontinentPermission.AddChild(AdventureWorksAbpPermissions.Subcontinent.Delete, L("Permission:Delete"));

        var countryPermission = DemographicsGroup.AddPermission(AdventureWorksAbpPermissions.Country.Default, L("Permission:Country"));
        countryPermission.AddChild(AdventureWorksAbpPermissions.Country.Create, L("Permission:Create"));
        countryPermission.AddChild(AdventureWorksAbpPermissions.Country.Update, L("Permission:Update"));
        countryPermission.AddChild(AdventureWorksAbpPermissions.Country.Delete, L("Permission:Delete"));

        var regionPermission = DemographicsGroup.AddPermission(AdventureWorksAbpPermissions.Region.Default, L("Permission:Region"));
        regionPermission.AddChild(AdventureWorksAbpPermissions.Region.Create, L("Permission:Create"));
        regionPermission.AddChild(AdventureWorksAbpPermissions.Region.Update, L("Permission:Update"));
        regionPermission.AddChild(AdventureWorksAbpPermissions.Region.Delete, L("Permission:Delete"));

        var stateProvincePermission = DemographicsGroup.AddPermission(AdventureWorksAbpPermissions.StateProvince.Default, L("Permission:StateProvince"));
        stateProvincePermission.AddChild(AdventureWorksAbpPermissions.StateProvince.Create, L("Permission:Create"));
        stateProvincePermission.AddChild(AdventureWorksAbpPermissions.StateProvince.Update, L("Permission:Update"));
        stateProvincePermission.AddChild(AdventureWorksAbpPermissions.StateProvince.Delete, L("Permission:Delete"));

        var districtCityPermission = DemographicsGroup.AddPermission(AdventureWorksAbpPermissions.DistrictCity.Default, L("Permission:DistrictCity"));
        districtCityPermission.AddChild(AdventureWorksAbpPermissions.DistrictCity.Create, L("Permission:Create"));
        districtCityPermission.AddChild(AdventureWorksAbpPermissions.DistrictCity.Update, L("Permission:Update"));
        districtCityPermission.AddChild(AdventureWorksAbpPermissions.DistrictCity.Delete, L("Permission:Delete"));

        var localityPermission = DemographicsGroup.AddPermission(AdventureWorksAbpPermissions.Locality.Default, L("Permission:Locality"));
        localityPermission.AddChild(AdventureWorksAbpPermissions.Locality.Create, L("Permission:Create"));
        localityPermission.AddChild(AdventureWorksAbpPermissions.Locality.Update, L("Permission:Update"));
        localityPermission.AddChild(AdventureWorksAbpPermissions.Locality.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AdventureWorksAbpResource>(name);
    }
}
