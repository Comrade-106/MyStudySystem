
using FluentValidation;

namespace MyStudySystem.Application.Features.Courses.Commands.UpdateCourse
{
    public class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseCommand>
    {
        public UpdateCourseCommandValidator() 
        {
            RuleFor(x => x.CourseId)
                .NotEmpty().WithMessage("CourseId is required.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(100).WithMessage("Title must be less than 100 characters.");

            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("Author is required.")
                .MaximumLength(100).WithMessage("Author must be less than 100 characters.");
        }
    }
}
