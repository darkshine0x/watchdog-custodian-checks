using System;

namespace Watchdog.Forms.Util
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TableHeader : Attribute
    {
        public string HeaderText { get; }
        public int Size { get; }

        public TableHeader(string headerText, int size = 200)
        {
            HeaderText = headerText;
            Size = size;
        }
    }
}
