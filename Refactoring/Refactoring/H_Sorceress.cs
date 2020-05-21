﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring
{
	public class H_Sorceress : DC_Hero
	{
		private readonly int MIN_ADD = 25;
		private readonly int MAX_ADD = 50;

		public H_Sorceress() : base("Sorceress", 75, 5, .7, 25, 50, .3) { }

		public void IncreaseHitPoints()
		{
			int hPoints;
			Random rand = new Random();

			hPoints = rand.Next(MIN_ADD, MAX_ADD);
			AddHitPoints(hPoints);
			Console.WriteLine(name + " Added [" + hPoints + "] points.\n" + "Total hit points remaining are: "	+ hitPoints + "\n");
		}

		public override void Attack(DC opponent)
		{
			Console.WriteLine(name + " casts a spell of fireball at " + opponent.GetName() + ":");
			base.Attack(opponent);
		}

		public override void BattleChoices(DC opponent)
		{
			base.BattleChoices(opponent);
			String choice;

			do
			{
				Console.WriteLine("1. Attack Opponent");
				Console.WriteLine("2. Increase Hit Points");
				Console.WriteLine("Choose an option: ");
				choice = Dungeon.GetInput();

				switch (choice)
				{
					case "1":
						Attack(opponent);
						break;
					case "2":
						IncreaseHitPoints();
						break;
					default:
						Console.WriteLine("invalid choice!");
                        numTurns++;
                        break;
				}

				numTurns--;
				if (numTurns > 0)
					Console.WriteLine("Number of turns remaining is: " + numTurns);

			} while (numTurns > 0 && hitPoints > 0 && opponent.GetHitPoints() > 0);
		}
	}
}
