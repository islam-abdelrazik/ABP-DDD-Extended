using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ARB.ERegistration.RetailCustomers.ACL
{
    public interface IRetailCustomerExternalService
    {
        Task<RetailCustomer> GetRetailCustomerBankInfo(string name);
    }
}
