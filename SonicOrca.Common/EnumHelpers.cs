using System;

namespace SonicOrca
{
	// Token: 0x02000004 RID: 4
	public static class EnumHelpers
	{
		// Token: 0x06000006 RID: 6 RVA: 0x000020F5 File Offset: 0x000002F5
		public static int GetEnumCount(Type enumeration)
		{
			return Enum.GetNames(enumeration).Length;
		}
	}
}
