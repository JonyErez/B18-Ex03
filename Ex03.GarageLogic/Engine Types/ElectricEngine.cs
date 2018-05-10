using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.EngineTypes
{
	internal class ElectricEngine : BaseClasses.Engine
	{
		public ElectricEngine(string i_Model, string i_LicensePlate, float i_MaxBattaryTime) : base (i_MaxBattaryTime)
		{
		}

		public override string ToString()
		{
			StringBuilder electricVehicalDetails = new StringBuilder(base.ToString());
			electricVehicalDetails.AppendLine(string.Format(@"Max battary time: {0}
Battary time left: {1}", MaxCapacity, CurrentCapacity));

			return electricVehicalDetails.ToString();
		}

		public void ChargeVehical(float i_HoursToCharge)
		{
			if (i_HoursToCharge < 0)
			{
				if (CurrentCapacity + i_HoursToCharge <= MaxCapacity)
				{
					CurrentCapacity += i_HoursToCharge;
				}
				else
				{
					throw new ValueOutOfRangeException(0, MaxCapacity - CurrentCapacity, "The ammount of hours to charge entered is too high and exceeds the max battary limit!");
				}
			}
			else
			{
				throw new ArgumentOutOfRangeException("i_HoursToCharge", i_HoursToCharge, "The ammount of hours to charge is negative!");
			}
		}
	}
}
