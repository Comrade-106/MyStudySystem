
using AutoMapper;
using MediatR;
using MyStudySystem.Application.Contracts.Persistence;
using MyStudySystem.Application.Exceptions;
using MyStudySystem.Domain.Entities;

namespace MyStudySystem.Application.Features.Courses.Commands.CreateCourse
{
    public class CreateCouserCommandHandler : IRequestHandler<CreateCourseCommand, Guid>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CreateCouserCommandHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCouseCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count() > 0)
                throw new ValidationException(validationResult);

            var course = _mapper.Map<Course>(request);

            course = await _courseRepository.AddAsync(course);

            return course.CourseId;
        }
    }
}
