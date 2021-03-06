using System;
using Highway.Data.Interceptors.Events;

namespace Highway.Data.Contexts
{
    public class InMemoryDomainContext<T> : InMemoryDataContext, IDomainContext<T> where T : class
    {
        public event EventHandler<BeforeSave> BeforeSave;
        public event EventHandler<AfterSave> AfterSave;

        public int Commit()
        {
            OnBeforeSave(new BeforeSave());
            var changes = base.Commit();
            OnAfterSave(new AfterSave());
            return changes;
        }

        protected virtual void OnBeforeSave(BeforeSave e)
        {
            BeforeSave?.Invoke(this, e);
        }

        protected virtual void OnAfterSave(AfterSave e)
        {
            AfterSave?.Invoke(this, e);
        }
    }
}