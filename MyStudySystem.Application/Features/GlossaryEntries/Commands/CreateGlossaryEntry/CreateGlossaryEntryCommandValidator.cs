
using FluentValidation;

namespace MyStudySystem.Application.Features.GlossaryEntries.Commands.CreateGlossaryEntry
{
    public class CreateGlossaryEntryCommandValidator : AbstractValidator<CreateGlossaryEntryCommand>
    {
        public CreateGlossaryEntryCommandValidator()
        {
            RuleFor(x => x.CourseId)
                .NotEmpty().WithMessage("CourseId is required.");

            RuleFor(x => x.Term)
                .NotEmpty().WithMessage("Term is required.")
                .MaximumLength(100).WithMessage("Term must be less than 100 characters.");

            RuleFor(x => x.Definition)
                .NotEmpty().WithMessage("Definition is required.")
                .MaximumLength(1000).WithMessage("Definition must be less than 1000 characters.");
        }
    }
}
