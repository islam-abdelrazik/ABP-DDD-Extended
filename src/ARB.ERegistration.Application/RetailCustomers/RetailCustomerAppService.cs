using ARB.ERegistration.BankAccounts;
using ARB.ERegistration.BankAccounts.Dtos;
using ARB.ERegistration.RetailCustomers.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ARB.ERegistration.RetailCustomers
{
    public class RetailCustomerAppService : ERegistrationAppService, IRetailCustomerAppService
    {
        private readonly IRetailCustomerRepository _retailCustomerRepository;
        private readonly RetailCustomerManager _retailCustomerManager;

        public RetailCustomerAppService(
            IRetailCustomerRepository retailCustomerRepository,
            RetailCustomerManager retailCustomerManager)
        {
            _retailCustomerRepository = retailCustomerRepository;
            _retailCustomerManager = retailCustomerManager;
        }

        public async Task<RetailCustomerDto> CreateAsync(CreateRetailCustomerDto input)
        {
            var bankAccounts = ObjectMapper.Map<IEnumerable<CreateBankAccountDto>, IEnumerable<BankAccount>>(input.BankAccounts);
              var retailCustomer = await _retailCustomerManager.CreateAsync(
                input.Name,
                input.CommercialRegisterNo,
                input.CICNo,
                input.Address,
                input.ATMCard_CardNumber,
                input.ATMCard_PinCode,
                bankAccounts
            );
            await _retailCustomerRepository.InsertAsync(retailCustomer,true);
            return ObjectMapper.Map<RetailCustomer, RetailCustomerDto>(retailCustomer);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<RetailCustomerDto> GetAsync(Guid id)
        {
            var retailCustomer = await _retailCustomerRepository.GetAsync(id);
            return ObjectMapper.Map<RetailCustomer, RetailCustomerDto>(retailCustomer);
        }

        public async Task<PagedResultDto<RetailCustomerDto>> GetListAsync(GetRetailCustomerListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(RetailCustomer.Name);
            }

            var retailCustomers = await _retailCustomerRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var countQuery = _retailCustomerRepository.WhereIf(
                    !input.Filter.IsNullOrWhiteSpace(),
                    retailCustomer => retailCustomer.Name.Contains(input.Filter)
                );
            var totalCount = await AsyncExecuter.CountAsync(
                countQuery.AsQueryable());

            return new PagedResultDto<RetailCustomerDto>(
                totalCount,
                ObjectMapper.Map<List<RetailCustomer>, List<RetailCustomerDto>>(retailCustomers)
            );
        }

        public Task UpdateAsync(Guid id, UpdateRetailCustomerDto input)
        {
            throw new NotImplementedException();
        }
    }
}
