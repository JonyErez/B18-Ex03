using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Vehical_Types
{
	class ElectricalMotorcycle : ElectricVehical
	{
		private readonly MotorcycleProperties r_MotorcycleProperties = null;

		public ElectricalMotorcycle(string i_Model, string i_LicensePlate, List<Wheel> i_Wheels, float i_MaxBattaryTime, float i_BattaryTimeLeft, int i_EngineVolume, Enums.eLicenseTypes i_LicenseType)
			: base(i_Model, i_LicensePlate, i_Wheels, i_MaxBattaryTime, i_BattaryTimeLeft)
		{
			r_MotorcycleProperties = new MotorcycleProperties(i_LicenseType, i_EngineVolume);
		}
	}
}
