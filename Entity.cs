using System;
using System.Collections;
using System.Collections.Generic;

namespace JRPGProject
{
	public class Entity
	{
		public string Name { get; set; }
		public XYCoord Xy { get; set; }
		public int Health { get; set; }
		public bool Mortal { get; set; }
		public bool Passable { get; set; }
		public Entity()
		{
		}

		public Entity(int health, XYCoord xy, bool mortal=false, bool passable=false)
		{
			Health = health;
			Xy = xy;
			Mortal = mortal;
			Passable = passable;
		}

		public override string ToString()
		{
			return string.Format("Name: {0}, Health: {1}, X:{2} Y:{3}, Mortal:{4}, Passable:{5}", Name, Health, Xy.X, Xy.Y, Mortal, Passable);
		}
	}

	public abstract class Character : Entity
    {
		public Direction Direction{ get; set; }
		public int Armor { get; set; }
		public int Mana { get; set; }

		public override string ToString()
		{
			return string.Format("Name: {0}, Health: {1}, Armor:{6}, Mana:{7}, X:{2} Y:{3}, Mortal:{4}, Passable:{5}", Name, Health, Xy.X, Xy.Y, Mortal, Passable, Armor, Mana);
		}
	}

	public class NPC : Character
    {
		public object DialogueBox { get; set; } // Placeholder code
		public bool PcHostile { get; set; } // Hostility to player character
		public bool NpcHostile { get; set; } // Hostility towards other NPC's. Should later be a hash table.
		public bool Follower { get; set; }
    }

	public class PlayerCharacter : Character
    {
		private object _controls; // Placeholder code
		public List<object> Inventory = new List<object>(); // List of objects
    }
}