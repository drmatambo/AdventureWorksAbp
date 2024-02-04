using Microsoft.EntityFrameworkCore;
using System;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.TenantManagement;
using Volo.Abp.Threading;
using VumbaSoft.AdventureWorksAbp.MultiTenancy;

namespace VumbaSoft.AdventureWorksAbp.EntityFrameworkCore;

public static class AdventureWorksAbpEfCoreEntityExtensionMappings
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public static void Configure()
    {
        AdventureWorksAbpGlobalFeatureConfigurator.Configure();
        AdventureWorksAbpModuleExtensionConfigurator.Configure();

        OneTimeRunner.Run(() =>
        {
            /* You can configure extra properties for the
             * entities defined in the modules used by your application.
             *
             * This class can be used to map these extra properties to table fields in the database.
             *
             * USE THIS CLASS ONLY TO CONFIGURE EF CORE RELATED MAPPING.
             * USE AdventureWorksAbpModuleExtensionConfigurator CLASS (in the Domain.Shared project)
             * FOR A HIGH LEVEL API TO DEFINE EXTRA PROPERTIES TO ENTITIES OF THE USED MODULES
             *
             * Example: Map a property to a table field:

                 ObjectExtensionManager.Instance
                     .MapEfCoreProperty<IdentityUser, string>(
                         "MyProperty",
                         (entityBuilder, propertyBuilder) =>
                         {
                             propertyBuilder.HasMaxLength(128);
                         }
                     );

             * See the documentation for more:
             * https://docs.abp.io/en/abp/latest/Customizing-Application-Modules-Extending-Entities
             */

            ObjectExtensionManager.Instance.MapEfCoreProperty<Tenant, Guid>(MultiTenancyConsts.LocalityId,
                (entityBuilder, propertyBuilder) =>
                {
                    //propertyBuilder.HasMaxLength(AdventureWorksAbpSharedConsts.LongNameMaxLength);
                    propertyBuilder.IsRequired();
                }
            );

            ObjectExtensionManager.Instance.MapEfCoreProperty<Tenant, string>(MultiTenancyConsts.Host,
                (entityBuilder, propertyBuilder) =>
                {
                    propertyBuilder.IsRequired();
                    propertyBuilder.HasMaxLength(AdventureWorksAbpSharedConsts.LongNameMaxLength);
                }
            );

            ObjectExtensionManager.Instance.MapEfCoreProperty<Tenant, string>(MultiTenancyConsts.TenantConnectionString,
                (entityBuilder, propertyBuilder) =>
                {
                    propertyBuilder.IsRequired();
                    propertyBuilder.HasMaxLength(AdventureWorksAbpSharedConsts.LongNameMaxLength);
                }
            );

            ObjectExtensionManager.Instance.MapEfCoreProperty<Tenant, bool>(MultiTenancyConsts.IsInTrial,
                (entityBuilder, propertyBuilder) =>
                {
                    //propertyBuilder.HasMaxLength(AdventureWorksAbpSharedConsts.LongNameMaxLength); 
                }
            );

            ObjectExtensionManager.Instance.MapEfCoreProperty<Tenant, DateTime>(MultiTenancyConsts.TrialStartDate,
                (entityBuilder, propertyBuilder) =>
                {
                    //propertyBuilder.HasMaxLength(AdventureWorksAbpSharedConsts.LongNameMaxLength); 
                }
            );
            ObjectExtensionManager.Instance.MapEfCoreProperty<Tenant, DateTime>(MultiTenancyConsts.TrialEndDate,
                (entityBuilder, propertyBuilder) =>
                {
                    //propertyBuilder.HasMaxLength(AdventureWorksAbpSharedConsts.LongNameMaxLength); 
                }
            );

            ObjectExtensionManager.Instance.MapEfCoreProperty<Tenant, bool>(MultiTenancyConsts.PaidOut,
                (entityBuilder, propertyBuilder) =>
                {
                    propertyBuilder.IsRequired();
                    //propertyBuilder.HasMaxLength(AdventureWorksAbpSharedConsts.LongNameMaxLength); 
                }
            );

            ObjectExtensionManager.Instance.MapEfCoreProperty<Tenant, Guid>(MultiTenancyConsts.PeriodPaidOutId,
                (entityBuilder, propertyBuilder) =>
                {
                    propertyBuilder.IsRequired();
                    //propertyBuilder.HasMaxLength(AdventureWorksAbpSharedConsts.LongNameMaxLength); 
                }
            );

            ObjectExtensionManager.Instance.MapEfCoreProperty<Tenant, DateTime>(MultiTenancyConsts.PaidStartDate,
                (entityBuilder, propertyBuilder) =>
                {
                    //propertyBuilder.HasMaxLength(AdventureWorksAbpSharedConsts.LongNameMaxLength); 
                }
            );

            ObjectExtensionManager.Instance.MapEfCoreProperty<Tenant, DateTime>(MultiTenancyConsts.PaidEndDate,
                (entityBuilder, propertyBuilder) =>
                {
                    //propertyBuilder.HasMaxLength(AdventureWorksAbpSharedConsts.LongNameMaxLength); 
                }
            );
            ObjectExtensionManager.Instance.MapEfCoreProperty<Tenant, bool>(MultiTenancyConsts.Disabled,
                (entityBuilder, propertyBuilder) =>
                {
                    propertyBuilder.IsRequired();
                    //propertyBuilder.HasMaxLength(AdventureWorksAbpSharedConsts.LongNameMaxLength); 
                }
            );

            ObjectExtensionManager.Instance.MapEfCoreProperty<Tenant, string>(MultiTenancyConsts.DisabledReason,
                (entityBuilder, propertyBuilder) =>
                {
                    propertyBuilder.HasMaxLength(AdventureWorksAbpSharedConsts.LongNameMaxLength);
                }
            );


            ObjectExtensionManager.Instance.MapEfCoreProperty<Tenant, DateTime>(MultiTenancyConsts.BillPaidDate,
                (entityBuilder, propertyBuilder) =>
                {
                    //propertyBuilder.HasMaxLength(AdventureWorksAbpSharedConsts.LongNameMaxLength); 
                }
            );

            ObjectExtensionManager.Instance.MapEfCoreProperty<Tenant, DateTime>(MultiTenancyConsts.NextBillingDate,
                (entityBuilder, propertyBuilder) =>
                {
                    //propertyBuilder.HasMaxLength(AdventureWorksAbpSharedConsts.LongNameMaxLength); 
                }
            );

            ObjectExtensionManager.Instance.MapEfCoreProperty<Tenant, byte>(MultiTenancyConsts.NextBillingDiscount,
                (entityBuilder, propertyBuilder) =>
                {
                    //propertyBuilder.HasMaxLength(AdventureWorksAbpSharedConsts.LongNameMaxLength); 
                    propertyBuilder.HasDefaultValueSql("0");
                }
            );

            ObjectExtensionManager.Instance.MapEfCoreProperty<Tenant, bool>(MultiTenancyConsts.IsPremium,
                (entityBuilder, propertyBuilder) =>
                {
                    propertyBuilder.IsRequired();
                    //propertyBuilder.HasMaxLength(AdventureWorksAbpSharedConsts.LongNameMaxLength); 
                }
            );

            ObjectExtensionManager.Instance.MapEfCoreProperty<Tenant, bool>(MultiTenancyConsts.IsVip,
                (entityBuilder, propertyBuilder) =>
                {
                    propertyBuilder.IsRequired();
                    //propertyBuilder.HasMaxLength(AdventureWorksAbpSharedConsts.LongNameMaxLength); 
                }
            );

            ObjectExtensionManager.Instance.MapEfCoreProperty<Tenant, bool>(MultiTenancyConsts.IsLocked,
                (entityBuilder, propertyBuilder) =>
                {
                    propertyBuilder.IsRequired();
                    //propertyBuilder.HasMaxLength(AdventureWorksAbpSharedConsts.LongNameMaxLength); 
                }
            );

            ObjectExtensionManager.Instance.MapEfCoreProperty<Tenant, DateTime>(MultiTenancyConsts.LockedDate,
                (entityBuilder, propertyBuilder) =>
                {
                    //propertyBuilder.HasMaxLength(AdventureWorksAbpSharedConsts.LongNameMaxLength); 
                }
            );

            ObjectExtensionManager.Instance.MapEfCoreProperty<Tenant, string>(MultiTenancyConsts.LockedReason,
                (entityBuilder, propertyBuilder) =>
                {
                    propertyBuilder.HasMaxLength(AdventureWorksAbpSharedConsts.LongNameMaxLength);
                }
            );

            ObjectExtensionManager.Instance.MapEfCoreProperty<Tenant, bool>(MultiTenancyConsts.Activated,
                (entityBuilder, propertyBuilder) =>
                {
                    propertyBuilder.IsRequired();
                    //propertyBuilder.HasMaxLength(AdventureWorksAbpSharedConsts.LongNameMaxLength); 
                }
            );

            ObjectExtensionManager.Instance.MapEfCoreProperty<Tenant, DateTime>(MultiTenancyConsts.ActivatedDate,
                (entityBuilder, propertyBuilder) =>
                {
                    //propertyBuilder.HasMaxLength(AdventureWorksAbpSharedConsts.LongNameMaxLength); 
                }
            );

            ObjectExtensionManager.Instance.MapEfCoreProperty<Tenant, string>(MultiTenancyConsts.ActivatedReason,
                (entityBuilder, propertyBuilder) =>
                {
                    propertyBuilder.HasMaxLength(AdventureWorksAbpSharedConsts.LongNameMaxLength);
                }
            );

            ObjectExtensionManager.Instance.MapEfCoreProperty<Tenant, bool>(MultiTenancyConsts.Upgraded,
                (entityBuilder, propertyBuilder) =>
                {
                    propertyBuilder.IsRequired();
                    //propertyBuilder.HasMaxLength(AdventureWorksAbpSharedConsts.LongNameMaxLength); 
                }
            );

            ObjectExtensionManager.Instance.MapEfCoreProperty<Tenant, DateTime>(MultiTenancyConsts.UpgradedDate,
                (entityBuilder, propertyBuilder) =>
                {
                    //propertyBuilder.HasMaxLength(AdventureWorksAbpSharedConsts.LongNameMaxLength); 
                }
            );

            ObjectExtensionManager.Instance.MapEfCoreProperty<Tenant, string>(MultiTenancyConsts.PostalCode,
                (entityBuilder, propertyBuilder) =>
                {
                    propertyBuilder.IsRequired();
                    propertyBuilder.HasMaxLength(AdventureWorksAbpSharedConsts.ZipPostalCodeMaxLength);
                }
            );

            ObjectExtensionManager.Instance.MapEfCoreProperty<Tenant, string>(MultiTenancyConsts.BusinessName,
                (entityBuilder, propertyBuilder) =>
                {
                    propertyBuilder.HasMaxLength(AdventureWorksAbpSharedConsts.LongNameMaxLength);
                }
            );

            ObjectExtensionManager.Instance.MapEfCoreProperty<Tenant, Guid>(MultiTenancyConsts.CustomCareTypeId,
                (entityBuilder, propertyBuilder) =>
                {
                    //propertyBuilder.HasMaxLength(AdventureWorksAbpSharedConsts.LongNameMaxLength); 
                }
            );

            ObjectExtensionManager.Instance.MapEfCoreProperty<Tenant, string>(MultiTenancyConsts.LogoPath,
                (entityBuilder, propertyBuilder) =>
                {
                    propertyBuilder.HasMaxLength(AdventureWorksAbpSharedConsts.LongNameMaxLength);
                }
            );

            ObjectExtensionManager.Instance.MapEfCoreProperty<Tenant, string>(MultiTenancyConsts.Remarks,
                (entityBuilder, propertyBuilder) =>
                {
                    propertyBuilder.HasMaxLength(AdventureWorksAbpSharedConsts.RemarksMaxLength);
                }
            );

        });
    }
}
