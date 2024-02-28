namespace DomainDrivenDesign.Domain.Users
{
    /// <summary>
    /// Password parametresine bir veri gönderildiğinde aşağıdaki kontrollerden geçecektir.
    /// </summary>
    public sealed record Password
    {
        public string Value { get; init; }
        public Password(string value)
        {
            if(string.IsNullOrEmpty(value))
                throw new ArgumentException("Şifre boş geçilemez.");

            if (value.Length < 6)
                throw new ArgumentException("Şifre 6 karakterden fazla olmalıdır.");

            Value = value;
        }

    }


}
