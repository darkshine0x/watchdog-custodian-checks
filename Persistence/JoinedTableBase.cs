using System;

namespace Watchdog.Persistence
{
    [AttributeUsage(AttributeTargets.Class)]
    class JoinedTableBase : Attribute
    {
        public Type[] DerivedTypes { get; set; }

        public JoinedTableBase(params Type[] derivedTypes)
        {
            DerivedTypes = derivedTypes;
        }
    }
}
