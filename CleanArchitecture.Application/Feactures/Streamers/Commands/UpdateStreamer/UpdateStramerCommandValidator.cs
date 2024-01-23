using FluentValidation;

namespace CleanArchitecture.Application.Feactures.Streamers.Commands.UpdateStreamer;

public class UpdateStramerCommandValidator: AbstractValidator<UpdateStreamerCommand>
{
    public UpdateStramerCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotNull().WithMessage("{Name} no permite valores nulos");

        RuleFor(p => p.Url)
            .NotNull().WithMessage("{Url} no permite valores nulos");
    }
    
}