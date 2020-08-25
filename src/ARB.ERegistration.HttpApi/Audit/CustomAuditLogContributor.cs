using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Auditing;
using Volo.Abp.Data;
using Volo.Abp.Users;

namespace ARB.ERegistration.Audit
{
    public class CustomAuditLogContributor : AuditLogContributor
    {
        public CustomAuditLogContributor()
        {
        }
        public override void PreContribute(AuditLogContributionContext context)
        {
            var currentUser = context.ServiceProvider.GetRequiredService<ICurrentUser>();
            context.AuditInfo.SetProperty(
                "MyCustomClaimValue",
                currentUser.FindClaimValue("MyCustomClaim")
            );
        }

        public override void PostContribute(AuditLogContributionContext context)
        {
            //var httpContextAccessor = context.ServiceProvider.GetRequiredService<IHttpContextAccessor>();
            //var response = FormatResponse(httpContextAccessor.HttpContext.Response).Result;
            context.AuditInfo.Comments.Add("Some comment...");
            //context.AuditInfo.ExtraProperties.Add("Response", response);

        }

        //private async Task<string> FormatResponse(HttpResponse response)
        //{
        //    try
        //    {
        //        var responseBodyStream = new MemoryStream();
        //        responseBodyStream.Seek(0, SeekOrigin.Begin);
        //        await responseBodyStream.CopyToAsync(response.Body);
        //        var resBodyText = new StreamReader(responseBodyStream).ReadToEnd();

        //        //Return the string for the response, including the status code (e.g. 200, 404, 401, etc.)
        //        return $"{response.StatusCode}: {resBodyText}";
        //    }
        //    catch(Exception ex)
        //    {
        //        //Empty response detected
        //        return string.Empty;
        //    }
            
        //}
    }
}
