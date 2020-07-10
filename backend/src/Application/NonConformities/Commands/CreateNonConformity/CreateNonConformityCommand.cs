using System;
using System.Linq;
using GoogleBooks.Application.Common.Interfaces;
using GoogleBooks.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using GoogleBooks.Domain.Enums;

namespace GoogleBooks.Application.NonConformities.Commands.CreateNonConformity
{
    public class CreateNonConformityCommand : IRequest<int>
    {
        public string Description { get; set; }

        public class CreateNonConformitiesCommandHandler : IRequestHandler<CreateNonConformityCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public CreateNonConformitiesCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateNonConformityCommand request, CancellationToken cancellationToken)
            {
                var lastIdentity = _context.NonConformities.Where(n => n.Year == DateTime.Now.Year)
                    .OrderByDescending(n => n.Identity).Select(n => n.Identity).FirstOrDefault();

                var entity = new NonConformity
                {
                    Description = request.Description
                    , Status = (int) NonConformityStatus.Open
                    , Year = DateTime.Now.Year
                    , Identity = lastIdentity + 1
                    , Revision = 0
                };

                _context.NonConformities.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}