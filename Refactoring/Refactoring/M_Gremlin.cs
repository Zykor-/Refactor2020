using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring
{
	public class M_Gremlin : DC_Monster
	{
		public M_Gremlin() : base("Gnarltooth the Gremlin", 70, 5, .8, .4, 15, 30, 20, 40) { }

		public override void attack(DungeonCharacter opponent)
		{
			Console.WriteLine(name + " jabs his kris at " + opponent.getName() + ":");
			base.attack(opponent);
		}
	}
}
