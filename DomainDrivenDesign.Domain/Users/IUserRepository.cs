using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Users
{
    public interface IUserRepository
    {
        Task CreateAsync(string name, string email, string password, string Country, string City, string Street, string FullAddress, string PostalCode, CancellationToken cancellationToken = default);
        Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
