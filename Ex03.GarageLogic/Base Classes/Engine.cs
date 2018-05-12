using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.BaseClasses
{
	public abstract class Engine
	{
		private readonly float r_MaxCapacity;
		private float m_CurrentCapacity;

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
				if (value > r_MaxCapacity)
				{
					throw new ValueOutOfRangeException(0, r_MaxCapacity, string.Format("Value out of range! Please enter a value between 0 and {0}!", r_MaxCapacity));
				}
				else if(value < 0)
				{
					throw new ArgumentException(string.Format("Value is negative! Please enter a value between 0 and {0}!", r_MaxCapacity));
				}
				else
				{
					m_CurrentCapacity = value;
				}
			}
		}

	}
}
