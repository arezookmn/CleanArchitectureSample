using MediatR;

namespace Clean.Application.Features.Posts.Queries.GetAllPosts;
public record GetAllPostsQuery : IRequest<IEnumerable<GetAllPostResponse>>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
}
