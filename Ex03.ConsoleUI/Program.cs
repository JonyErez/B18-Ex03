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
			Console.ReadLine();
		}
		
		private static void RunGarage()
		{
			UserInterface UI = new UserInterface();
			UI.PrintMenu();
			Console.WriteLine(UI.getMenuSelection());
			
		}
	}
}
