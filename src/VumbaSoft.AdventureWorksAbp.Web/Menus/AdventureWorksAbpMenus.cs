namespace VumbaSoft.AdventureWorksAbp.Web.Menus;

public class AdventureWorksAbpMenus
{
    private const string Prefix = "AdventureWorksAbp";
    public const string Home = Prefix + ".Home";

    //Add your menu items here...
    #region Application Groups Menus
    public const string DemographicsGroup = Prefix + ".Demographics";
    public const string HumanRespurcesGroup = Prefix + ".HumanResources";
    public const string PersonGroup = Prefix + ".Person";
    public const string ProductionGroup = Prefix + ".Production";
    public const string PurchasingGroup = Prefix + ".Purchasing";
    public const string SalesGroup = Prefix + ".Sales";
    #endregion

    //Add your menu items here...
    #region Demographics Menus Content
    //public const string Demographics =
    public const string Continent = DemographicsGroup + ".Continent";
    public const string Subcontinent = DemographicsGroup + ".Subcontinent";
    public const string Country = DemographicsGroup + ".Country";
    public const string Region = DemographicsGroup + ".Region";
    public const string StateProvince = DemographicsGroup + ".StateProvince";
    public const string DistrictCity = DemographicsGroup + ".DistrictCity";
    public const string Locality = DemographicsGroup + ".Locality";
    #endregion

    #region Humanresources Menus Content
    public const string Department = HumanRespurcesGroup + ".Department";
    public const string Employee = HumanRespurcesGroup + ".Employee";
    public const string EmployeeDepartmentHistory = HumanRespurcesGroup + ".EmployeeDepartmentHistory";
    public const string EmployeePayHistory = HumanRespurcesGroup + ".EmployeePayHistory";
    public const string JobCandidate = HumanRespurcesGroup + ".JobCandidate";
    public const string Shift = HumanRespurcesGroup + ".Shift";
    #endregion

    #region Person Menus Content
    public const string BusinessEntity = PersonGroup + ".BusinessEntity";
    public const string BusinessEntityAddress = PersonGroup + ".BusinessEntityAddress";
    public const string BusinessEntityContact = PersonGroup + ".BusinessEntityContact";
    public const string ContactType = PersonGroup + ".ContactType";
    public const string CountryRegion = PersonGroup + ".CountryRegion";
    public const string EmailAddress = PersonGroup + ".EmailAddress";
    public const string Password = PersonGroup + ".Password";
    public const string Person = PersonGroup + ".Person";
    public const string PersonPhone = PersonGroup + ".PersonPhone";
    public const string PhoneNumberType = PersonGroup + ".PhoneNumberType";
    public const string PersonStateProvince = PersonGroup + ".PersonStateProvince";
    #endregion

    #region Production Menus content
    public const string BillOfMaterials = ProductionGroup + ".BillOfMaterials";
    public const string Culture = ProductionGroup + ".Culture";
    public const string Document = ProductionGroup + ".Document";
    public const string lllustration = ProductionGroup + ".lllustration";
    public const string Location = ProductionGroup + ".Location";
    public const string Product = ProductionGroup + ".Product";
    public const string ProductCategory = ProductionGroup + ".ProductCategory";
    public const string ProductCostHistory = ProductionGroup + ".ProductCostHistory";
    public const string ProductDescription = ProductionGroup + ".ProductDescription";
    public const string ProductDocument = ProductionGroup + ".ProductDocument";
    public const string Productlnventory = ProductionGroup + ".Productlnventory";
    public const string ProductlistPriceHistory = ProductionGroup + ".ProductlistPriceHistory";
    public const string ProductModel = ProductionGroup + ".ProductModel";
    public const string ProductModellllustration = ProductionGroup + ".ProductModellllustration";
    public const string ProductModelProductDescriptionCulture = ProductionGroup + ".ProductModelProductDescriptionCulture";
    public const string ProductPhoto = ProductionGroup + ".ProductPhoto";
    public const string ProductProductPhoto = ProductionGroup + ".ProductProductPhoto";
    public const string ProductReview = ProductionGroup + ".ProductReview";
    public const string ProductSubcategory = ProductionGroup + ".ProductSubcategory";
    public const string ScrapReason = ProductionGroup + ".ScrapReason";
    public const string TransactionHistory = ProductionGroup + ".TransactionHistory";
    public const string TransactionHistoryArchive = ProductionGroup + ".TransactionHistoryArchive";
    public const string UnitMeasure = ProductionGroup + ".UnitMeasure";
    public const string WorkOrder = ProductionGroup + ".WorkOrder";
    public const string WorkOrderRouting = ProductionGroup + ".WorkOrderRouting";
    #endregion

    #region Purchasing Menu Content
    public const string ProductVendor = PurchasingGroup + ".ProductVendor";
    public const string PurchaseOrderDetail = PurchasingGroup + ".PurchaseOrderDetail";
    public const string PurchaseOrderHeader = PurchasingGroup + ".PurchaseOrderHeader";
    public const string ShipMethod = PurchasingGroup + ".ShipMethod";
    public const string Vendor = PurchasingGroup + ".Vendor";
    #endregion

    #region Sales Menus Content
    public const string CountryRegionCurrency = SalesGroup + ".CountryRegionCurrency";
    public const string CreditCard = SalesGroup + ".CreditCard";
    public const string Currency = SalesGroup + ".Currency";
    public const string CurrencyRate = SalesGroup + ".CurrencyRate";
    public const string Customer = SalesGroup + ".Customer";
    public const string PersonCreditCard = SalesGroup + ".PersonCreditCard";
    public const string SalesOrderDetail = SalesGroup + ".SalesOrderDetail";
    public const string SalesOrderHeader = SalesGroup + ".SalesOrderHeader";
    public const string SalesOrderHeaderSalesReason = SalesGroup + ".SalesOrderHeaderSalesReason";
    public const string SalesPerson = SalesGroup + ".SalesPerson";
    public const string SalesPersonQuotaHistory = SalesGroup + ".SalesPersonQuotaHistory";
    public const string SalesReason = SalesGroup + ".SalesReason";
    public const string SalesTaxRate = SalesGroup + ".SalesTaxRate";
    public const string SalesTerritory = SalesGroup + ".SalesTerritory";
    public const string SalesTerritoryHistory = SalesGroup + ".SalesTerritoryHistory";
    public const string ShoppingCartltem = SalesGroup + ".ShoppingCartltem";
    public const string SpecialOffer = SalesGroup + ".SpecialOffer";
    public const string SpecialOfferProduct = SalesGroup + ".SpecialOfferProduct";
    public const string Store = SalesGroup + ".Store";
    #endregion
}
