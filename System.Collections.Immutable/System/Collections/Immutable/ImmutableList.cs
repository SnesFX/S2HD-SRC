using System;
using System.Collections.Generic;

namespace System.Collections.Immutable
{
	// Token: 0x02000025 RID: 37
	public static class ImmutableList
	{
		// Token: 0x060001E8 RID: 488 RVA: 0x000065AA File Offset: 0x000047AA
		public static ImmutableList<T> Create<T>()
		{
			return ImmutableList<T>.Empty;
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x000065B1 File Offset: 0x000047B1
		public static ImmutableList<T> Create<T>(T item)
		{
			return ImmutableList<T>.Empty.Add(item);
		}

		// Token: 0x060001EA RID: 490 RVA: 0x000065BE File Offset: 0x000047BE
		public static ImmutableList<T> CreateRange<T>(IEnumerable<T> items)
		{
			return ImmutableList<T>.Empty.AddRange(items);
		}

		// Token: 0x060001EB RID: 491 RVA: 0x000065CB File Offset: 0x000047CB
		public static ImmutableList<T> Create<T>(params T[] items)
		{
			return ImmutableList<T>.Empty.AddRange(items);
		}

		// Token: 0x060001EC RID: 492 RVA: 0x000065D8 File Offset: 0x000047D8
		public static ImmutableList<T>.Builder CreateBuilder<T>()
		{
			return ImmutableList.Create<T>().ToBuilder();
		}

		// Token: 0x060001ED RID: 493 RVA: 0x000065E4 File Offset: 0x000047E4
		public static ImmutableList<TSource> ToImmutableList<TSource>(this IEnumerable<TSource> source)
		{
			ImmutableList<TSource> immutableList = source as ImmutableList<TSource>;
			if (immutableList != null)
			{
				return immutableList;
			}
			return ImmutableList<TSource>.Empty.AddRange(source);
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00006608 File Offset: 0x00004808
		public static IImmutableList<T> Replace<T>(this IImmutableList<T> list, T oldValue, T newValue)
		{
			Requires.NotNull<IImmutableList<T>>(list, "list");
			return list.Replace(oldValue, newValue, EqualityComparer<T>.Default);
		}

		// Token: 0x060001EF RID: 495 RVA: 0x00006622 File Offset: 0x00004822
		public static IImmutableList<T> Remove<T>(this IImmutableList<T> list, T value)
		{
			Requires.NotNull<IImmutableList<T>>(list, "list");
			return list.Remove(value, EqualityComparer<T>.Default);
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x0000663B File Offset: 0x0000483B
		public static IImmutableList<T> RemoveRange<T>(this IImmutableList<T> list, IEnumerable<T> items)
		{
			Requires.NotNull<IImmutableList<T>>(list, "list");
			return list.RemoveRange(items, EqualityComparer<T>.Default);
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x00006654 File Offset: 0x00004854
		public static int IndexOf<T>(this IImmutableList<T> list, T item)
		{
			Requires.NotNull<IImmutableList<T>>(list, "list");
			return list.IndexOf(item, 0, list.Count, EqualityComparer<T>.Default);
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x00006674 File Offset: 0x00004874
		public static int IndexOf<T>(this IImmutableList<T> list, T item, IEqualityComparer<T> equalityComparer)
		{
			Requires.NotNull<IImmutableList<T>>(list, "list");
			return list.IndexOf(item, 0, list.Count, equalityComparer);
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x00006690 File Offset: 0x00004890
		public static int IndexOf<T>(this IImmutableList<T> list, T item, int startIndex)
		{
			Requires.NotNull<IImmutableList<T>>(list, "list");
			return list.IndexOf(item, startIndex, list.Count - startIndex, EqualityComparer<T>.Default);
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x000066B2 File Offset: 0x000048B2
		public static int IndexOf<T>(this IImmutableList<T> list, T item, int startIndex, int count)
		{
			Requires.NotNull<IImmutableList<T>>(list, "list");
			return list.IndexOf(item, startIndex, count, EqualityComparer<T>.Default);
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x000066CD File Offset: 0x000048CD
		public static int LastIndexOf<T>(this IImmutableList<T> list, T item)
		{
			Requires.NotNull<IImmutableList<T>>(list, "list");
			if (list.Count == 0)
			{
				return -1;
			}
			return list.LastIndexOf(item, list.Count - 1, list.Count, EqualityComparer<T>.Default);
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x000066FE File Offset: 0x000048FE
		public static int LastIndexOf<T>(this IImmutableList<T> list, T item, IEqualityComparer<T> equalityComparer)
		{
			Requires.NotNull<IImmutableList<T>>(list, "list");
			if (list.Count == 0)
			{
				return -1;
			}
			return list.LastIndexOf(item, list.Count - 1, list.Count, equalityComparer);
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x0000672B File Offset: 0x0000492B
		public static int LastIndexOf<T>(this IImmutableList<T> list, T item, int startIndex)
		{
			Requires.NotNull<IImmutableList<T>>(list, "list");
			if (list.Count == 0 && startIndex == 0)
			{
				return -1;
			}
			return list.LastIndexOf(item, startIndex, startIndex + 1, EqualityComparer<T>.Default);
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x00006755 File Offset: 0x00004955
		public static int LastIndexOf<T>(this IImmutableList<T> list, T item, int startIndex, int count)
		{
			Requires.NotNull<IImmutableList<T>>(list, "list");
			return list.LastIndexOf(item, startIndex, count, EqualityComparer<T>.Default);
		}
	}
}
