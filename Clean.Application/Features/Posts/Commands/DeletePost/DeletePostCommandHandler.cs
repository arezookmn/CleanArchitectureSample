using Clean.Application.Common.Interfaces;
using Clean.Domain.RepositoryContracts;
using MediatR;

namespace Clean.Application.Features.Posts.Commands.DeletePost;
public class DeletePostCommandHandler(IApplicationUnitOfWork uow, IPostRepository postRepository) : IRequestHandler<DeletePostCommand>
{
    private readonly IApplicationUnitOfWork _uow = uow;
    private readonly IPostRepository _postRepository = postRepository;
    public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetByIdAsync(request.Id);
        if (post is null) { } //throw custom exception
        _postRepository.Delete(post);
        await _uow.SaveAsync(cancellationToken);
    }
}
