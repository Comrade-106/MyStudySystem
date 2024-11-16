
using AutoMapper;
using MediatR;
using MyStudySystem.Application.Contracts.Persistence;
using MyStudySystem.Application.Exceptions;
using MyStudySystem.Domain.Entities;

namespace MyStudySystem.Application.Features.Sections.Commands.CreateSection
{
    public class CreateSectionCommandHandler : IRequestHandler<CreateSectionCommand, Guid>
    {
        private readonly ISectionRepository _sectionRepository;
        private readonly IMapper _mapper;

        public CreateSectionCommandHandler(ISectionRepository sectionRepository, IMapper mapper)
        {
            _sectionRepository = sectionRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateSectionCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count() > 0)
                throw new ValidationException(validationResult);

            var section = _mapper.Map<Section>(request);

            section = await _sectionRepository.AddAsync(section);

            return section.SectionId;
        }
    }
}
