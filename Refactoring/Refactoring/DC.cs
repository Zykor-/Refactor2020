using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring
{
    public interface DC
    {
        string GetName();
        int GetHitPoints();
        int GetAttackSpeed();
        void AddHitPoints(int hitPoints);
        void SubtractHitPoints(int hitPoints);
        Boolean IsAlive();
        void Attack(DC opponent);
        void BattleChoices(DC opponent);
    }
}
