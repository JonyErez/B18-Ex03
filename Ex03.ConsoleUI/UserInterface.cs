using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;
 

namespace Ex03.ConsoleUI
{
	public class UserInterface
	{
		private GarageLogic.Garage m_Garage;

		public enum eMenuOptions
		{
			NewVehical = 1,
			DisplayListOfVehicals = 2,
			ChangeStatus = 3,
			InflateWheels = 4,
			RefuelVehical = 5,
			RechargeVehical = 6,
			DisplayVehicalDetails = 7,
			Exit = 8
		} 

		public void PrintMenu()
		{
			string menu = string.Format(@"Welcome to Joniv's garage!
Press 1 to enter a new vehical to the garage.
Press 2 to dislay the list of vehicals in the garage.
Press 3 to change status for a specific vehical.
Press 4 to infalte wheels for a specific vehical.
Press 5 to refuel gas vehical.
Press 6 to recharge electric vehical.
Press 7 to display details for a specific vehical.
Press 8 to Exit.");

			Console.WriteLine(menu);
		}

		public eMenuOptions getMenuSelection()
		{
			eMenuOptions menuOption;

			menuOption = (eMenuOptions)enumParse<eMenuOptions>();

			return menuOption;
		}

		public void MenuOperations(eMenuOptions i_UserSelectedAction)
		{
			switch(i_UserSelectedAction)
			{
				case eMenuOptions.NewVehical:
					
					break;
				case eMenuOptions.DisplayListOfVehicals:

					break;
				case eMenuOptions.ChangeStatus:

					break;
				case eMenuOptions.InflateWheels:

					break;
				case eMenuOptions.RefuelVehical:

					break;
				case eMenuOptions.RechargeVehical:

					break;
				case eMenuOptions.DisplayVehicalDetails:

					break;
				case eMenuOptions.Exit:

					break;

			}
		}

		
		private void addVehicalToTheGarage(string i_LicensePlate)
		{
			bool doesVehicalExist = false;
			VehicalFactory.eVehicalTypes vehicalType;
			
			doesVehicalExist = m_Garage.DoesVehicalExist(i_LicensePlate);	
			if(doesVehicalExist)
			{
				m_Garage.ChangeVehicalStatus(i_LicensePlate, GarageLogic.Enums.eVehicalStatus.InRepair);
				Console.WriteLine("The vehical license plate is already in the system, status changed to in repair.");
			}
			else
			{
				string vehicalModel;

				Console.WriteLine("Please choose the type of vehical you want to add");
				PrintVehicalTypes();
				vehicalType = (VehicalFactory.eVehicalTypes)enumParse<VehicalFactory.eVehicalTypes>();
				VehicalInformation newVehical = new VehicalInformation();
				vehicalModel = getVehicalModel();
				newVehical.Vehical = VehicalFactory.CreateVehical(vehicalType, vehicalModel, i_LicensePlate);

			}

		}

		private string getVehicalModel()
		{
			throw new NotImplementedException();
		}

		private void PrintVehicalTypes()
		{
			throw new NotImplementedException();
		}

		private object enumParse<T>()
		{
			T parsedEnum;
			while (true)
			{
				try
				{
					Console.WriteLine("Please enter your desired option: ");
					parsedEnum = (T)Enum.Parse(typeof(T), Console.ReadLine());
					break;
				}
				catch (ArgumentException)
				{
					Console.WriteLine("Invalid option, please enter a valid option.");
				}
			}

			return parsedEnum;
		}


	}
}
