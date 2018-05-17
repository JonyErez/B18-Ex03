using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Base_Classes
{
	public abstract class Vehical
	{
		private	readonly	string			r_Model;
		private	readonly	string			r_LicensePlate;
		private				float			m_EnergyLeft;
		private				Engine			m_Engine = null;
		private				List<Wheel>		m_Wheels;

		protected Vehical(string i_Model, string i_LicensePlate)
		{
			r_Model = i_Model;
			r_LicensePlate = i_LicensePlate;
		}

		public	override	string		ToString()
		{
			return string.Format(
@"License plate: {0}
Model: {1}
Energy left: {2:p}

Wheels:
{3}
{4}", 
LicensePlate, 
Model, 
EnergyLeft, 
getWheelDetails(), 
m_Engine.ToString());
		}

		private				string		getWheelDetails()
		{
			StringBuilder wheelsDetails = new StringBuilder();
			int i = 1;

			foreach(Wheel wheel in m_Wheels)
			{
				wheelsDetails.AppendLine(string.Format("Wheel {0}:", i));
				wheelsDetails.AppendLine(wheel.ToString());
				i++;
			}

			return wheelsDetails.ToString();
		}

		public				Engine		Engine
		{
			get
			{
				return m_Engine;
			}

			set
			{
				m_Engine = value;
			}
		}

		public				string		Model
		{
			get
			{
				return r_Model;
			}
		}

		public				string		LicensePlate
		{
			get
			{
				return r_LicensePlate;
			}
		}

		protected			float		EnergyLeft
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

		public				List<Wheel>	Wheels
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

		public				void		UpdateEnergyPercentLeft()
		{
			m_EnergyLeft = m_Engine.CurrentCapacity / m_Engine.MaxCapacity;
		}
	}
}
