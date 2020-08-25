using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARB.ERegistration.Auth;
using ARB.ERegistration.Localization;
using ARB.ERegistration.Models.Test;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Volo.Abp;
using Volo.Abp.Auditing;

namespace ARB.ERegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ERegistrationController
    {
        private ILogger<DemoController> _logger;
        private IStringLocalizer<ERegistrationResource> _stringLocalizer;
        private IConfiguration _config;

        public DemoController(ILogger<DemoController> logger, 
            IStringLocalizer<ERegistrationResource> stringLocalizer,
            IAuditingManager auditingManager,
            IConfiguration config) : base(auditingManager)
        {
            _config = config;
            _stringLocalizer = stringLocalizer;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<int>> GetAsync()
        {
            _logger.LogError("MainController Index executed at {date}", DateTime.Now);
            _logger.LogDebug("MainController Index executed at {date}", DateTime.Now);
            _logger.LogWarning("MainController Index executed at {date}", DateTime.Now);
            _logger.LogInformation("MainController Index executed at {date}", DateTime.Now);

            int x = 100;
            return Ok(x);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Login")]
        public async Task<ActionResult<string>> Login()
        {
            var jwt = new JwtService(_config);
            var token = jwt.GenerateSecurityToken("fake@email.com");
            return token;   
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostAsync([FromBody] TestModel testModel)
        {
            if (ModelState.IsValid)
                return OkAudited("done received");
            return BadRequest();
        }

        [HttpGet]
        [Route("/GetData")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> GetDataAsync()
        {
            //throw new UserFriendlyException(_stringLocalizer["UserNameShouldBeUniqueMessage"]);
            throw new BusinessException(ERegistrationDomainErrorCodes.UserNameUnique).WithData("key","value");
        }
    }
}
