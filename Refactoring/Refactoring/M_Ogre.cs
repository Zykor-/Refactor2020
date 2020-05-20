using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring
{
	public class M_Ogre : DC_Monster
	{
		public M_Ogre() : base("Oscar the Ogre", 200, 2, .6, .1, 30, 50, 30, 50) { }

		public override void attack(DungeonCharacter opponent)
		{
			Console.WriteLine(name + " slowly swings a club toward's " + opponent.getName() + ":");
			base.attack(opponent);
		}
	}
}
