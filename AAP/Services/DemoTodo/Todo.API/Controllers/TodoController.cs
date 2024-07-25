using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Command.Create;
using Todo.Application.Query.Get;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Todo.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TodoController(IMediator mediator) : ControllerBase
    {

        // POST api/<TodoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTodoCommand command)
        {
            var result = await mediator.Send(command);
            return CreatedAtAction(nameof(Get), new {Id = result.id}, result);
        }

        // GET: api/<TodoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var command = new GetTodoQuery();
            var result = await mediator.Send(command);
            return Ok(result);
        }

        // GET api/<TodoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // PUT api/<TodoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TodoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
