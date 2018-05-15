using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
	public class Garage
	{
		private	Dictionary<int, VehicalInformation>	Vehicals = new Dictionary<int, VehicalInformation>();

		public	VehicalInformation	FindVehical(string i_LicensePlate)
		{
			VehicalInformation VehicalToFind;

			if (!Vehicals.TryGetValue(i_LicensePlate.GetHashCode(), out VehicalToFind))
			{
				throw new ArgumentException(string.Format("No vehical that matches the license plate '{0}' in the garage!", i_LicensePlate));
			}

			return VehicalToFind;
		}

		public	void				AddVehical(VehicalInformation i_VehicalToAdd)
		{
			Vehicals.Add(i_VehicalToAdd.Vehical.LicensePlate.GetHashCode(), i_VehicalToAdd);
		}

		public	void				ChangeVehicalStatus(string i_LicensePlate, Enums.eVehicalStatus i_NewStatus)
		{
			VehicalInformation VehicalToUpdate = FindVehical(i_LicensePlate);
			VehicalToUpdate.VehicalStatus = i_NewStatus;
		}

		public	List<string>		ListVehicals()
		{
			List<string> licensePlates = new List<string>(Vehicals.Count);
			foreach (KeyValuePair<int, VehicalInformation> currentVehical in Vehicals)
			{
				licensePlates.Add(currentVehical.Value.Vehical.LicensePlate);
			}

			return licensePlates;
		}

		public	List<string>		ListVehicals(Enums.eVehicalStatus i_StatusToFilterBy)
		{
			List<string> licensePlates = new List<string>();
			foreach (KeyValuePair<int, VehicalInformation> currentVehical in Vehicals)
			{
				if (currentVehical.Value.VehicalStatus == i_StatusToFilterBy)
				{
					licensePlates.Add(currentVehical.Value.Vehical.LicensePlate);
				}
			}

			return licensePlates;
		}

		public	void				InflateWheels(string i_LicensePlate)
		{
			VehicalInformation VehicalToInflate = FindVehical(i_LicensePlate);
			foreach (Wheel currentWheel in VehicalToInflate.Vehical.Wheels)
			{
				currentWheel.Inflate(currentWheel.MaxPSI - currentWheel.CurrentPSI);
			}
		}

		public	void				RefuelVehical(string i_LicensePlate, Enums.eFuelType i_FuelType, float i_GasToFill)
		{
			VehicalInformation VehicalToRefuel = FindVehical(i_LicensePlate);
			EngineTypes.GasEngine gasVehicalToRefuel = VehicalToRefuel.Vehical.Engine as EngineTypes.GasEngine;

			if (gasVehicalToRefuel != null)
			{
				gasVehicalToRefuel.FillGas(i_FuelType, i_GasToFill);
			}
			else
			{
				throw new ArgumentException("Cannot refuel a car that is not run by gas!");
			}
		}

		public	void				RechargeVehical(string i_LicensePlate, float i_HoursToCharge)
		{
			VehicalInformation VehicalToRecharge = FindVehical(i_LicensePlate);
			EngineTypes.ElectricEngine electricVehicalToRecharge = VehicalToRecharge.Vehical.Engine as EngineTypes.ElectricEngine;

			if (electricVehicalToRecharge != null)
			{
				electricVehicalToRecharge.ChargeVehical(i_HoursToCharge);
			}
			else
			{
				throw new ArgumentException("Cannot recharge a car that is not run by electricity!");
			}
		}

		public	string				VehicalDetails(string i_LicensePlate)
		{
			VehicalInformation VehicalToPrintDetails = FindVehical(i_LicensePlate);
			return VehicalToPrintDetails.ToString();
		}

		public	bool				DoesVehicalExist(string i_LicensePlate)
		{
			return Vehicals.ContainsKey(i_LicensePlate.GetHashCode());
		}
	}
}
