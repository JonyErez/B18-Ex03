using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
	public class Garage
	{
		Dictionary<int, VehicalInformation> Vehicals = new Dictionary<int, VehicalInformation>();

		public VehicalInformation FindVehical(int i_LisencePlateKey)
		{
			VehicalInformation VehicalToFind;
			if (!Vehicals.TryGetValue(i_LisencePlateKey, out VehicalToFind))
			{
				VehicalToFind = null; 
			}
			return VehicalToFind;
		}

	}
}
