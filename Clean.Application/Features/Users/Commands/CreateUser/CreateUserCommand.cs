using MediatR;

namespace Clean.Application.Features.Users.Commands.CreateUser;
public record CreateUserCommand : IRequest<Guid> 
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

