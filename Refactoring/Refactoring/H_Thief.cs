using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring
{
	public class H_Thief : DC_Hero
	{
		public H_Thief() : base("Thief", 75, 6, .8, 20, 40, .5) { }

		private void SurpriseAttack(DC opponent)
		{
			Random rand = new Random();
			double surprise = rand.NextDouble();

			if (surprise <= .4)
			{
				Console.WriteLine("Surprise Attack was successful!\n" + name + " Gets an Additional turn.");
				numTurns++;
				Attack(opponent);
			}
			else if (surprise >= .9)
			{
				Console.WriteLine("Uh oh! " + opponent.GetName() + " saw you and" + " blocked your Attack!");
			}
			else
				Attack(opponent);
		}

		public override void BattleChoices(DC opponent)
		{
			base.BattleChoices(opponent);
			int choice;

			do
			{
                DungeonMenu m = new DungeonMenu();
                m.AddOption("Attack Opponent");
                m.AddOption("Surprise Attack");
                m.DisplayMenu();
                choice = m.Select();

				switch (choice)
				{
					case 1:
						Attack(opponent);
						break;
					case 2:
						SurpriseAttack(opponent);
						break;
				}

				numTurns--;
				if (numTurns > 0)
					Console.WriteLine("Number of turns remaining is: " + numTurns);

			} while (numTurns > 0);
		}
	}
}
