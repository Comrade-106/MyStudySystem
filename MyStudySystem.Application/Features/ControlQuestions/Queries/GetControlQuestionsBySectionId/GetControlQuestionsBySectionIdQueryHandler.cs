
using AutoMapper;
using MediatR;
using MyStudySystem.Application.Contracts.Persistence;
using MyStudySystem.Application.Exceptions;

namespace MyStudySystem.Application.Features.ControlQuestions.Queries.GetControlQuestionsBySectionId
{
    public class GetControlQuestionsBySectionIdQueryHandler : IRequestHandler<GetControlQuestionsBySectionIdQuery, IReadOnlyList<ControlQuestionDto>>
    {
        private readonly IControlQuestionRepository _controlQuestionRepository;
        private readonly IMapper _mapper;

        public GetControlQuestionsBySectionIdQueryHandler(IControlQuestionRepository controlQuestionRepository, IMapper mapper)
        {
            _controlQuestionRepository = controlQuestionRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ControlQuestionDto>> Handle(GetControlQuestionsBySectionIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetControlQuestionsBySectionIdQueryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count() > 0)
                throw new ValidationException(validationResult);

            var questions = await _controlQuestionRepository.GetQuestionsBySectionIdAsync(request.SectionId);

            return _mapper.Map<IReadOnlyList<ControlQuestionDto>>(questions);
        }
    }
}
