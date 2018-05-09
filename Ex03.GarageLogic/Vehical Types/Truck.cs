using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Vehical_Types
{
	class Truck : GasVehical
	{
		private readonly TruckProperties r_TruckProperties = null;

		public Truck(string i_Model, string i_LicensePlate, List<Wheel> i_Wheels, Enums.eFuelType i_FuelType, float i_MaxGasTankCapacity, float i_CurrentGasVolume, bool i_IsCargoholdCooled, float i_CargoholdVolume) : base(i_Model, i_LicensePlate, i_Wheels, i_FuelType, i_MaxGasTankCapacity, i_CurrentGasVolume)
		{
			r_TruckProperties = new TruckProperties(i_CargoholdVolume, i_IsCargoholdCooled);
		}
	}
}
