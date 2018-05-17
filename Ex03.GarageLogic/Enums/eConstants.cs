using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Enums
{
	public class EConstants 
	{
		public const int k_CarWheels = 4;
		public const int k_CarMaxPsi = 32;
		public const float k_CarMaxBattary = 3.2f;
		public const float k_CarMaxGas = 45f;
		public const eFuelType k_CarFuelType = eFuelType.Octan98;
		public const int k_MotorcycleWheels = 2;
		public const int k_MotorcycleMaxPsi = 30;
		public const float k_MotorcycleMaxBattary = 1.8f;
		public const float k_MotorcycleMaxGas = 6f;
		public const eFuelType k_MotorcycleFuelType = eFuelType.Octan96;
		public const int k_TruckWheels = 12;
		public const int k_TruckMaxPsi = 28;
		public const float k_TruckMaxGas = 115f;
		public const eFuelType k_TruckFuelType = eFuelType.Soler;
		public const int k_MinStringLength = 1;
		public const int k_MaxStringLength = 20;
		public const int k_MinPhoneNumberLength = 9;
		public const int k_MaxPhoneNumberLength = 10;
		public const int k_MinLicensePlateLength = 7;
		public const int k_MaxLicensePlateLength = 8;
	}
}
