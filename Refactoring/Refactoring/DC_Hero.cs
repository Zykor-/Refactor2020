using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring
{
	public abstract class DC_Hero : DungeonCharacter
	{
		protected double chanceToBlock;
		protected int numTurns;

		public DC_Hero(string name, int hitPoints, int AttackSpeed, double chanceToHit, int damageMin, int damageMax,  double chanceToBlock) 
			: base(name, hitPoints, AttackSpeed, chanceToHit, damageMin, damageMax)
		{
			this.chanceToBlock = chanceToBlock;
			ReadName();
		}

		private void ReadName()
		{
			Console.WriteLine("Enter character name: ");
			name = Convert.ToString(Console.ReadLine());
		}

		public Boolean CanDefend()
		{
			Random rand = new Random();
			return rand.NextDouble() <= chanceToBlock;
		}

		public override void SubtractHitPoints(int hitPoints)
		{
			if (CanDefend())
				Console.WriteLine(name + " BLOCKED the Attack!");
			else
				base.SubtractHitPoints(hitPoints);
		}

		public override void BattleChoices(DC opponent)
		{
			numTurns = AttackSpeed / opponent.GetAttackSpeed();

			if (numTurns == 0)
				numTurns++;

			Console.WriteLine("Number of turns this round is: " + numTurns);
		}
	}
}
