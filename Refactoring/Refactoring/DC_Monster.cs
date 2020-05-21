using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring
{
	public abstract class DC_Monster : DungeonCharacter
	{
		protected double chanceToHeal;
		protected int minHeal, maxHeal;

		public DC_Monster(string name, int hitPoints, int AttackSpeed, double chanceToHit, double chanceToHeal, int damageMin, int damageMax, int minHeal, int maxHeal)
			:base(name, hitPoints, AttackSpeed, chanceToHit, damageMin, damageMax)
		{
			this.chanceToHeal = chanceToHeal;
			this.maxHeal = maxHeal;
			this.minHeal = minHeal;
		}

		public void Heal()
		{
			bool canHeal;
			int HealPoints;
			Random rand = new Random();

			canHeal = (rand.NextDouble() <= chanceToHeal) && (hitPoints > 0);

			if (canHeal)
			{
				HealPoints = rand.Next(minHeal, maxHeal);
				AddHitPoints(HealPoints);
				Console.WriteLine(name + " Healed itself for " + HealPoints + " points.\n" + "Total hit points remaining are: " + hitPoints + "\n");
			}
		}

		public override void SubtractHitPoints(int hitPoints)
		{
			base.SubtractHitPoints(hitPoints);
			Heal();
		}
	}
}
