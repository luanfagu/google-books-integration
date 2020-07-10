using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GoogleBooks.Application.Actions.Commands.CreateAction;
using GoogleBooks.Application.NonConformities.Commands.CreateNonConformity;

namespace GoogleBooks.Api.Controllers
{
    public class ActionsController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateActionCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}