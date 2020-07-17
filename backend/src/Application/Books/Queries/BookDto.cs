using GoogleBooks.Application.Common.Mappings;
using GoogleBooks.Domain.Entities;

namespace GoogleBooks.Application.Books.Queries
{
    public class BookDto : IMapFrom<Book>
    {
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public string Id { get; set; }
    }
}