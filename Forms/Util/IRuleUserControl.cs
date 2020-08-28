using Watchdog.Entities;

namespace Watchdog.Forms.Util
{
    interface IRuleUserControl
    {
        void InvokeSubmission(RuleKind ruleKind);
    }
}
