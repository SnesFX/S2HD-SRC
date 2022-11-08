using System;
using System.Collections.Generic;
using System.Linq;

namespace SonicOrca.Extensions
{
	// Token: 0x02000009 RID: 9
	public static class CollectionExtensions
	{
		// Token: 0x06000010 RID: 16 RVA: 0x000021DC File Offset: 0x000003DC
		public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
		{
			foreach (T item in items)
			{
				collection.Add(item);
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002224 File Offset: 0x00000424
		public static void RemoveRange<T>(this ICollection<T> collection, IEnumerable<T> items)
		{
			foreach (T item in items)
			{
				collection.Remove(item);
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002270 File Offset: 0x00000470
		public static int RemoveAll<T>(this ICollection<T> collection, Predicate<T> match)
		{
			T[] array = (from x in collection
			where match(x)
			select x).ToArray<T>();
			foreach (T item in array)
			{
				collection.Remove(item);
			}
			return array.Length;
		}
	}
}
