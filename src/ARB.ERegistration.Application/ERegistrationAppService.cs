using System;
using System.Collections.Generic;
using System.Text;
using ARB.ERegistration.Localization;
using Volo.Abp.Application.Services;

namespace ARB.ERegistration
{
    /* Inherit your application services from this class.
     */
    public abstract class ERegistrationAppService : ApplicationService
    {
        protected ERegistrationAppService()
        {
            LocalizationResource = typeof(ERegistrationResource);
        }
    }
}
