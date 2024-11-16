
using FluentValidation;

namespace MyStudySystem.Application.Features.Sections.Commands.CreateSection
{
    public class CreateSectionCommandValidator : AbstractValidator<CreateSectionCommand>
    {
        public CreateSectionCommandValidator()
        {
            RuleFor(x => x.CourseId)
                .NotEmpty().WithMessage("CourseId is required.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title must be less than 100 characters.");

            RuleFor(x => x.ParentSectionId)
                .Must(BeValidGuidOrNull).WithMessage("Invalid ParentSectionId.");
        }

        private bool BeValidGuidOrNull(Guid? guid)
        {
            return guid == null || guid != Guid.Empty;
        }
    }
}
