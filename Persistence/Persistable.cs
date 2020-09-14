namespace Watchdog.Persistence
{
    public interface Persistable
    {
        string GetTableName();

        string GetShortName();

        double GetIndex();

        void SetIndex(double index);
    }
}
