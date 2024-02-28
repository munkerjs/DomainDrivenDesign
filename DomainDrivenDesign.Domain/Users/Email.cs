namespace DomainDrivenDesign.Domain.Users
{
    /// <summary>
    /// Email parametresine bir veri gönderildiğinde aşağıdaki kontrollerden geçecektir.
    /// </summary>
    public sealed record Email
    {
        public string Value { get; init; }
        public Email(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Email alanı boş geçilemez.");

            if (value.Length < 3)
                throw new ArgumentException("Email alanı 3 karakterden fazla olmalıdır.");

            if(!value.Contains("@"))
                throw new ArgumentException("Geçerli bir mail adresi giriniz.");

            Value = value;
        } 
    }


}
