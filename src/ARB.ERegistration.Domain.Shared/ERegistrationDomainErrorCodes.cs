namespace ARB.ERegistration
{
    public static class ERegistrationDomainErrorCodes
    {
        const string Namespace = nameof(ERegistrationDomainErrorCodes);
        /* You can add your business exception error codes here, as constants */
        public static string UserNameUnique = $"{Namespace}:UserNameUnique";
        public static string RetailCustomerAlreadyExists = $"{Namespace}:RetailCustomerAlreadyExists";
    }
}
