using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
	public class VehicalFactory
	{
		public enum eVehicalTypes
		{
			Truck,
			ElectricCar,
			GasCar,
			ElectricMotorcycle,
			GasMotorcycle
		}

		public static BaseClasses.Vehical CreateVehical(eVehicalTypes i_VehicalType, string i_Model, string i_LicensePlate)
		{
			BaseClasses.Vehical newVehical = null;

			switch (i_VehicalType)
			{
				case eVehicalTypes.ElectricCar:
					newVehical = new VehicalTypes.Car(i_Model, i_LicensePlate);
					break;
				case eVehicalTypes.GasCar:
					newVehical = new VehicalTypes.Car(i_Model, i_LicensePlate);
					break;
				case eVehicalTypes.ElectricMotorcycle:
					newVehical = new VehicalTypes.Motorcycle(i_Model, i_LicensePlate);
					break;
				case eVehicalTypes.GasMotorcycle:
					newVehical = new VehicalTypes.Motorcycle(i_Model, i_LicensePlate);
					break;
				case eVehicalTypes.Truck:
					newVehical = new VehicalTypes.Truck(i_Model, i_LicensePlate);
					break;
			}

			return newVehical;
		}

	}
}
