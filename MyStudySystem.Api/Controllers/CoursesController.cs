using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyStudySystem.Application.Features.Courses.Commands.CreateCourse;
using MyStudySystem.Application.Features.Courses.Commands.Delete_Course;
using MyStudySystem.Application.Features.Courses.Commands.UpdateCourse;
using MyStudySystem.Application.Features.Courses.Queries.GetCoursesByUserId;

namespace MyStudySystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CoursesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Courses/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(Guid id)
        {
            //var query = new GetCourseByIdQuery(id);
            //var course = await _mediator.Send(query);
            //return Ok(course);
            return Ok();
        }

        // GET: api/Courses/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetCoursesByUserId(Guid userId)
        {
            var query = new GetCoursesByUserIdQuery() { UserId = userId };
            var courses = await _mediator.Send(query);
            return Ok(courses);
        }

        // POST: api/Courses
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseCommand command)
        {
            var courseId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCourseById), new { id = courseId }, null);
        }

        // PUT: api/Courses/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(Guid id, [FromBody] UpdateCourseCommand command)
        {
            if (id != command.CourseId)
                return BadRequest("Course ID mismatch.");

            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE: api/Courses/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            var command = new DeleteCourseCommand { CourseId = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
