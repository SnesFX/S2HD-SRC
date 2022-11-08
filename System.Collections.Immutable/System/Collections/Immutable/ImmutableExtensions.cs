using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace System.Collections.Immutable
{
	// Token: 0x02000021 RID: 33
	internal static class ImmutableExtensions
	{
		// Token: 0x06000182 RID: 386 RVA: 0x000050F0 File Offset: 0x000032F0
		internal static IOrderedCollection<T> AsOrderedCollection<T>(this IEnumerable<T> sequence)
		{
			Requires.NotNull<IEnumerable<T>>(sequence, "sequence");
			IOrderedCollection<T> orderedCollection = sequence as IOrderedCollection<T>;
			if (orderedCollection != null)
			{
				return orderedCollection;
			}
			IList<T> list = sequence as IList<T>;
			if (list != null)
			{
				return new ImmutableExtensions.ListOfTWrapper<T>(list);
			}
			return new ImmutableExtensions.FallbackWrapper<T>(sequence);
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0000512B File Offset: 0x0000332B
		internal static void ClearFastWhenEmpty<T>(this Stack<T> stack)
		{
			if (stack.Count > 0)
			{
				stack.Clear();
			}
		}

		// Token: 0x06000184 RID: 388 RVA: 0x0000513C File Offset: 0x0000333C
		internal static DisposableEnumeratorAdapter<T, TEnumerator> GetEnumerableDisposable<T, TEnumerator>(this IEnumerable<T> enumerable) where TEnumerator : struct, IStrongEnumerator<T>, IEnumerator<T>
		{
			Requires.NotNull<IEnumerable<T>>(enumerable, "enumerable");
			IStrongEnumerable<T, TEnumerator> strongEnumerable = enumerable as IStrongEnumerable<T, TEnumerator>;
			if (strongEnumerable != null)
			{
				return new DisposableEnumeratorAdapter<T, TEnumerator>(strongEnumerable.GetEnumerator());
			}
			return new DisposableEnumeratorAdapter<T, TEnumerator>(enumerable.GetEnumerator());
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00005175 File Offset: 0x00003375
		internal static bool TryGetCount<T>(this IEnumerable<T> sequence, out int count)
		{
			return sequence.TryGetCount(out count);
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00005180 File Offset: 0x00003380
		internal static bool TryGetCount<T>(this IEnumerable sequence, out int count)
		{
			ICollection collection = sequence as ICollection;
			if (collection != null)
			{
				count = collection.Count;
				return true;
			}
			ICollection<T> collection2 = sequence as ICollection<T>;
			if (collection2 != null)
			{
				count = collection2.Count;
				return true;
			}
			IReadOnlyCollection<T> readOnlyCollection = sequence as IReadOnlyCollection<T>;
			if (readOnlyCollection != null)
			{
				count = readOnlyCollection.Count;
				return true;
			}
			count = 0;
			return false;
		}

		// Token: 0x06000187 RID: 391 RVA: 0x000051D0 File Offset: 0x000033D0
		internal static int GetCount<T>(ref IEnumerable<T> sequence)
		{
			int count;
			if (!sequence.TryGetCount(out count))
			{
				List<T> list = sequence.ToList<T>();
				count = list.Count;
				sequence = list;
			}
			return count;
		}

		// Token: 0x06000188 RID: 392 RVA: 0x000051FC File Offset: 0x000033FC
		internal static bool TryCopyTo<T>(this IEnumerable<T> sequence, T[] array, int arrayIndex)
		{
			IList<T> list = sequence as IList<T>;
			if (list != null)
			{
				List<T> list2 = sequence as List<T>;
				if (list2 != null)
				{
					list2.CopyTo(array, arrayIndex);
					return true;
				}
				if (sequence.GetType() == typeof(T[]))
				{
					T[] array2 = (T[])sequence;
					Array.Copy(array2, 0, array, arrayIndex, array2.Length);
					return true;
				}
				if (sequence is ImmutableArray<T>)
				{
					ImmutableArray<T> immutableArray = (ImmutableArray<T>)sequence;
					Array.Copy(immutableArray.array, 0, array, arrayIndex, immutableArray.Length);
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000189 RID: 393 RVA: 0x00005278 File Offset: 0x00003478
		internal static T[] ToArray<T>(this IEnumerable<T> sequence, int count)
		{
			Requires.NotNull<IEnumerable<T>>(sequence, "sequence");
			Requires.Range(count >= 0, "count", null);
			if (count == 0)
			{
				return ImmutableArray<T>.Empty.array;
			}
			T[] array = new T[count];
			if (!sequence.TryCopyTo(array, 0))
			{
				int num = 0;
				foreach (T t in sequence)
				{
					Requires.Argument(num < count);
					array[num++] = t;
				}
				Requires.Argument(num == count);
			}
			return array;
		}

		// Token: 0x02000052 RID: 82
		private class ListOfTWrapper<T> : IOrderedCollection<T>, IEnumerable<!0>, IEnumerable
		{
			// Token: 0x0600043B RID: 1083 RVA: 0x0000B310 File Offset: 0x00009510
			internal ListOfTWrapper(IList<T> collection)
			{
				Requires.NotNull<IList<T>>(collection, "collection");
				this._collection = collection;
			}

			// Token: 0x170000CA RID: 202
			// (get) Token: 0x0600043C RID: 1084 RVA: 0x0000B32A File Offset: 0x0000952A
			public int Count
			{
				get
				{
					return this._collection.Count;
				}
			}

			// Token: 0x170000CB RID: 203
			public T this[int index]
			{
				get
				{
					return this._collection[index];
				}
			}

			// Token: 0x0600043E RID: 1086 RVA: 0x0000B345 File Offset: 0x00009545
			public IEnumerator<T> GetEnumerator()
			{
				return this._collection.GetEnumerator();
			}

			// Token: 0x0600043F RID: 1087 RVA: 0x0000B352 File Offset: 0x00009552
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x04000087 RID: 135
			private readonly IList<T> _collection;
		}

		// Token: 0x02000053 RID: 83
		private class FallbackWrapper<T> : IOrderedCollection<T>, IEnumerable<!0>, IEnumerable
		{
			// Token: 0x06000440 RID: 1088 RVA: 0x0000B35A File Offset: 0x0000955A
			internal FallbackWrapper(IEnumerable<T> sequence)
			{
				Requires.NotNull<IEnumerable<T>>(sequence, "sequence");
				this._sequence = sequence;
			}

			// Token: 0x170000CC RID: 204
			// (get) Token: 0x06000441 RID: 1089 RVA: 0x0000B374 File Offset: 0x00009574
			public int Count
			{
				get
				{
					if (this._collection == null)
					{
						int result;
						if (this._sequence.TryGetCount(out result))
						{
							return result;
						}
						this._collection = this._sequence.ToArray<T>();
					}
					return this._collection.Count;
				}
			}

			// Token: 0x170000CD RID: 205
			public T this[int index]
			{
				get
				{
					if (this._collection == null)
					{
						this._collection = this._sequence.ToArray<T>();
					}
					return this._collection[index];
				}
			}

			// Token: 0x06000443 RID: 1091 RVA: 0x0000B3DD File Offset: 0x000095DD
			public IEnumerator<T> GetEnumerator()
			{
				return this._sequence.GetEnumerator();
			}

			// Token: 0x06000444 RID: 1092 RVA: 0x0000B3EA File Offset: 0x000095EA
			[ExcludeFromCodeCoverage]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x04000088 RID: 136
			private readonly IEnumerable<T> _sequence;

			// Token: 0x04000089 RID: 137
			private IList<T> _collection;
		}
	}
}
