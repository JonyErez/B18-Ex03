using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;
 

namespace Ex03.ConsoleUI
{
	public class UserInterface
	{
		private Garage m_Garage = new Garage();

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

				Console.Clear();
				Console.WriteLine("Please choose the type of vehical you want to add");
				PrintVehicalTypes();
				vehicalType = (VehicalFactory.eVehicalTypes)enumParse<VehicalFactory.eVehicalTypes>();
				VehicalInformation newVehical = new VehicalInformation();
				vehicalModel = getVehicalModel();
				newVehical.Vehical = VehicalFactory.CreateVehical(vehicalType, vehicalModel, i_LicensePlate);
				askVehicalDetails(newVehical);
				m_Garage.AddVehical(newVehical);
			}

		}

		private string getVehicalModel() //TODO
		{
			Console.Clear();
			Console.Write("Please enter the vehical model: ");
			return Console.ReadLine();
		}

		private void PrintVehicalTypes() //TODO
		{
			Console.WriteLine(string.Format(@"Vehical Types:
1. Gas Truck
2. Electric Car
3. Gas Car
4. Electric Motorcycle
5. Gas Motorcycle"));
		}

		private object enumParse<T>()
		{
			T parsedEnum;
			while (true)
			{
				try
				{
					Console.Write("Please enter your desired option: ");
					parsedEnum = (T)Enum.Parse(typeof(T), Console.ReadLine());
					if (!Enum.IsDefined(typeof(T), parsedEnum))
					{
						throw new ArgumentException();
					}
					break;
				}
				catch (ArgumentException)
				{
					Console.WriteLine("Invalid option, please enter a valid option.");
				}
			}

			return parsedEnum;
		}

		private void askVehicalDetails(VehicalInformation i_Vehical)
		{
			getGeneralVehicalInformation(i_Vehical);
			if (i_Vehical.Vehical is GarageLogic.VehicalTypes.Car)
			{
				askCarDetails(i_Vehical.Vehical);
			}

			if (i_Vehical.Vehical is GarageLogic.VehicalTypes.Motorcycle)
			{
				askMotorcycleDetails(i_Vehical.Vehical);
			}

			if (i_Vehical.Vehical is GarageLogic.VehicalTypes.Truck)
			{
				askTruckDetails(i_Vehical.Vehical);
			}
			updateEnergyPercentLeft(i_Vehical.Vehical);
		}

		private void getGeneralVehicalInformation(VehicalInformation i_Vehical)
		{
			i_Vehical.OwnerName = askOwnerName();
			i_Vehical.OwnerPhone = askOwnerPhone();
			askEngineDetails(i_Vehical.Vehical);
			askWheelsDetails(i_Vehical.Vehical.Wheels);

		}

		private string askOwnerPhone()
		{
			string phoneNumber;
			System.Text.RegularExpressions.Regex phoneNumberValidation = new System.Text.RegularExpressions.Regex(@"^[0-9]{9,10}$");

			Console.Clear();
			Console.Write("Please enter your phone number (9-10 digits): ");
			phoneNumber = Console.ReadLine();

			while (!phoneNumberValidation.IsMatch(phoneNumber))
			{
				Console.Write("Please enter a valid phone number (9-10 digits): ");
				phoneNumber = Console.ReadLine();
			}

			return phoneNumber;
		}

		private string askOwnerName()
		{
			string ownerName;
			System.Text.RegularExpressions.Regex nameValidation = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z]{1,20}$");

			Console.Clear();
			Console.Write("Please enter the car owners name (2-20 characters): ");
			ownerName = Console.ReadLine();

			while (!nameValidation.IsMatch(ownerName))
			{
				Console.Write("Please enter a valid name (2-20 characters): ");
				ownerName = Console.ReadLine();
			}

			return ownerName;
		}

		private void askEngineDetails (GarageLogic.BaseClasses.Vehical i_Vehical)
		{
			Console.Clear();
			while (true)
			{
				try
				{
					Console.Write("Please enter the engines current capacity: ");
					i_Vehical.Engine.CurrentCapacity = float.Parse(Console.ReadLine());
					break;
				}
				catch (GarageLogic.ValueOutOfRangeException ex)
				{
					Console.WriteLine(ex.Message);
				}
				catch (FormatException ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
		}

		private void askCarDetails(GarageLogic.BaseClasses.Vehical i_Vehical)
		{

		} //TODO

		private void askMotorcycleDetails(GarageLogic.BaseClasses.Vehical i_Vehical)
		{

		} //TODO

		private void askTruckDetails(GarageLogic.BaseClasses.Vehical i_Vehical)
		{

		} //TODO

		private void askWheelsDetails(List<Wheel> i_Wheels)
		{
			int i = 1;
			foreach (Wheel wheel in i_Wheels)
			{
				Console.WriteLine(string.Format("Wheel {0}", i));
				askCurrentWheelDetails(wheel);
				i++;
			}
		}

		private void askCurrentWheelDetails(Wheel i_Wheel)
		{
			while (true)
			{
				try
				{
					Console.Write("Please enter the wheels current PSI: ");
					i_Wheel.CurrentPSI = float.Parse(Console.ReadLine());
					break;
				}
				catch (GarageLogic.ValueOutOfRangeException ex)
				{
					Console.WriteLine(ex.Message);
				}
				catch (FormatException ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			Console.Write("Please enter the wheels model: ");
			i_Wheel.Manufacturer = Console.ReadLine();

			}
		
		private void updateEnergyPercentLeft(GarageLogic.BaseClasses.Vehical i_Vehical)
		{
			i_Vehical.UpdateEnergyPercentLeft();
		}
	}
}
