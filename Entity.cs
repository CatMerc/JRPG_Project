﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace JRPGProject
{
	public class Entity // Any entity. Can be wall, can be barrel, can be ur mum
	{
		public string Name { get; set; }
		public XYCoord Xy { get; set; }
		public int Health { get; set; }
		public bool Mortal { get; set; }
		public bool Passable { get; set; }
		public double Velocity { get; set; }
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

	public class NPC : Character // NPC character
    {
		public object DialogueBox { get; set; } // Placeholder code
		public bool PcHostile { get; set; } // Hostility to player character
		public bool NpcHostile { get; set; } // Hostility towards other NPC's. Should later be a hash table.
		public bool Follower { get; set; }
    }

	public class PlayerCharacter : Character
    {
		public List<object> Inventory = new List<object>(); // List of objects
		public Controls Controls;
		public PlayerCharacter(Form1 form)
		{
			Controls = new InputHandling(form).GetControls();

		}
    }
}