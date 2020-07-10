using GoogleBooks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace GoogleBooks.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<NonConformity> NonConformities { get; set; }
        DbSet<Action> Actions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
