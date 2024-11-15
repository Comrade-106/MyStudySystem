
using MediatR;

namespace MyStudySystem.Application.Features.Courses.Commands.CreateCourse
{
    public class CreateCourseCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public TimeSpan? Duration { get; set; }
        public string? Url { get; set; }
        public Guid UserId { get; set; }
    }
}
