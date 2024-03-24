using Clean.Domain.RepositoryContracts;
using MapsterMapper;
using MediatR;

namespace Clean.Application.Features.Posts.Queries.GetPostById;
public class GetPostQueryHandler(IPostRepository postRepository, IMapper mapper) : IRequestHandler<GetPostQuery, GetPostResponse>
{
    private readonly IPostRepository _postRepository = postRepository;
    private readonly IMapper _mapper = mapper;
    public async Task<GetPostResponse> Handle(GetPostQuery request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetByIdAsync(request.Id);
        if(post is null) { }//todo: custom exception
        var response = _mapper.Map<GetPostResponse>(post);
        return response;
    }
}
