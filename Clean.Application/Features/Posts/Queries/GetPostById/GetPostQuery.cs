using MediatR;

namespace Clean.Application.Features.Posts.Queries.GetPostById;
public record GetPostQuery : IRequest<GetPostResponse>
{
    public Guid Id { get; set; }
}
