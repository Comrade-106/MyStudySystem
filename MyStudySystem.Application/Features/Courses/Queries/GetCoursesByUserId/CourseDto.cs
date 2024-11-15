
namespace MyStudySystem.Application.Features.Courses.Queries.GetCoursesByUserId
{
    public class CourseDto
    {
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public TimeSpan Duration { get; set; }
        public string Url { get; set; }
    }
}
