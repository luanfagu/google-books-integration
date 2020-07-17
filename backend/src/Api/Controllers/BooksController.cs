using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GoogleBooks.Application.Books.Commands.AddAsFavoriteBook;
using GoogleBooks.Application.Books.Commands.RemoveFromFavorites;
using GoogleBooks.Application.Books.Queries;
using GoogleBooks.Application.Books.Queries.GetFavorites;
using GoogleBooks.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        [HttpGet("SearchBook/{query}")]
        public async Task<List<BookDto>> GetBooks(string query)
        {
            HttpClient client = new HttpClient();
            var jsonBooks = await client.GetStringAsync("https://www.googleapis.com/books/v1/volumes?q=" + query);

            var bookReturn = JsonConvert.DeserializeObject<Book>(jsonBooks);

            if (bookReturn.totalItems > 0)
            {
                return bookReturn.items.Select(b => new BookDto()
                    {Id = b.id, Name = b.volumeInfo.title, Thumbnail = b.volumeInfo.imageLinks?.thumbnail}).ToList();
            }

            return new List<BookDto>();
        }
    }
}
