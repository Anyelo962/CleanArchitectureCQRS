using FluentValidation;

namespace CleanArchitecture.Application.Feactures.Streamers.Commands.CreateStreamer;

public class CreateStreamerCommandValidator: AbstractValidator<CreateStreamerCommand>
{
    public CreateStreamerCommandValidator()
    {
        RuleFor(p => p.Nombre)
            .NotEmpty().WithMessage("The name can't be empty")
            .NotNull()
            .MaximumLength(50).WithMessage("The name don't be more than 50 characters");

        RuleFor(p => p.Url)
            .NotEmpty().WithMessage("You don't send the {Url} empty");
    }
}