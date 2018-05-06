using System;

namespace Ex03.GarageLogic
{
	internal class Wheel
	{
		private		readonly	string	r_Manufacturer;
		private		readonly	float	r_MaxPSI;
		private					float	m_CurrentPSI;

		public Wheel (string i_Manufacturer, float i_MaxPSI, float i_CurrentPSI)
		{
			r_Manufacturer = i_Manufacturer;
			r_MaxPSI = i_MaxPSI;
			m_CurrentPSI = i_CurrentPSI;
		}

		public	string	Manufacturer
		{
			get
			{
				return r_Manufacturer;
			}
		}

		public	float	CurrentPSI
		{
			get
			{
				return m_CurrentPSI;
			}
		}

		public	float	MaxPSI
		{
			get
			{
				return r_MaxPSI;
			}
		}

		public	void	Inflate(float i_AirToFill)
		{
			if (i_AirToFill < 0)
			{
				if (m_CurrentPSI + i_AirToFill <= r_MaxPSI)
				{
					m_CurrentPSI += i_AirToFill;
				}
				else
				{
					throw new ValueOutOfRangeException(0, r_MaxPSI - m_CurrentPSI, "The ammount of air to fill entered is too high and exceeds the max air pressure!");
				}
			}
			else
			{
				throw new ArgumentOutOfRangeException("i_AirToFill", i_AirToFill, "The ammount of air to fill is negative!");
			}
		}
	}
}
