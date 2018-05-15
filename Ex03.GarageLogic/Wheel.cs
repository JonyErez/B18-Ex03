using System;

namespace Ex03.GarageLogic
{
	public class Wheel
	{
		private		readonly	float	r_MaxPSI;
		private					string	i_Manufacturer;
		private					float	m_CurrentPSI;

		public Wheel(float i_MaxPSI)
		{
			r_MaxPSI = i_MaxPSI;
		}

		public override string ToString()
		{
			return string.Format(
@"Manufacor: {0}
Max PSI: {1}
Current PSI: {2}", 
i_Manufacturer, 
r_MaxPSI, 
m_CurrentPSI);
		}

		public	string	Manufacturer
		{
			get
			{
				return i_Manufacturer;
			}

			set
			{
				i_Manufacturer = value;
			}
		}

		public	float	CurrentPSI
		{
			get
			{
				return m_CurrentPSI;
			}

			set
			{
				if (value < 0 || value > r_MaxPSI)
				{
					throw new ValueOutOfRangeException(0, r_MaxPSI, string.Format("Value out of range! Please enter a value between 0 and {0}!", r_MaxPSI));
				}
				else
				{
					m_CurrentPSI = value;
				}
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
			if (i_AirToFill >= 0)
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
