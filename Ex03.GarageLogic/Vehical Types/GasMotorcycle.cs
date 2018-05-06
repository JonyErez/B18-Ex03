using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Vehical_Types
{
	class GasMotorcycle : GasVehical
	{
		private readonly eLicenseTypes r_LicenseType;
		private readonly int r_EngineVolume;

		public GasMotorcycle (string i_Model, string i_LicensePlate, List<Wheel> i_Wheels, eFuelType i_FuelType, float i_MaxGasTankCapacity, float i_CurrentGasVolume, int i_EngineVolume, eLicenseTypes i_LicenseType) : base(i_Model, i_LicensePlate, i_Wheels, i_FuelType, i_MaxGasTankCapacity, i_CurrentGasVolume)
		{
			r_LicenseType = i_LicenseType;
			r_EngineVolume = i_EngineVolume;
		}

		public eLicenseTypes LicenseType
		{
			get
			{
				return r_LicenseType;
			}
		}

		public int EngineVolume
		{
			get
			{
				return r_EngineVolume;
			}
		}
	}
}
