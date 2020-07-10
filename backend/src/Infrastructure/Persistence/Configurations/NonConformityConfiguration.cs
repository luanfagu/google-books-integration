using GoogleBooks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoogleBooks.Infrastructure.Persistence.Configurations
{
    public class NonConformityConfiguration : IEntityTypeConfiguration<NonConformity>
    {
        public void Configure(EntityTypeBuilder<NonConformity> builder)
        {            
        }
    }
}
