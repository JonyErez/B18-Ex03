using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Vehical_Types
{
	class GasMotorcycle : GasVehical
	{
		private readonly MotorcycleProperties r_MotorcycleProperties = null;

		public GasMotorcycle(string i_Model, string i_LicensePlate, List<Wheel> i_Wheels, Enums.eFuelType i_FuelType, float i_MaxGasTankCapacity, float i_CurrentGasVolume) : base(i_Model, i_LicensePlate, i_Wheels, i_FuelType, i_MaxGasTankCapacity, i_CurrentGasVolume)
		{
		}
	}
}
