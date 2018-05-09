using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Vehical_Types
{
	class Truck : GasVehical
	{
		private readonly float r_CargoholdVolume;
		private readonly bool r_IsCargoholdCooled;

		public Truck(string i_Model, string i_LicensePlate, List<Wheel> i_Wheels, Enums.eFuelType i_FuelType, float i_MaxGasTankCapacity, float i_CurrentGasVolume, bool i_IsCargoholdCooled, float i_CargoholdVolume) : base(i_Model, i_LicensePlate, i_Wheels, i_FuelType, i_MaxGasTankCapacity, i_CurrentGasVolume)
		{
			r_CargoholdVolume = i_CargoholdVolume;
			r_IsCargoholdCooled = i_IsCargoholdCooled;
		}

		public float CargoholdVolume
		{
			get
			{
				return r_CargoholdVolume;
			}
		}

		public bool IsCargoholdCooled
		{
			get
			{
				return r_IsCargoholdCooled;
			}
		}
	}
}
