using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Enums;

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
					newVehical.Engine = new EngineTypes.ElectricEngine(eConstants.CarMaxBattary);
					newVehical.Wheels = new List<Wheel>(eConstants.CarWheels);
					break;
				case eVehicalTypes.GasCar:
					newVehical = new VehicalTypes.Car(i_Model, i_LicensePlate);
					newVehical.Engine = new EngineTypes.GasEngine(eConstants.CarFuelType, eConstants.CarMaxGas);
					newVehical.Wheels = new List<Wheel>(eConstants.CarWheels); //cpypaste
					break;
				case eVehicalTypes.ElectricMotorcycle:
					newVehical = new VehicalTypes.Motorcycle(i_Model, i_LicensePlate);
					newVehical.Engine = new EngineTypes.ElectricEngine(eConstants.MotorcycleMaxBattary);
					newVehical.Wheels = new List<Wheel>(eConstants.MotorcycleWheels);
					break;
				case eVehicalTypes.GasMotorcycle:
					newVehical = new VehicalTypes.Motorcycle(i_Model, i_LicensePlate);
					newVehical.Engine = new EngineTypes.GasEngine(eConstants.MotorcycleFuelType, eConstants.MotorcycleMaxGas);
					newVehical.Wheels = new List<Wheel>(eConstants.MotorcycleWheels); //cpypaste
					break;
				case eVehicalTypes.Truck:
					newVehical = new VehicalTypes.Truck(i_Model, i_LicensePlate);
					newVehical.Engine = new EngineTypes.GasEngine(eConstants.TruckFuelType, eConstants.TruckMaxGas);
					newVehical.Wheels = new List<Wheel>(eConstants.TruckWheels); 
					break;
			}

			return newVehical;
		}

	}
}
