
using FluentValidation;

namespace MyStudySystem.Application.Features.ControlQuestions.Queries.GetControlQuestionsBySectionId
{
    public class GetControlQuestionsBySectionIdQueryValidator : AbstractValidator<GetControlQuestionsBySectionIdQuery>
    {
        public GetControlQuestionsBySectionIdQueryValidator()
        {
            RuleFor(x => x.SectionId)
                .NotEmpty().WithMessage("SectionId is required.");
        }
    }
}
