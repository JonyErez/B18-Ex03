using System;
using System.Text;
using Ex03.GarageLogic.Base_Classes;

namespace Ex03.GarageLogic.Engine_Types
{
	public class ElectricEngine : Engine
	{
		public						ElectricEngine(float i_MaxBattaryTime) : base(i_MaxBattaryTime)
		{
		}

		public	override	string	ToString()
		{
			StringBuilder electricVehicalDetails = new StringBuilder();
			electricVehicalDetails.AppendLine(string.Format(
@"Electric Engine Properties:
Max battary time: {0} hours
Battary time left: {1} hours", 
MaxCapacity, 
CurrentCapacity));

			return electricVehicalDetails.ToString();
		}

		internal			void	chargeVehical(float i_HoursToCharge)
		{
			if (i_HoursToCharge >= 0)
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
				throw new ArgumentException("The ammount of hours to charge is negative!");
			}
		}
	}
}
