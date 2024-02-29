using DomainDrivenDesign.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Application.Features.Users.GetAllUser
{
    public sealed record class GelAllUserQuery() : IRequest<List<User>>;
}
