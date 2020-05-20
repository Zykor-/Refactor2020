using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring
{
	public abstract class DungeonCharacter : IComparable
	{
		protected string name;
		protected int hitPoints;
		protected int attackSpeed;
		protected int damageMin;
		protected int damageMax;
		protected double chanceToHit;

		public DungeonCharacter(string name, int hitPoints, int attackSpeed, double chanceToHit, int damageMin, int damageMax)
		{
			this.name = name;
			this.hitPoints = hitPoints;
			this.attackSpeed = attackSpeed;			
			this.damageMin = damageMin;
			this.damageMax = damageMax;
			this.chanceToHit = chanceToHit;
		}

		public string getName()
		{
			return name;
		}

		public int getHitPoints()
		{
			return hitPoints;
		}

		public int getAttackSpeed()
		{
			return attackSpeed;
		}

		public void addHitPoints(int hitPoints)
		{
			if (hitPoints <= 0)
				Console.WriteLine("Hitpoint amount must be positive.");
			else
			{
				this.hitPoints += hitPoints;
				Console.WriteLine("Remaining Hit Points: " + hitPoints);
			}
		}

		public virtual void subtractHitPoints(int hitPoints)
		{
			if (hitPoints < 0)
				Console.WriteLine("Hitpoint amount must be positive.");
			else if (hitPoints > 0)
			{
				this.hitPoints -= hitPoints;
				if (this.hitPoints < 0)
					this.hitPoints = 0;
				Console.WriteLine(getName() + " hit " + " for <" + hitPoints + "> points damage.");
				Console.WriteLine(getName() + " now has " + getHitPoints() + " hit points remaining.\n");
			}

			if (this.hitPoints == 0)
				Console.WriteLine(name + " has been killed :-(");
		}

		public Boolean isAlive()
		{
			return (hitPoints > 0);
		}

		public virtual void attack(DungeonCharacter opponent)
		{
			bool canAttack;
			int damage;
			Random rand = new Random();

			canAttack = rand.NextDouble() <= chanceToHit;

			if (canAttack)
			{
				damage = rand.Next(damageMin, damageMax);
				opponent.subtractHitPoints(damage);

				Console.WriteLine();
			}
			else
				Console.WriteLine(getName() + "'s attack on " + opponent.getName() + " failed!\n");
		}

		public int CompareTo(object obj)
		{
			throw new NotImplementedException();
		}
	}
}
