using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyStudySystem.Application.Features.ControlQuestions.Commands.CreateControlQuestion;
using MyStudySystem.Application.Features.ControlQuestions.Commands.DeleteControlQuestion;
using MyStudySystem.Application.Features.ControlQuestions.Commands.UpdateControlQuestion;
using MyStudySystem.Application.Features.ControlQuestions.Queries.GetControlQuestionsBySectionId;

namespace MyStudySystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControlQuestionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ControlQuestionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/ControlQuestions/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetControlQuestionById(Guid id)
        {
            //var query = new GetControlQuestionByIdQuery(id);
            //var question = await _mediator.Send(query);
            //return Ok(question);

            return Ok();
        }

        // GET: api/ControlQuestions/section/{sectionId}
        [HttpGet("section/{sectionId}")]
        public async Task<IActionResult> GetControlQuestionsBySectionId(Guid sectionId)
        {
            var query = new GetControlQuestionsBySectionIdQuery() { SectionId = sectionId };
            var questions = await _mediator.Send(query);
            return Ok(questions);
        }

        // POST: api/ControlQuestions
        [HttpPost]
        public async Task<IActionResult> CreateControlQuestion([FromBody] CreateControlQuestionCommand command)
        {
            var questionId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetControlQuestionById), new { id = questionId }, null);
        }

        // PUT: api/ControlQuestions/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateControlQuestion(Guid id, [FromBody] UpdateControlQuestionCommand command)
        {
            if (id != command.QuestionId)
                return BadRequest("Question ID mismatch.");

            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE: api/ControlQuestions/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteControlQuestion(Guid id)
        {
            var command = new DeleteControlQuestionCommand { QuestionId = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
