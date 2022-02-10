using Microsoft.EntityFrameworkCore;

namespace Highway.Data.EntityFrameworkCore
{
    public static class ModelBuilderExtensions
    {
        public static void AddConfiguration<TEntity>(
            this ModelBuilder modelBuilder,
            EntityTypeConfiguration<TEntity> entityConfiguration)
            where TEntity : class
        {
            modelBuilder.Entity<TEntity>(entityConfiguration.Configure);
        }
    }
}