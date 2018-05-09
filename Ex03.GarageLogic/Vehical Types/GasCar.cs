using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Vehical_Types
{
	class GasCar : GasVehical
	{
		private readonly CarProperties r_carProperties = null;

		public GasCar(string i_Model, string i_LicensePlate, Enums.eFuelType i_FuelType, float i_MaxGasTankCapacity) : base(i_Model, i_LicensePlate, i_FuelType, i_MaxGasTankCapacity)
		{
		}

		public override string ToString()
		{
			StringBuilder GasCarDetails = new StringBuilder(base.ToString());
			GasCarDetails.AppendLine(r_carProperties.ToString());

			return GasCarDetails.ToString();
		}
	}
}
