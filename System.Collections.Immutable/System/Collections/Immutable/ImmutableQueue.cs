using System;
using System.Collections.Generic;

namespace System.Collections.Immutable
{
	// Token: 0x02000029 RID: 41
	public static class ImmutableQueue
	{
		// Token: 0x0600025D RID: 605 RVA: 0x000071CE File Offset: 0x000053CE
		public static ImmutableQueue<T> Create<T>()
		{
			return ImmutableQueue<T>.Empty;
		}

		// Token: 0x0600025E RID: 606 RVA: 0x000071D5 File Offset: 0x000053D5
		public static ImmutableQueue<T> Create<T>(T item)
		{
			return ImmutableQueue<T>.Empty.Enqueue(item);
		}

		// Token: 0x0600025F RID: 607 RVA: 0x000071E4 File Offset: 0x000053E4
		public static ImmutableQueue<T> CreateRange<T>(IEnumerable<T> items)
		{
			Requires.NotNull<IEnumerable<T>>(items, "items");
			T[] array = items as T[];
			if (array != null)
			{
				return ImmutableQueue.Create<T>(array);
			}
			ImmutableQueue<T> result;
			using (IEnumerator<T> enumerator = items.GetEnumerator())
			{
				if (!enumerator.MoveNext())
				{
					result = ImmutableQueue<T>.Empty;
				}
				else
				{
					ImmutableStack<T> forwards = ImmutableStack.Create<T>(enumerator.Current);
					ImmutableStack<T> immutableStack = ImmutableStack<T>.Empty;
					while (enumerator.MoveNext())
					{
						T value = enumerator.Current;
						immutableStack = immutableStack.Push(value);
					}
					result = new ImmutableQueue<T>(forwards, immutableStack);
				}
			}
			return result;
		}

		// Token: 0x06000260 RID: 608 RVA: 0x00007278 File Offset: 0x00005478
		public static ImmutableQueue<T> Create<T>(params T[] items)
		{
			Requires.NotNull<T[]>(items, "items");
			if (items.Length == 0)
			{
				return ImmutableQueue<T>.Empty;
			}
			ImmutableStack<T> immutableStack = ImmutableStack<T>.Empty;
			for (int i = items.Length - 1; i >= 0; i--)
			{
				immutableStack = immutableStack.Push(items[i]);
			}
			return new ImmutableQueue<T>(immutableStack, ImmutableStack<T>.Empty);
		}

		// Token: 0x06000261 RID: 609 RVA: 0x000072C9 File Offset: 0x000054C9
		public static IImmutableQueue<T> Dequeue<T>(this IImmutableQueue<T> queue, out T value)
		{
			Requires.NotNull<IImmutableQueue<T>>(queue, "queue");
			value = queue.Peek();
			return queue.Dequeue();
		}
	}
}
