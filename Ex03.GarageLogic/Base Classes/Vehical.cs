using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
	public abstract class Vehical
	{
		private readonly string r_Model;
		private readonly string r_LicensePlate;
		private float m_EnergyLeft;
		private List<Wheel> m_Wheels;

		public Vehical(string i_Model, string i_LicensePlate)
		{
			r_Model = i_Model;
			r_LicensePlate = i_LicensePlate;
		}

		public string Model
		{
			get
			{
				return r_Model;
			}
		}

		public string LicensePlate
		{
			get
			{
				return r_LicensePlate;
			}
		}

		protected float EnergyLeft
		{
			get
			{
				return m_EnergyLeft;
			}

			set
			{
				m_EnergyLeft = value;
			}
		}

		public List<Wheel> Wheels
		{
			get
			{
				return m_Wheels;
			}
			set
			{
				m_Wheels = value;
			}
		}

		protected abstract void UpdateEnergyPercentLeft();
	}
}
