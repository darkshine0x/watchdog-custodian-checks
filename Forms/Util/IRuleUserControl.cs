using Watchdog.Entities;

namespace Watchdog.Forms.Util
{
    interface IRuleUserControl
    {
        Rule InvokeSubmission(RuleKind ruleKind);
    }
}
