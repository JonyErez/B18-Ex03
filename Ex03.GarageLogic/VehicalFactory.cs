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
			GasTruck = 1,
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
					makeCarWheels(newVehical);
					break;
				case eVehicalTypes.GasCar:
					newVehical = new VehicalTypes.Car(i_Model, i_LicensePlate);
					newVehical.Engine = new EngineTypes.GasEngine(eConstants.CarFuelType, eConstants.CarMaxGas);
					makeCarWheels(newVehical);
					break;
				case eVehicalTypes.ElectricMotorcycle:
					newVehical = new VehicalTypes.Motorcycle(i_Model, i_LicensePlate);
					newVehical.Engine = new EngineTypes.ElectricEngine(eConstants.MotorcycleMaxBattary);
					makeMotorcycleWheels(newVehical);
					break;
				case eVehicalTypes.GasMotorcycle:
					newVehical = new VehicalTypes.Motorcycle(i_Model, i_LicensePlate);
					newVehical.Engine = new EngineTypes.GasEngine(eConstants.MotorcycleFuelType, eConstants.MotorcycleMaxGas);
					makeMotorcycleWheels(newVehical);
					break;
				case eVehicalTypes.GasTruck:
					newVehical = new VehicalTypes.Truck(i_Model, i_LicensePlate);
					newVehical.Engine = new EngineTypes.GasEngine(eConstants.TruckFuelType, eConstants.TruckMaxGas);
					makeTruckWheels(newVehical);
					break;
			}

			return newVehical;
		}

		private static void makeCarWheels(BaseClasses.Vehical i_Vehical)
		{
			i_Vehical.Wheels = new List<Wheel>(eConstants.CarWheels);
			makeWheels(i_Vehical.Wheels, eConstants.CarMaxPSI);
		}

		private static void makeMotorcycleWheels(BaseClasses.Vehical i_Vehical)
		{
			i_Vehical.Wheels = new List<Wheel>(eConstants.CarWheels);
			makeWheels(i_Vehical.Wheels, eConstants.MotorcycleMaxPSI);
		}

		private static void makeTruckWheels(BaseClasses.Vehical i_Vehical)
		{
			i_Vehical.Wheels = new List<Wheel>(eConstants.TruckMaxPSI);
			makeWheels(i_Vehical.Wheels, eConstants.CarMaxPSI);
		}

		private static void makeWheels(List<Wheel> i_Wheels, float i_MaxPSI)
		{
			for(int i=0; i<i_Wheels.Capacity; i++)
			{
				i_Wheels.Add(new Wheel(i_MaxPSI));
			}
		}

	}
}
