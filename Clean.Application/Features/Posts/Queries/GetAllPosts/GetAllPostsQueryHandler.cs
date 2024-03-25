using Clean.Domain.RepositoryContracts;
using MapsterMapper;
using MediatR;

namespace Clean.Application.Features.Posts.Queries.GetAllPosts;
public class GetAllPostsQueryHandler(IPostRepository postRepository, IMapper mapper) : IRequestHandler<GetAllPostsQuery, IEnumerable<GetAllPostResponse>>
{
    private readonly IPostRepository _postRepository = postRepository;
    private readonly IMapper _mapper = mapper;
    public async Task<IEnumerable<GetAllPostResponse>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
    {
        int skip = (request.Page - 1) * request.PageSize;
        int take = request.PageSize;

        var response = await _postRepository.GetAllPosts(skip, take);
        return response.Select(p => _mapper.Map<GetAllPostResponse>(p));    
    }
}
