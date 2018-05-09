using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Vehical_Types
{
	class GasMotorcycle : GasVehical
	{
		private readonly MotorcycleProperties r_MotorcycleProperties = null;

		public GasMotorcycle(string i_Model, string i_LicensePlate, Enums.eFuelType i_FuelType, float i_MaxGasTankCapacity) : base(i_Model, i_LicensePlate, i_FuelType, i_MaxGasTankCapacity)
		{
		}

		public override string ToString()
		{
			StringBuilder GasMotorcycleDetails = new StringBuilder(base.ToString());
			GasMotorcycleDetails.AppendLine(r_MotorcycleProperties.ToString());

			return GasMotorcycleDetails.ToString();
		}
	}
}
