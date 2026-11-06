using System.Collections.Generic;

namespace War.Soldiers
{
    internal class AttackReport
    {
        internal AttackReport(string attackersName, List<Target> targets)
        {
            AttackersName = attackersName;
            Targets = targets;
        }

        internal AttackReport(string attackersName, Target target)
        {
            AttackersName = attackersName;
            Targets = new List<Target> { target };
        }

        public IReadOnlyCollection<Target> Targets { get; private set; }

        public string AttackersName { get; private set; }
    }
}
