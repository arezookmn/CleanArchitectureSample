using Clean.Domain.Entities;
using MediatR;

namespace Clean.Application.Features.Posts.Commands.AddPost;
public record UpdatePostCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string text { get; set; }
    public string title { get; set; }
    public Guid UserId { get; set; }
}
