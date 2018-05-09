﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Vehical_Types
{
	class Truck : GasVehical
	{
		private readonly TruckProperties r_TruckProperties = null;

		public Truck(string i_Model, string i_LicensePlate, Enums.eFuelType i_FuelType, float i_MaxGasTankCapacity) : base(i_Model, i_LicensePlate, i_FuelType, i_MaxGasTankCapacity)
		{
		}

		public override string ToString()
		{
			StringBuilder TruckDetails = new StringBuilder(base.ToString());
			TruckDetails.AppendLine(r_TruckProperties.ToString());

			return TruckDetails.ToString();
		}
	}
}
