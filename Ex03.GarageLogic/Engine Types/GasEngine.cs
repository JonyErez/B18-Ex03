using System;
using System.Text;
using Ex03.GarageLogic.Base_Classes;

namespace Ex03.GarageLogic.Engine_Types
{
	public class GasEngine : Engine
	{
		private	readonly	Enums.eFuelType	r_FuelType;

		public								GasEngine(Enums.eFuelType i_FuelType, float i_MaxGasTankCapacity) : base(i_MaxGasTankCapacity)
		{
			r_FuelType = i_FuelType;
		}

		public	override	string			ToString()
		{
			StringBuilder gasVehicalDetails = new StringBuilder();
			gasVehicalDetails.AppendLine(string.Format(
@"Gas Engine Properties:
Fuel type: {0}
Max gas tank capacity: {1}L
Current gas volume: {2}L", 
FuelType.ToString(), 
MaxCapacity, 
CurrentCapacity));

			return gasVehicalDetails.ToString();
		}

		public				Enums.eFuelType	FuelType
		{
			get
			{
				return r_FuelType;
			}
		}
		
		internal			void			fillGas(Enums.eFuelType i_FuelType, float i_GasToFill)
		{
			if (i_FuelType == r_FuelType)
			{
				if (i_GasToFill >= 0)
				{
					if (CurrentCapacity + i_GasToFill <= MaxCapacity)
					{
						CurrentCapacity += i_GasToFill;
					}
					else
					{
						throw new ValueOutOfRangeException(0, MaxCapacity - CurrentCapacity, "The ammount of gas to fill entered is too high and exceeds the max tank capacity!");
					}
				}
				else
				{
					throw new ArgumentException("The ammount of gas to fill is negative!");
				}
			}
			else
			{
				throw new ArgumentException("Wrong fuel type for vehical!");
			}
		}
	}
}
