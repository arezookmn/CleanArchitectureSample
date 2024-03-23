using MediatR;

namespace Clean.Application.Features.Users.Queries.GetUser;
public record GetUserQuery : IRequest<GetUserResponse>
{
    public Guid Id { get; set; }
}
