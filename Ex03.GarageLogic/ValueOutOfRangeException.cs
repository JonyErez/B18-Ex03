using System;

namespace Ex03.GarageLogic
{
	class ValueOutOfRangeException : Exception
	{
		float m_MaxValue;
		float m_MinValue;

		public ValueOutOfRangeException(float i_MinValue, float i_MaxValue, string i_ExceptionMessage) : base(i_ExceptionMessage)
		{
			m_MaxValue = i_MaxValue;
			m_MinValue = i_MinValue;
		}
	}
}
