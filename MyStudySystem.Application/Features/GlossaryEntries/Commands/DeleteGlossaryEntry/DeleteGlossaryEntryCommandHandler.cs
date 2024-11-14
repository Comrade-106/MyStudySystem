
using AutoMapper;
using MediatR;
using MyStudySystem.Application.Contracts.Persistence;

namespace MyStudySystem.Application.Features.GlossaryEntries.Commands.DeleteGlossaryEntry
{
    public class DeleteGlossaryEntryCommandHandler : IRequestHandler<DeleteGlossaryEntryCommand>
    {
        private readonly IGlossaryEntryRepository _glossaryEntryRepository;

        public DeleteGlossaryEntryCommandHandler(IGlossaryEntryRepository glossaryEntryRepository)
        {
            _glossaryEntryRepository = glossaryEntryRepository;
        }

        public async Task<Unit> Handle(DeleteGlossaryEntryCommand request, CancellationToken cancellationToken)
        {
            var glossaryEntryToDelete = await _glossaryEntryRepository.GetByIdAsync(request.GlossaryEntryId);

            await _glossaryEntryRepository.DeleteAsync(glossaryEntryToDelete);

            return Unit.Value;
        }
    }
}
