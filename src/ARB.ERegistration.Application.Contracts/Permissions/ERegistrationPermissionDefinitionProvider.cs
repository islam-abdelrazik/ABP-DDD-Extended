using ARB.ERegistration.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ARB.ERegistration.Permissions
{
    public class ERegistrationPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(ERegistrationPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(ERegistrationPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ERegistrationResource>(name);
        }
    }
}
