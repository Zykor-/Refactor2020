using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring
{
	public abstract class DC_Monster : DungeonCharacter
	{
		protected double chanceToHeal;
		protected int minHeal, maxHeal;

		public DC_Monster(string name, int hitPoints, int attackSpeed, double chanceToHit, double chanceToHeal, int damageMin, int damageMax, int minHeal, int maxHeal)
			:base(name, hitPoints, attackSpeed, chanceToHit, damageMin, damageMax)
		{
			this.chanceToHeal = chanceToHeal;
			this.maxHeal = maxHeal;
			this.minHeal = minHeal;
		}

		public void heal()
		{
			bool canHeal;
			int healPoints;
			Random rand = new Random();

			canHeal = (rand.NextDouble() <= chanceToHeal) && (hitPoints > 0);

			if (canHeal)
			{
				healPoints = rand.Next(minHeal, maxHeal);
				addHitPoints(healPoints);
				Console.WriteLine(name + " healed itself for " + healPoints + " points.\n" + "Total hit points remaining are: " + hitPoints + "\n");
			}
		}

		public override void subtractHitPoints(int hitPoints)
		{
			base.subtractHitPoints(hitPoints);
			heal();
		}
	}
}
