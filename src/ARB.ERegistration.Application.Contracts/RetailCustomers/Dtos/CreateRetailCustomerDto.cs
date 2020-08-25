using ARB.ERegistration.ModelConstants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ARB.ERegistration.RetailCustomers.Dtos
{
    public class CreateRetailCustomerDto
    {
        [Required]
        [StringLength(RetailCustomerConstants.MaxNameLength)]
        public string Name { get; set; }
        public string CommercialRegisterNo { get; set; }
        public string CICNo { get; set; }
        public string Address { get; set; }
        public string ATMCard_PinCode { get; set; }
        public string ATMCard_CardNumber { get; set; }
    }
}
