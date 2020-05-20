using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring
{
	public class H_Warrior : DC_Hero
	{
		public H_Warrior() : base("Warrior", 125, 4, .8, 35, 60, .2) { }

		public void crushingBlow(DungeonCharacter opponent)
		{
			Random rand = new Random();

			if (rand.NextDouble() <= .4)
			{
				int blowPoints = rand.Next(100, 176);
				Console.WriteLine(name + " lands a CRUSHING BLOW for " + blowPoints + " damage!");
				opponent.subtractHitPoints(blowPoints);
			}
			else
				Console.WriteLine(name + " failed to land a crushing blow\n");
		}

		public override void attack(DungeonCharacter opponent)
		{
			Console.WriteLine(name + " swings a mighty sword at " + opponent.getName() + ":");
			base.attack(opponent);
		}

		public override void battleChoices(DungeonCharacter opponent)
		{
			int choice;

			base.battleChoices(opponent);

			do
			{
				Console.WriteLine("1. Attack Opponent");
				Console.WriteLine("2. Crushing Blow on Opponent");
				Console.WriteLine("Choose an option: ");
				choice = Convert.ToInt32(Console.ReadKey());

				switch (choice)
				{
					case 1:
						attack(opponent);
						break;
					case 2:
						crushingBlow(opponent);
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
