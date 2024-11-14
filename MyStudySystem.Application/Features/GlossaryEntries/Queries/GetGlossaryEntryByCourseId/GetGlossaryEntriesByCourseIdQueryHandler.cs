using AutoMapper;
using MediatR;
using MyStudySystem.Application.Contracts.Persistence;

namespace MyStudySystem.Application.Features.GlossaryEntries.Queries.GetGlossaryEntryByCourseId
{
    public class GetGlossaryEntriesByCourseIdQueryHandler : IRequestHandler<GetGlossaryEntriesByCourseIdQuery, IReadOnlyList<GlossaryEntryDto>>
    {
        private readonly IGlossaryEntryRepository _glossaryEntryRepository;
        private readonly IMapper _mapper;

        public GetGlossaryEntriesByCourseIdQueryHandler(IGlossaryEntryRepository glossaryEntryRepository, IMapper mapper)
        {
            _glossaryEntryRepository = glossaryEntryRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<GlossaryEntryDto>> Handle(GetGlossaryEntriesByCourseIdQuery request, CancellationToken cancellationToken)
        {
            var entries = await _glossaryEntryRepository.GetEntriesByCourseIdAsync(request.CourseId);

            return _mapper.Map<IReadOnlyList<GlossaryEntryDto>>(entries);
        }
    }

}
