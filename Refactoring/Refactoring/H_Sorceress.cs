using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring
{
	public class H_Sorceress : DC_Hero
	{
		private readonly int MIN_ADD = 25;
		private readonly int MAX_ADD = 50;

		public H_Sorceress() : base("Sorceress", 75, 5, .7, 25, 50, .3) { }

		public void increaseHitPoints()
		{
			int hPoints;
			Random rand = new Random();

			hPoints = rand.Next(MIN_ADD, MAX_ADD);
			addHitPoints(hPoints);
			Console.WriteLine(name + " added [" + hPoints + "] points.\n" + "Total hit points remaining are: "	+ hitPoints + "\n");
		}

		public override void attack(DungeonCharacter opponent)
		{
			Console.WriteLine(name + " casts a spell of fireball at " + opponent.getName() + ":");
			base.attack(opponent);
		}

		public override void battleChoices(DungeonCharacter opponent)
		{
			base.battleChoices(opponent);
			int choice;

			do
			{
				Console.WriteLine("1. Attack Opponent");
				Console.WriteLine("2. Increase Hit Points");
				Console.WriteLine("Choose an option: ");
				choice = Convert.ToInt32(Console.ReadKey());

				switch (choice)
				{
					case 1:
						attack(opponent);
						break;
					case 2:
						increaseHitPoints();
						break;
					default:
						Console.WriteLine("invalid choice!");
						break;
				}

				numTurns--;
				if (numTurns > 0)
					Console.WriteLine("Number of turns remaining is: " + numTurns);

			} while (numTurns > 0 && hitPoints > 0 && opponent.getHitPoints() > 0);
		}
	}
}
