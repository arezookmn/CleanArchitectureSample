using MediatR;

namespace Clean.Application.Features.Users.Commands.DeleteUser;
public class DeleteUserCommand : IRequest
{
    public Guid Id { get; set; }
}
