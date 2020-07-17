using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GoogleBooks.Application.Books.Commands.AddAsFavoriteBook;
using GoogleBooks.Application.Common.Exceptions;
using GoogleBooks.Application.Common.Interfaces;
using GoogleBooks.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GoogleBooks.Application.Books.Commands.RemoveFromFavorites
{
    public class RemoveFromFavoritesCommand : IRequest<string>
    {
        public string Id { get; set; }

        public class RemoveFromFavoritesCommandHandler : IRequestHandler<RemoveFromFavoritesCommand, string>
        {
            private readonly IApplicationDbContext _context;

            public RemoveFromFavoritesCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<string> Handle(RemoveFromFavoritesCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.FavoriteBooks
                    .Where(l => l.Id == request.Id)
                    .SingleOrDefaultAsync(cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(FavoriteBook), request.Id);
                }

                _context.FavoriteBooks.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}