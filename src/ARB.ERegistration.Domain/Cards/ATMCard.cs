using ARB.ERegistration.Cards;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Values;
using NN = System.Diagnostics.CodeAnalysis;

namespace ARB.ERegistration.Card
{
    [Owned]
    public class ATMCard : ValueObject
    {
        private ATMCard()
        {

        }
        internal ATMCard(string cardNumber, string pinCode)
        {
            SetATMCard(cardNumber, pinCode);
        }

        public string PinCode { get; private set; }
        public string CardNumber { get; private set; }

        private void SetATMCard([NN.NotNull] string cardNumber, [NN.NotNull] string pinCode)
        {
            try
            {
                PinCode = Check.NotNullOrWhiteSpace(
                   pinCode,
                   nameof(pinCode),
                   maxLength: ATMCardConstants.PinCodeLength
               );

            }
            catch
            {
                throw new BusinessException(ERegistrationDomainErrorCodes.PinCodeLengthError).WithData(nameof(pinCode), pinCode);
            }
            
            try
            {
                CardNumber = Check.NotNullOrWhiteSpace(
                cardNumber,
                nameof(cardNumber),
                maxLength: ATMCardConstants.CardNumberLength
                );
            }
            catch
            {
                throw new BusinessException(ERegistrationDomainErrorCodes.CardNumberLengthError).WithData(nameof(cardNumber), cardNumber); ;
            }


        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return CardNumber;
            yield return PinCode;
        }
    }
}
