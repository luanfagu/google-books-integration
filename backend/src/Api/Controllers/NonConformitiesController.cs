using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GoogleBooks.Application.NonConformities.Commands.CreateNonConformity;
using GoogleBooks.Application.NonConformities.Commands.CreateNonConformityRevision;
using GoogleBooks.Application.NonConformities.Commands.UpdateNonConformityStatus;
using GoogleBooks.Application.NonConformities.Queries.GetNonConformity;
using GoogleBooks.Domain.Enums;

namespace GoogleBooks.Api.Controllers
{
    public class NonConformitiesController : ApiController
    {
        [HttpGet("{id}")]
        public async Task<NonConformityDto> Get(int id)
        {
            return await Mediator.Send(new GetNonConformityQuery {Id = id});
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateNonConformityCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateNonConformityStatusCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            if (command.Status == (int) NonConformityStatus.Ineffective)
            {
                await Mediator.Send(new CreateNonConformityRevisionCommand()
                {
                    Id = id
                });
            }

            return NoContent();
        }
    }
}