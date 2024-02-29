﻿using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Users;
using DomainDrivenDesign.Domain.Users.Events;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Users.CreateUser
{
    internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // TODO: Kontrol varsa bu alanda belirleyelim.

           var user = await _userRepository.CreateAsync(
                request.name, 
                request.email, 
                request.password, 
                request.Country, 
                request.City, 
                request.Street,
                request.FullAddress, 
                request.PostalCode
            );

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _mediator.Publish(new UserDomainEvent(user)); // görevleri tetikleyelim.
        }
    }
}
