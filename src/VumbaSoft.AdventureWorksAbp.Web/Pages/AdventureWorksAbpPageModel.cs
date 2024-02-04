using VumbaSoft.AdventureWorksAbp.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace VumbaSoft.AdventureWorksAbp.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class AdventureWorksAbpPageModel : AbpPageModel
{
    protected AdventureWorksAbpPageModel()
    {
        LocalizationResourceType = typeof(AdventureWorksAbpResource);
    }
}
