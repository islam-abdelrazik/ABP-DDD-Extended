using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;

namespace ARB.ERegistration.RetailCustomers
{
    public class RetailCustomerExistsException : BusinessException
    {
        public RetailCustomerExistsException(string name)
            : base(ERegistrationDomainErrorCodes.RetailCustomerAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
