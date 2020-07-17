using System.Threading;
using System.Threading.Tasks;
using GoogleBooks.Application.Common.Interfaces;
using GoogleBooks.Domain.Entities;
using MediatR;

namespace GoogleBooks.Application.Books.Commands.AddAsFavoriteBook
{
    public class AddAsFavoriteBookCommand : IRequest<string>
    {
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public string Id { get; set; }

        public class AddAsFavoriteBookCommandHandler : IRequestHandler<AddAsFavoriteBookCommand, string>
        {
            private readonly IApplicationDbContext _context;

            public AddAsFavoriteBookCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<string> Handle(AddAsFavoriteBookCommand request, CancellationToken cancellationToken)
            {
                var entity = new FavoriteBook()
                {
                    Name = request.Name
                    , Thumbnail = request.Thumbnail
                    , Id = request.Id
                };

                _context.FavoriteBooks.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}