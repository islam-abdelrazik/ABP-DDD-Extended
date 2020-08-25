using Volo.Abp.Settings;

namespace ARB.ERegistration.Settings
{
    public class ERegistrationSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(ERegistrationSettings.MySetting1));
        }
    }
}
