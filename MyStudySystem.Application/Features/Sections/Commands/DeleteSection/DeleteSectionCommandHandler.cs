
using MediatR;
using MyStudySystem.Application.Contracts.Persistence;

namespace MyStudySystem.Application.Features.Sections.Commands.DeleteSection
{
    public class DeleteSectionCommandHandler : IRequestHandler<DeleteSectionCommand>
    {
        private ISectionRepository _sectionRepository;

        public DeleteSectionCommandHandler(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public async Task<Unit> Handle(DeleteSectionCommand request, CancellationToken cancellationToken)
        {
            var section = await _sectionRepository.GetByIdAsync(request.SectionId);

            await _sectionRepository.DeleteAsync(section);

            return Unit.Value;
        }
    }
}
