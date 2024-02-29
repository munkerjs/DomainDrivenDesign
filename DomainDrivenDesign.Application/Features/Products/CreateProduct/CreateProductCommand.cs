﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Application.Features.Products.CreateProduct
{
    public sealed record class CreateProductCommand(string Name, int Quantity, decimal Amount, string Currency, Guid CategoryId) : IRequest;
}
