using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.VehicalTypes
{
	public class Car : BaseClasses.Vehical
	{
		private Enums.eColor m_Color;                      
		private Enums.eNumberOfDoors m_NumberOfDoors;

		internal Car(string i_Model, string i_LicensePlate) : base(i_Model, i_LicensePlate)
		{
		}

		public override string ToString()
		{
			StringBuilder ElectricCarDetails = new StringBuilder(base.ToString());
			ElectricCarDetails.AppendLine(string.Format(
@"Color: {0}
Number of doors: {1}", 
m_Color.ToString(), 
m_NumberOfDoors.ToString()));

			return ElectricCarDetails.ToString();
		}

		public Enums.eColor Color
		{
			get
			{
				return m_Color;
			}

			set
			{
				m_Color = value;
			}
		}

		public Enums.eNumberOfDoors NumberOfDoors
		{
			get
			{
				return m_NumberOfDoors;
			}

			set
			{
				m_NumberOfDoors = value;
			}
		}
	}
}
