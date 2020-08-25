using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ARB.ERegistration.RetailCustomers
{
    public interface IRetailCustomerRepository : IRepository<RetailCustomer, Guid>
    {
        Task<RetailCustomer> FindByNameAsync(string name);
        Task<List<RetailCustomer>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
