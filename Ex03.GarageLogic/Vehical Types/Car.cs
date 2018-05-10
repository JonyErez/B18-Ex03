using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.VehicalTypes
{
	class Car : BaseClasses.Vehical
	{
		private Enums.eColor r_Color;                      
		private Enums.eNumberOfDoors r_NumberOfDoors;

		public Car(string i_Model, string i_LicensePlate) : base(i_Model, i_LicensePlate)
		{
		}

		public override string ToString()
		{
			StringBuilder ElectricCarDetails =  new StringBuilder(base.ToString());
			ElectricCarDetails.AppendLine(string.Format(@"Color: {0}
Number of doors: {1}", r_Color.ToString(), r_NumberOfDoors.ToString()));

			return ElectricCarDetails.ToString();
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
