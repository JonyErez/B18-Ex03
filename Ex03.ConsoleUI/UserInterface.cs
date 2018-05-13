using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Enums;

namespace Ex03.ConsoleUI
{
	public class UserInterface
	{
		private Garage m_Garage = new Garage();

		public enum eMenuOptions
		{
			[System.ComponentModel.Description("Add vehical to garage")]
			NewVehical = 1,
			[System.ComponentModel.Description("Display garage vehials license plates")]
			DisplayListOfVehicals,
			[System.ComponentModel.Description("Change specific vehicals status")]
			ChangeStatus,
			[System.ComponentModel.Description("Inflate a vehicals wheels")]
			InflateWheels,
			[System.ComponentModel.Description("Refuel a gas vehical")]
			RefuelVehical,
			[System.ComponentModel.Description("Recharge an electrical vehical")]
			RechargeVehical,
			[System.ComponentModel.Description("Display a specific vehicals full information")]
			DisplayVehicalDetails,
			[System.ComponentModel.Description("Exit the garage")]
			Exit
		} 

		public eMenuOptions getMenuSelection()
		{
			eMenuOptions menuOption;

			Console.Clear();
			Console.WriteLine("Welcome to Joniv's garage!");
			menuOption = (eMenuOptions)enumParse<eMenuOptions>();

			return menuOption;
		}

		public bool MenuOperations(eMenuOptions i_UserSelectedAction)
		{
			bool exitGarage = false;

			switch(i_UserSelectedAction)
			{
				case eMenuOptions.NewVehical:
					addVehicalToTheGarage();
					break;
				case eMenuOptions.DisplayListOfVehicals:
					displayListOfVehicals();
					break;
				case eMenuOptions.ChangeStatus:
					changeVehicalStatus();
					break;
				case eMenuOptions.InflateWheels:
					inflateWheels();
					break;
				case eMenuOptions.RefuelVehical:
					refuelVehical();
					break;
				case eMenuOptions.RechargeVehical:
					rechargeVehical();
					break;
				case eMenuOptions.DisplayVehicalDetails:
					printVehicalInformation();
					break;
				case eMenuOptions.Exit:
					exitGarage = true;
					break;

			}

			return exitGarage;
		}

		private void displayListOfVehicals()
		{
			bool filter;
			List<string> licensePlates;

			Console.Clear();
			Console.Write("Do you wish to filter by car status? ");
			filter = askUserYesNoInput();
			if (filter)
			{
				licensePlates = m_Garage.ListVehicals((eVehicalStatus)enumParse<eVehicalStatus>());
			}
			else
			{
				licensePlates = m_Garage.ListVehicals();
			}

			if (licensePlates.Count != 0)
			{
				foreach (string licensePlate in licensePlates)
				{
					Console.WriteLine(licensePlate);
				}
			}
			else
			{
				Console.WriteLine("No vehicals found!");
			}

			returnToMenuPrompt();
		}

		private void changeVehicalStatus()
		{
			VehicalInformation vehical;

			Console.Clear();
			try
			{
				vehical = m_Garage.FindVehical(askLicensePlate());
				Console.WriteLine("Please select your desired status:");
				vehical.VehicalStatus = (eVehicalStatus)enumParse<eVehicalStatus>();
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				returnToMenuPrompt();
			}
		}

		private void inflateWheels()
		{
			VehicalInformation vehical;

			Console.Clear();
			try
			{
				vehical = m_Garage.FindVehical(askLicensePlate());
				foreach(Wheel currentWheel in vehical.Vehical.Wheels)
				{
					currentWheel.Inflate(currentWheel.MaxPSI - currentWheel.CurrentPSI);
				}
				Console.WriteLine("All the vehicals wheels were successfully inflated!");
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				returnToMenuPrompt();
			}
		}

