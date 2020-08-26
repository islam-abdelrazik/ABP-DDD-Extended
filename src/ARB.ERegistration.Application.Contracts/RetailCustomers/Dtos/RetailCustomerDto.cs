using ARB.ERegistration.BankAccounts.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ARB.ERegistration.RetailCustomers.Dtos
{
    public class RetailCustomerDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string CommercialRegisterNo { get; set; }
        public string CICNo { get; set; }
        public string Address { get; set; }
        public string ATMCard_PinCode { get; set; }
        public string ATMCard_CardNumber { get; set; }
        public List<BankAccountDto> BankAccounts { get; set; }
    }
}
