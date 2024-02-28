namespace DomainDrivenDesign.Domain.Users
{
    /// <summary>
    /// Kimliği olmayan, genellikle Immutable olan nesneler Value Object kavramına dahildir. 
    /// Buna örnek olarak; Adres bilgileri, para birimleri, kordinatlar ve benzeri yapılar.. 
    /// Value Object yapısı ve kullanım örneği;
    /// Record: Class'ın daha kısası, set bloklarını int olarak alıp atandıktan sonra bir daha değiştirilemez.
    /// Entity içerisinde tanımladığım propertiler, gruplayabildiğim veya tek başına kullanbildiğim; kontrolünün daha fazla bence olmasını ve ayrı bir şekilde değerlendirmek 
    /// istediğim alanları ayrı bir class a alıp ekstra iş kuralları yazarak yönetebilirim.
    /// </summary>
    /// <param name="Country"></param>
    /// <param name="City"></param>
    /// <param name="Street"></param>
    /// <param name="FullAddress"></param>
    /// <param name="PostalCode"></param>
    public sealed record Address(string Country, string City, string Street, string FullAddress, string PostalCode);


}
