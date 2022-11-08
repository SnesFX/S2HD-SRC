using System;
using System.Collections.Generic;

namespace SonicOrca.Extensions
{
	// Token: 0x0200000C RID: 12
	public static class ListExtensions
	{
		// Token: 0x06000020 RID: 32 RVA: 0x0000264C File Offset: 0x0000084C
		public static int IndexOf<T>(this IReadOnlyList<T> list, Predicate<T> match)
		{
			return list.IndexOf(0, match);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002658 File Offset: 0x00000858
		public static int IndexOf<T>(this IReadOnlyList<T> list, int startIndex, Predicate<T> match)
		{
			for (int i = startIndex; i < list.Count; i++)
			{
				if (match(list[i]))
				{
					return i;
				}
			}
			return -1;
		}
	}
}
