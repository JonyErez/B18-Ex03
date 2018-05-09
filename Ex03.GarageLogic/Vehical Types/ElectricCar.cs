using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Vehical_Types
{
	class ElectricCar : ElectricVehical 
	{
		private CarProperties m_carProperties = null;

		public ElectricCar(string i_Model, string i_LicensePlate, float i_MaxBattaryTime)
			: base(i_Model, i_LicensePlate, i_MaxBattaryTime)
		{
		}

		public override string ToString()
		{
			StringBuilder ElectricCarDetails =  new StringBuilder(base.ToString());
			ElectricCarDetails.AppendLine(m_carProperties.ToString());

			return ElectricCarDetails.ToString();
		}
	}
}
