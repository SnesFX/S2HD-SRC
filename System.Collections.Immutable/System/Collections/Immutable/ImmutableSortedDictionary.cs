using System;
using System.Collections.Generic;
using System.Linq;

namespace System.Collections.Immutable
{
	// Token: 0x0200002B RID: 43
	public static class ImmutableSortedDictionary
	{
		// Token: 0x06000272 RID: 626 RVA: 0x00007446 File Offset: 0x00005646
		public static ImmutableSortedDictionary<TKey, TValue> Create<TKey, TValue>()
		{
			return ImmutableSortedDictionary<TKey, TValue>.Empty;
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0000744D File Offset: 0x0000564D
		public static ImmutableSortedDictionary<TKey, TValue> Create<TKey, TValue>(IComparer<TKey> keyComparer)
		{
			return ImmutableSortedDictionary<TKey, TValue>.Empty.WithComparers(keyComparer);
		}

		// Token: 0x06000274 RID: 628 RVA: 0x0000745A File Offset: 0x0000565A
		public static ImmutableSortedDictionary<TKey, TValue> Create<TKey, TValue>(IComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
		{
			return ImmutableSortedDictionary<TKey, TValue>.Empty.WithComparers(keyComparer, valueComparer);
		}

		// Token: 0x06000275 RID: 629 RVA: 0x00007468 File Offset: 0x00005668
		public static ImmutableSortedDictionary<TKey, TValue> CreateRange<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> items)
		{
			return ImmutableSortedDictionary<TKey, TValue>.Empty.AddRange(items);
		}

		// Token: 0x06000276 RID: 630 RVA: 0x00007475 File Offset: 0x00005675
		public static ImmutableSortedDictionary<TKey, TValue> CreateRange<TKey, TValue>(IComparer<TKey> keyComparer, IEnumerable<KeyValuePair<TKey, TValue>> items)
		{
			return ImmutableSortedDictionary<TKey, TValue>.Empty.WithComparers(keyComparer).AddRange(items);
		}

		// Token: 0x06000277 RID: 631 RVA: 0x00007488 File Offset: 0x00005688
		public static ImmutableSortedDictionary<TKey, TValue> CreateRange<TKey, TValue>(IComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, IEnumerable<KeyValuePair<TKey, TValue>> items)
		{
			return ImmutableSortedDictionary<TKey, TValue>.Empty.WithComparers(keyComparer, valueComparer).AddRange(items);
		}

		// Token: 0x06000278 RID: 632 RVA: 0x0000749C File Offset: 0x0000569C
		public static ImmutableSortedDictionary<TKey, TValue>.Builder CreateBuilder<TKey, TValue>()
		{
			return ImmutableSortedDictionary.Create<TKey, TValue>().ToBuilder();
		}

		// Token: 0x06000279 RID: 633 RVA: 0x000074A8 File Offset: 0x000056A8
		public static ImmutableSortedDictionary<TKey, TValue>.Builder CreateBuilder<TKey, TValue>(IComparer<TKey> keyComparer)
		{
			return ImmutableSortedDictionary.Create<TKey, TValue>(keyComparer).ToBuilder();
		}

		// Token: 0x0600027A RID: 634 RVA: 0x000074B5 File Offset: 0x000056B5
		public static ImmutableSortedDictionary<TKey, TValue>.Builder CreateBuilder<TKey, TValue>(IComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
		{
			return ImmutableSortedDictionary.Create<TKey, TValue>(keyComparer, valueComparer).ToBuilder();
		}

		// Token: 0x0600027B RID: 635 RVA: 0x000074C4 File Offset: 0x000056C4
		public static ImmutableSortedDictionary<TKey, TValue> ToImmutableSortedDictionary<TSource, TKey, TValue>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TValue> elementSelector, IComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
		{
			Requires.NotNull<IEnumerable<TSource>>(source, "source");
			Requires.NotNull<Func<TSource, TKey>>(keySelector, "keySelector");
			Requires.NotNull<Func<TSource, TValue>>(elementSelector, "elementSelector");
			return ImmutableSortedDictionary<TKey, TValue>.Empty.WithComparers(keyComparer, valueComparer).AddRange(from element in source
			select new KeyValuePair<TKey, TValue>(keySelector(element), elementSelector(element)));
		}

		// Token: 0x0600027C RID: 636 RVA: 0x00007534 File Offset: 0x00005734
		public static ImmutableSortedDictionary<TKey, TValue> ToImmutableSortedDictionary<TSource, TKey, TValue>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TValue> elementSelector, IComparer<TKey> keyComparer)
		{
			return source.ToImmutableSortedDictionary(keySelector, elementSelector, keyComparer, null);
		}

		// Token: 0x0600027D RID: 637 RVA: 0x00007540 File Offset: 0x00005740
		public static ImmutableSortedDictionary<TKey, TValue> ToImmutableSortedDictionary<TSource, TKey, TValue>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TValue> elementSelector)
		{
			return source.ToImmutableSortedDictionary(keySelector, elementSelector, null, null);
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0000754C File Offset: 0x0000574C
		public static ImmutableSortedDictionary<TKey, TValue> ToImmutableSortedDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source, IComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
		{
			Requires.NotNull<IEnumerable<KeyValuePair<TKey, TValue>>>(source, "source");
			ImmutableSortedDictionary<TKey, TValue> immutableSortedDictionary = source as ImmutableSortedDictionary<TKey, TValue>;
			if (immutableSortedDictionary != null)
			{
				return immutableSortedDictionary.WithComparers(keyComparer, valueComparer);
			}
			return ImmutableSortedDictionary<TKey, TValue>.Empty.WithComparers(keyComparer, valueComparer).AddRange(source);
		}

		// Token: 0x0600027F RID: 639 RVA: 0x00007589 File Offset: 0x00005789
		public static ImmutableSortedDictionary<TKey, TValue> ToImmutableSortedDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source, IComparer<TKey> keyComparer)
		{
			return source.ToImmutableSortedDictionary(keyComparer, null);
		}

		// Token: 0x06000280 RID: 640 RVA: 0x00007593 File Offset: 0x00005793
		public static ImmutableSortedDictionary<TKey, TValue> ToImmutableSortedDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source)
		{
			return source.ToImmutableSortedDictionary(null, null);
		}
	}
}
