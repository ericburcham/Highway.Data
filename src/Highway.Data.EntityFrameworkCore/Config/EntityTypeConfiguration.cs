using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Highway.Data.EntityFrameworkCore
{
    public abstract class EntityTypeConfiguration<T>
        where T : class
    {
        public abstract void Configure(EntityTypeBuilder<T> builder);
    }
}
