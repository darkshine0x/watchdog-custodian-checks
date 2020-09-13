using System;

namespace Watchdog.Persistence
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    class PersistableField : Attribute
    {
        public int Order { get; }

        public PersistableField(int order)
        {
            Order = order;
        }
    }
}
