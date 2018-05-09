using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
	public class MotorcycleProperties
	{
		private readonly Enums.eLicenseTypes r_LicenseType;				//checkIfReadonly
		private readonly int r_EngineVolume;

		public MotorcycleProperties(Enums.eLicenseTypes i_LicenseType, int i_EngineVolume)
		{
			r_LicenseType = i_LicenseType;
			r_EngineVolume = i_EngineVolume;
		}

		public Enums.eLicenseTypes LicenseType
		{
			get
			{
				return r_LicenseType;
			}
		}

		public int EngineVolume
		{
			get
			{
				return r_EngineVolume;
			}
		}
	}
}
