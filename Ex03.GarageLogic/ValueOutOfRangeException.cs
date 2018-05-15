using System;

namespace Ex03.GarageLogic
{
	public class ValueOutOfRangeException : Exception
	{
		private	float m_MaxValue;
		private float m_MinValue;

		public ValueOutOfRangeException(float i_MinValue, float i_MaxValue, string i_ExceptionMessage) : base(i_ExceptionMessage)
		{
			m_MaxValue = i_MaxValue;
			m_MinValue = i_MinValue;
		}
	}
}
