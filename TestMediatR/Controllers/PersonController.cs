using System.Threading.Tasks;
using BusinessLogic;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TestMediatR.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PersonController : Controller
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddPersonCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Query([FromQuery] PersonQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}