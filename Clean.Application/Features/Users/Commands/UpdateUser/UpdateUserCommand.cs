using MediatR;

namespace Clean.Application.Features.Users.Commands.UpdateUser;
public record UpdateUserCommand : IRequest<Guid> 
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

