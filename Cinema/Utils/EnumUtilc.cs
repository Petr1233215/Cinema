using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Utils
{
	public static class EnumUtilc
	{
		public static IEnumerable<T> GetValues<T>()
		{
			return Enum.GetValues(typeof(T)).Cast<T>();
		}
	}
}