
using MediatR;

namespace MyStudySystem.Application.Features.Courses.Commands.Delete_Course
{
    public class DeleteCourseCommand : IRequest
    {
        public Guid CourseId { get; set; }
    }
}
