using GoogleBooks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace GoogleBooks.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<FavoriteBook> FavoriteBooks { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
