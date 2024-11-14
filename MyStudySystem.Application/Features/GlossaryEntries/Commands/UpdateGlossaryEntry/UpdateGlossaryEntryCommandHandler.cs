
using AutoMapper;
using MediatR;
using MyStudySystem.Application.Contracts.Persistence;
using MyStudySystem.Application.Exceptions;
using MyStudySystem.Domain.Entities;

namespace MyStudySystem.Application.Features.GlossaryEntries.Commands.UpdateGlossaryEntry
{
    public class UpdateGlossaryEntryCommandHandler : IRequestHandler<UpdateGlossaryEntryCommand>
    {
        private readonly IGlossaryEntryRepository _glossaryEntryRepository;
        private readonly IMapper _mapper;

        public UpdateGlossaryEntryCommandHandler(IGlossaryEntryRepository glossaryEntryRepository, IMapper mapper)
        {
            _glossaryEntryRepository = glossaryEntryRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateGlossaryEntryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateGlossaryEntryCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count() > 0)
                throw new ValidationException(validationResult);

            var glossaryEntry = await _glossaryEntryRepository.GetByIdAsync(request.GlossaryEntryId);
            if (glossaryEntry == null)
                throw new NotFoundException(nameof(GlossaryEntry), request.GlossaryEntryId);

            _mapper.Map(request, glossaryEntry);

            await _glossaryEntryRepository.UpdateAsync(glossaryEntry);

            return Unit.Value;
        }
    }
}
