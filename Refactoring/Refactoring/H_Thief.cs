using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring
{
	public class H_Thief : DC_Hero
	{
		public H_Thief() : base("Thief", 75, 6, .8, 20, 40, .5) { }

		public void surpriseAttack(DungeonCharacter opponent)
		{
			Random rand = new Random();
			double surprise = rand.NextDouble();

			if (surprise <= .4)
			{
				Console.WriteLine("Surprise attack was successful!\n" + name + " gets an additional turn.");
				numTurns++;
				attack(opponent);
			}
			else if (surprise >= .9)
			{
				Console.WriteLine("Uh oh! " + opponent.getName() + " saw you and" + " blocked your attack!");
			}
			else
				attack(opponent);
		}

		public override void battleChoices(DungeonCharacter opponent)
		{
			base.battleChoices(opponent);
			int choice;

			do
			{
				Console.WriteLine("1. Attack Opponent");
				Console.WriteLine("2. Surprise Attack");
				Console.WriteLine("Choose an option: ");
				choice = Convert.ToInt32(Console.ReadKey());

				switch (choice)
				{
					case 1:
						attack(opponent);
						break;
					case 2:
						surpriseAttack(opponent);
						break;
					default:
						Console.WriteLine("invalid choice!");
						break;
				}

				numTurns--;
				if (numTurns > 0)
					Console.WriteLine("Number of turns remaining is: " + numTurns);

			} while (numTurns > 0);
		}
	}
}
