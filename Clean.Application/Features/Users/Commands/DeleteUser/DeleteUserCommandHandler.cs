using Clean.Application.Common.Interfaces;
using Clean.Domain.RepositoryContracts;
using MediatR;

namespace Clean.Application.Features.Users.Commands.DeleteUser;
public class DeleteUserCommandHandler(IApplicationUnitOfWork uow, IUserRepository userRepository) : IRequestHandler<DeleteUserCommand,bool>
{
    private readonly IApplicationUnitOfWork _uow = uow;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        _userRepository.Delete(await _userRepository.GetByIdAsync(request.Id));
        await _uow.SaveAsync(cancellationToken);
        return true;
    }
}
