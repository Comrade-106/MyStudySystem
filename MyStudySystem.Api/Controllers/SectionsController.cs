using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyStudySystem.Application.Features.Sections.Commands.CreateSection;
using MyStudySystem.Application.Features.Sections.Commands.DeleteSection;
using MyStudySystem.Application.Features.Sections.Commands.UpdateSection;
using MyStudySystem.Application.Features.Sections.Queries.GetSectionsByCourseId;

namespace MyStudySystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SectionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SectionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Sections/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSectionById(Guid id)
        {
            //var query = new GetSectionByIdQuery(id);
            //var section = await _mediator.Send(query);
            //return Ok(section);

            return Ok();
        }

        // GET: api/Sections/course/{courseId}
        [HttpGet("course/{courseId}")]
        public async Task<IActionResult> GetSectionsByCourseId(Guid courseId)
        {
            var query = new GetSectionsByCourseIdQuery() { CourseId = courseId };
            var sections = await _mediator.Send(query);
            return Ok(sections);
        }

        // POST: api/Sections
        [HttpPost]
        public async Task<IActionResult> CreateSection([FromBody] CreateSectionCommand command)
        {
            var sectionId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetSectionById), new { id = sectionId }, null);
        }

        // PUT: api/Sections/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSection(Guid id, [FromBody] UpdateSectionCommand command)
        {
            if (id != command.SectionId)
                return BadRequest("Section ID mismatch.");

            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE: api/Sections/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSection(Guid id)
        {
            var command = new DeleteSectionCommand { SectionId = id };
            await _mediator.Send(command);
            return NoContent();
        }

        // POST: api/Sections/{sectionId}/images
        //[HttpPost("{sectionId}/images")]
        //public async Task<IActionResult> AddImageToSection(Guid sectionId, [FromForm] IFormFile imageFile, [FromForm] string description)
        //{
        //    if (imageFile == null || imageFile.Length == 0)
        //        return BadRequest("No image file provided.");

        //    using var memoryStream = new MemoryStream();
        //    await imageFile.CopyToAsync(memoryStream);
        //    var imageData = memoryStream.ToArray();

        //    var command = new AddImageToSectionCommand
        //    {
        //        SectionId = sectionId,
        //        ImageData = imageData,
        //        Description = description
        //    };

        //    await _mediator.Send(command);
        //    return Ok();
        //}
    }
}
