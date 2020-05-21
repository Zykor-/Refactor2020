using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring
{
    public class CharacterList
    {
        public static DC GetHero(int choice)
        {
            switch (choice)
            {
                case 1: return new H_Warrior();
                case 2: return new H_Sorceress();
                case 3: return new H_Thief();
                default: return null;
            }

        }
        public static DC GetMonster(int choice)
        {
            switch (choice)
            {
                case 1: return new M_Ogre();
                case 2: return new M_Gremlin();
                case 3: return new M_Skeleton();
                default: return null;
            }

        }
    }
}
