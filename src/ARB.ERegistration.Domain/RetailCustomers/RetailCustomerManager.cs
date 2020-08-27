using ARB.ERegistration.BankAccounts;
using ARB.ERegistration.RetailCustomers.ACL;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;
using NN = System.Diagnostics.CodeAnalysis;

namespace ARB.ERegistration.RetailCustomers
{
    public class RetailCustomerManager : DomainService
    {
        private readonly IRetailCustomerRepository _retailCustomerRepository;
        private readonly IRetailCustomerExternalService _retailCustomerESBService;

        public RetailCustomerManager(IRetailCustomerRepository retailCustomerRepository,
            IRetailCustomerExternalService retailCustomerESBService)
        {
            _retailCustomerRepository = retailCustomerRepository;
            _retailCustomerESBService = retailCustomerESBService;
        }

        public async Task<RetailCustomer> CreateAsync(
            [NN.NotNull] string name,
            [NN.NotNull] string commercialRegisterNo,
            [NN.NotNull] string CICNo,
            [NN.NotNull] string address,
            [CanBeNull] string cardNumber, 
            [CanBeNull] string pinCode,
            [NN.NotNull] IEnumerable<BankAccount> bankAccounts)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var retailCustomerData = await _retailCustomerESBService.GetRetailCustomerBankInfo(name);
            var existingRetailCustomer = await _retailCustomerRepository.FindByNameAsync(name);
            if (existingRetailCustomer != null)
            {
                throw new RetailCustomerExistsException(name);
            }

            return new RetailCustomer(
                GuidGenerator.Create(),
                name,
                retailCustomerData.CommercialRegisterNo,
                retailCustomerData.CICNo,
                address,
                cardNumber,
                pinCode,
                bankAccounts
            );
        }
    }
}
