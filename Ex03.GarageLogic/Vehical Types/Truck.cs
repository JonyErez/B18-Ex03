﻿using System;
using System.Text;
using Ex03.GarageLogic.Base_Classes;

namespace Ex03.GarageLogic.Vehical_Types
{
	public class Truck : Vehical
	{
		private	float	m_CargoholdVolume;
		private	bool	m_IsCargoholdCooled;

		internal					Truck(string i_Model, string i_LicensePlate) : base(i_Model, i_LicensePlate)
		{
		}

		public				float	CargoholdVolume
		{
			get
			{
				return m_CargoholdVolume;
			}

			set
			{
				if(value < 0)
				{
					throw new ArgumentException("Value is negative! Please enter a vaid input.");
				}
				else
				{
					m_CargoholdVolume = value;
				}
			}
		}

		public				bool	IsCargoholdCooled
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

		public	override	string	ToString()
		{
			StringBuilder TruckDetails = new StringBuilder(base.ToString());
			TruckDetails.AppendLine(string.Format(
@"
Truck Properties:
Cargohold volume: {0}L
Is cargohold cooled: {1}", 
CargoholdVolume, 
IsCargoholdCooled == true ? "Yes" : "No"));

			return TruckDetails.ToString();
		}
	}
}
