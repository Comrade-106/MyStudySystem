
using MediatR;
using MyStudySystem.Application.Contracts.Persistence;

namespace MyStudySystem.Application.Features.ControlQuestions.Commands.DeleteControlQuestion
{
    public class DeleteControlQuestionCommandHandler : IRequestHandler<DeleteControlQuestionCommand>
    {
        private readonly IControlQuestionRepository _controlQuestionRepository;

        public DeleteControlQuestionCommandHandler(IControlQuestionRepository controlQuestionRepository)
        {
            _controlQuestionRepository = controlQuestionRepository;
        }

        public async Task<Unit> Handle(DeleteControlQuestionCommand request, CancellationToken cancellationToken)
        {
            var questionToDelete = await _controlQuestionRepository.GetByIdAsync(request.QuestionId);

            await _controlQuestionRepository.DeleteAsync(questionToDelete);

            return Unit.Value;
        }
    }
}
