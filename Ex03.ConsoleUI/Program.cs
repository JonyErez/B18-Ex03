using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
	public class Program
	{
		public	static void Main()
		{
			runGarage();
		}
		
		private	static void runGarage()
		{
			try
			{
				UserInterface userInterface = new UserInterface();
				while (!userInterface.MenuOperations(userInterface.GetMenuSelection()))
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
