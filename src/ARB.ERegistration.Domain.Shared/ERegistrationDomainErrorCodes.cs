namespace ARB.ERegistration
{
    public static class ERegistrationDomainErrorCodes
    {
        const string Namespace = nameof(ERegistrationDomainErrorCodes);
        /* You can add your business exception error codes here, as constants */
        public static string UserNameUnique = $"{Namespace}:111";
        public static string RetailCustomerAlreadyExists = $"{Namespace}:222";
        public static string PinCodeLengthError = $"{Namespace}:333";
        public static string CardNumberLengthError = $"{Namespace}:444";
    }
}
