using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.VehicalTypes
{
	public class Truck : BaseClasses.Vehical
	{
		private float r_CargoholdVolume;
		private bool r_IsCargoholdCooled;

		internal Truck(string i_Model, string i_LicensePlate) : base(i_Model, i_LicensePlate)
		{
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

		public override string ToString()
		{
			StringBuilder TruckDetails = new StringBuilder(base.ToString());
			TruckDetails.AppendLine(string.Format(@"Cargohold volume: {0}L
Is cargohold cooled: {1:Yes;;No}", CargoholdVolume, IsCargoholdCooled)); //TODO: check condition.

			return TruckDetails.ToString();
		}
	}
}
