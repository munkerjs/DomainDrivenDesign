using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Users
{
    public sealed class User : BaseEntity
    {
        public User(Guid Id, Name name, Email email, Password password, Address address) : base(Id)
        {
            Name = name;
            Email = email;
            Password = password;
            Address = address;
        }

        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }
        public Address Address { get; private set; }

        public void ChangeName(string name) => Name = new(name);
        public void ChangeEmail(string email) => Email = new(email);        
        public void ChangePassword(string password) => Password = new(password);        
        public void ChangeAddress(string Country, string City, string Street, string FullAddress, string PostalCode) => Address = new(Country, City, Street, FullAddress, PostalCode);
    }
}
