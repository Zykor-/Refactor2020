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
     * 12. Added Dungeon.GetInput() to simplify getting a string from the user. This is used exclusively in the Dungeon class to avoid interdepency.
     * 13. Created a Interface DC that is implemented by the base DungeonCharacter class. Changed calling DungeonCharacter to calling DC in all instances. (Programming to interface)
     * 14. Created new interface DM meant to manage multiple types of menus. Only one class uses it, but it will be useful if expansion is needed.
     * 15. Implemented that interface in the new DungeonMenu class, a class which easily creates and displays menus, then gets user input. Significantly cuts down on reused code. 
     * 16. Removed all the unnecessary switch-case defaults, since the DungeonMenu class automatically senses the upper and lower limits of input and loops back on itself. This eliminates 10 or so lines.
     * 17. Implemented new class CharacterList, which returns a DC from a static list of heroes and monsters. Eliminates the need for the switch cases in the chooseHero and chooseMonster functions.
     * 18. Removed while(true) loops made unnecessary by refactors 17, 16, and 15
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

        public static String GetInput()
        {
            return Console.ReadLine();
        }

        public static DC chooseHero()
		{
            int choice;

            DungeonMenu m = new DungeonMenu();

            m.ChangeHeader("Choose a hero.");
            m.AddOption("Warrior");
            m.AddOption("Sorceress");
            m.AddOption("Thief");
            m.DisplayMenu();

            choice = m.Select();

            return CharacterList.GetHero(choice);
		}

            
		public static DC generateMonster()
		{
            int choice;
            Random rand = new Random();

            choice = rand.Next(1, 3);

            return CharacterList.GetMonster(choice);
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
