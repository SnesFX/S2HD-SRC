using System;
using System.Collections.Generic;

namespace System.Collections.Immutable
{
	// Token: 0x02000022 RID: 34
	public static class ImmutableHashSet
	{
		// Token: 0x0600018A RID: 394 RVA: 0x00005318 File Offset: 0x00003518
		public static ImmutableHashSet<T> Create<T>()
		{
			return ImmutableHashSet<T>.Empty;
		}

		// Token: 0x0600018B RID: 395 RVA: 0x0000531F File Offset: 0x0000351F
		public static ImmutableHashSet<T> Create<T>(IEqualityComparer<T> equalityComparer)
		{
			return ImmutableHashSet<T>.Empty.WithComparer(equalityComparer);
		}

		// Token: 0x0600018C RID: 396 RVA: 0x0000532C File Offset: 0x0000352C
		public static ImmutableHashSet<T> Create<T>(T item)
		{
			return ImmutableHashSet<T>.Empty.Add(item);
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00005339 File Offset: 0x00003539
		public static ImmutableHashSet<T> Create<T>(IEqualityComparer<T> equalityComparer, T item)
		{
			return ImmutableHashSet<T>.Empty.WithComparer(equalityComparer).Add(item);
		}

		// Token: 0x0600018E RID: 398 RVA: 0x0000534C File Offset: 0x0000354C
		public static ImmutableHashSet<T> CreateRange<T>(IEnumerable<T> items)
		{
			return ImmutableHashSet<T>.Empty.Union(items);
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00005359 File Offset: 0x00003559
		public static ImmutableHashSet<T> CreateRange<T>(IEqualityComparer<T> equalityComparer, IEnumerable<T> items)
		{
			return ImmutableHashSet<T>.Empty.WithComparer(equalityComparer).Union(items);
		}

		// Token: 0x06000190 RID: 400 RVA: 0x0000536C File Offset: 0x0000356C
		public static ImmutableHashSet<T> Create<T>(params T[] items)
		{
			return ImmutableHashSet<T>.Empty.Union(items);
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00005379 File Offset: 0x00003579
		public static ImmutableHashSet<T> Create<T>(IEqualityComparer<T> equalityComparer, params T[] items)
		{
			return ImmutableHashSet<T>.Empty.WithComparer(equalityComparer).Union(items);
		}

		// Token: 0x06000192 RID: 402 RVA: 0x0000538C File Offset: 0x0000358C
		public static ImmutableHashSet<T>.Builder CreateBuilder<T>()
		{
			return ImmutableHashSet.Create<T>().ToBuilder();
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00005398 File Offset: 0x00003598
		public static ImmutableHashSet<T>.Builder CreateBuilder<T>(IEqualityComparer<T> equalityComparer)
		{
			return ImmutableHashSet.Create<T>(equalityComparer).ToBuilder();
		}

		// Token: 0x06000194 RID: 404 RVA: 0x000053A8 File Offset: 0x000035A8
		public static ImmutableHashSet<TSource> ToImmutableHashSet<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> equalityComparer)
		{
			ImmutableHashSet<TSource> immutableHashSet = source as ImmutableHashSet<TSource>;
			if (immutableHashSet != null)
			{
				return immutableHashSet.WithComparer(equalityComparer);
			}
			return ImmutableHashSet<TSource>.Empty.WithComparer(equalityComparer).Union(source);
		}

		// Token: 0x06000195 RID: 405 RVA: 0x000053D8 File Offset: 0x000035D8
		public static ImmutableHashSet<TSource> ToImmutableHashSet<TSource>(this IEnumerable<TSource> source)
		{
			return source.ToImmutableHashSet(null);
		}
	}
}
