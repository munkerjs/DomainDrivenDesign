using DomainDrivenDesign.Domain.Users;
using DomainDrivenDesign.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Infrastructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(string name, string email, string password, string Country, string City, string Street, string FullAddress, string PostalCode, CancellationToken cancellationToken = default)
        {
            User user = User.CreateUser(name, email, password, Country, City, Street, FullAddress, PostalCode);
            await _context.Users.AddAsync(user, cancellationToken);

            return user;
        }

        public Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _context.Users.ToListAsync(cancellationToken);
        }
    }
}
