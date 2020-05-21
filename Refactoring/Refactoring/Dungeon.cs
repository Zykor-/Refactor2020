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
	 * 3. Renamed Classes. C# standard has classes named in capital letters, and interfaces require this.
	 * 4. Replaced Keyboard.java references with Console.Read* 
	 * 5. Removed unused Keyboard class
	 * 6. Added override to DC_Hero subclass method BattleChoices so they are actually used
	 * 7. Added override to DC_Hero subclass method subractHitPoints so they are actually used
	 * 8. Made DungeonCharacter.Attack virtual so it can be overridden by subclasses
	 * 9. Removed DC_Hero theHero; declaration in Dungeon.chooseHero() because it is never called.
	 * 10. Changed public Hero fields to private where they did not need to be public
     * 11. Changed DC_Hero classes accessed from within the class to private
     * 12. Added Dungeon.GetInput() to simplify getting a string from the user. This comes with the change of most int casts to strings. They were causing all sorts of crashes.
     * e.g. choice = Convert.ToInt32(Console.ReadLine()); becomes choice = GetInput(); Simple, stable, and implementable across all classes.
     * 13. Created a Interface DC that is implemented by the base DungeonCharacter class. Changed calling DungeonCharacter to calling DC in all instances. (Programming to interface)
     * Not really refactoring, but I also changed a few of the menus so that the player never crashes or gets stuck. also, quitting and Y/N are no longer case-sensitive.
	 */

    public class Dungeon
	{
		public static void Main(string[] args)
		{
			DC theHero;
			DC theMonster;

			do
			{
				theHero = chooseHero();
				theMonster = generateMonster();
				battle(theHero, theMonster);

			} while (playAgain());
		}

		public static DC chooseHero()
		{
            while (true)
            {
                String choice;

                Console.WriteLine("Choose a hero:\n" +
                                   "1. Warrior\n" +
                                   "2. Sorceress\n" +
                                   "3. Thief");

                choice = GetInput();

                switch (choice)
                {
                    case "1": return new H_Warrior(); 

                    case "2": return new H_Sorceress(); 

                    case "3": return new H_Thief();

                    default:
                        Console.WriteLine("invalid choice!");
                        continue;
                        
                }
            }
		}

        public static String GetInput()
        {
            return Console.ReadLine();
        }
            
		public static DC generateMonster()
		{
            while (true)
            {
                int choice;
                Random rand = new Random();

                choice = rand.Next(1, 3);

                switch (choice)
                {
                    case 1: return new M_Ogre(); 

                    case 2: return new M_Gremlin(); 

                    case 3: return new M_Skeleton(); 

                    default:
                        Console.WriteLine("invalid choice!");
                        continue;
                }
            }
		}

		public static Boolean playAgain()
		{
            while (true)
            {
                String again;

                Console.WriteLine("Play again (y/n)?");
                again = GetInput();
                if (again == "Y" || again == "y")
                    return true;
                if (again == "N" || again == "n")
                    return true;
                Console.WriteLine("Invalid input!");

            }
		}

		public static void battle(DC theHero, DC theMonster)
		{
			String pause = "p";
			Console.WriteLine(theHero.GetName() + " battles " + theMonster.GetName());
			Console.WriteLine("---------------------------------------------");

			while (theHero.IsAlive() && theMonster.IsAlive() && (!(pause == "q" || pause == "Q")))
			{
				theHero.BattleChoices(theMonster);

				if (theMonster.IsAlive())
					theMonster.Attack(theHero);

				Console.WriteLine("\n-->q to quit, anything else to continue: ");
                pause = GetInput();

			}

			if (!theMonster.IsAlive())
				Console.WriteLine(theHero.GetName() + " was victorious!");
			else if (!theHero.IsAlive())
				Console.WriteLine(theHero.GetName() + " was defeated :-(");
			else
				Console.WriteLine("Quitters never win ;-)");
		}
	}
}
