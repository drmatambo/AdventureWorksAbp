using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace VumbaSoft.AdventureWorksAbp.Web;

[Dependency(ReplaceServices = true)]
public class AdventureWorksAbpBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AdventureWorksAbp";
}
