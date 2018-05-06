using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Vehical_Types
{
	class ElectricalMotorcycle : ElectricVehical
	{
		private readonly eLicenseTypes r_LicenseType;
		private readonly int r_EngineVolume;

		public ElectricalMotorcycle(string i_Model, string i_LicensePlate, List<Wheel> i_Wheels, float i_MaxBattaryTime, float i_BattaryTimeLeft, int i_EngineVolume, eLicenseTypes i_LicenseType)
			: base(i_Model, i_LicensePlate, i_Wheels, i_MaxBattaryTime, i_BattaryTimeLeft)
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
