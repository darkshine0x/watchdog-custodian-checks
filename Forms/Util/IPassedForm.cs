using System.Collections.Generic;

namespace Watchdog.Forms.Util
{
    public interface IPassedForm
    {
        void OnSubmit(List<string> passedValue = null, string reference = null);
    }
}
