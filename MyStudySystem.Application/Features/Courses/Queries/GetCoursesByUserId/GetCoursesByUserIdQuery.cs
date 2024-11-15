
using MediatR;

namespace MyStudySystem.Application.Features.Courses.Queries.GetCoursesByUserId
{
    public class GetCoursesByUserIdQuery : IRequest<IReadOnlyList<CourseDto>>
    {
        public Guid UserId { get; set; }
    }
}
