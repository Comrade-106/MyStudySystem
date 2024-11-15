
using MediatR;

namespace MyStudySystem.Application.Features.Courses.Commands.UpdateCourse
{
    public class UpdateCourseCommand : IRequest
    {
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public TimeSpan? Duration { get; set; }
        public string? Url { get; set; }
    }
}
