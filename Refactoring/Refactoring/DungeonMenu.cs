using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring
{
    class DungeonMenu : DM
    {
        String[] options = new string[0];
        String header = "";




        public void ChangeHeader(String change)
        {
            header = change;
        }

        public void DisplayMenu()
        {
            if (header.Length > 0)
                Console.WriteLine(header);
            for (int i = 0; i < options.Length; ++i)
                Console.WriteLine((i+1) + ". " + options[i]);
        }

        public int Select()
        {
            int c;
            while (true)
            {
                Console.WriteLine("\nChoose an option: ");
                
                String choice = Console.ReadLine();
                if(int.TryParse(choice, out c))
                {
                    if (c < options.Length + 1 && c >0)
                        break;
                }
                Console.WriteLine("Invalid choice!\n");
                DisplayMenu();
            }

            return c;
        }

        public void AddOption(String option)
        {
            String[] newoptions = new string[options.Length + 1];
            for (int i = 0; i < options.Length; ++i)
                newoptions[i] = options[i];
            newoptions[options.Length] = option;
            options = newoptions;
        }
    }
}
