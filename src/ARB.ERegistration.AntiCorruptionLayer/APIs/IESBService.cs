using ARB.ERegistration.AntiCorruptionLayer.Models;
using ARB.ERegistration.RetailCustomers;
using RestEase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ARB.ERegistration.AntiCorruptionLayer.APIs
{
    public interface IESBService
    {
        [Get("RetailCustomer/GetCRByName/{name}")]
        Task<ESBModel> GetCRByName([Path] string name);
    }
}
