using System;
using System.Text;
using Ex03.GarageLogic.Base_Classes;

namespace Ex03.GarageLogic.Vehical_Types
{
	public class Motorcycle : Vehical
	{
		private Enums.eLicenseType	m_LicenseType;             
		private int					m_EngineVolume;

		internal								Motorcycle(string i_Model, string i_LicensePlate) : base(i_Model, i_LicensePlate)
		{
		}

		public				Enums.eLicenseType	LicenseType
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
			StringBuilder electricMotorcycleDetails = new StringBuilder(base.ToString());
			electricMotorcycleDetails.AppendLine(string.Format(
@"
Motorcycle Properties:
License type: {0}
Engine volume: {1}cc", 
LicenseType.ToString(), 
EngineVolume));

			return electricMotorcycleDetails.ToString();
		}
	}
}
