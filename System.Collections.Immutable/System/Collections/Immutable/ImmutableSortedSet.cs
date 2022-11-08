using System;
using System.Collections.Generic;

namespace System.Collections.Immutable
{
	// Token: 0x0200002E RID: 46
	public static class ImmutableSortedSet
	{
		// Token: 0x060002C5 RID: 709 RVA: 0x00007D94 File Offset: 0x00005F94
		public static ImmutableSortedSet<T> Create<T>()
		{
			return ImmutableSortedSet<T>.Empty;
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x00007D9B File Offset: 0x00005F9B
		public static ImmutableSortedSet<T> Create<T>(IComparer<T> comparer)
		{
			return ImmutableSortedSet<T>.Empty.WithComparer(comparer);
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x00007DA8 File Offset: 0x00005FA8
		public static ImmutableSortedSet<T> Create<T>(T item)
		{
			return ImmutableSortedSet<T>.Empty.Add(item);
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x00007DB5 File Offset: 0x00005FB5
		public static ImmutableSortedSet<T> Create<T>(IComparer<T> comparer, T item)
		{
			return ImmutableSortedSet<T>.Empty.WithComparer(comparer).Add(item);
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x00007DC8 File Offset: 0x00005FC8
		public static ImmutableSortedSet<T> CreateRange<T>(IEnumerable<T> items)
		{
			return ImmutableSortedSet<T>.Empty.Union(items);
		}

		// Token: 0x060002CA RID: 714 RVA: 0x00007DD5 File Offset: 0x00005FD5
		public static ImmutableSortedSet<T> CreateRange<T>(IComparer<T> comparer, IEnumerable<T> items)
		{
			return ImmutableSortedSet<T>.Empty.WithComparer(comparer).Union(items);
		}

		// Token: 0x060002CB RID: 715 RVA: 0x00007DE8 File Offset: 0x00005FE8
		public static ImmutableSortedSet<T> Create<T>(params T[] items)
		{
			return ImmutableSortedSet<T>.Empty.Union(items);
		}

		// Token: 0x060002CC RID: 716 RVA: 0x00007DF5 File Offset: 0x00005FF5
		public static ImmutableSortedSet<T> Create<T>(IComparer<T> comparer, params T[] items)
		{
			return ImmutableSortedSet<T>.Empty.WithComparer(comparer).Union(items);
		}

		// Token: 0x060002CD RID: 717 RVA: 0x00007E08 File Offset: 0x00006008
		public static ImmutableSortedSet<T>.Builder CreateBuilder<T>()
		{
			return ImmutableSortedSet.Create<T>().ToBuilder();
		}

		// Token: 0x060002CE RID: 718 RVA: 0x00007E14 File Offset: 0x00006014
		public static ImmutableSortedSet<T>.Builder CreateBuilder<T>(IComparer<T> comparer)
		{
			return ImmutableSortedSet.Create<T>(comparer).ToBuilder();
		}

		// Token: 0x060002CF RID: 719 RVA: 0x00007E24 File Offset: 0x00006024
		public static ImmutableSortedSet<TSource> ToImmutableSortedSet<TSource>(this IEnumerable<TSource> source, IComparer<TSource> comparer)
		{
			ImmutableSortedSet<TSource> immutableSortedSet = source as ImmutableSortedSet<TSource>;
			if (immutableSortedSet != null)
			{
				return immutableSortedSet.WithComparer(comparer);
			}
			return ImmutableSortedSet<TSource>.Empty.WithComparer(comparer).Union(source);
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x00007E54 File Offset: 0x00006054
		public static ImmutableSortedSet<TSource> ToImmutableSortedSet<TSource>(this IEnumerable<TSource> source)
		{
			return source.ToImmutableSortedSet(null);
		}
	}
}
