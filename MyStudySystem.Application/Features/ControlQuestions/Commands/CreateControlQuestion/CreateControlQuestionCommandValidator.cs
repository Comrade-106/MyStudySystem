
using FluentValidation;
using System.Security.Cryptography.X509Certificates;

namespace MyStudySystem.Application.Features.ControlQuestions.Commands.CreateControlQuestion
{
    public class CreateControlQuestionCommandValidator : AbstractValidator<CreateControlQuestionCommand>
    {
        public CreateControlQuestionCommandValidator()
        {
            RuleFor(x => x.SectionId)
                .NotEmpty().WithMessage("SectionId is required.");

            RuleFor(x => x.QuestionText).
                NotEmpty().WithMessage("QuestionText is required")
                .MaximumLength(200).WithMessage("QuestionText must be less than 200 characters.");

            RuleFor(x => x.AnswerText)
                .NotEmpty().WithMessage("AnswerText is required.")
                .MaximumLength(1000).WithMessage("AnswerText must be less than 1000 characters.");
        }
    }
}
