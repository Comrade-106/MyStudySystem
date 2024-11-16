
using AutoMapper;
using MediatR;
using MyStudySystem.Application.Contracts.Persistence;
using MyStudySystem.Application.Exceptions;
using MyStudySystem.Domain.Entities;

namespace MyStudySystem.Application.Features.Sections.Commands.UpdateSection
{
    public class UpdateSectionCommandHandler : IRequestHandler<UpdateSectionCommand>
    {
        private readonly ISectionRepository _sectionRepository;
        private readonly IMapper _mapper;

        public UpdateSectionCommandHandler(ISectionRepository sectionRepository, IMapper mapper)
        {
            _sectionRepository = sectionRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSectionCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count() > 0)
                throw new ValidationException(validationResult);

            var section = await _sectionRepository.GetByIdAsync(request.SectionId);
            if (section == null)
                throw new NotFoundException(nameof(Section), request.SectionId);

            _mapper.Map(request, section);

            await _sectionRepository.UpdateAsync(section);

            return Unit.Value;
        }
    }
}
