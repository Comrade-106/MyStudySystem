
using AutoMapper;
using MediatR;
using MyStudySystem.Application.Contracts.Persistence;
using MyStudySystem.Application.Exceptions;

namespace MyStudySystem.Application.Features.Courses.Queries.GetCoursesByUserId
{
    public class GetCoursesByUserIdQueryHandler : IRequestHandler<GetCoursesByUserIdQuery, IReadOnlyList<CourseDto>>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public GetCoursesByUserIdQueryHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<CourseDto>> Handle(GetCoursesByUserIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetCoursesByUserIdQueryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count() > 0)
                throw new ValidationException(validationResult);

            var courses = await _courseRepository.GetCoursesByUserIdAsync(request.UserId);

            return _mapper.Map<IReadOnlyList<CourseDto>>(courses);
        }
    }
}
