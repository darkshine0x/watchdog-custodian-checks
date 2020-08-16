namespace Watchdog.Persistence
{
    public class TableUpdateWrapper
    {
        public double Index { get; }
        public string Attribute { get; }
        public string Value { get; }

        public TableUpdateWrapper(double index, string attribute, string value)
        {
            Index = index;
            Attribute = attribute;
            Value = value;
        }
    }
}
