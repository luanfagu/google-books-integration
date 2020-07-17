using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GoogleBooks.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GoogleBooks.Application.Books.Queries.GetFavorites
{
    public class GetFavoritesQuery : IRequest<List<FavoriteBookDto>>
    {
        public class GetFavoritesQueryHandler : IRequestHandler<GetFavoritesQuery, List<FavoriteBookDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
        
            public GetFavoritesQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
        
            public async Task<List<FavoriteBookDto>> Handle(GetFavoritesQuery request, CancellationToken cancellationToken)
            {
                return await _context.FavoriteBooks
                    .ProjectTo<FavoriteBookDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
            }
        }
    }
}