﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Users.Events
{
    public sealed class UserDomainEvent : INotification
    {
        public User User { get; }
        public UserDomainEvent(User user)
        {
            User = user;
        }
    }
}
