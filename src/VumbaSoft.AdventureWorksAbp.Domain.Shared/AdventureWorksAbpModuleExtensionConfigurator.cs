using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;
using VumbaSoft.AdventureWorksAbp.MultiTenancy;

namespace VumbaSoft.AdventureWorksAbp;

public static class AdventureWorksAbpModuleExtensionConfigurator
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public static void Configure()
    {
        OneTimeRunner.Run(() =>
        {
            ConfigureExistingProperties();
            ConfigureExtraProperties();
        });
    }

    private static void ConfigureExistingProperties()
    {
        /* You can change max lengths for properties of the
         * entities defined in the modules used by your application.
         *
         * Example: Change user and role name max lengths

           AbpUserConsts.MaxNameLength = 99;
           IdentityRoleConsts.MaxNameLength = 99;

         * Notice: It is not suggested to change property lengths
         * unless you really need it. Go with the standard values wherever possible.
         *
         * If you are using EF Core, you will need to run the add-migration command after your changes.
         */
    }

    private static void ConfigureExtraProperties()
    {
        /* You can configure extra properties for the
         * entities defined in the modules used by your application.
         *
         * This class can be used to define these extra properties
         * with a high level, easy to use API.
         *
         * Example: Add a new property to the user entity of the identity module

           ObjectExtensionManager.Instance.Modules()
              .ConfigureIdentity(identity =>
              {
                  identity.ConfigureUser(user =>
                  {
                      user.AddOrUpdateProperty<string>( //property type: string
                          "SocialSecurityNumber", //property name
                          property =>
                          {
                              //validation rules
                              property.Attributes.Add(new RequiredAttribute());
                              property.Attributes.Add(new StringLengthAttribute(64) {MinimumLength = 4});
                              
                              property.Configuration[IdentityModuleExtensionConsts.ConfigurationNames.AllowUserToEdit] = true;

                              //...other configurations for this property
                          }
                      );
                  });
              });

         * See the documentation for more:
         * https://docs.abp.io/en/abp/latest/Module-Entity-Extensions
         */

        ObjectExtensionManager.Instance.Modules()
            .ConfigureTenantManagement(tenantConfig =>
            {
                tenantConfig.ConfigureTenant(tenant =>
                {
                    tenant.AddOrUpdateProperty<Guid>(MultiTenancyConsts.LocalityId,
                        property =>
                        {
                            //validation rules
                            property.Attributes.Add(new RequiredAttribute());
                            //property.Attributes.Add(
                            //    new StringLengthAttribute(AdventureWorksAbpSharedConsts.NameMaxLength)
                            //    {
                            //        MinimumLength = AdventureWorksAbpSharedConsts.IsFixedFourLettersLengthColumnMaxLength
                            //    }
                            //);
                        });
                });

                tenantConfig.ConfigureTenant(tenant =>
                {
                    tenant.AddOrUpdateProperty<string>(MultiTenancyConsts.Host,
                        property =>
                        {
                            //validation rules
                            property.Attributes.Add(new RequiredAttribute());
                            property.Attributes.Add(
                                new StringLengthAttribute(AdventureWorksAbpSharedConsts.NameMaxLength)
                                {
                                    MinimumLength = AdventureWorksAbpSharedConsts.IsFixedFourLettersLengthColumnMaxLength
                                }
                            );
                        });
                });

                tenantConfig.ConfigureTenant(tenant =>
                {
                    tenant.AddOrUpdateProperty<string>(MultiTenancyConsts.TenantConnectionString,
                        property =>
                        {
                            //validation rules
                            property.Attributes.Add(new RequiredAttribute());
                            property.Attributes.Add(
                                new StringLengthAttribute(AdventureWorksAbpSharedConsts.LongNameMaxLength)
                                {
                                    MinimumLength = AdventureWorksAbpSharedConsts.IsFixedFourLettersLengthColumnMaxLength
                                }
                            );
                        });
                });

                tenantConfig.ConfigureTenant(tenant =>
                {
                    tenant.AddOrUpdateProperty<bool>(MultiTenancyConsts.IsInTrial,
                        property =>
                        {
                            //validation rules
                            property.Attributes.Add(new RequiredAttribute());
                            //property.Attributes.Add(
                            //    new StringLengthAttribute(AdventureWorksAbpSharedConsts.LongNameMaxLength)
                            //    {
                            //        MinimumLength = AdventureWorksAbpSharedConsts.IsFixedFourLettersLengthColumnMaxLength
                            //    }
                            //);
                        });
                });

                tenantConfig.ConfigureTenant(tenant =>
                {
                    tenant.AddOrUpdateProperty<DateTime>(MultiTenancyConsts.TrialStartDate,
                        property =>
                        {
                            //validation rules
                            //property.Attributes.Add(new RequiredAttribute());
                            //property.Attributes.Add(
                            //    new StringLengthAttribute(AdventureWorksAbpSharedConsts.LongNameMaxLength)
                            //    {
                            //        MinimumLength = AdventureWorksAbpSharedConsts.IsFixedFourLettersLengthColumnMaxLength
                            //    }
                            //);
                        });
                });

                tenantConfig.ConfigureTenant(tenant =>
                {
                    tenant.AddOrUpdateProperty<DateTime>(MultiTenancyConsts.TrialEndDate,
                        property =>
                        {
                            //validation rules
                            //property.Attributes.Add(new RequiredAttribute());
                            //property.Attributes.Add(
                            //    new StringLengthAttribute(AdventureWorksAbpSharedConsts.LongNameMaxLength)
                            //    {
                            //        MinimumLength = AdventureWorksAbpSharedConsts.IsFixedFourLettersLengthColumnMaxLength
                            //    }
                            //);
                        });
                });

                tenantConfig.ConfigureTenant(tenant =>
                {
                    tenant.AddOrUpdateProperty<DateTime>(MultiTenancyConsts.TrialStartDate,
                        property =>
                        {
                            //validation rules
                            property.Attributes.Add(new RequiredAttribute());
                            //property.Attributes.Add(
                            //    new StringLengthAttribute(AdventureWorksAbpSharedConsts.LongNameMaxLength)
                            //    {
                            //        MinimumLength = AdventureWorksAbpSharedConsts.IsFixedFourLettersLengthColumnMaxLength
                            //    }
                            //);
                        });
                });

                tenantConfig.ConfigureTenant(tenant =>
                {
                    tenant.AddOrUpdateProperty<bool>(MultiTenancyConsts.PaidOut);
                });

                tenantConfig.ConfigureTenant(tenant =>
                {
                    tenant.AddOrUpdateProperty<Guid>(MultiTenancyConsts.PeriodPaidOutId);
                });

                tenantConfig.ConfigureTenant(tenant =>
                {
                    tenant.AddOrUpdateProperty<DateTime>(MultiTenancyConsts.PaidStartDate);
                });

                tenantConfig.ConfigureTenant(tenant =>
                {
                    tenant.AddOrUpdateProperty<DateTime>(MultiTenancyConsts.PaidEndDate);
                });

                tenantConfig.ConfigureTenant(tenant =>
                {
                    tenant.AddOrUpdateProperty<bool>(MultiTenancyConsts.Disabled);
                });

                tenantConfig.ConfigureTenant(tenant =>
                {
                    tenant.AddOrUpdateProperty<string>(MultiTenancyConsts.DisabledReason,
                        property =>
                        {
                            //validation rules
                            property.Attributes.Add(new RequiredAttribute());
                            property.Attributes.Add(
                                new StringLengthAttribute(AdventureWorksAbpSharedConsts.LongNameMaxLength)
                                {
                                    MinimumLength = AdventureWorksAbpSharedConsts.IsFixedFourLettersLengthColumnMaxLength
                                }
                            );
                        });
                });

                tenantConfig.ConfigureTenant(tenant =>
                {
                    tenant.AddOrUpdateProperty<DateTime>(MultiTenancyConsts.BillPaidDate);
                });

                tenantConfig.ConfigureTenant(tenant =>
                {
                    tenant.AddOrUpdateProperty<DateTime>(MultiTenancyConsts.NextBillingDate);
                });

                tenantConfig.ConfigureTenant(tenant =>
                {
                    tenant.AddOrUpdateProperty<byte>(MultiTenancyConsts.NextBillingDiscount);
                });

                tenantConfig.ConfigureTenant(tenant =>
                {
                    tenant.AddOrUpdateProperty<bool>(MultiTenancyConsts.IsPremium);
                });

                tenantConfig.ConfigureTenant(tenant =>
                {
                    tenant.AddOrUpdateProperty<bool>(MultiTenancyConsts.IsVip);
                });

                tenantConfig.ConfigureTenant(tenant =>
                {
                    tenant.AddOrUpdateProperty<bool>(MultiTenancyConsts.IsLocked);
                });

                tenantConfig.ConfigureTenant(tenant =>
                {
                    tenant.AddOrUpdateProperty<DateTime>(MultiTenancyConsts.LockedDate);
                });


                tenantConfig.ConfigureTenant(tenant =>
                {
                    tenant.AddOrUpdateProperty<string>(MultiTenancyConsts.LockedReason,
                        property =>
                        {
                            //validation rules
                            //property.Attributes.Add(new RequiredAttribute());
                            property.Attributes.Add(
                                new StringLengthAttribute(AdventureWorksAbpSharedConsts.RemarksMaxLength)
                                {
                                    MinimumLength = AdventureWorksAbpSharedConsts.IsFixedFourLettersLengthColumnMaxLength
                                }
                            );
                        });
                });

                tenantConfig.ConfigureTenant(tenant =>
                {
                    tenant.AddOrUpdateProperty<bool>(MultiTenancyConsts.Activated);
                });

                tenantConfig.ConfigureTenant(tenant =>
                {
                    tenant.AddOrUpdateProperty<DateTime>(MultiTenancyConsts.ActivatedDate);
                });

                tenantConfig.ConfigureTenant(tenant =>
                {
                    tenant.AddOrUpdateProperty<string>(MultiTenancyConsts.ActivatedReason,
                        property =>
                        {
                            //validation rules
                            //property.Attributes.Add(new RequiredAttribute());
                            property.Attributes.Add(
                                new StringLengthAttribute(AdventureWorksAbpSharedConsts.RemarksMaxLength)
                                {
                                    MinimumLength = AdventureWorksAbpSharedConsts.IsFixedFourLettersLengthColumnMaxLength
                                }
                            );
                        });
                });

                tenantConfig.ConfigureTenant(tenant =>
                {
                    tenant.AddOrUpdateProperty<bool>(MultiTenancyConsts.Upgraded);
                });

                tenantConfig.ConfigureTenant(tenant =>
                {
                    tenant.AddOrUpdateProperty<DateTime>(MultiTenancyConsts.UpgradedDate);
                });

                tenantConfig.ConfigureTenant(tenant =>
                {
                    tenant.AddOrUpdateProperty<string>(MultiTenancyConsts.PostalCode,
                        property =>
                        {
                            //validation rules
                            //property.Attributes.Add(new RequiredAttribute());
                            property.Attributes.Add(
                                new StringLengthAttribute(AdventureWorksAbpSharedConsts.ZipPostalCodeMaxLength)
                                {
                                    MinimumLength = AdventureWorksAbpSharedConsts.IsFixedFourLettersLengthColumnMaxLength
                                }
                            );
                        });
                });

                tenantConfig.ConfigureTenant(tenant =>
                {
                    tenant.AddOrUpdateProperty<string>(MultiTenancyConsts.BusinessName,
                        property =>
                        {
                            //validation rules
                            //property.Attributes.Add(new RequiredAttribute());
                            property.Attributes.Add(
                                new StringLengthAttribute(AdventureWorksAbpSharedConsts.LongNameMaxLength)
                                {
                                    MinimumLength = AdventureWorksAbpSharedConsts.IsFixedFourLettersLengthColumnMaxLength
                                }
                            );
                        });
                });

                tenantConfig.ConfigureTenant(tenant =>
                {
                    tenant.AddOrUpdateProperty<Guid>(MultiTenancyConsts.CustomCareTypeId);
                });

                tenantConfig.ConfigureTenant(tenant =>
                {
                    tenant.AddOrUpdateProperty<string>(MultiTenancyConsts.LogoPath,
                        property =>
                        {
                            //validation rules
                            //property.Attributes.Add(new RequiredAttribute());
                            property.Attributes.Add(
                                new StringLengthAttribute(AdventureWorksAbpSharedConsts.LongNameMaxLength)
                                {
                                    MinimumLength = AdventureWorksAbpSharedConsts.IsFixedFourLettersLengthColumnMaxLength
                                }
                            );
                        });
                });

                tenantConfig.ConfigureTenant(tenant =>
                {
                    tenant.AddOrUpdateProperty<string>(MultiTenancyConsts.Remarks,
                        property =>
                        {
                            //validation rules
                            //property.Attributes.Add(new RequiredAttribute());
                            property.Attributes.Add(
                                new StringLengthAttribute(AdventureWorksAbpSharedConsts.RemarksMaxLength)
                                {
                                    MinimumLength = AdventureWorksAbpSharedConsts.IsFixedFourLettersLengthColumnMaxLength
                                }
                            );
                        });
                });

            });
    }
}
