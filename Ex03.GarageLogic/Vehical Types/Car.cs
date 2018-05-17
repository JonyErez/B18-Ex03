using System.Text;
using Ex03.GarageLogic.Base_Classes;

namespace Ex03.GarageLogic.Vehical_Types
{
	public class Car : Vehical
	{
		private	Enums.eColor			m_Color;                      
		private Enums.eNumberOfDoors	m_NumberOfDoors;

		internal								Car(string i_Model, string i_LicensePlate) : base(i_Model, i_LicensePlate)
		{
		}

		public override string					ToString()
		{
			StringBuilder electricCarDetails = new StringBuilder(base.ToString());
			electricCarDetails.AppendLine(string.Format(
@"
Car Properties:
Color: {0}
Number of doors: {1}", 
m_Color.ToString(), 
m_NumberOfDoors.ToString()));

			return electricCarDetails.ToString();
		}

		public			Enums.eColor			Color
		{
			get
			{
				return m_Color;
			}

			set
			{
				m_Color = value;
			}
		}

		public			Enums.eNumberOfDoors	NumberOfDoors
		{
			get
			{
				return m_NumberOfDoors;
			}

			set
			{
				m_NumberOfDoors = value;
			}
		}
	}
}
