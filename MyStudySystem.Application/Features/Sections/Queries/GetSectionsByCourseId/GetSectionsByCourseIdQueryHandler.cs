
using AutoMapper;
using MediatR;
using MyStudySystem.Application.Contracts.Persistence;
using MyStudySystem.Application.Exceptions;

namespace MyStudySystem.Application.Features.Sections.Queries.GetSectionsByCourseId
{
    public class GetSectionsByCourseIdQueryHandler : IRequestHandler<GetSectionsByCourseIdQuery, IReadOnlyList<SectionDto>>
    {
        private readonly ISectionRepository _sectionRepository;
        private readonly IMapper _mapper;

        public GetSectionsByCourseIdQueryHandler(ISectionRepository sectionRepository, IMapper mapper)
        {
            _sectionRepository = sectionRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<SectionDto>> Handle(GetSectionsByCourseIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetSectionsByCourseIdQueryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count() > 0)
                throw new ValidationException(validationResult);

            var sections = await _sectionRepository.GetSectionsByCourseIdAsync(request.CourseId);

            var sectionDtos = _mapper.Map<IReadOnlyList<SectionDto>>(sections);

            return sectionDtos;
        }
    }
}
