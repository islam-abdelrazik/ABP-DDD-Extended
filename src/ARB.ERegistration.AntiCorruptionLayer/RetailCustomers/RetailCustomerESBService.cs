using ARB.ERegistration.AntiCorruptionLayer.APIs;
using ARB.ERegistration.RetailCustomers;
using ARB.ERegistration.RetailCustomers.ACL;
using Microsoft.Extensions.Configuration;
using RestEase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ARB.ERegistration.AntiCorruptionLayer.RetailCustomers
{
    [ExposeServices(typeof(IRetailCustomerExternalService))]
    public class RetailCustomerESBService : IRetailCustomerExternalService, ITransientDependency
    {
        private readonly IConfiguration _configuration;
        public RetailCustomerESBService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<RetailCustomer> GetRetailCustomerBankInfo(string name)
        {
            var esbURL = _configuration.GetSection("ESB").GetSection("URL").Value;
            IESBService api = RestClient.For<IESBService>(esbURL);
            var esbModel = await api.GetCRByName(name);
            return new RetailCustomer(Guid.NewGuid(), name, esbModel.CR, esbModel.CIC.ToString(), "", "dddsfsdfsf", "1234", null);

        }
    }
}
