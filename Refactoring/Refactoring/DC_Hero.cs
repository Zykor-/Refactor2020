using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring
{
	public abstract class DC_Hero : DungeonCharacter
	{
		protected double chanceToBlock;
		protected int numTurns;

		public DC_Hero(string name, int hitPoints, int attackSpeed, double chanceToHit, int damageMin, int damageMax,  double chanceToBlock) 
			: base(name, hitPoints, attackSpeed, chanceToHit, damageMin, damageMax)
		{
			this.chanceToBlock = chanceToBlock;
			readName();
		}

		public void readName()
		{
			Console.WriteLine("Enter character name: ");
			name = Convert.ToString(Console.ReadLine());
		}

		public Boolean canDefend()
		{
			Random rand = new Random();
			return rand.NextDouble() <= chanceToBlock;
		}

		public override void subtractHitPoints(int hitPoints)
		{
			if (canDefend())
				Console.WriteLine(name + " BLOCKED the attack!");
			else
				base.subtractHitPoints(hitPoints);
		}

		public virtual void battleChoices(DungeonCharacter opponent)
		{
			numTurns = attackSpeed / opponent.getAttackSpeed();

			if (numTurns == 0)
				numTurns++;

			Console.WriteLine("Number of turns this round is: " + numTurns);
		}
	}
}
