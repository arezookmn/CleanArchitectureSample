using FluentValidation;

namespace Clean.Application.Features.Posts.Commands.AddPost;
public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
{
    public CreatePostCommandValidator()
    {
        RuleFor(p => p.text)
            .NotEmpty().WithMessage("Post content cant be empty")
            .MaximumLength(5000).WithMessage("Post content cant be exceed than 5000 character");


        RuleFor(p => p.title)
            .NotEmpty().WithMessage("Post title cant be empty")
            .MaximumLength(300).WithMessage("Post title cant be exceed than 300 character");
    }
}
