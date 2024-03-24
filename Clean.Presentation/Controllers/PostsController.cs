using Clean.Application.Features.Posts.Commands.AddPost;
using Clean.Application.Features.Posts.Commands.DeletePost;
using Clean.Application.Features.Posts.Queries.GetPostById;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Presentation.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PostsController (ISender sender): ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<ActionResult> CreatePost([FromBody] CreatePostCommand createPostCommand, CancellationToken cancellationToken)
    {
        try
        {
            return Ok(await _sender.Send(createPostCommand, cancellationToken));
        }
        catch (ValidationException ex)
        {
            var validationProblemDetails = new ValidationProblemDetails(ex.Errors.ToDictionary(e => e.PropertyName, e => new[] { e.ErrorMessage }));
            return ValidationProblem(validationProblemDetails);
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetPostResponse>> GetPost([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        GetPostQuery query = new GetPostQuery() { Id = id };
        var response = await _sender.Send(query, cancellationToken);
        if (response is null) return NotFound();
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdatePost([FromBody] UpdatePostCommand updatePostCommand, [FromRoute] Guid id, CancellationToken cancellationToken)
    {
        try
        {
            updatePostCommand.Id = id;
            await _sender.Send(updatePostCommand, cancellationToken);
            return NoContent();
        }
        catch (ValidationException ex)
        {
            var validationProblemDetails = new ValidationProblemDetails(ex.Errors.ToDictionary(e => e.PropertyName, e => new[] { e.ErrorMessage }));
            return ValidationProblem(validationProblemDetails);
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeletePost([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        DeletePostCommand command = new DeletePostCommand() { Id = id };
        await _sender.Send(command, cancellationToken);
        return NoContent();
    }

}
