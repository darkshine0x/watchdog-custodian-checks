using System;

namespace Watchdog.Persistence
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    class PersistableField : Attribute
    {
    }
}
