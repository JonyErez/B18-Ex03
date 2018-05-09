using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
	public class CarProperties
	{
		private readonly Enums.eColor r_Color;						//checkIfReadonly
		private readonly Enums.eNumberOfDoors r_NumberOfDoors;

		public CarProperties(Enums.eColor i_Color, Enums.eNumberOfDoors i_NumberOfDoors)
		{
			r_Color = i_Color;
			r_NumberOfDoors = i_NumberOfDoors;
		}

		public Enums.eColor Color
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
