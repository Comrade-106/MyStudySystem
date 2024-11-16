
using FluentValidation;

namespace MyStudySystem.Application.Features.Sections.Commands.UpdateSection
{
    public class UpdateSectionCommandValidator : AbstractValidator<UpdateSectionCommand>
    {
        public UpdateSectionCommandValidator()
        {
            RuleFor(x => x.SectionId)
                .NotEmpty().WithMessage("SectionId is required.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title must be less than 100 characters.");
        }
    }
}
