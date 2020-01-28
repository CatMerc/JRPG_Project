using System;

namespace JRPGProject
{
	public struct XYCoord
	{
		private int _x;
		private int _y;

		public int x
		{
			get { return _x; }
			set { _x = value; }
		}
		public int y
		{
			get { return _y; }
			set { _y = value; }
		}

		public double GetDist(int x, int y)
		{
			return Math.Sqrt(_x * _y + x * y);
		}
	}

	public struct Direction
    {
		// Arrow Win32 Keyboard values
		public const int up = 0x26;
		public const int down = 0x28;
		public const int left = 0x25;
		public const int right = 0x27;
	}

	// Defines the screen area
	public class ScreenSpace
	{
		private int width;
		private int height;
		//private XYCoord _xy;
		public ScreenSpace(int width, int height)
		{
			this.width = width;
			this.height = height;
		}
	}

}