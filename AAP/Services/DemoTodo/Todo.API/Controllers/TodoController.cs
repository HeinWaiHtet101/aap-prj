using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Command.Create;
using Todo.Application.Command.Delete;
using Todo.Application.Query.Get;
using Todo.Application.Query.GetById;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Todo.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TodoController(IMediator mediator) : ControllerBase
    {

        #region Create

        // POST api/<TodoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTodoCommand command)
        {
            var result = await mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { Id = result.id }, result);
        }
        #endregion

        #region Read

        // GET: api/<TodoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var command = new GetTodoQuery();
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [Produces("application/json")]
        [EndpointSummary("Get Todo byId")]
        [EndpointDescription("Get Todo ById")]
        public async Task<IActionResult> Get(Guid id)
        {
            // request bind with query for application call
            var query = new GetTodoByIdQuery(id);

            // call application via Mediator
            var result = await mediator.Send(query);

            // Result Response
            return Ok(result);
        }
        #endregion

        #region Update

        // PUT api/<TodoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        #endregion

        #region Delete


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [Produces("application/json")]
        [EndpointSummary("Delete Todo")]
        [EndpointDescription("Delete Todo ")]
        public async Task<IActionResult> Delete(Guid id)
        {
            // bind request as command
            var command = new DeleteTodoCommand(id);

            var result = await mediator.Send(command);

            return Ok(result);
        }
        #endregion
    }
}
