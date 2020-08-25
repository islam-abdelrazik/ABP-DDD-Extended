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
            DateTime birthDate,
            [CanBeNull] string shortBio = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingRetailCustomer = await _retailCustomerRepository.FindByNameAsync(name);
            if (existingRetailCustomer != null)
            {
                throw new RetailCustomerExistsException(name);
            }

            //return new RetailCustomer(
            //    GuidGenerator.Create(),
            //    name,
            //    birthDate,
            //    shortBio
            //);
            return null;
        }

       
    }
}
