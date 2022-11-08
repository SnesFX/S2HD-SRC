using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace System.Linq
{
	// Token: 0x02000007 RID: 7
	public static class ImmutableArrayExtensions
	{
		// Token: 0x06000015 RID: 21 RVA: 0x0000221A File Offset: 0x0000041A
		public static IEnumerable<TResult> Select<T, TResult>(this ImmutableArray<T> immutableArray, Func<T, TResult> selector)
		{
			immutableArray.ThrowNullRefIfNotInitialized();
			return immutableArray.array.Select(selector);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x0000222F File Offset: 0x0000042F
		public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this ImmutableArray<TSource> immutableArray, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
		{
			immutableArray.ThrowNullRefIfNotInitialized();
			if (collectionSelector == null || resultSelector == null)
			{
				return immutableArray.SelectMany(collectionSelector, resultSelector);
			}
			if (immutableArray.Length != 0)
			{
				return immutableArray.SelectManyIterator(collectionSelector, resultSelector);
			}
			return Enumerable.Empty<TResult>();
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002263 File Offset: 0x00000463
		public static IEnumerable<T> Where<T>(this ImmutableArray<T> immutableArray, Func<T, bool> predicate)
		{
			immutableArray.ThrowNullRefIfNotInitialized();
			return immutableArray.array.Where(predicate);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002278 File Offset: 0x00000478
		public static bool Any<T>(this ImmutableArray<T> immutableArray)
		{
			return immutableArray.Length > 0;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002284 File Offset: 0x00000484
		public static bool Any<T>(this ImmutableArray<T> immutableArray, Func<T, bool> predicate)
		{
			immutableArray.ThrowNullRefIfNotInitialized();
			Requires.NotNull<Func<T, bool>>(predicate, "predicate");
			foreach (T arg in immutableArray.array)
			{
				if (predicate(arg))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000022CC File Offset: 0x000004CC
		public static bool All<T>(this ImmutableArray<T> immutableArray, Func<T, bool> predicate)
		{
			immutableArray.ThrowNullRefIfNotInitialized();
			Requires.NotNull<Func<T, bool>>(predicate, "predicate");
			foreach (T arg in immutableArray.array)
			{
				if (!predicate(arg))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002314 File Offset: 0x00000514
		public static bool SequenceEqual<TDerived, TBase>(this ImmutableArray<TBase> immutableArray, ImmutableArray<TDerived> items, IEqualityComparer<TBase> comparer = null) where TDerived : TBase
		{
			immutableArray.ThrowNullRefIfNotInitialized();
			items.ThrowNullRefIfNotInitialized();
			if (immutableArray.array == items.array)
			{
				return true;
			}
			if (immutableArray.Length != items.Length)
			{
				return false;
			}
			if (comparer == null)
			{
				comparer = EqualityComparer<TBase>.Default;
			}
			for (int i = 0; i < immutableArray.Length; i++)
			{
				if (!comparer.Equals(immutableArray.array[i], (TBase)((object)items.array[i])))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000239C File Offset: 0x0000059C
		public static bool SequenceEqual<TDerived, TBase>(this ImmutableArray<TBase> immutableArray, IEnumerable<TDerived> items, IEqualityComparer<TBase> comparer = null) where TDerived : TBase
		{
			Requires.NotNull<IEnumerable<TDerived>>(items, "items");
			if (comparer == null)
			{
				comparer = EqualityComparer<TBase>.Default;
			}
			int num = 0;
			int length = immutableArray.Length;
			foreach (TDerived tderived in items)
			{
				if (num == length)
				{
					return false;
				}
				if (!comparer.Equals(immutableArray[num], (TBase)((object)tderived)))
				{
					return false;
				}
				num++;
			}
			return num == length;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002430 File Offset: 0x00000630
		public static bool SequenceEqual<TDerived, TBase>(this ImmutableArray<TBase> immutableArray, ImmutableArray<TDerived> items, Func<TBase, TBase, bool> predicate) where TDerived : TBase
		{
			Requires.NotNull<Func<TBase, TBase, bool>>(predicate, "predicate");
			immutableArray.ThrowNullRefIfNotInitialized();
			items.ThrowNullRefIfNotInitialized();
			if (immutableArray.array == items.array)
			{
				return true;
			}
			if (immutableArray.Length != items.Length)
			{
				return false;
			}
			int i = 0;
			int length = immutableArray.Length;
			while (i < length)
			{
				if (!predicate(immutableArray[i], (TBase)((object)items[i])))
				{
					return false;
				}
				i++;
			}
			return true;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000024B4 File Offset: 0x000006B4
		public static T Aggregate<T>(this ImmutableArray<T> immutableArray, Func<T, T, T> func)
		{
			Requires.NotNull<Func<T, T, T>>(func, "func");
			if (immutableArray.Length == 0)
			{
				return default(T);
			}
			T t = immutableArray[0];
			int i = 1;
			int length = immutableArray.Length;
			while (i < length)
			{
				t = func(t, immutableArray[i]);
				i++;
			}
			return t;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002510 File Offset: 0x00000710
		public static TAccumulate Aggregate<TAccumulate, T>(this ImmutableArray<T> immutableArray, TAccumulate seed, Func<TAccumulate, T, TAccumulate> func)
		{
			Requires.NotNull<Func<TAccumulate, T, TAccumulate>>(func, "func");
			TAccumulate taccumulate = seed;
			foreach (T arg in immutableArray.array)
			{
				taccumulate = func(taccumulate, arg);
			}
			return taccumulate;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002551 File Offset: 0x00000751
		public static TResult Aggregate<TAccumulate, TResult, T>(this ImmutableArray<T> immutableArray, TAccumulate seed, Func<TAccumulate, T, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
		{
			Requires.NotNull<Func<TAccumulate, TResult>>(resultSelector, "resultSelector");
			return resultSelector(immutableArray.Aggregate(seed, func));
		}

		// Token: 0x06000021 RID: 33 RVA: 0x0000256C File Offset: 0x0000076C
		public static T ElementAt<T>(this ImmutableArray<T> immutableArray, int index)
		{
			return immutableArray[index];
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002578 File Offset: 0x00000778
		public static T ElementAtOrDefault<T>(this ImmutableArray<T> immutableArray, int index)
		{
			if (index < 0 || index >= immutableArray.Length)
			{
				return default(T);
			}
			return immutableArray[index];
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000025A8 File Offset: 0x000007A8
		public static T First<T>(this ImmutableArray<T> immutableArray, Func<T, bool> predicate)
		{
			Requires.NotNull<Func<T, bool>>(predicate, "predicate");
			foreach (T t in immutableArray.array)
			{
				if (predicate(t))
				{
					return t;
				}
			}
			return Enumerable.Empty<T>().First<T>();
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000025F2 File Offset: 0x000007F2
		public static T First<T>(this ImmutableArray<T> immutableArray)
		{
			if (immutableArray.Length <= 0)
			{
				return immutableArray.array.First<T>();
			}
			return immutableArray[0];
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002614 File Offset: 0x00000814
		public static T FirstOrDefault<T>(this ImmutableArray<T> immutableArray)
		{
			if (immutableArray.array.Length == 0)
			{
				return default(T);
			}
			return immutableArray.array[0];
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002640 File Offset: 0x00000840
		public static T FirstOrDefault<T>(this ImmutableArray<T> immutableArray, Func<T, bool> predicate)
		{
			Requires.NotNull<Func<T, bool>>(predicate, "predicate");
			foreach (T t in immutableArray.array)
			{
				if (predicate(t))
				{
					return t;
				}
			}
			return default(T);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002689 File Offset: 0x00000889
		public static T Last<T>(this ImmutableArray<T> immutableArray)
		{
			if (immutableArray.Length <= 0)
			{
				return immutableArray.array.Last<T>();
			}
			return immutableArray[immutableArray.Length - 1];
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000026B4 File Offset: 0x000008B4
		public static T Last<T>(this ImmutableArray<T> immutableArray, Func<T, bool> predicate)
		{
			Requires.NotNull<Func<T, bool>>(predicate, "predicate");
			for (int i = immutableArray.Length - 1; i >= 0; i--)
			{
				if (predicate(immutableArray[i]))
				{
					return immutableArray[i];
				}
			}
			return Enumerable.Empty<T>().Last<T>();
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002703 File Offset: 0x00000903
		public static T LastOrDefault<T>(this ImmutableArray<T> immutableArray)
		{
			immutableArray.ThrowNullRefIfNotInitialized();
			return immutableArray.array.LastOrDefault<T>();
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002718 File Offset: 0x00000918
		public static T LastOrDefault<T>(this ImmutableArray<T> immutableArray, Func<T, bool> predicate)
		{
			Requires.NotNull<Func<T, bool>>(predicate, "predicate");
			for (int i = immutableArray.Length - 1; i >= 0; i--)
			{
				if (predicate(immutableArray[i]))
				{
					return immutableArray[i];
				}
			}
			return default(T);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002766 File Offset: 0x00000966
		public static T Single<T>(this ImmutableArray<T> immutableArray)
		{
			immutableArray.ThrowNullRefIfNotInitialized();
			return immutableArray.array.Single<T>();
		}

		// Token: 0x0600002C RID: 44 RVA: 0x0000277C File Offset: 0x0000097C
		public static T Single<T>(this ImmutableArray<T> immutableArray, Func<T, bool> predicate)
		{
			Requires.NotNull<Func<T, bool>>(predicate, "predicate");
			bool flag = true;
			T result = default(T);
			foreach (T t in immutableArray.array)
			{
				if (predicate(t))
				{
					if (!flag)
					{
						ImmutableArray.TwoElementArray.Single<byte>();
					}
					flag = false;
					result = t;
				}
			}
			if (flag)
			{
				Enumerable.Empty<T>().Single<T>();
			}
			return result;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000027E8 File Offset: 0x000009E8
		public static T SingleOrDefault<T>(this ImmutableArray<T> immutableArray)
		{
			immutableArray.ThrowNullRefIfNotInitialized();
			return immutableArray.array.SingleOrDefault<T>();
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000027FC File Offset: 0x000009FC
		public static T SingleOrDefault<T>(this ImmutableArray<T> immutableArray, Func<T, bool> predicate)
		{
			Requires.NotNull<Func<T, bool>>(predicate, "predicate");
			bool flag = true;
			T result = default(T);
			foreach (T t in immutableArray.array)
			{
				if (predicate(t))
				{
					if (!flag)
					{
						ImmutableArray.TwoElementArray.Single<byte>();
					}
					flag = false;
					result = t;
				}
			}
			return result;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x0000285A File Offset: 0x00000A5A
		public static Dictionary<TKey, T> ToDictionary<TKey, T>(this ImmutableArray<T> immutableArray, Func<T, TKey> keySelector)
		{
			return immutableArray.ToDictionary(keySelector, EqualityComparer<TKey>.Default);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002868 File Offset: 0x00000A68
		public static Dictionary<TKey, TElement> ToDictionary<TKey, TElement, T>(this ImmutableArray<T> immutableArray, Func<T, TKey> keySelector, Func<T, TElement> elementSelector)
		{
			return immutableArray.ToDictionary(keySelector, elementSelector, EqualityComparer<TKey>.Default);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002878 File Offset: 0x00000A78
		public static Dictionary<TKey, T> ToDictionary<TKey, T>(this ImmutableArray<T> immutableArray, Func<T, TKey> keySelector, IEqualityComparer<TKey> comparer)
		{
			Requires.NotNull<Func<T, TKey>>(keySelector, "keySelector");
			Dictionary<TKey, T> dictionary = new Dictionary<TKey, T>(comparer);
			foreach (T t in immutableArray)
			{
				dictionary.Add(keySelector(t), t);
			}
			return dictionary;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000028C4 File Offset: 0x00000AC4
		public static Dictionary<TKey, TElement> ToDictionary<TKey, TElement, T>(this ImmutableArray<T> immutableArray, Func<T, TKey> keySelector, Func<T, TElement> elementSelector, IEqualityComparer<TKey> comparer)
		{
			Requires.NotNull<Func<T, TKey>>(keySelector, "keySelector");
			Requires.NotNull<Func<T, TElement>>(elementSelector, "elementSelector");
			Dictionary<TKey, TElement> dictionary = new Dictionary<TKey, TElement>(immutableArray.Length, comparer);
			foreach (T arg in immutableArray.array)
			{
				dictionary.Add(keySelector(arg), elementSelector(arg));
			}
			return dictionary;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002927 File Offset: 0x00000B27
		public static T[] ToArray<T>(this ImmutableArray<T> immutableArray)
		{
			immutableArray.ThrowNullRefIfNotInitialized();
			if (immutableArray.array.Length == 0)
			{
				return ImmutableArray<T>.Empty.array;
			}
			return (T[])immutableArray.array.Clone();
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002954 File Offset: 0x00000B54
		public static T First<T>(this ImmutableArray<T>.Builder builder)
		{
			Requires.NotNull<ImmutableArray<T>.Builder>(builder, "builder");
			if (!builder.Any<T>())
			{
				throw new InvalidOperationException();
			}
			return builder[0];
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002978 File Offset: 0x00000B78
		public static T FirstOrDefault<T>(this ImmutableArray<T>.Builder builder)
		{
			Requires.NotNull<ImmutableArray<T>.Builder>(builder, "builder");
			if (!builder.Any<T>())
			{
				return default(T);
			}
			return builder[0];
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000029A9 File Offset: 0x00000BA9
		public static T Last<T>(this ImmutableArray<T>.Builder builder)
		{
			Requires.NotNull<ImmutableArray<T>.Builder>(builder, "builder");
			if (!builder.Any<T>())
			{
				throw new InvalidOperationException();
			}
			return builder[builder.Count - 1];
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000029D4 File Offset: 0x00000BD4
		public static T LastOrDefault<T>(this ImmutableArray<T>.Builder builder)
		{
			Requires.NotNull<ImmutableArray<T>.Builder>(builder, "builder");
			if (!builder.Any<T>())
			{
				return default(T);
			}
			return builder[builder.Count - 1];
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002A0C File Offset: 0x00000C0C
		public static bool Any<T>(this ImmutableArray<T>.Builder builder)
		{
			Requires.NotNull<ImmutableArray<T>.Builder>(builder, "builder");
			return builder.Count > 0;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002A22 File Offset: 0x00000C22
		private static IEnumerable<TResult> SelectManyIterator<TSource, TCollection, TResult>(this ImmutableArray<TSource> immutableArray, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
		{
			foreach (TSource item in immutableArray.array)
			{
				foreach (TCollection arg in collectionSelector(item))
				{
					yield return resultSelector(item, arg);
				}
				IEnumerator<TCollection> enumerator = null;
				item = default(TSource);
			}
			TSource[] array = null;
			yield break;
			yield break;
		}
	}
}
