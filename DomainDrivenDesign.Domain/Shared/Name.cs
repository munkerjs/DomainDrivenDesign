namespace DomainDrivenDesign.Domain.Shared
{
    /// <summary>
    /// Artık Name parametresine bir veri gönderildiğinde aşağıdaki kontrollerden geçecektir.
    /// </summary>
    public sealed record Name
    {
        public string Value { get; init; }
        public Name(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("İsim alanı boş geçilemez.");

            if (value.Length < 3)
                throw new ArgumentException("İsim alanı 3 karakterden fazla olmalıdır.");

            Value = value;
        }
    }


}
