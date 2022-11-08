using System;
using System.Collections.Generic;
using System.Linq;

namespace SonicOrca.Extensions
{
	// Token: 0x0200000B RID: 11
	public static class LinqExtensions
	{
		// Token: 0x06000015 RID: 21 RVA: 0x00002308 File Offset: 0x00000508
		public static T[] AsArray<T>(this IEnumerable<T> items)
		{
			T[] array = items as T[];
			if (array == null)
			{
				array = items.ToArray<T>();
			}
			return array;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002328 File Offset: 0x00000528
		public static int GetCollectionHashCode<T>(this IEnumerable<T> e)
		{
			IEnumerator<T> enumerator = e.GetEnumerator();
			int num = 27;
			if (enumerator.MoveNext())
			{
				int num2 = num;
				int num3;
				if (enumerator.Current != null)
				{
					T t = enumerator.Current;
					num3 = t.GetHashCode();
				}
				else
				{
					num3 = -1.GetHashCode();
				}
				num = num2 * num3;
			}
			while (enumerator.MoveNext())
			{
				int num4 = 13 * num;
				int num5;
				if (enumerator.Current != null)
				{
					T t = enumerator.Current;
					num5 = t.GetHashCode();
				}
				else
				{
					num5 = -1.GetHashCode();
				}
				num = num4 + num5;
			}
			return num;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000023B5 File Offset: 0x000005B5
		public static int GetCollectionHashCode(params object[] items)
		{
			return items.GetCollectionHashCode<object>();
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000023C0 File Offset: 0x000005C0
		public static bool HasSameElementsAs<T>(this IEnumerable<T> first, IEnumerable<T> second)
		{
			Dictionary<T, int> firstMap = (from x in first
			group x by x).ToDictionary((IGrouping<T, T> x) => x.Key, (IGrouping<T, T> x) => x.Count<T>());
			Dictionary<T, int> secondMap = (from x in second
			group x by x).ToDictionary((IGrouping<T, T> x) => x.Key, (IGrouping<T, T> x) => x.Count<T>());
			return firstMap.Keys.All((T x) => secondMap.Keys.Contains(x) && firstMap[x] == secondMap[x]) && secondMap.Keys.All((T x) => firstMap.Keys.Contains(x) && secondMap[x] == firstMap[x]);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000024EC File Offset: 0x000006EC
		public static string CommaAndConcatenation<T>(this IEnumerable<T> strings)
		{
			T[] array = strings.ToArray<T>();
			if (array.Length == 0)
			{
				return string.Empty;
			}
			if (array.Length == 1)
			{
				return array[0].ToString();
			}
			if (array.Length == 2)
			{
				return string.Format("{0} and {1}", array[0], array[1]);
			}
			return string.Format("{0} and {1}", string.Join<T>(", ", array.Take(array.Length - 1)), array.Last<T>());
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002578 File Offset: 0x00000778
		public static IEnumerable<T> TakeAllButLast<T>(this IEnumerable<T> source)
		{
			IEnumerator<T> it = source.GetEnumerator();
			bool hasRemainingItems = false;
			bool flag = true;
			T t = default(T);
			do
			{
				hasRemainingItems = it.MoveNext();
				if (hasRemainingItems)
				{
					if (!flag)
					{
						yield return t;
					}
					t = it.Current;
					flag = false;
				}
			}
			while (hasRemainingItems);
			yield break;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002588 File Offset: 0x00000788
		public static IEnumerable<T> Intersperse<T>(this IEnumerable<T> source, T separator)
		{
			bool flag = true;
			foreach (T value in source)
			{
				if (!flag)
				{
					yield return separator;
				}
				yield return value;
				flag = false;
				value = default(T);
			}
			IEnumerator<T> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000259F File Offset: 0x0000079F
		public static IEnumerable<IEnumerable<T>> SplitWhen<T>(this IEnumerable<T> source, Func<T, bool> shouldSplit)
		{
			List<T> currentGroup = new List<T>();
			foreach (T item in source)
			{
				if (shouldSplit(item) && currentGroup.Count > 0)
				{
					yield return currentGroup.ToArray();
					currentGroup.Clear();
				}
				currentGroup.Add(item);
				item = default(T);
			}
			IEnumerator<T> enumerator = null;
			if (currentGroup.Count > 0)
			{
				yield return currentGroup.ToArray();
			}
			yield break;
			yield break;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000025B8 File Offset: 0x000007B8
		public static bool Contains(this IEnumerable<string> items, string query, bool ignoreCase = false)
		{
			return items.Any((string x) => string.Compare(x, query, ignoreCase) == 0);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000025EC File Offset: 0x000007EC
		public static string FirstOrDefault(this IEnumerable<string> items, string query, bool ignoreCase = false)
		{
			return items.FirstOrDefault((string x) => string.Compare(x, query, ignoreCase) == 0);
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002620 File Offset: 0x00000820
		public static IEnumerable<string> Surround(this IEnumerable<string> strings, string surrounder)
		{
			return from x in strings
			select surrounder + x + surrounder;
		}
	}
}
