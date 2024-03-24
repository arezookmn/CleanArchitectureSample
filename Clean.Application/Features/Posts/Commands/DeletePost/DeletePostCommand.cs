using MediatR;

namespace Clean.Application.Features.Posts.Commands.DeletePost;
public record DeletePostCommand : IRequest
{
    public Guid Id { get; set; }    
}
