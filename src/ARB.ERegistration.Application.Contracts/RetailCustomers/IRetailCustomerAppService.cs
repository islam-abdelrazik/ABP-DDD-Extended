using ARB.ERegistration.RetailCustomers.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ARB.ERegistration.RetailCustomers
{
    public interface IRetailCustomerAppService
    {
        Task<RetailCustomerDto> GetAsync(Guid id);

        Task<PagedResultDto<RetailCustomerDto>> GetListAsync(GetRetailCustomerListDto input);

        Task<RetailCustomerDto> CreateAsync(CreateRetailCustomerDto input);

        Task UpdateAsync(Guid id, UpdateRetailCustomerDto input);

        Task DeleteAsync(Guid id);
    }
}
