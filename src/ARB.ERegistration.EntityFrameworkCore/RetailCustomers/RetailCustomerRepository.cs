using ARB.ERegistration.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ARB.ERegistration.RetailCustomers
{
    public class RetailCustomerRepository : EfCoreRepository<ERegistrationDbContext, RetailCustomer, Guid>,
            IRetailCustomerRepository
    {
        public RetailCustomerRepository(
            IDbContextProvider<ERegistrationDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<RetailCustomer> FindByNameAsync(string name)
        {
            return await DbSet.FirstOrDefaultAsync(author => author.Name == name);
        }

        public async Task<List<RetailCustomer>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            return await DbSet
                .WhereIf(
                    filter!=null && !filter.IsNullOrWhiteSpace(),
                    retailCustomer => retailCustomer.Name.Contains(filter)
                 )
                //.OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
