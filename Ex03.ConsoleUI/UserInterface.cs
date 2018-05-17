using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Base_Classes;
using Ex03.GarageLogic.Engine_Types;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Vehical_Types;

namespace Ex03.ConsoleUI
{
	public class UserInterface
	{
		private readonly Garage	r_Garage = new Garage();

		public	enum			eMenuOptions
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

		public	eMenuOptions	GetMenuSelection()
		{
			Console.Clear();
			Console.WriteLine("Welcome to Joniv's garage!");
			eMenuOptions menuOption = (eMenuOptions)enumParse<eMenuOptions>();

			return menuOption;
		}

		public	bool			MenuOperations(eMenuOptions i_UserSelectedAction)
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
					Console.Clear();
					Console.WriteLine("Thank you for coming to Jonivs garage!");
					Console.WriteLine("Press 'Enter' to exit the program!");
					Console.ReadLine();
					break;
			}

			return exitGarage;
		}

		private	void			displayListOfVehicals()
		{
			bool filter;
			List<string> licensePlates;

			Console.Clear();
			Console.Write("Do you wish to filter by vehical status? ");
			filter = askUserYesNoInput();
			if (filter)
			{
				licensePlates = r_Garage.ListVehicals((eVehicalStatus)enumParse<eVehicalStatus>());
			}
			else
			{
				licensePlates = r_Garage.ListVehicals();
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

		private	void			changeVehicalStatus()
		{
			Console.Clear();
			try
			{
				VehicalInformation vehical = r_Garage.FindVehical(askLicensePlate());
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

		private	void			inflateWheels()
		{
			Console.Clear();
			try
			{
				VehicalInformation vehical = r_Garage.FindVehical(askLicensePlate());
				r_Garage.InflateWheels(vehical.Vehical.LicensePlate);

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

		private	void			refuelVehical()
		{
			Console.Clear();
			try
			{
				VehicalInformation vehical = r_Garage.FindVehical(askLicensePlate());
				if (vehical.Vehical.Engine is GasEngine gasVehicalEngine)
				{
					Console.WriteLine("Select the desired fuel type to use: ");
					eFuelType fuelType = (eFuelType)enumParse<eFuelType>();
					Console.WriteLine("Enter how much fuel do you wish to fill (liters): ");
					r_Garage.RefuelVehical(vehical, fuelType, askUserForFloat());
					vehical.Vehical.UpdateEnergyPercentLeft();
					Console.WriteLine("Vehical was successfully refueled!");
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

		private	float			askUserForFloat()
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

		private	void			rechargeVehical()
		{
			Console.Clear();
			try
			{
				VehicalInformation vehical = r_Garage.FindVehical(askLicensePlate());
				if (vehical.Vehical.Engine is ElectricEngine)
				{
					Console.Write("Enter how much time do you wish to recharge for (hours): ");
					r_Garage.RechargeVehical(vehical, askUserForFloat());
					Console.WriteLine("Vehical was successfully recharged!");
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

		private	void			addVehicalToTheGarage()
		{
			bool doesVehicalExist = false;

			Console.Clear();
			string licensePlate = askLicensePlate();
			doesVehicalExist = r_Garage.DoesVehicalExist(licensePlate);	
			if(doesVehicalExist)
			{
				r_Garage.ChangeVehicalStatus(licensePlate, GarageLogic.Enums.eVehicalStatus.InRepair);
				Console.WriteLine("The vehical license plate is already in the system, status changed to in repair.");
			}
			else
			{
				Console.Clear();
				Console.WriteLine("Please choose the type of vehical you want to add");
				VehicalFactory.eVehicalTypes vehicalType = (VehicalFactory.eVehicalTypes)enumParse<VehicalFactory.eVehicalTypes>();
				VehicalInformation newVehical = new VehicalInformation();
				Console.Clear();
				string vehicalModel = askString("vehicals model");
				newVehical.Vehical = VehicalFactory.CreateVehical(vehicalType, vehicalModel, licensePlate);
				askVehicalDetails(newVehical);
				r_Garage.AddVehical(newVehical);
				Console.WriteLine("The vehical was successfully added to the garage!");
			}

			returnToMenuPrompt();
		}

		private	string			askString(string i_StringToAskFor)
		{
			string modelName;
			string minMaxValues = string.Format("{{{0},{1}}}", EConstants.k_MinStringLength, EConstants.k_MaxStringLength);
			string modelNameFormat = string.Format(@"^[a-zA-Z0-9]{0}$", minMaxValues);
			System.Text.RegularExpressions.Regex modelValidation = new System.Text.RegularExpressions.Regex(modelNameFormat);

			Console.Write("Please enter the {0} ({1}-{2} letters/numbers): ", i_StringToAskFor, EConstants.k_MinStringLength, EConstants.k_MaxStringLength);
			modelName = Console.ReadLine();

			while (!modelValidation.IsMatch(modelName))
			{
				Console.Write("Please enter a valid {0} ({1}-{2} letters/numbers): ", i_StringToAskFor, EConstants.k_MinStringLength, EConstants.k_MaxStringLength);
				modelName = Console.ReadLine();
			}

			return modelName;
		}

		private	object			enumParse<T>()
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
					Console.Clear();
					Console.WriteLine("Invalid option, please enter a valid option.");
				}
			}

			return parsedEnum;
		}

		private	void			askVehicalDetails(VehicalInformation i_Vehical)
		{
			getGeneralVehicalInformation(i_Vehical);
			if (i_Vehical.Vehical is Car)
			{
				askCarDetails(i_Vehical.Vehical);
			}

			if (i_Vehical.Vehical is Motorcycle)
			{
				askMotorcycleDetails(i_Vehical.Vehical);
			}

			if (i_Vehical.Vehical is Truck)
			{
				askTruckDetails(i_Vehical.Vehical);
			}

			updateEnergyPercentLeft(i_Vehical.Vehical);
		}

		private	void			getGeneralVehicalInformation(VehicalInformation i_Vehical)
		{
			i_Vehical.OwnerName = askOwnerName();
			i_Vehical.OwnerPhone = askOwnerPhone();
			askEngineDetails(i_Vehical.Vehical);
			askWheelsDetails(i_Vehical.Vehical.Wheels);
		}

		private	string			askOwnerPhone()
		{
			string minMaxValues = string.Format("{{{0},{1}}}", EConstants.k_MinPhoneNumberLength, EConstants.k_MaxPhoneNumberLength);
			string phoneNumberFormat = string.Format(@"^[0-9]{0}$", minMaxValues);
			System.Text.RegularExpressions.Regex phoneNumberValidation = new System.Text.RegularExpressions.Regex(phoneNumberFormat);

			Console.Clear();
			Console.Write("Please enter the vehicals owner phone number ({0}-{1} digits): ", EConstants.k_MinPhoneNumberLength, EConstants.k_MaxPhoneNumberLength);
			string phoneNumber = Console.ReadLine();

			while (!phoneNumberValidation.IsMatch(phoneNumber))
			{
				Console.Write("Please enter a valid phone number ({0}-{1} digits): ", EConstants.k_MinPhoneNumberLength, EConstants.k_MaxPhoneNumberLength);
				phoneNumber = Console.ReadLine();
			}

			return phoneNumber;
		}

		private	string			askOwnerName()
		{
			string minMaxValues = string.Format("{{{0},{1}}}", EConstants.k_MinStringLength, EConstants.k_MaxStringLength);
			string ownerNameFormat = string.Format(@"^[a-zA-Z]{0}$", minMaxValues);
			System.Text.RegularExpressions.Regex nameValidation = new System.Text.RegularExpressions.Regex(ownerNameFormat);

			Console.Clear();
			Console.Write("Please enter the vehicals owner name ({0}-{1} letters): ", EConstants.k_MinStringLength, EConstants.k_MaxStringLength);
			string ownerName = Console.ReadLine();

			while (!nameValidation.IsMatch(ownerName))
			{
				Console.Write("Please enter a valid name ({0}-{1} letters): ", EConstants.k_MinStringLength, EConstants.k_MaxStringLength);
				ownerName = Console.ReadLine();
			}

			return ownerName;
		}

		private	void			askEngineDetails(Vehical i_Vehical)
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

		private	void			askCarDetails(Vehical i_Vehical)
		{
			Console.Clear();
			Car car = i_Vehical as Car;
			askForColor(car);
			askForNumberOfDoors(car);
		}

		private	void			printEnum<T>()
		{
			foreach(var value in Enum.GetValues(typeof(T)))
			{
				Console.WriteLine("{0}. {1}", (int)value, getEnumDescription((Enum)value));
			}
		} 

		private	void			askForNumberOfDoors(Car i_Car)
		{
			Console.Clear();
			Console.WriteLine("Please choose a number of doors for your car:");
			i_Car.NumberOfDoors = (eNumberOfDoors)enumParse<eNumberOfDoors>();
		}

		private	void			askForColor(Car i_Car)
		{
			Console.Clear();
			Console.WriteLine("Please choose a color for your car:");
			i_Car.Color = (eColor)enumParse<eColor>();
		}

		private	void			askMotorcycleDetails(Vehical i_Vehical)
		{
			Motorcycle motorcycle = i_Vehical as Motorcycle;
			askLicenseTypes(motorcycle);
			askEngineVolume(motorcycle);
		} 

		private	void			askLicenseTypes(Motorcycle i_Motorcycle)
		{
			Console.Clear();
			Console.WriteLine("Please choose a license type for your motorcycle:");
			i_Motorcycle.LicenseType = (eLicenseType)enumParse<eLicenseType>();
		}

		private	void			askEngineVolume(Motorcycle i_Motorcycle)
		{
			Console.Clear();
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
					printExceptionMessage(ex);
				}
				catch (ArgumentException ex)
				{
					printExceptionMessage(ex);
				}
			}
		}

		private	void			printExceptionMessage(Exception i_Ex)
		{
			Console.Clear();
			Console.WriteLine(i_Ex.Message);
		}

		private	void			askTruckDetails(Vehical i_Vehical)
		{
			Truck truck = i_Vehical as Truck;
			askCargoholdVolume(truck);
			askIfCargoholdCooled(truck);
		}

		private	void			askIfCargoholdCooled(Truck i_Truck)
		{
			Console.Clear();
			Console.WriteLine("Is cargohold cooled?");
			i_Truck.IsCargoholdCooled = askUserYesNoInput();				
		}

		private	void			askCargoholdVolume(Truck i_Truck)
		{
			Console.Clear();
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
					printExceptionMessage(ex);
				}
				catch (ArgumentException ex)
				{
					printExceptionMessage(ex);
				}
			}
		}

		private	void			askWheelsDetails(List<Wheel> i_Wheels)
		{
			int i = 1;

			foreach (Wheel wheel in i_Wheels)
			{
				Console.Clear();
				Console.WriteLine("Vehical wheels information:");
				Console.WriteLine(string.Format("Wheel {0}", i));
				askCurrentWheelDetails(wheel);
				i++;
			}
		}

		private	void			askCurrentWheelDetails(Wheel i_Wheel)
		{
			while (true)
			{
				try
				{
					Console.Write("Please enter the wheels current PSI: ");
					i_Wheel.CurrentPsi = float.Parse(Console.ReadLine());
					break;
				}
				catch (GarageLogic.ValueOutOfRangeException ex)
				{
					printExceptionMessage(ex);
				}
				catch (FormatException ex)
				{
					printExceptionMessage(ex);
				}
			}

			i_Wheel.Manufacturer = askString("wheels manufacturer");
			}

		private	string			askLicensePlate()
		{
			string minMaxValues = string.Format("{{{0},{1}}}", EConstants.k_MinLicensePlateLength, EConstants.k_MaxLicensePlateLength);
			string licensePlateFormat = string.Format(@"^[A-Z0-9]{0}$", minMaxValues);
			System.Text.RegularExpressions.Regex modelValidation = new System.Text.RegularExpressions.Regex(licensePlateFormat);

			Console.Clear();
			Console.Write("Please enter a license plate ({0}-{1} capital letters/numbers): ", EConstants.k_MinLicensePlateLength, EConstants.k_MaxLicensePlateLength);
			string licensePlate = Console.ReadLine();

			while (!modelValidation.IsMatch(licensePlate))
			{
				Console.Write("Please enter a valid license plate ({0}-{1} capital letters/numbers): ", EConstants.k_MinLicensePlateLength, EConstants.k_MaxLicensePlateLength);
				licensePlate = Console.ReadLine();
			}

			return licensePlate;
		}
		
		private	void			updateEnergyPercentLeft(Vehical i_Vehical)
		{
			i_Vehical.UpdateEnergyPercentLeft();
		}

		private	void			printVehicalInformation()
		{
			Console.Clear();
			try
			{
				VehicalInformation vehical = r_Garage.FindVehical(askLicensePlate());
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

		private	bool			askUserYesNoInput()
		{
			bool userAnswer;

			while (true)
			{
				Console.Write("Please select yes or no [Y/N]: ");
				string userInput = Console.ReadLine();
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

		private	void			returnToMenuPrompt()
		{
			Console.Write("{0}Press 'Enter' to return to the menu.", Environment.NewLine);
			Console.ReadLine();
		}

		private	string			getEnumDescription(Enum i_Value)
		{
			System.Reflection.FieldInfo fiendInfo = i_Value.GetType().GetField(i_Value.ToString());

			System.ComponentModel.DescriptionAttribute[] attributes =
				(System.ComponentModel.DescriptionAttribute[])fiendInfo.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);

			string enumDescription = attributes.Length > 0 ? attributes[0].Description : i_Value.ToString();

			return enumDescription;
		}
	}
}