		private void refuelVehical()
		{
			VehicalInformation vehical;
			eFuelType fuelType;

			Console.Clear();
			try
			{
				vehical = m_Garage.FindVehical(askLicensePlate());
				GarageLogic.EngineTypes.GasEngine gasVehicalEngine = vehical.Vehical.Engine as GarageLogic.EngineTypes.GasEngine;
				if (gasVehicalEngine != null)
				{
					Console.WriteLine("Select the desired fuel type to use: ");
					fuelType = (eFuelType)enumParse<eFuelType>();
					Console.WriteLine("Enter how much fuel do you wish to fill (liters): ");
					gasVehicalEngine.FillGas(fuelType, askUserForFloat());
					Console.WriteLine("Car was successfully refueled!");
					vehical.Vehical.UpdateEnergyPercentLeft();
				}
				else
				{
					Console.WriteLine("Cannot refuel a vehical that does not run on gas!");
				}
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (ValueOutOfRangeException ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				returnToMenuPrompt();
			}
		}

		private float askUserForFloat()
		{
			float userInput;

			while (true)
			{
				try
				{
					userInput = float.Parse(Console.ReadLine());
					break;
				}
				catch (FormatException ex)
				{
					Console.WriteLine(ex.Message);
				}
			}

			return userInput;
		}

		private void rechargeVehical()
		{
			VehicalInformation vehical;

			Console.Clear();
			try
			{
				vehical = m_Garage.FindVehical(askLicensePlate());
				GarageLogic.EngineTypes.ElectricEngine electricVehicalEngine = vehical.Vehical.Engine as GarageLogic.EngineTypes.ElectricEngine;
				if (electricVehicalEngine != null)
				{
					Console.WriteLine("Enter how much time do you wish to recharge for (hours): ");
					electricVehicalEngine.ChargeVehical(askUserForFloat());
					Console.WriteLine("Car was successfully recharged!");
					vehical.Vehical.UpdateEnergyPercentLeft();
				}
				else
				{
					Console.WriteLine("Cannot recharge a vehical that does not run on electricity!");
				}
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (ValueOutOfRangeException ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				returnToMenuPrompt();
			}
		}

		private void addVehicalToTheGarage()
		{
			bool doesVehicalExist = false;
			VehicalFactory.eVehicalTypes vehicalType;

			Console.Clear();
			string licensePlate = askLicensePlate();
			doesVehicalExist = m_Garage.DoesVehicalExist(licensePlate);	
			if(doesVehicalExist)
			{
				m_Garage.ChangeVehicalStatus(licensePlate, GarageLogic.Enums.eVehicalStatus.InRepair);
				Console.WriteLine("The vehical license plate is already in the system, status changed to in repair.");
			}
			else
			{
				string vehicalModel;

				Console.Clear();
				Console.WriteLine("Please choose the type of vehical you want to add");
				vehicalType = (VehicalFactory.eVehicalTypes)enumParse<VehicalFactory.eVehicalTypes>();
				VehicalInformation newVehical = new VehicalInformation();
				vehicalModel = getVehicalModel();
				newVehical.Vehical = VehicalFactory.CreateVehical(vehicalType, vehicalModel, licensePlate);
				askVehicalDetails(newVehical);
				m_Garage.AddVehical(newVehical);
			}

			returnToMenuPrompt();
		}

		private string getVehicalModel() //TODO
		{
			Console.Clear();
			Console.Write("Please enter the vehical model: ");
			return Console.ReadLine();
		}

		private object enumParse<T>()
		{
			T parsedEnum;
			while (true)
			{
				try
				{
					printEnum<T>();
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
			Console.Write("Please enter the car owners name (1-20 characters): ");
			ownerName = Console.ReadLine();

			while (!nameValidation.IsMatch(ownerName))
			{
				Console.Write("Please enter a valid name (1-20 characters): ");
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
				catch (ArgumentException ex)
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
			Console.Clear();
			GarageLogic.VehicalTypes.Car car = i_Vehical as GarageLogic.VehicalTypes.Car;
			askForColor(car);
			askForNumberOfDoors(car);
		}

		private void printEnum<T>()
		{
			foreach(var value in Enum.GetValues(typeof(T)))
			{
				Console.WriteLine("{0}. {1}", (int)value, GetEnumDescription((Enum)value));
			}
		} 

		private void askForNumberOfDoors(GarageLogic.VehicalTypes.Car i_Car)
		{
			Console.WriteLine("Please choose a number of doors for your car:");
			i_Car.NumberOfDoors = (eNumberOfDoors)enumParse<eNumberOfDoors>();
		}

		private void askForColor(GarageLogic.VehicalTypes.Car i_Car)
		{
			Console.WriteLine("Please choose a color for your car:");
			i_Car.Color = (eColor)enumParse<eColor>();
		}

		private void askMotorcycleDetails(GarageLogic.BaseClasses.Vehical i_Vehical)
		{
			Console.Clear();
			GarageLogic.VehicalTypes.Motorcycle motorcycle = i_Vehical as GarageLogic.VehicalTypes.Motorcycle;
			askLicenseTypes(motorcycle);
			askEngineVolume(motorcycle);
		} 

		private void askLicenseTypes(GarageLogic.VehicalTypes.Motorcycle i_Motorcycle)
		{
			Console.WriteLine("Please choose a license type for your motorcycle:");
			i_Motorcycle.LicenseType = (eLicenseTypes)enumParse<eLicenseTypes>();
		}

		private void askEngineVolume(GarageLogic.VehicalTypes.Motorcycle i_Motorcycle)
		{
			while(true)
			{
				try
				{
					Console.Write("Please choose an engine volume for your motorcycle: ");
					i_Motorcycle.EngineVolume = int.Parse(Console.ReadLine());
					break;
				}
				catch(FormatException ex)
				{
					Console.WriteLine(ex.Message);
				}
				catch(ArgumentException ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
		}

		private void askTruckDetails(GarageLogic.BaseClasses.Vehical i_Vehical)
		{
			Console.Clear();
			GarageLogic.VehicalTypes.Truck truck = i_Vehical as GarageLogic.VehicalTypes.Truck;
			askCargoholdVolume(truck);
			askIfCargoholdCooled(truck);
		}

		private void askIfCargoholdCooled(GarageLogic.VehicalTypes.Truck i_Truck)
		{
			Console.WriteLine("Is cargohold cooled?");
			i_Truck.IsCargoholdCooled = askUserYesNoInput();				
		}

		private void askCargoholdVolume(GarageLogic.VehicalTypes.Truck i_Truck)
		{
			while(true)
			{
				try
				{
					Console.Write("Please enter the cargohold volume: ");
					i_Truck.CargoholdVolume = float.Parse(Console.ReadLine());
					break;
				}
				catch(FormatException ex)
				{
					Console.Write(ex.Message);
				}
				catch (ArgumentException ex)
				{
					Console.Write(ex.Message);
				}
			}
		}

		private void askWheelsDetails(List<Wheel> i_Wheels)
		{
			int i = 1;

			Console.Clear();
			Console.WriteLine("Vehical wheels information:");
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

		public string askLicensePlate()
		{
			Console.Write("Please enter the vehicals license plate: ");
			return Console.ReadLine();
		}
		
		private void updateEnergyPercentLeft(GarageLogic.BaseClasses.Vehical i_Vehical)
		{
			i_Vehical.UpdateEnergyPercentLeft();
		}

		private void printVehicalInformation()
		{
			VehicalInformation vehical;

			Console.Clear();
			try
			{
				vehical = m_Garage.FindVehical(askLicensePlate());
				Console.WriteLine(vehical.ToString());
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				returnToMenuPrompt();
			}
		}

		private bool askUserYesNoInput()
		{
			bool userAnswer;
			string userInput;

			while (true)
			{
				Console.Write("Please select yes or no [Y/N]: ");
				userInput = Console.ReadLine();
				if (char.ToLower(userInput[0]) == 'y' && userInput.Length == 1)
				{
					userAnswer = true;
					break;
				}
				else if (char.ToLower(userInput[0]) == 'n' && userInput.Length == 1)
				{
					userAnswer = false;
					break;
				}
				Console.WriteLine("Invalid selection!");
			}

			return userAnswer;
		}

		private void returnToMenuPrompt()
		{
			Console.Write("{0}Press 'Enter' to return to the menu.", Environment.NewLine);
			Console.ReadLine();
		}

		private string GetEnumDescription(Enum value)
		{
			System.Reflection.FieldInfo fi = value.GetType().GetField(value.ToString());

			System.ComponentModel.DescriptionAttribute[] attributes =
				(System.ComponentModel.DescriptionAttribute[])fi.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);

			if (attributes != null && attributes.Length > 0)
				return attributes[0].Description;
			else
				return value.ToString();
		}
	}
}
