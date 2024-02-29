using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Application.Features.Users.CreateUser
{
    public sealed record class CreateUserCommand(
        string name, 
        string email, 
        string password, 
        string Country, 
        string City, 
        string Street, 
        string FullAddress, 
        string PostalCode) : IRequest;
}
