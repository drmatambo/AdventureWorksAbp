namespace VumbaSoft.AdventureWorksAbp.Permissions;

public static class AdventureWorksAbpPermissions
{
    public const string GroupName = "AdventureWorksAbp";

    public const string DemographicsGroupName = "Demographics";
    public const string HumanResourcesGroupName = "HumanResources";
    public const string PersonsGroupName = "Person";
    public const string ProductionGroupName = "Production";
    public const string PurchasingGroupName = "Purchasing";
    public const string SalesGroupName = "Sales";
    public const string CatalogGroupName = "Catalogues";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
    public class Continent
    {
        public const string Default = DemographicsGroupName + ".Continent";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
    public class Subcontinent
    {
        public const string Default = DemographicsGroupName + ".Subcontinent";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
    public class Country
    {
        public const string Default = DemographicsGroupName + ".Country";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
    public class Region
    {
        public const string Default = DemographicsGroupName + ".Region";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
    public class StateProvince
    {
        public const string Default = DemographicsGroupName + ".StateProvince";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
    public class DistrictCity
    {
        public const string Default = DemographicsGroupName + ".DistrictCity";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
    public class Locality
    {
        public const string Default = DemographicsGroupName + ".Locality";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}
