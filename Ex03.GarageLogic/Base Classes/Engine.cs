using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.BaseClasses
{
	public abstract class Engine
	{
		private readonly float r_MaxCapacity;
		private float m_CurrentCapacity; //rename

		public Engine(float i_MaxCapacity)
		{
			r_MaxCapacity = i_MaxCapacity;
		}

		public float MaxCapacity
		{
			get
			{
				return r_MaxCapacity;
			}
		}

		public float CurrentCapacity
		{
			get
			{
				return m_CurrentCapacity;
			}

			set
			{
				m_CurrentCapacity = value;
			}
		}

	}
}
