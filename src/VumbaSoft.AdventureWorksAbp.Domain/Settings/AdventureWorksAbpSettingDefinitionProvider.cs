using Volo.Abp.Settings;

namespace VumbaSoft.AdventureWorksAbp.Settings;

public class AdventureWorksAbpSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AdventureWorksAbpSettings.MySetting1));
    }
}
