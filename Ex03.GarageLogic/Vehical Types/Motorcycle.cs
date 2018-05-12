using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.VehicalTypes
{
	public class Motorcycle : BaseClasses.Vehical
	{
		private Enums.eLicenseTypes r_LicenseType;             
		private int r_EngineVolume;

		internal Motorcycle(string i_Model, string i_LicensePlate) : base(i_Model, i_LicensePlate)
		{
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
		
		public override string ToString()
		{
			StringBuilder ElectricMotorcycleDetails = new StringBuilder(base.ToString());
			ElectricMotorcycleDetails.AppendLine(string.Format(@"License type: {0}
Engine volume: {1}cc", LicenseType.ToString(), EngineVolume));

			return ElectricMotorcycleDetails.ToString();
		}
	}
}
