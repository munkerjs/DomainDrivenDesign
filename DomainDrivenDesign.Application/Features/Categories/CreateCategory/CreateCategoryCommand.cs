﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Application.Features.Categories.CreateCategory
{
    public sealed record class CreateCategoryCommand(string name) : IRequest;
}
