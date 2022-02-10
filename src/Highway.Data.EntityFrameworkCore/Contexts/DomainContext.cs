using Highway.Data.EntityFrameworkCore.Interfaces;

namespace Highway.Data.EntityFrameworkCore.Contexts
{
    internal class DomainContext<T> : DataContext, IDomainContext<T>
        where T : class, IDomain
    {
        public DomainContext(T domain)
            : base(domain.ConnectionString, domain.Mappings)
        {
        }
    }
}
