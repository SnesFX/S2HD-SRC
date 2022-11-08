using System;
using System.Collections.Generic;
using System.Linq;

namespace System.Collections.Immutable
{
	// Token: 0x02000019 RID: 25
	public static class ImmutableArray
	{
		// Token: 0x0600009E RID: 158 RVA: 0x00002C7A File Offset: 0x00000E7A
		public static ImmutableArray<T> Create<T>()
		{
			return ImmutableArray<T>.Empty;
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00002C84 File Offset: 0x00000E84
		public static ImmutableArray<T> Create<T>(T item)
		{
			T[] items = new T[]
			{
				item
			};
			return new ImmutableArray<T>(items);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00002CA8 File Offset: 0x00000EA8
		public static ImmutableArray<T> Create<T>(T item1, T item2)
		{
			T[] items = new T[]
			{
				item1,
				item2
			};
			return new ImmutableArray<T>(items);
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00002CD4 File Offset: 0x00000ED4
		public static ImmutableArray<T> Create<T>(T item1, T item2, T item3)
		{
			T[] items = new T[]
			{
				item1,
				item2,
				item3
			};
			return new ImmutableArray<T>(items);
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00002D08 File Offset: 0x00000F08
		public static ImmutableArray<T> Create<T>(T item1, T item2, T item3, T item4)
		{
			T[] items = new T[]
			{
				item1,
				item2,
				item3,
				item4
			};
			return new ImmutableArray<T>(items);
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00002D44 File Offset: 0x00000F44
		public static ImmutableArray<T> CreateRange<T>(IEnumerable<T> items)
		{
			Requires.NotNull<IEnumerable<T>>(items, "items");
			IImmutableArray immutableArray = items as IImmutableArray;
			if (immutableArray != null)
			{
				Array array = immutableArray.Array;
				if (array == null)
				{
					throw new InvalidOperationException(SR.InvalidOperationOnDefaultArray);
				}
				return new ImmutableArray<T>((T[])array);
			}
			else
			{
				int count;
				if (items.TryGetCount(out count))
				{
					return new ImmutableArray<T>(items.ToArray(count));
				}
				return new ImmutableArray<T>(items.ToArray<T>());
			}
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00002DA9 File Offset: 0x00000FA9
		public static ImmutableArray<T> Create<T>(params T[] items)
		{
			if (items == null)
			{
				return ImmutableArray.Create<T>();
			}
			return ImmutableArray.CreateDefensiveCopy<T>(items);
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00002DBC File Offset: 0x00000FBC
		public static ImmutableArray<T> Create<T>(T[] items, int start, int length)
		{
			Requires.NotNull<T[]>(items, "items");
			Requires.Range(start >= 0 && start <= items.Length, "start", null);
			Requires.Range(length >= 0 && start + length <= items.Length, "length", null);
			if (length == 0)
			{
				return ImmutableArray.Create<T>();
			}
			T[] array = new T[length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = items[start + i];
			}
			return new ImmutableArray<T>(array);
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00002E40 File Offset: 0x00001040
		public static ImmutableArray<T> Create<T>(ImmutableArray<T> items, int start, int length)
		{
			Requires.Range(start >= 0 && start <= items.Length, "start", null);
			Requires.Range(length >= 0 && start + length <= items.Length, "length", null);
			if (length == 0)
			{
				return ImmutableArray.Create<T>();
			}
			if (start == 0 && length == items.Length)
			{
				return items;
			}
			T[] array = new T[length];
			Array.Copy(items.array, start, array, 0, length);
			return new ImmutableArray<T>(array);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00002EC4 File Offset: 0x000010C4
		public static ImmutableArray<TResult> CreateRange<TSource, TResult>(ImmutableArray<TSource> items, Func<TSource, TResult> selector)
		{
			Requires.NotNull<Func<TSource, TResult>>(selector, "selector");
			int length = items.Length;
			if (length == 0)
			{
				return ImmutableArray.Create<TResult>();
			}
			TResult[] array = new TResult[length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = selector(items[i]);
			}
			return new ImmutableArray<TResult>(array);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00002F20 File Offset: 0x00001120
		public static ImmutableArray<TResult> CreateRange<TSource, TResult>(ImmutableArray<TSource> items, int start, int length, Func<TSource, TResult> selector)
		{
			int length2 = items.Length;
			Requires.Range(start >= 0 && start <= length2, "start", null);
			Requires.Range(length >= 0 && start + length <= length2, "length", null);
			Requires.NotNull<Func<TSource, TResult>>(selector, "selector");
			if (length == 0)
			{
				return ImmutableArray.Create<TResult>();
			}
			TResult[] array = new TResult[length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = selector(items[i + start]);
			}
			return new ImmutableArray<TResult>(array);
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00002FB0 File Offset: 0x000011B0
		public static ImmutableArray<TResult> CreateRange<TSource, TArg, TResult>(ImmutableArray<TSource> items, Func<TSource, TArg, TResult> selector, TArg arg)
		{
			Requires.NotNull<Func<TSource, TArg, TResult>>(selector, "selector");
			int length = items.Length;
			if (length == 0)
			{
				return ImmutableArray.Create<TResult>();
			}
			TResult[] array = new TResult[length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = selector(items[i], arg);
			}
			return new ImmutableArray<TResult>(array);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000300C File Offset: 0x0000120C
		public static ImmutableArray<TResult> CreateRange<TSource, TArg, TResult>(ImmutableArray<TSource> items, int start, int length, Func<TSource, TArg, TResult> selector, TArg arg)
		{
			int length2 = items.Length;
			Requires.Range(start >= 0 && start <= length2, "start", null);
			Requires.Range(length >= 0 && start + length <= length2, "length", null);
			Requires.NotNull<Func<TSource, TArg, TResult>>(selector, "selector");
			if (length == 0)
			{
				return ImmutableArray.Create<TResult>();
			}
			TResult[] array = new TResult[length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = selector(items[i + start], arg);
			}
			return new ImmutableArray<TResult>(array);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x000030A0 File Offset: 0x000012A0
		public static ImmutableArray<T>.Builder CreateBuilder<T>()
		{
			return ImmutableArray.Create<T>().ToBuilder();
		}

		// Token: 0x060000AC RID: 172 RVA: 0x000030BA File Offset: 0x000012BA
		public static ImmutableArray<T>.Builder CreateBuilder<T>(int initialCapacity)
		{
			return new ImmutableArray<T>.Builder(initialCapacity);
		}

		// Token: 0x060000AD RID: 173 RVA: 0x000030C2 File Offset: 0x000012C2
		public static ImmutableArray<TSource> ToImmutableArray<TSource>(this IEnumerable<TSource> items)
		{
			if (items is ImmutableArray<TSource>)
			{
				return (ImmutableArray<TSource>)items;
			}
			return ImmutableArray.CreateRange<TSource>(items);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x000030D9 File Offset: 0x000012D9
		public static int BinarySearch<T>(this ImmutableArray<T> array, T value)
		{
			return Array.BinarySearch<T>(array.array, value);
		}

		// Token: 0x060000AF RID: 175 RVA: 0x000030E7 File Offset: 0x000012E7
		public static int BinarySearch<T>(this ImmutableArray<T> array, T value, IComparer<T> comparer)
		{
			return Array.BinarySearch<T>(array.array, value, comparer);
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x000030F6 File Offset: 0x000012F6
		public static int BinarySearch<T>(this ImmutableArray<T> array, int index, int length, T value)
		{
			return Array.BinarySearch<T>(array.array, index, length, value);
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00003106 File Offset: 0x00001306
		public static int BinarySearch<T>(this ImmutableArray<T> array, int index, int length, T value, IComparer<T> comparer)
		{
			return Array.BinarySearch<T>(array.array, index, length, value, comparer);
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00003118 File Offset: 0x00001318
		internal static ImmutableArray<T> CreateDefensiveCopy<T>(T[] items)
		{
			if (items.Length == 0)
			{
				return ImmutableArray<T>.Empty;
			}
			T[] array = new T[items.Length];
			Array.Copy(items, 0, array, 0, items.Length);
			return new ImmutableArray<T>(array);
		}

		// Token: 0x04000009 RID: 9
		internal static readonly byte[] TwoElementArray = new byte[2];
	}
}
