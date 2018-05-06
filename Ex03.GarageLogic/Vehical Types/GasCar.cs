using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
	class GasCar : GasVehical
	{
		private readonly eColor r_Color;
		private readonly Enums.eNumberOfDoors r_NumberOfDoors;

		public GasCar (string i_Model, string i_LicensePlate, List<Wheel> i_Wheels, eFuelType i_FuelType, float i_MaxGasTankCapacity, float i_CurrentGasVolume, eColor i_Color, Enums.eNumberOfDoors i_NumberOfDoors) : base(i_Model, i_LicensePlate, i_Wheels, i_FuelType, i_MaxGasTankCapacity, i_CurrentGasVolume)
		{
			r_Color = i_Color;
			r_NumberOfDoors = i_NumberOfDoors;
		}

		public eColor Color
		{
			get
			{
				return r_Color;
			}
		}

		public Enums.eNumberOfDoors NumberOfDoors
		{
			get
			{
				return r_NumberOfDoors;
			}
		}
	}
}
