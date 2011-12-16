using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app
{
	public static class Extensions
	{
		public static string format(this String theString, params object[] values)
		{
			return String.Format(theString, values);
		}
	}
}
