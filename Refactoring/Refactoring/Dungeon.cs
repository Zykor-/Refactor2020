using System;

namespace Refactoring
{
	/*
	 * ----------------------------------------------
	 * -----------------REFACTORS--------------------
	 * ----------------------------------------------
	 * 
	 * 1. Removed Excess comments and spaces
	 * 2. Converted code to C#
	 * 3. Renamed Classes
	 * 4. Replaced Keyboard.java references with Console.Read* 
	 * 5. Removed unused Keyboard class
	 * 6. Added ovveride to DC_Hero subclass method battleChoices so they are actually used
	 * 7. Added ovveride to DC_Hero subclass method subractHitPoints so they are actually used
	 * 8. Made DungeonCharacter.attack virtual so it can be overridden by subclasses
	 * 9. Removed DC_Hero theHero; declaration in Dungeon.chooseHero() because it is never called.
	 * 10. Changed public H_Sorceress fields to private
	 */

	public class Dungeon
	{
		public static void Main(string[] args)
		{
			DC_Hero theHero;
			DC_Monster theMonster;

			do
			{
				theHero = chooseHero();
				theMonster = generateMonster();
				battle(theHero, theMonster);

			} while (playAgain());
		}

		public static DC_Hero chooseHero()
		{
			int choice;

			Console.WriteLine("Choose a hero:\n" +
							   "1. Warrior\n" +
							   "2. Sorceress\n" +
							   "3. Thief");

			choice = Convert.ToInt32(Console.ReadLine());

			switch (choice)
			{
				case 1: return new H_Warrior();

				case 2: return new H_Sorceress();

				case 3: return new H_Thief();

				default:
					Console.WriteLine("invalid choice, returning Thief");
					return new H_Thief();
			}
		}

		public static DC_Monster generateMonster()
		{
			int choice;
			Random rand = new Random();

			choice = rand.Next(1,3);

			switch (choice)
			{
				case 1: return new M_Ogre();

				case 2: return new M_Gremlin();

				case 3: return new M_Skeleton();

				default:
					Console.WriteLine("invalid choice, returning Skeleton");
					return new M_Skeleton();
			}
		}

		public static Boolean playAgain()
		{
			char again;

			Console.WriteLine("Play again (y/n)?");
			again = Convert.ToChar(Console.ReadLine());

			return (again == 'Y' || again == 'y');
		}

		public static void battle(DC_Hero theHero, DC_Monster theMonster)
		{
			char pause = 'p';
			Console.WriteLine(theHero.getName() + " battles " + theMonster.getName());
			Console.WriteLine("---------------------------------------------");

			while (theHero.isAlive() && theMonster.isAlive() && pause != 'q')
			{
				theHero.battleChoices(theMonster);

				if (theMonster.isAlive())
					theMonster.attack(theHero);

				Console.WriteLine("\n-->q to quit, anything else to continue: ");
				pause = Convert.ToChar(Console.ReadLine());

			}

			if (!theMonster.isAlive())
				Console.WriteLine(theHero.getName() + " was victorious!");
			else if (!theHero.isAlive())
				Console.WriteLine(theHero.getName() + " was defeated :-(");
			else
				Console.WriteLine("Quitters never win ;-)");
		}
	}
}
