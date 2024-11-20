using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyStudySystem.Application.Features.GlossaryEntries.Commands.CreateGlossaryEntry;
using MyStudySystem.Application.Features.GlossaryEntries.Commands.DeleteGlossaryEntry;
using MyStudySystem.Application.Features.GlossaryEntries.Commands.UpdateGlossaryEntry;
using MyStudySystem.Application.Features.GlossaryEntries.Queries.GetGlossaryEntryByCourseId;

namespace MyStudySystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GlossaryEntriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GlossaryEntriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/GlossaryEntries/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGlossaryEntryById(Guid id)
        {
            //var query = new GetGlossaryEntryByIdQuery(id);
            //var entry = await _mediator.Send(query);
            //return Ok(entry);

            return Ok();
        }

        // GET: api/GlossaryEntries/course/{courseId}
        [HttpGet("course/{courseId}")]
        public async Task<IActionResult> GetGlossaryEntriesByCourseId(Guid courseId)
        {
            var query = new GetGlossaryEntriesByCourseIdQuery(courseId);
            var entries = await _mediator.Send(query);
            return Ok(entries);
        }

        // POST: api/GlossaryEntries
        [HttpPost]
        public async Task<IActionResult> CreateGlossaryEntry([FromBody] CreateGlossaryEntryCommand command)
        {
            var entryId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetGlossaryEntryById), new { id = entryId }, null);
        }

        // PUT: api/GlossaryEntries/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGlossaryEntry(Guid id, [FromBody] UpdateGlossaryEntryCommand command)
        {
            if (id != command.GlossaryEntryId)
                return BadRequest("Glossary Entry ID mismatch.");

            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE: api/GlossaryEntries/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGlossaryEntry(Guid id)
        {
            var command = new DeleteGlossaryEntryCommand { GlossaryEntryId = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
