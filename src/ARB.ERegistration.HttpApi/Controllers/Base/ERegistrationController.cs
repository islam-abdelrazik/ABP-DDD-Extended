using ARB.ERegistration.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Auditing;
using Volo.Abp.Data;

namespace ARB.ERegistration.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class ERegistrationController : AbpController
    {
        private readonly IAuditingManager _auditingManager;
        protected ILogger<ERegistrationController> _logger;

        protected ERegistrationController(IAuditingManager auditingManager, ILogger<ERegistrationController> logger)
        {
            _auditingManager = auditingManager;
            LocalizationResource = typeof(ERegistrationResource);
            _logger = logger;
        }

        protected OkObjectResult OkAudited(object data)
        {
            var currentAuditLogScope = _auditingManager.Current;
            if (currentAuditLogScope != null)
            {
                currentAuditLogScope.Log.ExtraProperties.Add("Response",
                    data
                );
                _logger.LogInformation("Response Audited", data);
            };
            return Ok(data);
        }

    }
}