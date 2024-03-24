using Clean.Application.Common.Interfaces;
using Clean.Domain.Entities;
using Clean.Domain.RepositoryContracts;
using MapsterMapper;
using MediatR;

namespace Clean.Application.Features.Posts.Commands.AddPost;
public class CreatePostCommandHandler(IApplicationUnitOfWork uow, IPostRepository postRepository, IMapper mapper) : IRequestHandler<CreatePostCommand, Guid>
{
    private readonly IApplicationUnitOfWork _uow = uow;
    private readonly IPostRepository _postRepository = postRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var post = _mapper.Map<Post>(request);
        _postRepository.Add(post);
        await _uow.SaveAsync(cancellationToken);
        return post.Id;
    }
}
