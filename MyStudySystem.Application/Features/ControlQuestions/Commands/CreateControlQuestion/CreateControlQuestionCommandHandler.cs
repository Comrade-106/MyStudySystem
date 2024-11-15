
using AutoMapper;
using MediatR;
using MyStudySystem.Application.Contracts.Persistence;
using MyStudySystem.Application.Exceptions;
using MyStudySystem.Domain.Entities;

namespace MyStudySystem.Application.Features.ControlQuestions.Commands.CreateControlQuestion
{
    public class CreateControlQuestionCommandHandler : IRequestHandler<CreateControlQuestionCommand, Guid>
    {
        private readonly IControlQuestionRepository _controlQuestionRepository;
        private readonly IMapper _mapper;

        public CreateControlQuestionCommandHandler(IControlQuestionRepository controlQuestionRepository, IMapper mapper)
        {
            _controlQuestionRepository = controlQuestionRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateControlQuestionCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateControlQuestionCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count() > 0)
                throw new ValidationException(validationResult);

            var controleQuestion = _mapper.Map<ControlQuestion>(request);

            var result = await _controlQuestionRepository.AddAsync(controleQuestion);

            return result.QuestionId;
        }
    }
}
