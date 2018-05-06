using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Vehical_Types
{
	class ElectricCar : ElectricVehical 
	{
		private readonly eColor r_Color;
		private readonly Enums.eNumberOfDoors r_NumberOfDoors;

		public ElectricCar(string i_Model, string i_LicensePlate, List<Wheel> i_Wheels, float i_MaxBattaryTime, float i_BattaryTimeLeft, eColor i_Color, Enums.eNumberOfDoors i_NumberOfDoors)
			: base(i_Model, i_LicensePlate, i_Wheels, i_MaxBattaryTime, i_BattaryTimeLeft)
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
