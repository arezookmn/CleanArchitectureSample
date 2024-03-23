using Clean.Application.Common.Interfaces;
using Clean.Domain.Entities;
using Clean.Domain.RepositoryContracts;
using MapsterMapper;
using MediatR;

namespace Clean.Application.Features.Users.Commands.UpdateUser;
public class UpdateUserCommandHandler (IApplicationUnitOfWork uow, IUserRepository userRepository, IMapper mapper) : IRequestHandler<UpdateUserCommand, Guid>
{
    private readonly IApplicationUnitOfWork _uow = uow;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var userEntity = _mapper.Map<User>(request);
        _userRepository.Update(userEntity);
        await _uow.SaveAsync(cancellationToken);
        return userEntity.Id;
    }
}
