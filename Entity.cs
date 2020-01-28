using System;
using System.Collections;
using System.Collections.Generic;

namespace JRPGProject
{
	public abstract class _Entity
	{
		protected string _name;
		protected XYCoord _xy;
		protected int _health;
		protected bool _mortal;
		protected bool _passable;

		public int health
		{
			get { return _health; }
			set { _health = value; }
		}
		public bool mortal
		{
			get { return _mortal; }
			set { _mortal = value; }
		}
		public bool passable
		{
			get { return _passable; }
			set { _passable = value; }
		}
		public XYCoord xy
		{
			get { return _xy; }
			set { _xy = value; }
		}
		public string name
		{
			get { return _name; }
			set { _name = value; }
		}
		public _Entity()
		{
		}

		public _Entity(int health, XYCoord xy, bool mortal=false, bool passable=false)
		{
			_health = health;
			_xy = xy;
			_mortal = mortal;
			_passable = passable;
		}

		public override string ToString()
		{
			return string.Format("Name: {0}, Health: {1}, X:{2} Y:{3}, Mortal:{4}, Passable:{5}", _name, _health, _xy.x, _xy.y, _mortal, _passable);
		}
	}

	public abstract class _Character : _Entity
    {
		protected Direction _direction;
		protected int _armor;
		protected int _mana;

		public Direction direction
		{
			get { return _direction; }
			set { _direction = value; }
		}
		public int armor
		{
			get { return _armor; }
			set { _armor = value; }
		}
		public int mana
		{
			get { return _mana; }
			set { _mana = value; }
		}

		public override string ToString()
		{
			return string.Format("Name: {0}, Health: {1}, Armor:{6}, Mana:{7}, X:{2} Y:{3}, Mortal:{4}, Passable:{5}", _name, _health, _xy.x, _xy.y, _mortal, _passable, _armor, _mana);
		}
	}

	public class Entity : _Entity
	{
		public Entity()
		{
		}

		public Entity(int health, XYCoord xy, bool mortal = false, bool passable = false) : base (health, xy,mortal, passable)
		{

		}

	}

	public class NPC : _Character
    {
		private object _dialogueBox; // Placeholder code
		private bool _pcHostile; // Hostility to player character
		private bool _npcHostile; // Hostility towards other NPC's. Should later be a hash table.
		private bool _follower;
    }

	public class PlayerCharacter : _Character
    {
		private object _controls; // Placeholder code
		private List<object> _inventory = new List<object>(); // List of objects
    }
}