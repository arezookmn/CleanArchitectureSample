using Clean.Application.Features.Users.Commands.CreateUser;
using Clean.Application.Features.Users.Commands.DeleteUser;
using Clean.Application.Features.Users.Commands.UpdateUser;
using Clean.Application.Features.Users.Queries.GetUser;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Presentation.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand createUserCommand, CancellationToken cancellationToken)
    {
        try
        {
            return Ok(await _sender.Send(createUserCommand, cancellationToken));
        }
        catch (ValidationException ex)
        {
            var validationProblemDetails = new ValidationProblemDetails(ex.Errors.ToDictionary(e => e.PropertyName, e => new[] { e.ErrorMessage }));
            return ValidationProblem(validationProblemDetails);
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetUserResponse>> GetUser([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        GetUserQuery query = new GetUserQuery() { Id = id};
        var response = await _sender.Send(query, cancellationToken);
        if(response is null) return NotFound();
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateUser([FromBody] UpdateUserCommand updateUserCommand, [FromRoute] Guid id, CancellationToken cancellationToken)
    {
        try
        {
            updateUserCommand.Id = id;
            await _sender.Send(updateUserCommand, cancellationToken);
            return NoContent();
        }
        catch (ValidationException ex)
        {
            var validationProblemDetails = new ValidationProblemDetails(ex.Errors.ToDictionary(e => e.PropertyName, e => new[] { e.ErrorMessage }));
            return ValidationProblem(validationProblemDetails);
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteUser([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        DeleteUserCommand command = new DeleteUserCommand() {  Id = id };
        var response = await _sender.Send(command, cancellationToken);
        return Ok(true);
    }
}
