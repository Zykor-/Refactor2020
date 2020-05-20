using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring
{
	public class M_Skeleton : DC_Monster
	{
		public M_Skeleton() : base("Sargath the Skeleton", 100, 3, .8, .3, 30, 50, 30, 50) { }

		public override void attack(DungeonCharacter opponent)
		{
			Console.WriteLine(name + " slices his rusty blade at " + opponent.getName() + ":");
			base.attack(opponent);
		}
	}
}
