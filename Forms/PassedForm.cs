using System.Collections.Generic;

namespace Watchdog.Forms
{
    public interface PassedForm
    {
        void OnSubmit(List<string> passedValue, string reference);
    }
}
