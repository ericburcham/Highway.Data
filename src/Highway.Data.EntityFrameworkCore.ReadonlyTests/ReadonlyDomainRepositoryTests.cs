using System;

using Highway.Data.EntityFrameworkCore.Factories;
using Highway.Data.EntityFrameworkCore.Interfaces;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Highway.Data.EntityFrameworkCore.ReadonlyTests
{
    [TestClass]
    public class ReadonlyDomainRepositoryTests
    {
        private static IReadonlyRepository _target;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            var schoolDomain = new Domain();
            var domainRepositoryFactory = new DomainRepositoryFactory(new IDomain[] { schoolDomain });
            var domainRepository = domainRepositoryFactory.Create(typeof(Domain));

            var firstGrade = new Grade
            {
                Name = "first",
                Section = "section one"
            };

            var bill = new Student
            {
                DoB = DateTime.Now.Subtract(TimeSpan.FromDays(365)),
                Height = 60,
                Weight = 180,
                Name = "Bill"
            };

            firstGrade.AddStudent(bill);

            domainRepository.Context.Add(bill);
            domainRepository.Context.Commit();

            _target = domainRepositoryFactory.CreateReadonly(typeof(Domain)) as IReadonlyDomainRepository<Domain>;
        }

        [TestMethod]
        public void CanExecuteQuery()
        {
        }

        [TestMethod]
        public void CanExecuteScalar()
        {
        }
    }
}
