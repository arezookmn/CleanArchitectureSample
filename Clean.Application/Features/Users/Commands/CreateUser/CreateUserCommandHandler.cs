using Clean.Application.Common.Interfaces;
using Clean.Domain.Entities;
using Clean.Domain.RepositoryContracts;
using MapsterMapper;
using MediatR;

namespace Clean.Application.Features.Users.Commands.CreateUser;
public class CreateUserCommandHandler (IApplicationUnitOfWork uow, IUserRepository userRepository, IMapper mapper) : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IApplicationUnitOfWork _uow = uow;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userEntity = _mapper.Map<User>(request);
        _userRepository.Add(userEntity);
        await _uow.SaveAsync(cancellationToken);
        return userEntity.Id;
    }
}
