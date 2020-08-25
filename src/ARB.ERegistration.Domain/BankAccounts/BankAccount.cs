using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace ARB.ERegistration.BankAccounts
{
    public class BankAccount : AuditedEntity<Guid>
    {
        private BankAccount()
        {

        }
        internal BankAccount(string bankName, string bankNumber, Guid retailCustomerId)
        {
            BankName = bankName;
            BankNumber = bankNumber;
            RetailCustomerId = retailCustomerId;
        }

        public string BankName { get; private set; }
        public string BankNumber { get; private set; }
        public Guid RetailCustomerId { get; private set; }

    }
}
