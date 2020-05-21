using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring
{
	public class DungeonCharacter : DC
	{
		protected string name;
		protected int hitPoints;
		protected int AttackSpeed;
		protected int damageMin;
		protected int damageMax;
		protected double chanceToHit;

		public DungeonCharacter(string name, int hitPoints, int AttackSpeed, double chanceToHit, int damageMin, int damageMax)
		{
			this.name = name;
			this.hitPoints = hitPoints;
			this.AttackSpeed = AttackSpeed;			
			this.damageMin = damageMin;
			this.damageMax = damageMax;
			this.chanceToHit = chanceToHit;
		}

		public string GetName()
		{
			return name;
		}

		public int GetHitPoints()
		{
			return hitPoints;
		}

		public int GetAttackSpeed()
		{
			return AttackSpeed;
		}

		public void AddHitPoints(int hitPoints)
		{
			if (hitPoints <= 0)
				Console.WriteLine("Hitpoint amount must be positive.");
			else
			{
				this.hitPoints += hitPoints;
				Console.WriteLine("Remaining Hit Points: " + hitPoints);
			}
		}

		public virtual void SubtractHitPoints(int hitPoints)
		{
			if (hitPoints < 0)
				Console.WriteLine("Hitpoint amount must be positive.");
			else if (hitPoints > 0)
			{
				this.hitPoints -= hitPoints;
				if (this.hitPoints < 0)
					this.hitPoints = 0;
				Console.WriteLine(GetName() + " hit " + " for <" + hitPoints + "> points damage.");
				Console.WriteLine(GetName() + " now has " + GetHitPoints() + " hit points remaining.\n");
			}

			if (this.hitPoints == 0)
				Console.WriteLine(name + " has been killed :-(");
		}

		public Boolean IsAlive()
		{
			return (hitPoints > 0);
		}

        public virtual void BattleChoices(DC opponent)
        {
            //empty function, designed for override
            return;
        }

		public virtual void Attack(DC opponent)
		{
			bool canAttack;
			int damage;
			Random rand = new Random();

			canAttack = rand.NextDouble() <= chanceToHit;

			if (canAttack)
			{
				damage = rand.Next(damageMin, damageMax);
				opponent.SubtractHitPoints(damage);

				Console.WriteLine();
			}
			else
				Console.WriteLine(GetName() + "'s Attack on " + opponent.GetName() + " failed!\n");
		}

	}
}
