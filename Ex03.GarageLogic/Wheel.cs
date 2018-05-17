using System;

namespace Ex03.GarageLogic
{
	public class Wheel
	{
		private	readonly	float	r_MaxPsi;
		private				string	m_Manufacturer;
		private				float	m_CurrentPsi;

		public						Wheel(float i_MaxPsi)
		{
			r_MaxPsi = i_MaxPsi;
		}

		public	override	string	ToString()
		{
			return string.Format(
@"Manufacor: {0}
Max PSI: {1}
Current PSI: {2}", 
m_Manufacturer, 
r_MaxPsi, 
m_CurrentPsi);
		}

		public				string	Manufacturer
		{
			get
			{
				return m_Manufacturer;
			}

			set
			{
				m_Manufacturer = value;
			}
		}

		public				float	CurrentPsi
		{
			get
			{
				return m_CurrentPsi;
			}

			set
			{
				if (value < 0 || value > r_MaxPsi)
				{
					throw new ValueOutOfRangeException(0, r_MaxPsi, string.Format("Value out of range! Please enter a value between 0 and {0}!", r_MaxPsi));
				}
				else
				{
					m_CurrentPsi = value;
				}
			}
		}

		public				float	MaxPsi
		{
			get
			{
				return r_MaxPsi;
			}
		}

		public				void	Inflate(float i_AirToFill)
		{
			if (i_AirToFill >= 0)
			{
				if (m_CurrentPsi + i_AirToFill <= r_MaxPsi)
				{
					m_CurrentPsi += i_AirToFill;
				}
				else
				{
					throw new ValueOutOfRangeException(0, r_MaxPsi - m_CurrentPsi, "The ammount of air to fill entered is too high and exceeds the max air pressure!");
				}
			}
			else
			{
				throw new ArgumentOutOfRangeException("i_AirToFill", i_AirToFill, "The ammount of air to fill is negative!");
			}
		}
	}
}
