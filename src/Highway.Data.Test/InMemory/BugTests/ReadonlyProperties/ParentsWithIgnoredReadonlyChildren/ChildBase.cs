namespace Highway.Data.Test.InMemory.BugTests.ReadonlyProperties.ParentsWithIgnoredReadonlyChildren
{
    public class ChildBase : IIdentifiable<long>
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
