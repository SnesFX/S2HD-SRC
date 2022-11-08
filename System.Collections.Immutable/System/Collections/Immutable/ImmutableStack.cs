using System;
using System.Collections.Generic;

namespace System.Collections.Immutable
{
	// Token: 0x02000031 RID: 49
	public static class ImmutableStack
	{
		// Token: 0x0600031B RID: 795 RVA: 0x0000888D File Offset: 0x00006A8D
		public static ImmutableStack<T> Create<T>()
		{
			return ImmutableStack<T>.Empty;
		}

		// Token: 0x0600031C RID: 796 RVA: 0x00008894 File Offset: 0x00006A94
		public static ImmutableStack<T> Create<T>(T item)
		{
			return ImmutableStack<T>.Empty.Push(item);
		}

		// Token: 0x0600031D RID: 797 RVA: 0x000088A4 File Offset: 0x00006AA4
		public static ImmutableStack<T> CreateRange<T>(IEnumerable<T> items)
		{
			Requires.NotNull<IEnumerable<T>>(items, "items");
			ImmutableStack<T> immutableStack = ImmutableStack<T>.Empty;
			foreach (T value in items)
			{
				immutableStack = immutableStack.Push(value);
			}
			return immutableStack;
		}

		// Token: 0x0600031E RID: 798 RVA: 0x00008900 File Offset: 0x00006B00
		public static ImmutableStack<T> Create<T>(params T[] items)
		{
			Requires.NotNull<T[]>(items, "items");
			ImmutableStack<T> immutableStack = ImmutableStack<T>.Empty;
			foreach (T value in items)
			{
				immutableStack = immutableStack.Push(value);
			}
			return immutableStack;
		}

		// Token: 0x0600031F RID: 799 RVA: 0x0000893F File Offset: 0x00006B3F
		public static IImmutableStack<T> Pop<T>(this IImmutableStack<T> stack, out T value)
		{
			Requires.NotNull<IImmutableStack<T>>(stack, "stack");
			value = stack.Peek();
			return stack.Pop();
		}
	}
}
