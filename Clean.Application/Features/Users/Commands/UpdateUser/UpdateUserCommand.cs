using MediatR;

namespace Clean.Application.Features.Users.Commands.UpdateUser;
public record UpdateUserCommand : IRequest<Guid> 
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
}

