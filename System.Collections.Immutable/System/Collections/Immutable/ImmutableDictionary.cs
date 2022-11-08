using System;
using System.Collections.Generic;
using System.Linq;

namespace System.Collections.Immutable
{
	// Token: 0x0200001C RID: 28
	public static class ImmutableDictionary
	{
		// Token: 0x0600011E RID: 286 RVA: 0x00004405 File Offset: 0x00002605
		public static ImmutableDictionary<TKey, TValue> Create<TKey, TValue>()
		{
			return ImmutableDictionary<TKey, TValue>.Empty;
		}

		// Token: 0x0600011F RID: 287 RVA: 0x0000440C File Offset: 0x0000260C
		public static ImmutableDictionary<TKey, TValue> Create<TKey, TValue>(IEqualityComparer<TKey> keyComparer)
		{
			return ImmutableDictionary<TKey, TValue>.Empty.WithComparers(keyComparer);
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00004419 File Offset: 0x00002619
		public static ImmutableDictionary<TKey, TValue> Create<TKey, TValue>(IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
		{
			return ImmutableDictionary<TKey, TValue>.Empty.WithComparers(keyComparer, valueComparer);
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00004427 File Offset: 0x00002627
		public static ImmutableDictionary<TKey, TValue> CreateRange<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> items)
		{
			return ImmutableDictionary<TKey, TValue>.Empty.AddRange(items);
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00004434 File Offset: 0x00002634
		public static ImmutableDictionary<TKey, TValue> CreateRange<TKey, TValue>(IEqualityComparer<TKey> keyComparer, IEnumerable<KeyValuePair<TKey, TValue>> items)
		{
			return ImmutableDictionary<TKey, TValue>.Empty.WithComparers(keyComparer).AddRange(items);
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00004447 File Offset: 0x00002647
		public static ImmutableDictionary<TKey, TValue> CreateRange<TKey, TValue>(IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, IEnumerable<KeyValuePair<TKey, TValue>> items)
		{
			return ImmutableDictionary<TKey, TValue>.Empty.WithComparers(keyComparer, valueComparer).AddRange(items);
		}

		// Token: 0x06000124 RID: 292 RVA: 0x0000445B File Offset: 0x0000265B
		public static ImmutableDictionary<TKey, TValue>.Builder CreateBuilder<TKey, TValue>()
		{
			return ImmutableDictionary.Create<TKey, TValue>().ToBuilder();
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00004467 File Offset: 0x00002667
		public static ImmutableDictionary<TKey, TValue>.Builder CreateBuilder<TKey, TValue>(IEqualityComparer<TKey> keyComparer)
		{
			return ImmutableDictionary.Create<TKey, TValue>(keyComparer).ToBuilder();
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00004474 File Offset: 0x00002674
		public static ImmutableDictionary<TKey, TValue>.Builder CreateBuilder<TKey, TValue>(IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
		{
			return ImmutableDictionary.Create<TKey, TValue>(keyComparer, valueComparer).ToBuilder();
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00004484 File Offset: 0x00002684
		public static ImmutableDictionary<TKey, TValue> ToImmutableDictionary<TSource, TKey, TValue>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TValue> elementSelector, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
		{
			Requires.NotNull<IEnumerable<TSource>>(source, "source");
			Requires.NotNull<Func<TSource, TKey>>(keySelector, "keySelector");
			Requires.NotNull<Func<TSource, TValue>>(elementSelector, "elementSelector");
			return ImmutableDictionary<TKey, TValue>.Empty.WithComparers(keyComparer, valueComparer).AddRange(from element in source
			select new KeyValuePair<TKey, TValue>(keySelector(element), elementSelector(element)));
		}

		// Token: 0x06000128 RID: 296 RVA: 0x000044F4 File Offset: 0x000026F4
		public static ImmutableDictionary<TKey, TValue> ToImmutableDictionary<TSource, TKey, TValue>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TValue> elementSelector, IEqualityComparer<TKey> keyComparer)
		{
			return source.ToImmutableDictionary(keySelector, elementSelector, keyComparer, null);
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00004500 File Offset: 0x00002700
		public static ImmutableDictionary<TKey, TSource> ToImmutableDictionary<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			return source.ToImmutableDictionary(keySelector, (TSource v) => v, null, null);
		}

		// Token: 0x0600012A RID: 298 RVA: 0x0000452A File Offset: 0x0000272A
		public static ImmutableDictionary<TKey, TSource> ToImmutableDictionary<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> keyComparer)
		{
			return source.ToImmutableDictionary(keySelector, (TSource v) => v, keyComparer, null);
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00004554 File Offset: 0x00002754
		public static ImmutableDictionary<TKey, TValue> ToImmutableDictionary<TSource, TKey, TValue>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TValue> elementSelector)
		{
			return source.ToImmutableDictionary(keySelector, elementSelector, null, null);
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00004560 File Offset: 0x00002760
		public static ImmutableDictionary<TKey, TValue> ToImmutableDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
		{
			Requires.NotNull<IEnumerable<KeyValuePair<TKey, TValue>>>(source, "source");
			ImmutableDictionary<TKey, TValue> immutableDictionary = source as ImmutableDictionary<TKey, TValue>;
			if (immutableDictionary != null)
			{
				return immutableDictionary.WithComparers(keyComparer, valueComparer);
			}
			return ImmutableDictionary<TKey, TValue>.Empty.WithComparers(keyComparer, valueComparer).AddRange(source);
		}

		// Token: 0x0600012D RID: 301 RVA: 0x0000459D File Offset: 0x0000279D
		public static ImmutableDictionary<TKey, TValue> ToImmutableDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source, IEqualityComparer<TKey> keyComparer)
		{
			return source.ToImmutableDictionary(keyComparer, null);
		}

		// Token: 0x0600012E RID: 302 RVA: 0x000045A7 File Offset: 0x000027A7
		public static ImmutableDictionary<TKey, TValue> ToImmutableDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source)
		{
			return source.ToImmutableDictionary(null, null);
		}

		// Token: 0x0600012F RID: 303 RVA: 0x000045B1 File Offset: 0x000027B1
		public static bool Contains<TKey, TValue>(this IImmutableDictionary<TKey, TValue> map, TKey key, TValue value)
		{
			Requires.NotNull<IImmutableDictionary<TKey, TValue>>(map, "map");
			Requires.NotNullAllowStructs<TKey>(key, "key");
			return map.Contains(new KeyValuePair<TKey, TValue>(key, value));
		}

		// Token: 0x06000130 RID: 304 RVA: 0x000045D8 File Offset: 0x000027D8
		public static TValue GetValueOrDefault<TKey, TValue>(this IImmutableDictionary<TKey, TValue> dictionary, TKey key)
		{
			return dictionary.GetValueOrDefault(key, default(TValue));
		}

		// Token: 0x06000131 RID: 305 RVA: 0x000045F8 File Offset: 0x000027F8
		public static TValue GetValueOrDefault<TKey, TValue>(this IImmutableDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
		{
			Requires.NotNull<IImmutableDictionary<TKey, TValue>>(dictionary, "dictionary");
			Requires.NotNullAllowStructs<TKey>(key, "key");
			TValue result;
			if (dictionary.TryGetValue(key, out result))
			{
				return result;
			}
			return defaultValue;
		}
	}
}
