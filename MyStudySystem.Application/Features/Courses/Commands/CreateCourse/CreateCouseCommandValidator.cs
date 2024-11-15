
using FluentValidation;

namespace MyStudySystem.Application.Features.Courses.Commands.CreateCourse
{
    public class CreateCouseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        public CreateCouseCommandValidator() 
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(100).WithMessage("Title must be less than 100 characters.");

            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("Author is required.")
                .MaximumLength(100).WithMessage("Author must be less than 100 characters.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId is required.");
        }
    }
}
