namespace Watchdog.Forms.Util
{
    public class DropDownItem<T>
    {
        public T Value { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
