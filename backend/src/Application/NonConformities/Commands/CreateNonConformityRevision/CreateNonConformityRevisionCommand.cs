﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using GoogleBooks.Application.Common.Interfaces;
using GoogleBooks.Application.NonConformities.Commands.CreateNonConformity;
using GoogleBooks.Domain.Entities;
using GoogleBooks.Domain.Enums;

namespace GoogleBooks.Application.NonConformities.Commands.CreateNonConformityRevision
{
    public class CreateNonConformityRevisionCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class CreateNonConformityRevisionCommandHandler : IRequestHandler<CreateNonConformityRevisionCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public CreateNonConformityRevisionCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateNonConformityRevisionCommand request, CancellationToken cancellationToken)
            {
                var baseNonConformity = await _context.NonConformities.FindAsync(request.Id);

                var entity = new NonConformity
                {
                    Description = baseNonConformity.Description
                    , Status = (int)NonConformityStatus.Open
                    , Year = baseNonConformity.Year
                    , Identity = baseNonConformity.Identity
                    , Revision = baseNonConformity.Revision + 1
                };

                _context.NonConformities.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}