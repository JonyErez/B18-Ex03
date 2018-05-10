using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.EngineTypes
{
	internal abstract class GasEngine : BaseClasses.Engine
	{
		private readonly Enums.eFuelType r_FuelType;
		//private readonly float r_MaxGasTankCapacity;
		//private float m_CurrentGasVolume;

		public GasEngine(string i_Model, string i_LicensePlate, Enums.eFuelType i_FuelType, float i_MaxGasTankCapacity) : base(i_MaxGasTankCapacity)
		{
			r_FuelType = i_FuelType;
		}

		public override string ToString()
		{
			StringBuilder gasVehicalDetails = new StringBuilder(base.ToString());
			gasVehicalDetails.AppendLine(string.Format(@"Fuel type: {0}
Max gas tank capacity: {1}L
Current gas volume: {2}L", r_FuelType.ToString(), MaxCapacity, CurrentCapacity));

			return gasVehicalDetails.ToString();
		}

		public Enums.eFuelType FuelType
		{
			get
			{
				return r_FuelType;
			}
		}
		
		public void FillGas(Enums.eFuelType i_FuelType, float i_GasToFill)
		{
			if (i_FuelType == r_FuelType)
			{
				if (i_GasToFill < 0)
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
					throw new ArgumentOutOfRangeException("i_GasToFill", i_GasToFill, "The ammount of gas to fill is negative!");
				}
			}
			else
			{
				throw new ArgumentOutOfRangeException("i_FuelType", i_FuelType, "Wrong fuel type for vehical!");
			}
		}
	}
}
