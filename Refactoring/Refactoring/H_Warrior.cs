﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring
{
	public class H_Warrior : DC_Hero
	{
		public H_Warrior() : base("Warrior", 125, 4, .8, 35, 60, .2) { }

		private void CrushingBlow(DC opponent)
		{
			Random rand = new Random();

			if (rand.NextDouble() <= .4)
			{
				int blowPoints = rand.Next(100, 176);
				Console.WriteLine(name + " lands a CRUSHING BLOW for " + blowPoints + " damage!");
				opponent.SubtractHitPoints(blowPoints);
			}
			else
				Console.WriteLine(name + " failed to land a crushing blow\n");
		}

		public override void Attack(DC opponent)
		{
			Console.WriteLine(name + " swings a mighty sword at " + opponent.GetName() + ":");
			base.Attack(opponent);
		}

		public override void BattleChoices(DC opponent)
		{
			int choice;

			base.BattleChoices(opponent);

			do
			{
                DungeonMenu m = new DungeonMenu();
                m.AddOption("Attack Opponent");
                m.AddOption("Crushing blow on Opponent");
                m.DisplayMenu();
                choice = m.Select();

				switch (choice)
				{
					case 1:
						Attack(opponent);
						break;
					case 2:
						CrushingBlow(opponent);
						break;
				}

				numTurns--;
				if (numTurns > 0)
					Console.WriteLine("Number of turns remaining is: " + numTurns);

			} while (numTurns > 0);
		}
	}
}
