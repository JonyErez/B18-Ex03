using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
	internal abstract class ElectricVehical : Vehical
	{
		private readonly float r_MaxBattaryTime;
		private float m_BattaryTimeLeft;

		public ElectricVehical(string i_Model, string i_LicensePlate, List<Wheel> i_Wheels, float i_MaxBattaryTime, float i_BattaryTimeLeft) : base (i_Model, i_LicensePlate, i_Wheels)
		{
			r_MaxBattaryTime = i_MaxBattaryTime;
			m_BattaryTimeLeft = i_BattaryTimeLeft;
			UpdateEnergyPercentLeft();
		}

		public float MaxBattaryTime
		{
			get
			{
				return r_MaxBattaryTime;
			}
		}

		public float BattaryTimeleft
		{
			get
			{
				return m_BattaryTimeLeft;
			}
		}

		public void ChargeVehical(float i_HoursToCharge)
		{
			if (i_HoursToCharge < 0)
			{
				if (m_BattaryTimeLeft + i_HoursToCharge <= r_MaxBattaryTime)
				{
					m_BattaryTimeLeft += i_HoursToCharge;
					UpdateEnergyPercentLeft();
				}
				else
				{
					throw new ValueOutOfRangeException(0, r_MaxBattaryTime - m_BattaryTimeLeft, "The ammount of hours to charge entered is too high and exceeds the max battary limit!");
				}
			}
			else
			{
				throw new ArgumentOutOfRangeException("i_HoursToCharge", i_HoursToCharge, "The ammount of hours to charge is negative!");
			}
		}

		protected override void UpdateEnergyPercentLeft()
		{
			base.EnergyLeft = (m_BattaryTimeLeft / r_MaxBattaryTime);
		}
	}
}
