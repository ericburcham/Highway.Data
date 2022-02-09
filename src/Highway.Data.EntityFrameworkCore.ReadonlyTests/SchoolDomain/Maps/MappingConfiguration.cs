using Microsoft.EntityFrameworkCore;

namespace Highway.Data.EntityFrameworkCore.ReadonlyTests
{
    internal class MappingConfiguration : IMappingConfiguration
    {
        public void ConfigureModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new GradeMap());
            modelBuilder.AddConfiguration(new StudentMap());
        }
    }
}
