using System;
using System.Collections.Generic;
using System.Text;
using VumbaSoft.AdventureWorksAbp.Localization;
using Volo.Abp.Application.Services;

namespace VumbaSoft.AdventureWorksAbp;

/* Inherit your application services from this class.
 */
public abstract class AdventureWorksAbpAppService : ApplicationService
{
    protected AdventureWorksAbpAppService()
    {
        LocalizationResource = typeof(AdventureWorksAbpResource);
    }
}
