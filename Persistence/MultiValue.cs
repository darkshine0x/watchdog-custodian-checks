using System;

namespace Watchdog.Persistence
{
    [AttributeUsage(AttributeTargets.Property)]
    class MultiValue : Attribute
    {
        public MultiValue()
        {
        }
    }
}
