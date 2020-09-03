namespace Watchdog.Forms.Util
{
    public interface IPassedObject<T>
    {
        void OnSubmit(T obj);
    }
}
