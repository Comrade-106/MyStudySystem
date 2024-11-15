
using AutoMapper;
using MediatR;
using MyStudySystem.Application.Contracts.Persistence;
using MyStudySystem.Application.Exceptions;
using MyStudySystem.Domain.Entities;

namespace MyStudySystem.Application.Features.Courses.Commands.UpdateCourse
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public UpdateCourseCommandHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCourseCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count() > 0)
                throw new ValidationException(validationResult);

            var course = await _courseRepository.GetByIdAsync(request.CourseId);

            if (course == null)
                throw new NotFoundException(nameof(Course), request.CourseId);

            _mapper.Map(request, course);

            await _courseRepository.UpdateAsync(course);

            return Unit.Value;
        }
    }
}
