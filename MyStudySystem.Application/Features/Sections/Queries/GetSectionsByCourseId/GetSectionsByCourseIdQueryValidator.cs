
using FluentValidation;

namespace MyStudySystem.Application.Features.Sections.Queries.GetSectionsByCourseId
{
    public class GetSectionsByCourseIdQueryValidator : AbstractValidator<GetSectionsByCourseIdQuery>
    {
        public GetSectionsByCourseIdQueryValidator()
        {
            RuleFor(x => x.CourseId)
                .NotEmpty().WithMessage("CourseId is required.");
        }
    }
}
