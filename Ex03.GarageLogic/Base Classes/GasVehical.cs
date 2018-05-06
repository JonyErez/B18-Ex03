using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
	internal abstract class GasVehical : Vehical
	{
		private readonly eFuelType r_FuelType;
		private readonly float r_MaxGasTankCapacity;
		private float m_CurrentGasVolume;

		public GasVehical(string i_Model, string i_LicensePlate, List<Wheel> i_Wheels, eFuelType i_FuelType, float i_MaxGasTankCapacity, float i_CurrentGasVolume) : base(i_Model, i_LicensePlate, i_Wheels)
		{
			r_FuelType = i_FuelType;
			r_MaxGasTankCapacity = i_MaxGasTankCapacity;
			m_CurrentGasVolume = i_CurrentGasVolume;
			UpdateEnergyPercentLeft();
		}

		public eFuelType FuelType
		{
			get
			{
				return r_FuelType;
			}
		}

		public float MaxGasTankCapacity
		{
			get
			{
				return r_MaxGasTankCapacity;
			}
		}

		public float CurrentGasVolume
		{
			get
			{
				return m_CurrentGasVolume;
			}
		}

		public void FillGas(eFuelType i_FuelType, float i_GasToFill)
		{
			if (i_FuelType == r_FuelType)
			{
				if (i_GasToFill < 0)
				{
					if (m_CurrentGasVolume + i_GasToFill <= r_MaxGasTankCapacity)
					{
						m_CurrentGasVolume += i_GasToFill;
						UpdateEnergyPercentLeft();
					}
					else
					{
						throw new ValueOutOfRangeException(0, r_MaxGasTankCapacity - m_CurrentGasVolume, "The ammount of gas to fill entered is too high and exceeds the max tank capacity!");
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

		protected override void UpdateEnergyPercentLeft()
		{
			base.EnergyLeft = (m_CurrentGasVolume / r_MaxGasTankCapacity);
		}
	}
}
