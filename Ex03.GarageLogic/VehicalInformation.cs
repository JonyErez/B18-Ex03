using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
	public class VehicalInformation
	{
		private string m_OwnerName;
		private string m_OwnerPhone;
		private Enums.eVehicalStatus m_VehicalStatus;
		Vehical m_Vehical;

		public override string ToString()
		{
			StringBuilder vehicalInformation = new StringBuilder();
			vehicalInformation.AppendLine(string.Format(@"Owner: {0}
Phone number: {1}
Status: {2}
Vehical information:
{3}", m_OwnerName, m_OwnerPhone, m_VehicalStatus.ToString(), m_Vehical.ToString()));

			return vehicalInformation.ToString();
		}

		public string OwnerName
		{
			get
			{
				return m_OwnerName;
			}

			set
			{
				m_OwnerName = value;
			}
		}

		public string OwnerPhone
		{
			get
			{
				return m_OwnerPhone;
			}

			set
			{
				m_OwnerPhone = value;
			}
		}

		public Enums.eVehicalStatus VehicalStatus
		{
			get
			{
				return m_VehicalStatus;
			}

			set
			{
				m_VehicalStatus = value;
			}
		}

		public Vehical Vehical
		{
			get
			{
				return m_Vehical;
			}

			set
			{
				m_Vehical = value;
			}
		}
	}
}
