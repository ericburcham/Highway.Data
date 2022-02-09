using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Highway.Data.EntityFrameworkCore.ReadonlyTests
{
    [TestClass]
    public class ReadonlyDbContextTests
    {
        private static ReadonlyDbContext _target;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _target = new ReadonlyDbContext(Configuration.Instance.TestDatabaseConnectionString, new NoOpLogger());
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void CannotCallGenericSet()
        {
            var students = _target.Set<Student>();
            students.Add(new Student());
            _target.SaveChanges();
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void CannotCallSaveChanges()
        {
            _target.SaveChanges();
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public async Task CannotCallSaveChangesAsync()
        {
            await _target.SaveChangesAsync();
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public async Task CannotCallSaveChangesAsyncWithCancellationToken()
        {
            await _target.SaveChangesAsync(new CancellationToken());
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void CannotCallTypedSet()
        {
            var students = _target.Set(typeof(Student));
            students.Add(new Student());
            _target.SaveChanges();
        }
    }
}
