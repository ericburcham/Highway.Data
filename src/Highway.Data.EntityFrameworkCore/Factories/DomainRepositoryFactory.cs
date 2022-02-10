using System;
using System.Linq;

using Highway.Data.EntityFrameworkCore.Contexts;
using Highway.Data.EntityFrameworkCore.Interfaces;
using Highway.Data.EntityFrameworkCore.Repositories;

namespace Highway.Data.EntityFrameworkCore.Factories
{
    internal class DomainRepositoryFactory : IDomainRepositoryFactory, IReadonlyDomainRepositoryFactory
    {
        private readonly IDomain[] _domains;

        /// <summary>
        ///     Creates a repository factory for the supplied list of domains
        /// </summary>
        /// <param name="domains">Domains to support construction for</param>
        public DomainRepositoryFactory(IDomain[] domains)
        {
            _domains = domains;
        }

        public IRepository Create<T>()
            where T : class, IDomain
        {
            var domain = _domains.OfType<T>().SingleOrDefault();
            var context = new DomainContext<T>(domain);

            return new DomainRepository<T>(context, domain);
        }

        public IRepository Create(Type type)
        {
            return (IRepository)CreateRepository(type, typeof(DomainContext<>), typeof(DomainRepository<>));
        }

        public IReadonlyRepository CreateReadonly<T>()
            where T : class, IDomain
        {
            throw new NotImplementedException();
        }

        public IReadonlyRepository CreateReadonly(Type type)
        {
            throw new NotImplementedException();
        }

        private object CreateRepository(Type domainType, Type contextType, Type repositoryType)
        {
            Type[] typeArgs = { domainType };

            var domain = _domains.SingleOrDefault(x => x.GetType() == domainType);
            var contextConstructor = contextType.MakeGenericType(typeArgs);
            var context = Activator.CreateInstance(contextConstructor, domain);
            var repositoryConstructor = repositoryType.MakeGenericType(typeArgs);

            return Activator.CreateInstance(repositoryConstructor, context, domain);
        }
    }
}
