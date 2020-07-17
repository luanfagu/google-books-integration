using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoogleBooks.Application.Books.Commands.AddAsFavoriteBook;
using GoogleBooks.Application.Books.Commands.RemoveFromFavorites;
using GoogleBooks.Application.Books.Queries;
using GoogleBooks.Application.Books.Queries.GetFavorites;
using Microsoft.AspNetCore.Mvc;

namespace GoogleBooks.Api.Controllers
{
    public class BooksController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<string>> Add(AddAsFavoriteBookCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("GetFavorites")]
        public async Task<List<FavoriteBookDto>> Get()
        {
            return await Mediator.Send(new GetFavoritesQuery());
        }

        [HttpDelete("RemoveFavorite/{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await Mediator.Send(new RemoveFromFavoritesCommand() { Id = id });

            return NoContent();
        }
    }
}
