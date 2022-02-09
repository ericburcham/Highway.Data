using System.Data.Entity.ModelConfiguration;

namespace Highway.Data.EntityFramework.ReadonlyTests
{
    public class GradeMap : EntityTypeConfiguration<Grade>
    {
        public GradeMap()
        {
            ToTable("Grade");
            HasKey(x => x.GradeId);
        }
    }
}
