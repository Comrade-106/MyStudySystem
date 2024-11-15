
using FluentValidation;

namespace MyStudySystem.Application.Features.ControlQuestions.Commands.UpdateControlQuestion
{
    public class UpdateControlQuestionCommandValidator : AbstractValidator<UpdateControlQuestionCommand>
    {
        public UpdateControlQuestionCommandValidator() 
        {
            RuleFor(x => x.QuestionId)
                .NotEmpty().WithMessage("QuestionId is required.");

            RuleFor(x => x.QuestionText)
                .NotEmpty().WithMessage("QuesitonText is required.")
                .MaximumLength(200).WithMessage("QuestionText must be less than 200 characters.");

            RuleFor(x => x.AnswerText)
                .NotEmpty().WithMessage("AnswerText is required.")
                .MaximumLength(1000).WithMessage("AnswerText must be less than 1000 charactes.");
        }
    }
}
