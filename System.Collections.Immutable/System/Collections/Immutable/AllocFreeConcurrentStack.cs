using System;
using System.Collections.Generic;

namespace System.Collections.Immutable
{
	// Token: 0x02000008 RID: 8
	internal static class AllocFreeConcurrentStack<T>
	{
		// Token: 0x0600003A RID: 58 RVA: 0x00002A40 File Offset: 0x00000C40
		public static void TryAdd(T item)
		{
			Stack<RefAsValueType<T>> threadLocalStack = AllocFreeConcurrentStack<T>.ThreadLocalStack;
			if (threadLocalStack.Count < 35)
			{
				threadLocalStack.Push(new RefAsValueType<T>(item));
			}
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002A6C File Offset: 0x00000C6C
		public static bool TryTake(out T item)
		{
			Stack<RefAsValueType<T>> threadLocalStack = AllocFreeConcurrentStack<T>.ThreadLocalStack;
			if (threadLocalStack != null && threadLocalStack.Count > 0)
			{
				item = threadLocalStack.Pop().Value;
				return true;
			}
			item = default(T);
			return false;
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00002AA8 File Offset: 0x00000CA8
		private static Stack<RefAsValueType<T>> ThreadLocalStack
		{
			get
			{
				Dictionary<Type, object> dictionary = AllocFreeConcurrentStack.t_stacks;
				if (dictionary == null)
				{
					dictionary = (AllocFreeConcurrentStack.t_stacks = new Dictionary<Type, object>());
				}
				object obj;
				if (!dictionary.TryGetValue(AllocFreeConcurrentStack<T>.s_typeOfT, out obj))
				{
					obj = new Stack<RefAsValueType<T>>(35);
					dictionary.Add(AllocFreeConcurrentStack<T>.s_typeOfT, obj);
				}
				return (Stack<RefAsValueType<T>>)obj;
			}
		}

		// Token: 0x04000003 RID: 3
		private const int MaxSize = 35;

		// Token: 0x04000004 RID: 4
		private static readonly Type s_typeOfT = typeof(T);
	}
}
