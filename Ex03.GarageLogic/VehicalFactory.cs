using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
	public static class VehicalFactory
	{
		public enum eVehicalTypes
		{
			Truck,
			ElectricCar,
			GasCar,
			ElectricMotorcycle,
			GasMotorcycle
		}

		public Vehical CreateVehical(eVehicalTypes i_VehicalType, )
		{
			Vehical newVehical;
			switch (i_VehicalType)
			{
				case eVehicalTypes.ElectricCar:

					break;

			}
		}

	}
}
