using AutoMapper;
using MediatR;
using MyStudySystem.Application.Contracts.Persistence;
using MyStudySystem.Application.Exceptions;
using MyStudySystem.Domain.Entities;

namespace MyStudySystem.Application.Features.GlossaryEntries.Commands.CreateGlossaryEntry
{
    public class CreateGlossaryEntryCommandHandler : IRequestHandler<CreateGlossaryEntryCommand, Guid>
    {
        private readonly IGlossaryEntryRepository _glossaryEntryRepository;
        private readonly IMapper _mapper;

        public CreateGlossaryEntryCommandHandler(IGlossaryEntryRepository glossaryEntryRepository, IMapper mapper)
        {
            _glossaryEntryRepository = glossaryEntryRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateGlossaryEntryCommand request, CancellationToken cancellationToken)
        {
            var glossaryEntry = _mapper.Map<GlossaryEntry>(request);

            var validator = new CreateGlossaryEntryCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count() > 0)
                throw new ValidationException(validatorResult);

            glossaryEntry = await _glossaryEntryRepository.AddAsync(glossaryEntry);

            return glossaryEntry.GlossaryEntryId;
        }
    }
}
