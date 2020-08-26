using System;
using System.Collections.Generic;
using System.Text;

namespace ARB.ERegistration.BankAccounts.Dtos
{
    public class CreateBankAccountDto
    {
        public string BankName { get; set; }
        public string BankNumber { get; set; }
    }
}
