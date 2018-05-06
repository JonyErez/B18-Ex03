using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
	internal abstract class Vehical
	{
		private readonly string r_Model;
		private readonly string r_LisencePlate;
		private float m_EnergyLeft;
		private List<Wheel> m_Wheels;

		public Vehical(string i_Model, string i_LisencePlate, List<Wheel> i_Wheels)
		{
			r_Model = i_Model;
			r_LisencePlate = i_LisencePlate;
			m_Wheels = i_Wheels;
		}

		public string Model
		{
			get
			{
				return r_Model;
			}
		}

		public string LisencePlate
		{
			get
			{
				return r_LisencePlate;
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
		}

		protected abstract void UpdateEnergyPercentLeft();
	}
}
