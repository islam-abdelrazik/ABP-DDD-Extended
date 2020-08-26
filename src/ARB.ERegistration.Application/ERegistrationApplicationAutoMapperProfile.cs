using ARB.ERegistration.BankAccounts;
using ARB.ERegistration.BankAccounts.Dtos;
using ARB.ERegistration.RetailCustomers;
using ARB.ERegistration.RetailCustomers.Dtos;
using AutoMapper;

namespace ARB.ERegistration
{
    public class ERegistrationApplicationAutoMapperProfile : Profile
    {
        public ERegistrationApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<RetailCustomer, RetailCustomerDto>();
            CreateMap<CreateBankAccountDto, BankAccount>();
            CreateMap<BankAccount, BankAccountDto>();

        }
    }
}
