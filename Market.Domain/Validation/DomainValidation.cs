namespace Market.Domain.Validation
{
    internal class DomainValidation : Exception
    {
        public DomainValidation(string error) : base(error) { }
        public static void When(bool hasError, string error)
        {
            if (hasError)
            {
                throw new DomainValidation(error);
            }
        }
    }
}
