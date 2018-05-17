using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Engine_Types;

namespace Ex03.GarageLogic
{
	public class Garage
	{
		private	readonly	Dictionary<int, VehicalInformation>	r_Vehicals = new Dictionary<int, VehicalInformation>();

		public				VehicalInformation					FindVehical(string i_LicensePlate)
		{
			if (!r_Vehicals.TryGetValue(i_LicensePlate.GetHashCode(), out VehicalInformation vehicalToFind))
			{
				throw new ArgumentException(string.Format("No vehical that matches the license plate '{0}' in the garage!", i_LicensePlate));
			}

			return vehicalToFind;
		}

		public				void								AddVehical(VehicalInformation i_VehicalToAdd)
		{
			r_Vehicals.Add(i_VehicalToAdd.Vehical.LicensePlate.GetHashCode(), i_VehicalToAdd);
		}

		public				void								ChangeVehicalStatus(string i_LicensePlate, Enums.eVehicalStatus i_NewStatus)
		{
			VehicalInformation VehicalToUpdate = FindVehical(i_LicensePlate);
			VehicalToUpdate.VehicalStatus = i_NewStatus;
		}

		public				List<string>						ListVehicals()
		{
			List<string> licensePlates = new List<string>(r_Vehicals.Count);
			foreach (KeyValuePair<int, VehicalInformation> currentVehical in r_Vehicals)
			{
				licensePlates.Add(currentVehical.Value.Vehical.LicensePlate);
			}

			return licensePlates;
		}

		public				List<string>						ListVehicals(Enums.eVehicalStatus i_StatusToFilterBy)
		{
			List<string> licensePlates = new List<string>();
			foreach (KeyValuePair<int, VehicalInformation> currentVehical in r_Vehicals)
			{
				if (currentVehical.Value.VehicalStatus == i_StatusToFilterBy)
				{
					licensePlates.Add(currentVehical.Value.Vehical.LicensePlate);
				}
			}

			return licensePlates;
		}

		public				void								InflateWheels(string i_LicensePlate)
		{
			VehicalInformation vehicalToInflate = FindVehical(i_LicensePlate);
			foreach (Wheel currentWheel in vehicalToInflate.Vehical.Wheels)
			{
				currentWheel.Inflate(currentWheel.MaxPsi - currentWheel.CurrentPsi);
			}
		}

		public				void								RefuelVehical(VehicalInformation i_VehicalToRefuel, Enums.eFuelType i_FuelType, float i_GasToFill)
		{
			if (i_VehicalToRefuel.Vehical.Engine is GasEngine gasVehicalToRefuel)
			{
				gasVehicalToRefuel.fillGas(i_FuelType, i_GasToFill);
			}
			else
			{
				throw new ArgumentException("Cannot refuel a vehical that is not run by gas!");
			}
		}

		public				void								RechargeVehical(VehicalInformation i_VehicalToRecharge, float i_HoursToCharge)
		{
			if (i_VehicalToRecharge.Vehical.Engine is ElectricEngine electricVehicalToRecharge)
			{
				electricVehicalToRecharge.chargeVehical(i_HoursToCharge);
			}
			else
			{
				throw new ArgumentException("Cannot recharge a vehical that is not run by electricity!");
			}
		}

		public				bool								DoesVehicalExist(string i_LicensePlate)
		{
			return r_Vehicals.ContainsKey(i_LicensePlate.GetHashCode());
		}
	}
}
