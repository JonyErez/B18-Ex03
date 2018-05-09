using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
	class TruckProperties
	{
		private readonly float r_CargoholdVolume;
		private readonly bool r_IsCargoholdCooled;

		public TruckProperties(float i_CargoholdVolume, bool i_IsCargoholdCooled)
		{
			r_CargoholdVolume = i_CargoholdVolume;
			r_IsCargoholdCooled = i_IsCargoholdCooled;
		}

		public float CargoholdVolume
		{
			get
			{
				return r_CargoholdVolume;
			}
		}

		public bool IsCargoholdCooled
		{
			get
			{
				return r_IsCargoholdCooled;
			}
		}
	}
}
