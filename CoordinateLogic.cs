﻿using System;

namespace JRPGProject
{
	public class XYCoord
	{
		public int X { get; set; }
		public int Y { get; set; }

		public double GetDist(int x, int y)
		{
			return Math.Sqrt(X * Y + x * y);
		}
	}

	public struct Direction // Defines what keyboard input results in what direction
    {
		// Arrow Win32 Keyboard values
		//public const int up = 0x26;
		//public const int down = 0x28;
		//public const int left = 0x25;
		//public const int right = 0x27;

		// WASD Win32 Keyboard Values
		public const int up = 0x57;
		public const int down = 0x53;
		public const int left = 0x41;
		public const int right = 0x44;
	}

	public class ScreenSpace // Defines the screen area. Placeholder
	{
		private int Width;
		private int Height;
		//private XYCoord _xy;
		public ScreenSpace(int width, int height)
		{
			Width = width;
			Height = height;
		}
	}

}