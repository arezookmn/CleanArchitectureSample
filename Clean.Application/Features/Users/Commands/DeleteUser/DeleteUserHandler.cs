using Clean.Application.Common.Interfaces;
using Clean.Domain.RepositoryContracts;
using MediatR;

namespace Clean.Application.Features.Users.Commands.DeleteUser;
public class DeleteUserHandler(IApplicationUnitOfWork uow, IUserRepository userRepository) : IRequestHandler<DeleteUserCommand>
{
    private readonly IApplicationUnitOfWork _uow = uow;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        _userRepository.Delete(await _userRepository.GetByIdAsync(request.Id));
        await _uow.SaveAsync(cancellationToken);

    }
}
