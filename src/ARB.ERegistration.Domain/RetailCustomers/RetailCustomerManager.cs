using ARB.ERegistration.BankAccounts;
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

        public RetailCustomerManager(IRetailCustomerRepository retailCustomerRepository)
        {
            _retailCustomerRepository = retailCustomerRepository;
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

            var existingRetailCustomer = await _retailCustomerRepository.FindByNameAsync(name);
            if (existingRetailCustomer != null)
            {
                throw new RetailCustomerExistsException(name);
            }

            return new RetailCustomer(
                GuidGenerator.Create(),
                name,
                commercialRegisterNo,
                CICNo,
                address,
                cardNumber,
                pinCode,
                bankAccounts
            );
        }

       
    }
}
