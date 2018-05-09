using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
	public class Garage
	{
		Dictionary<int, VehicalInformation> Vehicals = new Dictionary<int, VehicalInformation>();

		public VehicalInformation FindVehical(string i_LisencePlateKey)
		{
			VehicalInformation VehicalToFind;
			if (!Vehicals.TryGetValue(i_LisencePlateKey.GetHashCode(), out VehicalToFind))
			{
				VehicalToFind = null; 
			}
			return VehicalToFind;
		}

		public void AddVehical(VehicalInformation i_VehicalToAdd)
		{
			Vehicals.Add(i_VehicalToAdd.Vehical.LicensePlate.GetHashCode(), i_VehicalToAdd);
		}

	}
}
