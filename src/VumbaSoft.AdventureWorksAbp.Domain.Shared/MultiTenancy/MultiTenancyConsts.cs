namespace VumbaSoft.AdventureWorksAbp.MultiTenancy;

public static class MultiTenancyConsts
{
    /* Enable/disable multi-tenancy easily in a single point.
     * If you will never need to multi-tenancy, you can remove
     * related modules and code parts, including this file.
     */
    public const bool IsEnabled = true;

    public const string LocalityId = "LocalityId";
    public const string Host = "Host";
    public const string TenantConnectionString = "TenantConnectionString";
    public const string IsInTrial = "IsInTrial";
    public const string TrialStartDate = "TrialStartDate";
    public const string TrialEndDate = "TrialEndDate";
    public const string PaidOut = "PaidOut";
    public const string PeriodPaidOutId = "PeriodPaidOutId";
    public const string PaidStartDate = "PaidStartDate";
    public const string PaidEndDate = "PaidEndDate";
    public const string Disabled = "Disabled";
    public const string DisabledReason = "DisabledReason";
    public const string BillPaidDate = "BillPaidDate";
    public const string NextBillingDate = "NextBillingDate";
    public const string NextBillingDiscount = "NextBillingDiscount";
    public const string IsPremium = "IsPremium";
    public const string IsVip = "IsVip";
    public const string IsLocked = "IsLocked";
    public const string LockedDate = "LockedDate";
    public const string LockedReason = "LockedReason";
    public const string Activated = "Activated";
    public const string ActivatedDate = "ActivatedDate";
    public const string ActivatedReason = "ActivatedReason";
    public const string Upgraded = "Upgraded";
    public const string UpgradedDate = "UpgradedDate";
    public const string PostalCode = "PostalCode";
    public const string BusinessName = "BusinessName";
    public const string CustomCareTypeId = "CustomCareTypeId";
    public const string LogoPath = "LogoPath";
    public const string Remarks = "Remarks";
}
