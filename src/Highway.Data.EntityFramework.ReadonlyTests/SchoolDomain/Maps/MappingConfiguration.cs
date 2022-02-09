using System.Data.Entity;

namespace Highway.Data.EntityFramework.ReadonlyTests
{
    public class MappingConfiguration : IMappingConfiguration
    {
        public void ConfigureModelBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GradeMap());
            modelBuilder.Configurations.Add(new StudentMap());
        }
    }
}
