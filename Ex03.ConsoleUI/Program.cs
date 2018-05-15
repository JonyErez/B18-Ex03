using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
	public class Program
	{
		public static void Main()
		{
			RunGarage();
		}
		
		private static void RunGarage()
		{
			UserInterface UI = new UserInterface();
			while (!UI.MenuOperations(UI.getMenuSelection()))
			{
			}
		}
	}
}
