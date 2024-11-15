
using AutoMapper;
using MediatR;
using MyStudySystem.Application.Contracts.Persistence;
using MyStudySystem.Application.Exceptions;

namespace MyStudySystem.Application.Features.ControlQuestions.Commands.UpdateControlQuestion
{
    public class UpdateControlQuestionCommandHandler : IRequestHandler<UpdateControlQuestionCommand>
    {
        private readonly IControlQuestionRepository _controlQuestionRepository;
        private readonly IMapper _mapper;

        public UpdateControlQuestionCommandHandler(IControlQuestionRepository controlQuestionRepository, IMapper mapper)
        {
            _controlQuestionRepository = controlQuestionRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateControlQuestionCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateControlQuestionCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if(validationResult.Errors.Count() > 0)
                throw new ValidationException(validationResult);

            var controlQuestion = await _controlQuestionRepository.GetByIdAsync(request.QuestionId);
            if (controlQuestion == null)
                throw new NotFoundException(nameof(ControlQuestions), request.QuestionId);

            _mapper.Map(request, controlQuestion);

            await _controlQuestionRepository.UpdateAsync(controlQuestion);

            return Unit.Value;
        }
    }
}
