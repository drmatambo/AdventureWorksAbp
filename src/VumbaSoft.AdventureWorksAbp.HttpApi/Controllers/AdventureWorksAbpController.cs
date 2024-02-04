using VumbaSoft.AdventureWorksAbp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace VumbaSoft.AdventureWorksAbp.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AdventureWorksAbpController : AbpControllerBase
{
    protected AdventureWorksAbpController()
    {
        LocalizationResource = typeof(AdventureWorksAbpResource);
    }
}
