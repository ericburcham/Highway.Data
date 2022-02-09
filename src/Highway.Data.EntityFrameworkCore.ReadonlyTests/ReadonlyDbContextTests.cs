using System;
using System.Linq;
using System.Threading.Tasks;

using Highway.Data.EntityFrameworkCore.Contexts;

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
            _target = new ReadonlyDbContext();
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void CannotCallAdd()
        {
            var foo = (object)new Foo();
            _target.Add(foo);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public async Task CannotCallAddAsync()
        {
            var foo = (object)new Foo();
            await _target.AddAsync(foo);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public async Task CannotCallAddRangeAsyncWithEnumerable()
        {
            await _target.AddRangeAsync(Enumerable.Empty<Foo>());
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public async Task CannotCallAddRangeAsyncWithParams()
        {
            await _target.AddRangeAsync(new Foo());
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void CannotCallAddRangeWithEnumerable()
        {
            _target.AddRange(Enumerable.Empty<Foo>());
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void CannotCallAddRangeWithParams()
        {
            _target.AddRange(new Foo());
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void CannotCallAttach()
        {
            var foo = (object)new Foo();
            _target.Attach(foo);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void CannotCallAttachRangeWithEnumerable()
        {
            _target.AttachRange(Enumerable.Empty<Foo>());
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void CannotCallAttachRangeWithParams()
        {
            _target.AttachRange(new Foo());
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void CannotCallGenericAdd()
        {
            _target.Add(new Foo());
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public async Task CannotCallGenericAddAsync()
        {
            await _target.AddAsync(new Foo());
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void CannotCallGenericAddRange()
        {
            _target.AddRange(new Foo());
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public async Task CannotCallGenericAddRangeAsync()
        {
            await _target.AddRangeAsync(new Foo());
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void CannotCallGenericAttach()
        {
            _target.Attach(new Foo());
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void CannotCallGenericAttachRange()
        {
            _target.AttachRange(new Foo());
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void CannotCallGenericRemove()
        {
            _target.Remove(new Foo());
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void CannotCallGenericRemoveRange()
        {
            _target.RemoveRange(Enumerable.Empty<Foo>());
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void CannotCallGenericUpdate()
        {
            _target.Update(new Foo());
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void CannotCallGenericUpdateRange()
        {
            _target.UpdateRange(Enumerable.Empty<Foo>());
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void CannotCallRemove()
        {
            var foo = (object)new Foo();
            _target.Remove(foo);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void CannotCallRemoveRange()
        {
            var foo = (object)new Foo();
            _target.RemoveRange(foo);
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
        public async Task CannotCallSaveChangesAsyncWithAcceptAllChangesOnSuccess()
        {
            await _target.SaveChangesAsync(true);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public async Task CannotCallSaveChangesAsyncWithCancellationToken()
        {
            await _target.SaveChangesAsync();
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void CannotCallSaveChangesWithAcceptAllChangesOnSuccess()
        {
            _target.SaveChanges(true);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void CannotCallSet()
        {
            var students = _target.Set<Foo>();
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void CannotCallSetWithName()
        {
            var students = _target.Set<Foo>("name");
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void CannotCallUpdate()
        {
            var foo = (object)new Foo();
            _target.Update(foo);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void CannotCallUpdateRange()
        {
            var foo = (object)new Foo();
            _target.UpdateRange(foo);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void CannotGetChangeTracker()
        {
            var changeTacker = _target.ChangeTracker;
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void CannotGetDatabase()
        {
            var database = _target.Database;
        }

        private class Foo
        {
        }
    }
}
