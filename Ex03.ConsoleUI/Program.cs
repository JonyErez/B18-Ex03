using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
	public class Program
	{
		public	static void Main()
		{
			RunGarage();
		}
		
		private	static void RunGarage()
		{
			try
			{
				UserInterface UI = new UserInterface();
				while (!UI.MenuOperations(UI.getMenuSelection()))
				{
				}
			}

			catch (Exception)
			{
				Console.WriteLine("An unexpected error has occured, the program will now terminate!");
				Console.WriteLine("Press 'Enter' to close the program.");
				Console.ReadLine();
			}
		}
	}
}
