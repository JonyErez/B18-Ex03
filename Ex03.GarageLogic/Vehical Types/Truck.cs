using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.VehicalTypes
{
	public class Truck : BaseClasses.Vehical
	{
		private float m_CargoholdVolume;
		private bool m_IsCargoholdCooled;

		internal Truck(string i_Model, string i_LicensePlate) : base(i_Model, i_LicensePlate)
		{
		}

		public float CargoholdVolume
		{
			get
			{
				return m_CargoholdVolume;
			}
			set
			{
				if(m_CargoholdVolume < 0)
				{
					throw new ArgumentException("Value is negative! Please enter a vaid input.");
				}
				else
				{
					m_CargoholdVolume = value;
				}
			}
		}

		public bool IsCargoholdCooled
		{
			get
			{
				return m_IsCargoholdCooled;
			}
			set
			{
				m_IsCargoholdCooled = value;
			}
		}

		public override string ToString()
		{
			StringBuilder TruckDetails = new StringBuilder(base.ToString());
			TruckDetails.AppendLine(string.Format(@"Cargohold volume: {0}L
Is cargohold cooled: {1:Yes;;No}", CargoholdVolume, IsCargoholdCooled)); //TODO: check condition.

			return TruckDetails.ToString();
		}
	}
}
