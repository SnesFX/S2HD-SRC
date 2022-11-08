using System;
using System.Collections.Generic;
using System.Threading;

namespace System.Collections.Immutable
{
	// Token: 0x02000024 RID: 36
	public static class ImmutableInterlocked
	{
		// Token: 0x060001D7 RID: 471 RVA: 0x000060E8 File Offset: 0x000042E8
		public static bool Update<T>(ref T location, Func<T, T> transformer) where T : class
		{
			Requires.NotNull<Func<T, T>>(transformer, "transformer");
			T t = Volatile.Read<T>(ref location);
			for (;;)
			{
				T t2 = transformer(t);
				if (t == t2)
				{
					break;
				}
				T t3 = Interlocked.CompareExchange<T>(ref location, t2, t);
				bool flag = t == t3;
				t = t3;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x00006140 File Offset: 0x00004340
		public static bool Update<T, TArg>(ref T location, Func<T, TArg, T> transformer, TArg transformerArgument) where T : class
		{
			Requires.NotNull<Func<T, TArg, T>>(transformer, "transformer");
			T t = Volatile.Read<T>(ref location);
			for (;;)
			{
				T t2 = transformer(t, transformerArgument);
				if (t == t2)
				{
					break;
				}
				T t3 = Interlocked.CompareExchange<T>(ref location, t2, t);
				bool flag = t == t3;
				t = t3;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x00006196 File Offset: 0x00004396
		public static ImmutableArray<T> InterlockedExchange<T>(ref ImmutableArray<T> location, ImmutableArray<T> value)
		{
			return new ImmutableArray<T>(Interlocked.Exchange<T[]>(ref location.array, value.array));
		}

		// Token: 0x060001DA RID: 474 RVA: 0x000061AE File Offset: 0x000043AE
		public static ImmutableArray<T> InterlockedCompareExchange<T>(ref ImmutableArray<T> location, ImmutableArray<T> value, ImmutableArray<T> comparand)
		{
			return new ImmutableArray<T>(Interlocked.CompareExchange<T[]>(ref location.array, value.array, comparand.array));
		}

		// Token: 0x060001DB RID: 475 RVA: 0x000061CC File Offset: 0x000043CC
		public static bool InterlockedInitialize<T>(ref ImmutableArray<T> location, ImmutableArray<T> value)
		{
			return ImmutableInterlocked.InterlockedCompareExchange<T>(ref location, value, default(ImmutableArray<T>)).IsDefault;
		}

		// Token: 0x060001DC RID: 476 RVA: 0x000061F4 File Offset: 0x000043F4
		public static TValue GetOrAdd<TKey, TValue, TArg>(ref ImmutableDictionary<TKey, TValue> location, TKey key, Func<TKey, TArg, TValue> valueFactory, TArg factoryArgument)
		{
			Requires.NotNull<Func<TKey, TArg, TValue>>(valueFactory, "valueFactory");
			ImmutableDictionary<TKey, TValue> immutableDictionary = Volatile.Read<ImmutableDictionary<TKey, TValue>>(ref location);
			Requires.NotNull<ImmutableDictionary<TKey, TValue>>(immutableDictionary, "location");
			TValue tvalue;
			if (immutableDictionary.TryGetValue(key, out tvalue))
			{
				return tvalue;
			}
			tvalue = valueFactory(key, factoryArgument);
			return ImmutableInterlocked.GetOrAdd<TKey, TValue>(ref location, key, tvalue);
		}

		// Token: 0x060001DD RID: 477 RVA: 0x0000623C File Offset: 0x0000443C
		public static TValue GetOrAdd<TKey, TValue>(ref ImmutableDictionary<TKey, TValue> location, TKey key, Func<TKey, TValue> valueFactory)
		{
			Requires.NotNull<Func<TKey, TValue>>(valueFactory, "valueFactory");
			ImmutableDictionary<TKey, TValue> immutableDictionary = Volatile.Read<ImmutableDictionary<TKey, TValue>>(ref location);
			Requires.NotNull<ImmutableDictionary<TKey, TValue>>(immutableDictionary, "location");
			TValue tvalue;
			if (immutableDictionary.TryGetValue(key, out tvalue))
			{
				return tvalue;
			}
			tvalue = valueFactory(key);
			return ImmutableInterlocked.GetOrAdd<TKey, TValue>(ref location, key, tvalue);
		}

		// Token: 0x060001DE RID: 478 RVA: 0x00006284 File Offset: 0x00004484
		public static TValue GetOrAdd<TKey, TValue>(ref ImmutableDictionary<TKey, TValue> location, TKey key, TValue value)
		{
			ImmutableDictionary<TKey, TValue> immutableDictionary = Volatile.Read<ImmutableDictionary<TKey, TValue>>(ref location);
			TValue result;
			for (;;)
			{
				Requires.NotNull<ImmutableDictionary<TKey, TValue>>(immutableDictionary, "location");
				if (immutableDictionary.TryGetValue(key, out result))
				{
					break;
				}
				ImmutableDictionary<TKey, TValue> value2 = immutableDictionary.Add(key, value);
				ImmutableDictionary<TKey, TValue> immutableDictionary2 = Interlocked.CompareExchange<ImmutableDictionary<TKey, TValue>>(ref location, value2, immutableDictionary);
				bool flag = immutableDictionary == immutableDictionary2;
				immutableDictionary = immutableDictionary2;
				if (flag)
				{
					return value;
				}
			}
			return result;
		}

		// Token: 0x060001DF RID: 479 RVA: 0x000062D0 File Offset: 0x000044D0
		public static TValue AddOrUpdate<TKey, TValue>(ref ImmutableDictionary<TKey, TValue> location, TKey key, Func<TKey, TValue> addValueFactory, Func<TKey, TValue, TValue> updateValueFactory)
		{
			Requires.NotNull<Func<TKey, TValue>>(addValueFactory, "addValueFactory");
			Requires.NotNull<Func<TKey, TValue, TValue>>(updateValueFactory, "updateValueFactory");
			ImmutableDictionary<TKey, TValue> immutableDictionary = Volatile.Read<ImmutableDictionary<TKey, TValue>>(ref location);
			TValue tvalue;
			bool flag;
			do
			{
				Requires.NotNull<ImmutableDictionary<TKey, TValue>>(immutableDictionary, "location");
				TValue arg;
				if (immutableDictionary.TryGetValue(key, out arg))
				{
					tvalue = updateValueFactory(key, arg);
				}
				else
				{
					tvalue = addValueFactory(key);
				}
				ImmutableDictionary<TKey, TValue> value = immutableDictionary.SetItem(key, tvalue);
				ImmutableDictionary<TKey, TValue> immutableDictionary2 = Interlocked.CompareExchange<ImmutableDictionary<TKey, TValue>>(ref location, value, immutableDictionary);
				flag = (immutableDictionary == immutableDictionary2);
				immutableDictionary = immutableDictionary2;
			}
			while (!flag);
			return tvalue;
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x00006348 File Offset: 0x00004548
		public static TValue AddOrUpdate<TKey, TValue>(ref ImmutableDictionary<TKey, TValue> location, TKey key, TValue addValue, Func<TKey, TValue, TValue> updateValueFactory)
		{
			Requires.NotNull<Func<TKey, TValue, TValue>>(updateValueFactory, "updateValueFactory");
			ImmutableDictionary<TKey, TValue> immutableDictionary = Volatile.Read<ImmutableDictionary<TKey, TValue>>(ref location);
			TValue tvalue;
			bool flag;
			do
			{
				Requires.NotNull<ImmutableDictionary<TKey, TValue>>(immutableDictionary, "location");
				TValue arg;
				if (immutableDictionary.TryGetValue(key, out arg))
				{
					tvalue = updateValueFactory(key, arg);
				}
				else
				{
					tvalue = addValue;
				}
				ImmutableDictionary<TKey, TValue> value = immutableDictionary.SetItem(key, tvalue);
				ImmutableDictionary<TKey, TValue> immutableDictionary2 = Interlocked.CompareExchange<ImmutableDictionary<TKey, TValue>>(ref location, value, immutableDictionary);
				flag = (immutableDictionary == immutableDictionary2);
				immutableDictionary = immutableDictionary2;
			}
			while (!flag);
			return tvalue;
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x000063AC File Offset: 0x000045AC
		public static bool TryAdd<TKey, TValue>(ref ImmutableDictionary<TKey, TValue> location, TKey key, TValue value)
		{
			ImmutableDictionary<TKey, TValue> immutableDictionary = Volatile.Read<ImmutableDictionary<TKey, TValue>>(ref location);
			for (;;)
			{
				Requires.NotNull<ImmutableDictionary<TKey, TValue>>(immutableDictionary, "location");
				if (immutableDictionary.ContainsKey(key))
				{
					break;
				}
				ImmutableDictionary<TKey, TValue> value2 = immutableDictionary.Add(key, value);
				ImmutableDictionary<TKey, TValue> immutableDictionary2 = Interlocked.CompareExchange<ImmutableDictionary<TKey, TValue>>(ref location, value2, immutableDictionary);
				bool flag = immutableDictionary == immutableDictionary2;
				immutableDictionary = immutableDictionary2;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x000063F4 File Offset: 0x000045F4
		public static bool TryUpdate<TKey, TValue>(ref ImmutableDictionary<TKey, TValue> location, TKey key, TValue newValue, TValue comparisonValue)
		{
			EqualityComparer<TValue> @default = EqualityComparer<TValue>.Default;
			ImmutableDictionary<TKey, TValue> immutableDictionary = Volatile.Read<ImmutableDictionary<TKey, TValue>>(ref location);
			for (;;)
			{
				Requires.NotNull<ImmutableDictionary<TKey, TValue>>(immutableDictionary, "location");
				TValue x;
				if (!immutableDictionary.TryGetValue(key, out x) || !@default.Equals(x, comparisonValue))
				{
					break;
				}
				ImmutableDictionary<TKey, TValue> value = immutableDictionary.SetItem(key, newValue);
				ImmutableDictionary<TKey, TValue> immutableDictionary2 = Interlocked.CompareExchange<ImmutableDictionary<TKey, TValue>>(ref location, value, immutableDictionary);
				bool flag = immutableDictionary == immutableDictionary2;
				immutableDictionary = immutableDictionary2;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x00006454 File Offset: 0x00004654
		public static bool TryRemove<TKey, TValue>(ref ImmutableDictionary<TKey, TValue> location, TKey key, out TValue value)
		{
			ImmutableDictionary<TKey, TValue> immutableDictionary = Volatile.Read<ImmutableDictionary<TKey, TValue>>(ref location);
			for (;;)
			{
				Requires.NotNull<ImmutableDictionary<TKey, TValue>>(immutableDictionary, "location");
				if (!immutableDictionary.TryGetValue(key, out value))
				{
					break;
				}
				ImmutableDictionary<TKey, TValue> value2 = immutableDictionary.Remove(key);
				ImmutableDictionary<TKey, TValue> immutableDictionary2 = Interlocked.CompareExchange<ImmutableDictionary<TKey, TValue>>(ref location, value2, immutableDictionary);
				bool flag = immutableDictionary == immutableDictionary2;
				immutableDictionary = immutableDictionary2;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x0000649C File Offset: 0x0000469C
		public static bool TryPop<T>(ref ImmutableStack<T> location, out T value)
		{
			ImmutableStack<T> immutableStack = Volatile.Read<ImmutableStack<T>>(ref location);
			for (;;)
			{
				Requires.NotNull<ImmutableStack<T>>(immutableStack, "location");
				if (immutableStack.IsEmpty)
				{
					break;
				}
				ImmutableStack<T> value2 = immutableStack.Pop(out value);
				ImmutableStack<T> immutableStack2 = Interlocked.CompareExchange<ImmutableStack<T>>(ref location, value2, immutableStack);
				bool flag = immutableStack == immutableStack2;
				immutableStack = immutableStack2;
				if (flag)
				{
					return true;
				}
			}
			value = default(T);
			return false;
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x000064E8 File Offset: 0x000046E8
		public static void Push<T>(ref ImmutableStack<T> location, T value)
		{
			ImmutableStack<T> immutableStack = Volatile.Read<ImmutableStack<T>>(ref location);
			bool flag;
			do
			{
				Requires.NotNull<ImmutableStack<T>>(immutableStack, "location");
				ImmutableStack<T> value2 = immutableStack.Push(value);
				ImmutableStack<T> immutableStack2 = Interlocked.CompareExchange<ImmutableStack<T>>(ref location, value2, immutableStack);
				flag = (immutableStack == immutableStack2);
				immutableStack = immutableStack2;
			}
			while (!flag);
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x00006524 File Offset: 0x00004724
		public static bool TryDequeue<T>(ref ImmutableQueue<T> location, out T value)
		{
			ImmutableQueue<T> immutableQueue = Volatile.Read<ImmutableQueue<T>>(ref location);
			for (;;)
			{
				Requires.NotNull<ImmutableQueue<T>>(immutableQueue, "location");
				if (immutableQueue.IsEmpty)
				{
					break;
				}
				ImmutableQueue<T> value2 = immutableQueue.Dequeue(out value);
				ImmutableQueue<T> immutableQueue2 = Interlocked.CompareExchange<ImmutableQueue<T>>(ref location, value2, immutableQueue);
				bool flag = immutableQueue == immutableQueue2;
				immutableQueue = immutableQueue2;
				if (flag)
				{
					return true;
				}
			}
			value = default(T);
			return false;
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00006570 File Offset: 0x00004770
		public static void Enqueue<T>(ref ImmutableQueue<T> location, T value)
		{
			ImmutableQueue<T> immutableQueue = Volatile.Read<ImmutableQueue<T>>(ref location);
			bool flag;
			do
			{
				Requires.NotNull<ImmutableQueue<T>>(immutableQueue, "location");
				ImmutableQueue<T> value2 = immutableQueue.Enqueue(value);
				ImmutableQueue<T> immutableQueue2 = Interlocked.CompareExchange<ImmutableQueue<T>>(ref location, value2, immutableQueue);
				flag = (immutableQueue == immutableQueue2);
				immutableQueue = immutableQueue2;
			}
			while (!flag);
		}
	}
}
