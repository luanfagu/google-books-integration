using System.Threading;
using System.Threading.Tasks;
using MediatR;
using GoogleBooks.Application.Common.Exceptions;
using GoogleBooks.Application.Common.Interfaces;
using GoogleBooks.Domain.Entities;

namespace GoogleBooks.Application.NonConformities.Commands.UpdateNonConformityStatus
{
    public partial class UpdateNonConformityStatusCommand : IRequest
    {
        public int Id { get; set; }

        public int Status { get; set; }

        public class UpdateNonConformityStatusCommandHandler : IRequestHandler<UpdateNonConformityStatusCommand>
        {
            private readonly IApplicationDbContext _context;

            public UpdateNonConformityStatusCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateNonConformityStatusCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.NonConformities.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(NonConformity), request.Id);
                }

                entity.Status = request.Status;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}