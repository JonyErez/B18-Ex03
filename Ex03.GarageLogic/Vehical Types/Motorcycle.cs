using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.VehicalTypes
{
	public class Motorcycle : BaseClasses.Vehical
	{
		private Enums.eLicenseTypes	m_LicenseType;             
		private int					m_EngineVolume;

		internal								Motorcycle(string i_Model, string i_LicensePlate) : base(i_Model, i_LicensePlate)
		{
		}

		public				Enums.eLicenseTypes	LicenseType
		{
			get
			{
				return m_LicenseType;
			}

			set
			{
				m_LicenseType = value;
			}
		}

		public				int					EngineVolume
		{
			get
			{
				return m_EngineVolume;
			}

			set
			{
				if (value < 0)
				{
					throw new ArgumentException("Value is negative! Please enter a vaid input.");
				}
				else
				{
					m_EngineVolume = value;
				}
			}
		}
		
		public	override	string				ToString()
		{
			StringBuilder ElectricMotorcycleDetails = new StringBuilder(base.ToString());
			ElectricMotorcycleDetails.AppendLine(string.Format(
@"License type: {0}
Engine volume: {1}cc", 
LicenseType.ToString(), 
EngineVolume));

			return ElectricMotorcycleDetails.ToString();
		}
	}
}
