using ARB.ERegistration.Card;
using ARB.ERegistration.ModelConstants;
using ARB.ERegistration.RetailCustomers;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ARB.ERegistration.EntityFrameworkCore
{
    public static class ERegistrationDbContextModelCreatingExtensions
    {
        public static void ConfigureERegistration(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<RetailCustomer>(b =>
            {
                b.ToTable(ERegistrationConsts.DbBusinessTablePrefix + ".RetailCustomers",
                    ERegistrationConsts.DbSchema);

                b.ConfigureByConvention();

                b.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(RetailCustomerConstants.MaxNameLength);

                b.HasIndex(x => x.Name);

                b.HasMany(p => p.BankAccounts);

                b.OwnsOne(p => p.ATMCard,
                    oa =>
                    {
                        oa.Property(c => c.CardNumber).HasColumnName("CardNumber").IsRequired()
                        .HasMaxLength(50);
                        oa.Property(c => c.PinCode).HasColumnName("PinCode").IsRequired()
                               .HasMaxLength(4);
                        oa.WithOwner();
                    }
                    //navigationBuilder =>
                    //{
                    //    navigationBuilder.WithOwner().HasForeignKey("RetailCustomerId");
                    //}

                   );
                var navigation = b.Metadata.FindNavigation(nameof(RetailCustomer.BankAccounts));
                navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            });

        }
    }
}