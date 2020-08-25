using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ARB.ERegistration.RetailCustomers.Dtos
{
    public class GetRetailCustomerListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
