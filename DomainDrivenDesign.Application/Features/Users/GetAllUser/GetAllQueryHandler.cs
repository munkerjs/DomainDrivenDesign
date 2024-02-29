using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Users;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Users.GetAllUser
{
    internal sealed class GetAllQueryHandler : IRequestHandler<GelAllUserQuery, List<User>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllQueryHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<User>> Handle(GelAllUserQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllAsync(cancellationToken);
        }
    }
}
