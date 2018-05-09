using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Vehical_Types
{
	class GasCar : GasVehical
	{
		private readonly CarProperties r_carProperties = null;

		public GasCar(string i_Model, string i_LicensePlate, List<Wheel> i_Wheels, Enums.eFuelType i_FuelType, float i_MaxGasTankCapacity, float i_CurrentGasVolume, Enums.eColor i_Color, Enums.eNumberOfDoors i_NumberOfDoors) : base(i_Model, i_LicensePlate, i_Wheels, i_FuelType, i_MaxGasTankCapacity, i_CurrentGasVolume)
		{
			r_carProperties = new CarProperties(i_Color, i_NumberOfDoors);
		}
	}
}
