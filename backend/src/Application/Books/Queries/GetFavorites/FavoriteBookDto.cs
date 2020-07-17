using GoogleBooks.Application.Common.Mappings;
using GoogleBooks.Domain.Entities;

namespace GoogleBooks.Application.Books.Queries.GetFavorites
{
    public class FavoriteBookDto : IMapFrom<FavoriteBook>
    {
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public string Id { get; set; }
    }
}