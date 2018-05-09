using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Vehical_Types
{
	class ElectricalMotorcycle : ElectricVehical
	{
		private readonly MotorcycleProperties r_MotorcycleProperties = null;

		public ElectricalMotorcycle(string i_Model, string i_LicensePlate, float i_MaxBattaryTime)
			: base(i_Model, i_LicensePlate, i_MaxBattaryTime)
		{
		}

		public override string ToString()
		{
			StringBuilder ElectricMotorcycleDetails = new StringBuilder(base.ToString());
			ElectricMotorcycleDetails.AppendLine(r_MotorcycleProperties.ToString());

			return ElectricMotorcycleDetails.ToString();
		}
	}
}
