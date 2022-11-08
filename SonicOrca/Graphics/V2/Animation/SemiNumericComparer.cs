using System;
using System.Collections.Generic;

namespace SonicOrca.Graphics.V2.Animation
{
	// Token: 0x020000F7 RID: 247
	public class SemiNumericComparer : IComparer<string>
	{
		// Token: 0x06000886 RID: 2182 RVA: 0x00021478 File Offset: 0x0001F678
		public int Compare(string s1, string s2)
		{
			if (SemiNumericComparer.IsNumeric(s1) && SemiNumericComparer.IsNumeric(s2))
			{
				if (Convert.ToInt32(s1) > Convert.ToInt32(s2))
				{
					return 1;
				}
				if (Convert.ToInt32(s1) < Convert.ToInt32(s2))
				{
					return -1;
				}
				if (Convert.ToInt32(s1) == Convert.ToInt32(s2))
				{
					return 0;
				}
			}
			if (SemiNumericComparer.IsNumeric(s1) && !SemiNumericComparer.IsNumeric(s2))
			{
				return -1;
			}
			if (!SemiNumericComparer.IsNumeric(s1) && SemiNumericComparer.IsNumeric(s2))
			{
				return 1;
			}
			return string.Compare(s1, s2, true);
		}

		// Token: 0x06000887 RID: 2183 RVA: 0x000214F4 File Offset: 0x0001F6F4
		public static bool IsNumeric(object value)
		{
			bool result;
			try
			{
				Convert.ToInt32(value.ToString());
				result = true;
			}
			catch (FormatException)
			{
				result = false;
			}
			return result;
		}
	}
}
