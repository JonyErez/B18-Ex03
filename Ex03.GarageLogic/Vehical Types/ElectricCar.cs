using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Vehical_Types
{
	class ElectricCar : ElectricVehical 
	{
		private CarProperties m_carProperties = null;

		public ElectricCar(string i_Model, string i_LicensePlate, List<Wheel> i_Wheels, float i_MaxBattaryTime, float i_BattaryTimeLeft, Enums.eColor i_Color, Enums.eNumberOfDoors i_NumberOfDoors)
			: base(i_Model, i_LicensePlate, i_Wheels, i_MaxBattaryTime, i_BattaryTimeLeft)
		{
			m_carProperties = new CarProperties(i_Color, i_NumberOfDoors); 
		}
	}
}
