using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Base_Classes;
using Ex03.GarageLogic.Engine_Types;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Vehical_Types;

namespace Ex03.GarageLogic
{
	public class VehicalFactory
	{
		public enum eVehicalTypes
		{
			[System.ComponentModel.Description("Gas Truck")]
			GasTruck = 1,
			[System.ComponentModel.Description("Electric Car")]
			ElectricCar,
			[System.ComponentModel.Description("Gas Car")]
			GasCar,
			[System.ComponentModel.Description("Electric Motorcycle")]
			ElectricMotorcycle,
			[System.ComponentModel.Description("Gas Motorcycle")]
			GasMotorcycle
		}

		public	static	Vehical		CreateVehical(eVehicalTypes i_VehicalType, string i_Model, string i_LicensePlate)
		{
			Vehical newVehical = null;

			switch (i_VehicalType)
			{
				case eVehicalTypes.ElectricCar:
					newVehical = new Car(i_Model, i_LicensePlate);
					newVehical.Engine = new ElectricEngine(EConstants.k_CarMaxBattary);
					makeCarWheels(newVehical);
					break;
				case eVehicalTypes.GasCar:
					newVehical = new Car(i_Model, i_LicensePlate);
					newVehical.Engine = new GasEngine(EConstants.k_CarFuelType, EConstants.k_CarMaxGas);
					makeCarWheels(newVehical);
					break;
				case eVehicalTypes.ElectricMotorcycle:
					newVehical = new Motorcycle(i_Model, i_LicensePlate);
					newVehical.Engine = new ElectricEngine(EConstants.k_MotorcycleMaxBattary);
					makeMotorcycleWheels(newVehical);
					break;
				case eVehicalTypes.GasMotorcycle:
					newVehical = new Motorcycle(i_Model, i_LicensePlate);
					newVehical.Engine = new GasEngine(EConstants.k_MotorcycleFuelType, EConstants.k_MotorcycleMaxGas);
					makeMotorcycleWheels(newVehical);
					break;
				case eVehicalTypes.GasTruck:
					newVehical = new Truck(i_Model, i_LicensePlate);
					newVehical.Engine = new GasEngine(EConstants.k_TruckFuelType, EConstants.k_TruckMaxGas);
					makeTruckWheels(newVehical);
					break;
			}

			return newVehical;
		}

		private	static void						makeCarWheels(Vehical i_Vehical)
		{
			i_Vehical.Wheels = new List<Wheel>(EConstants.k_CarWheels);
			makeWheels(i_Vehical.Wheels, EConstants.k_CarMaxPsi);
		}

		private static void						makeMotorcycleWheels(Vehical i_Vehical)
		{
			i_Vehical.Wheels = new List<Wheel>(EConstants.k_MotorcycleWheels);
			makeWheels(i_Vehical.Wheels, EConstants.k_MotorcycleMaxPsi);
		}

		private static void						makeTruckWheels(Vehical i_Vehical)
		{
			i_Vehical.Wheels = new List<Wheel>(EConstants.k_TruckWheels);
			makeWheels(i_Vehical.Wheels, EConstants.k_TruckMaxPsi);
		}

		private static void						makeWheels(List<Wheel> i_Wheels, float i_MaxPSI)
		{
			for (int i = 0; i < i_Wheels.Capacity; i++)
			{
				i_Wheels.Add(new Wheel(i_MaxPSI));
			}
		}
	}
}
