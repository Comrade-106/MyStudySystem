
using FluentValidation;

namespace MyStudySystem.Application.Features.Courses.Queries.GetCoursesByUserId
{
    public class GetCoursesByUserIdQueryValidator : AbstractValidator<GetCoursesByUserIdQuery>
    {
        public GetCoursesByUserIdQueryValidator() 
        { 
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId is required.");
        }
    }
}
