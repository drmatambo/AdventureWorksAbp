using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.Permissions;
using VumbaSoft.AdventureWorksAbp.Localization;
using VumbaSoft.AdventureWorksAbp.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace VumbaSoft.AdventureWorksAbp.Web.Menus;

public class AdventureWorksAbpMenuContributor : IMenuContributor
{

    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private static async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<AdventureWorksAbpResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                AdventureWorksAbpMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        #region Application Group Menus

        var demographicsGroupMenu = new ApplicationMenuItem(
            AdventureWorksAbpMenus.DemographicsGroup,
            l["Menu:Demographics"],
            /*"~/",*/
            icon: "fa fa-globe"
        );

        var HumanRespurcesGroupMenu = new ApplicationMenuItem(
            AdventureWorksAbpMenus.HumanRespurcesGroup,
            l["Menu:HumanResources"],
            /*"~/",*/
            icon: "fa fa-globe"
        );

        var PersonGroupMenu = new ApplicationMenuItem(
            AdventureWorksAbpMenus.PersonGroup,
            l["Menu:Person"],
            /*"~/",*/
            icon: "fa fa-globe"
        );

        var ProductionGroupMenu = new ApplicationMenuItem(
            AdventureWorksAbpMenus.ProductionGroup,
            l["Menu:Production"],
            /*"~/",*/
            icon: "fa fa-globe"
        );

        var PurchasingGroupMenu = new ApplicationMenuItem(
            AdventureWorksAbpMenus.PurchasingGroup,
            l["Menu:Purchansing"],
            /*"~/",*/
            icon: "fa fa-globe"
        );


        var SalesGroupMenu = new ApplicationMenuItem(
            AdventureWorksAbpMenus.SalesGroup,
            l["Menu:Sales"],
            /*"~/",*/
            icon: "fa fa-globe"
        );
        #endregion

        #region Demographics Menu Itens
        if (await context.IsGrantedAsync(AdventureWorksAbpPermissions.Continent.Default))
        {
            demographicsGroupMenu.AddItem(new ApplicationMenuItem(
                AdventureWorksAbpMenus.Continent,
                l["Menu:Continent"], "/Demographics/Continents/Continent")
            );
        }

        if (await context.IsGrantedAsync(AdventureWorksAbpPermissions.Subcontinent.Default))
        {
            demographicsGroupMenu.AddItem(new ApplicationMenuItem(
                 AdventureWorksAbpMenus.Subcontinent,
                  l["Menu:Subcontinent"], "/Demographics/Subcontinents/Subcontinent"
             ));
        }

        if (await context.IsGrantedAsync(AdventureWorksAbpPermissions.Country.Default))
        {
            demographicsGroupMenu.AddItem(new ApplicationMenuItem(
               AdventureWorksAbpMenus.Country,
                l["Menu:Country"], "/Demographics/Countries/Country"
            ));
        }

        if (await context.IsGrantedAsync(AdventureWorksAbpPermissions.Region.Default))
        {
            demographicsGroupMenu.AddItem(new ApplicationMenuItem(
                AdventureWorksAbpMenus.Region,
                l["Menu:Region"], "/Demographics/Regions/Region"
            ));
        }

        if (await context.IsGrantedAsync(AdventureWorksAbpPermissions.StateProvince.Default))
        {
            demographicsGroupMenu.AddItem(new ApplicationMenuItem(
                AdventureWorksAbpMenus.StateProvince,
                l["Menu:StateProvince"], "/Demographics/StateProvinces/StateProvince"
            ));
        }

        if (await context.IsGrantedAsync(AdventureWorksAbpPermissions.DistrictCity.Default))
        {
            demographicsGroupMenu.AddItem(new ApplicationMenuItem(
                AdventureWorksAbpMenus.DistrictCity,
                l["Menu:DistrictCity"], "/Demographics/DistrictCities/DistrictCity"
            ));
        }

        if (await context.IsGrantedAsync(AdventureWorksAbpPermissions.Locality.Default))
        {
            demographicsGroupMenu.AddItem(new ApplicationMenuItem(
                AdventureWorksAbpMenus.Locality,
                l["Menu:Locality"], "/Demographics/Localities/Locality"
            ));
        }
        #endregion

        #region Add Context Group Menus
        context.Menu.AddItem(demographicsGroupMenu);
        context.Menu.AddItem(HumanRespurcesGroupMenu);
        context.Menu.AddItem(PersonGroupMenu);
        context.Menu.AddItem(ProductionGroupMenu);
        context.Menu.AddItem(PurchasingGroupMenu);
        context.Menu.AddItem(SalesGroupMenu);
        #endregion
    }
}
