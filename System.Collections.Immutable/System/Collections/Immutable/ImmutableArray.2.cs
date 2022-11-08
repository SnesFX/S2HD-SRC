using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Runtime.Versioning;

namespace System.Collections.Immutable
{
	// Token: 0x0200001A RID: 26
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	[NonVersionable]
	public struct ImmutableArray<T> : IReadOnlyList<T>, IReadOnlyCollection<T>, IEnumerable<T>, IEnumerable, IList<T>, ICollection<T>, IEquatable<ImmutableArray<T>>, IList, ICollection, IImmutableArray, IStructuralComparable, IStructuralEquatable, IImmutableList<T>
	{
		// Token: 0x17000020 RID: 32
		T IList<!0>.this[int index]
		{
			get
			{
				ImmutableArray<T> immutableArray = this;
				immutableArray.ThrowInvalidOperationIfNotInitialized();
				return immutableArray[index];
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000B6 RID: 182 RVA: 0x00003182 File Offset: 0x00001382
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		bool ICollection<!0>.IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000B7 RID: 183 RVA: 0x00003188 File Offset: 0x00001388
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		int ICollection<!0>.Count
		{
			get
			{
				ImmutableArray<T> immutableArray = this;
				immutableArray.ThrowInvalidOperationIfNotInitialized();
				return immutableArray.Length;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x000031AC File Offset: 0x000013AC
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		int IReadOnlyCollection<!0>.Count
		{
			get
			{
				ImmutableArray<T> immutableArray = this;
				immutableArray.ThrowInvalidOperationIfNotInitialized();
				return immutableArray.Length;
			}
		}

		// Token: 0x17000024 RID: 36
		T IReadOnlyList<!0>.this[int index]
		{
			get
			{
				ImmutableArray<T> immutableArray = this;
				immutableArray.ThrowInvalidOperationIfNotInitialized();
				return immutableArray[index];
			}
		}

		// Token: 0x060000BA RID: 186 RVA: 0x000031F4 File Offset: 0x000013F4
		public int IndexOf(T item)
		{
			ImmutableArray<T> immutableArray = this;
			return immutableArray.IndexOf(item, 0, immutableArray.Length, EqualityComparer<T>.Default);
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00003220 File Offset: 0x00001420
		public int IndexOf(T item, int startIndex, IEqualityComparer<T> equalityComparer)
		{
			ImmutableArray<T> immutableArray = this;
			return immutableArray.IndexOf(item, startIndex, immutableArray.Length - startIndex, equalityComparer);
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00003248 File Offset: 0x00001448
		public int IndexOf(T item, int startIndex)
		{
			ImmutableArray<T> immutableArray = this;
			return immutableArray.IndexOf(item, startIndex, immutableArray.Length - startIndex, EqualityComparer<T>.Default);
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00003273 File Offset: 0x00001473
		public int IndexOf(T item, int startIndex, int count)
		{
			return this.IndexOf(item, startIndex, count, EqualityComparer<T>.Default);
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00003284 File Offset: 0x00001484
		public int IndexOf(T item, int startIndex, int count, IEqualityComparer<T> equalityComparer)
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowNullRefIfNotInitialized();
			if (count == 0 && startIndex == 0)
			{
				return -1;
			}
			Requires.Range(startIndex >= 0 && startIndex < immutableArray.Length, "startIndex", null);
			Requires.Range(count >= 0 && startIndex + count <= immutableArray.Length, "count", null);
			equalityComparer = (equalityComparer ?? EqualityComparer<T>.Default);
			if (equalityComparer == EqualityComparer<T>.Default)
			{
				return Array.IndexOf<T>(immutableArray.array, item, startIndex, count);
			}
			for (int i = startIndex; i < startIndex + count; i++)
			{
				if (equalityComparer.Equals(immutableArray.array[i], item))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00003330 File Offset: 0x00001530
		public int LastIndexOf(T item)
		{
			ImmutableArray<T> immutableArray = this;
			if (immutableArray.Length == 0)
			{
				return -1;
			}
			return immutableArray.LastIndexOf(item, immutableArray.Length - 1, immutableArray.Length, EqualityComparer<T>.Default);
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000336C File Offset: 0x0000156C
		public int LastIndexOf(T item, int startIndex)
		{
			ImmutableArray<T> immutableArray = this;
			if (immutableArray.Length == 0 && startIndex == 0)
			{
				return -1;
			}
			return immutableArray.LastIndexOf(item, startIndex, startIndex + 1, EqualityComparer<T>.Default);
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0000339F File Offset: 0x0000159F
		public int LastIndexOf(T item, int startIndex, int count)
		{
			return this.LastIndexOf(item, startIndex, count, EqualityComparer<T>.Default);
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x000033B0 File Offset: 0x000015B0
		public int LastIndexOf(T item, int startIndex, int count, IEqualityComparer<T> equalityComparer)
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowNullRefIfNotInitialized();
			if (startIndex == 0 && count == 0)
			{
				return -1;
			}
			Requires.Range(startIndex >= 0 && startIndex < immutableArray.Length, "startIndex", null);
			Requires.Range(count >= 0 && startIndex - count + 1 >= 0, "count", null);
			equalityComparer = (equalityComparer ?? EqualityComparer<T>.Default);
			if (equalityComparer == EqualityComparer<T>.Default)
			{
				return Array.LastIndexOf<T>(immutableArray.array, item, startIndex, count);
			}
			for (int i = startIndex; i >= startIndex - count + 1; i--)
			{
				if (equalityComparer.Equals(item, immutableArray.array[i]))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000345A File Offset: 0x0000165A
		public bool Contains(T item)
		{
			return this.IndexOf(item) >= 0;
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000346C File Offset: 0x0000166C
		public ImmutableArray<T> Insert(int index, T item)
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowNullRefIfNotInitialized();
			Requires.Range(index >= 0 && index <= immutableArray.Length, "index", null);
			if (immutableArray.Length == 0)
			{
				return ImmutableArray.Create<T>(item);
			}
			T[] array = new T[immutableArray.Length + 1];
			array[index] = item;
			if (index != 0)
			{
				Array.Copy(immutableArray.array, 0, array, 0, index);
			}
			if (index != immutableArray.Length)
			{
				Array.Copy(immutableArray.array, index, array, index + 1, immutableArray.Length - index);
			}
			return new ImmutableArray<T>(array);
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00003508 File Offset: 0x00001708
		public ImmutableArray<T> InsertRange(int index, IEnumerable<T> items)
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowNullRefIfNotInitialized();
			Requires.Range(index >= 0 && index <= immutableArray.Length, "index", null);
			Requires.NotNull<IEnumerable<T>>(items, "items");
			if (immutableArray.Length == 0)
			{
				return ImmutableArray.CreateRange<T>(items);
			}
			int count = ImmutableExtensions.GetCount<T>(ref items);
			if (count == 0)
			{
				return immutableArray;
			}
			T[] array = new T[immutableArray.Length + count];
			if (index != 0)
			{
				Array.Copy(immutableArray.array, 0, array, 0, index);
			}
			if (index != immutableArray.Length)
			{
				Array.Copy(immutableArray.array, index, array, index + count, immutableArray.Length - index);
			}
			if (!items.TryCopyTo(array, index))
			{
				int num = index;
				foreach (T t in items)
				{
					array[num++] = t;
				}
			}
			return new ImmutableArray<T>(array);
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00003608 File Offset: 0x00001808
		public ImmutableArray<T> InsertRange(int index, ImmutableArray<T> items)
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowNullRefIfNotInitialized();
			items.ThrowNullRefIfNotInitialized();
			Requires.Range(index >= 0 && index <= immutableArray.Length, "index", null);
			if (immutableArray.IsEmpty)
			{
				return items;
			}
			if (items.IsEmpty)
			{
				return immutableArray;
			}
			T[] array = new T[immutableArray.Length + items.Length];
			if (index != 0)
			{
				Array.Copy(immutableArray.array, 0, array, 0, index);
			}
			if (index != immutableArray.Length)
			{
				Array.Copy(immutableArray.array, index, array, index + items.Length, immutableArray.Length - index);
			}
			Array.Copy(items.array, 0, array, index, items.Length);
			return new ImmutableArray<T>(array);
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x000036CC File Offset: 0x000018CC
		public ImmutableArray<T> Add(T item)
		{
			ImmutableArray<T> immutableArray = this;
			if (immutableArray.Length == 0)
			{
				return ImmutableArray.Create<T>(item);
			}
			return immutableArray.Insert(immutableArray.Length, item);
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00003700 File Offset: 0x00001900
		public ImmutableArray<T> AddRange(IEnumerable<T> items)
		{
			ImmutableArray<T> immutableArray = this;
			return immutableArray.InsertRange(immutableArray.Length, items);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00003724 File Offset: 0x00001924
		public ImmutableArray<T> AddRange(ImmutableArray<T> items)
		{
			ImmutableArray<T> immutableArray = this;
			return immutableArray.InsertRange(immutableArray.Length, items);
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00003748 File Offset: 0x00001948
		public ImmutableArray<T> SetItem(int index, T item)
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowNullRefIfNotInitialized();
			Requires.Range(index >= 0 && index < immutableArray.Length, "index", null);
			T[] array = new T[immutableArray.Length];
			Array.Copy(immutableArray.array, 0, array, 0, immutableArray.Length);
			array[index] = item;
			return new ImmutableArray<T>(array);
		}

		// Token: 0x060000CB RID: 203 RVA: 0x000037AF File Offset: 0x000019AF
		public ImmutableArray<T> Replace(T oldValue, T newValue)
		{
			return this.Replace(oldValue, newValue, EqualityComparer<T>.Default);
		}

		// Token: 0x060000CC RID: 204 RVA: 0x000037C0 File Offset: 0x000019C0
		public ImmutableArray<T> Replace(T oldValue, T newValue, IEqualityComparer<T> equalityComparer)
		{
			ImmutableArray<T> immutableArray = this;
			int num = immutableArray.IndexOf(oldValue, 0, immutableArray.Length, equalityComparer);
			if (num < 0)
			{
				throw new ArgumentException(SR.CannotFindOldValue, "oldValue");
			}
			return immutableArray.SetItem(num, newValue);
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00003803 File Offset: 0x00001A03
		public ImmutableArray<T> Remove(T item)
		{
			return this.Remove(item, EqualityComparer<T>.Default);
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00003814 File Offset: 0x00001A14
		public ImmutableArray<T> Remove(T item, IEqualityComparer<T> equalityComparer)
		{
			ImmutableArray<T> result = this;
			result.ThrowNullRefIfNotInitialized();
			int num = result.IndexOf(item, 0, result.Length, equalityComparer);
			if (num >= 0)
			{
				return result.RemoveAt(num);
			}
			return result;
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0000384F File Offset: 0x00001A4F
		public ImmutableArray<T> RemoveAt(int index)
		{
			return this.RemoveRange(index, 1);
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000385C File Offset: 0x00001A5C
		public ImmutableArray<T> RemoveRange(int index, int length)
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowNullRefIfNotInitialized();
			Requires.Range(index >= 0 && index <= immutableArray.Length, "index", null);
			Requires.Range(length >= 0 && index + length <= immutableArray.Length, "length", null);
			if (length == 0)
			{
				return immutableArray;
			}
			T[] array = new T[immutableArray.Length - length];
			Array.Copy(immutableArray.array, 0, array, 0, index);
			Array.Copy(immutableArray.array, index + length, array, index, immutableArray.Length - index - length);
			return new ImmutableArray<T>(array);
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x000038FB File Offset: 0x00001AFB
		public ImmutableArray<T> RemoveRange(IEnumerable<T> items)
		{
			return this.RemoveRange(items, EqualityComparer<T>.Default);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0000390C File Offset: 0x00001B0C
		public ImmutableArray<T> RemoveRange(IEnumerable<T> items, IEqualityComparer<T> equalityComparer)
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowNullRefIfNotInitialized();
			Requires.NotNull<IEnumerable<T>>(items, "items");
			SortedSet<int> sortedSet = new SortedSet<int>();
			foreach (T item in items)
			{
				int num = immutableArray.IndexOf(item, 0, immutableArray.Length, equalityComparer);
				while (num >= 0 && !sortedSet.Add(num) && num + 1 < immutableArray.Length)
				{
					num = immutableArray.IndexOf(item, num + 1, equalityComparer);
				}
			}
			return immutableArray.RemoveAtRange(sortedSet);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x000039B4 File Offset: 0x00001BB4
		public ImmutableArray<T> RemoveRange(ImmutableArray<T> items)
		{
			return this.RemoveRange(items, EqualityComparer<T>.Default);
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000039C4 File Offset: 0x00001BC4
		public ImmutableArray<T> RemoveRange(ImmutableArray<T> items, IEqualityComparer<T> equalityComparer)
		{
			ImmutableArray<T> result = this;
			Requires.NotNull<T[]>(items.array, "items");
			if (items.IsEmpty)
			{
				result.ThrowNullRefIfNotInitialized();
				return result;
			}
			if (items.Length == 1)
			{
				return result.Remove(items[0], equalityComparer);
			}
			return result.RemoveRange(items.array, equalityComparer);
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00003A24 File Offset: 0x00001C24
		public ImmutableArray<T> RemoveAll(Predicate<T> match)
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowNullRefIfNotInitialized();
			Requires.NotNull<Predicate<T>>(match, "match");
			if (immutableArray.IsEmpty)
			{
				return immutableArray;
			}
			List<int> list = null;
			for (int i = 0; i < immutableArray.array.Length; i++)
			{
				if (match(immutableArray.array[i]))
				{
					if (list == null)
					{
						list = new List<int>();
					}
					list.Add(i);
				}
			}
			if (list == null)
			{
				return immutableArray;
			}
			return immutableArray.RemoveAtRange(list);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00003A9B File Offset: 0x00001C9B
		public ImmutableArray<T> Clear()
		{
			return ImmutableArray<T>.Empty;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00003AA4 File Offset: 0x00001CA4
		public ImmutableArray<T> Sort()
		{
			ImmutableArray<T> immutableArray = this;
			return immutableArray.Sort(0, immutableArray.Length, Comparer<T>.Default);
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00003ACC File Offset: 0x00001CCC
		public ImmutableArray<T> Sort(Comparison<T> comparison)
		{
			Requires.NotNull<Comparison<T>>(comparison, "comparison");
			ImmutableArray<T> immutableArray = this;
			return immutableArray.Sort(Comparer<T>.Create(comparison));
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00003AF8 File Offset: 0x00001CF8
		public ImmutableArray<T> Sort(IComparer<T> comparer)
		{
			ImmutableArray<T> immutableArray = this;
			return immutableArray.Sort(0, immutableArray.Length, comparer);
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00003B1C File Offset: 0x00001D1C
		public ImmutableArray<T> Sort(int index, int count, IComparer<T> comparer)
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowNullRefIfNotInitialized();
			Requires.Range(index >= 0, "index", null);
			Requires.Range(count >= 0 && index + count <= immutableArray.Length, "count", null);
			if (count > 1)
			{
				if (comparer == null)
				{
					comparer = Comparer<T>.Default;
				}
				bool flag = false;
				for (int i = index + 1; i < index + count; i++)
				{
					if (comparer.Compare(immutableArray.array[i - 1], immutableArray.array[i]) > 0)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					T[] array = new T[immutableArray.Length];
					Array.Copy(immutableArray.array, 0, array, 0, immutableArray.Length);
					Array.Sort<T>(array, index, count, comparer);
					return new ImmutableArray<T>(array);
				}
			}
			return immutableArray;
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00003BE8 File Offset: 0x00001DE8
		public IEnumerable<TResult> OfType<TResult>()
		{
			ImmutableArray<T> immutableArray = this;
			if (immutableArray.array == null || immutableArray.array.Length == 0)
			{
				return Enumerable.Empty<TResult>();
			}
			return immutableArray.array.OfType<TResult>();
		}

		// Token: 0x060000DC RID: 220 RVA: 0x0000317B File Offset: 0x0000137B
		void IList<!0>.Insert(int index, T item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0000317B File Offset: 0x0000137B
		void IList<!0>.RemoveAt(int index)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0000317B File Offset: 0x0000137B
		void ICollection<!0>.Add(T item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0000317B File Offset: 0x0000137B
		void ICollection<!0>.Clear()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x0000317B File Offset: 0x0000137B
		bool ICollection<!0>.Remove(T item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00003C20 File Offset: 0x00001E20
		[ExcludeFromCodeCoverage]
		IImmutableList<T> IImmutableList<!0>.Clear()
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowInvalidOperationIfNotInitialized();
			return immutableArray.Clear();
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00003C48 File Offset: 0x00001E48
		[ExcludeFromCodeCoverage]
		IImmutableList<T> IImmutableList<!0>.Add(T value)
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowInvalidOperationIfNotInitialized();
			return immutableArray.Add(value);
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00003C70 File Offset: 0x00001E70
		[ExcludeFromCodeCoverage]
		IImmutableList<T> IImmutableList<!0>.AddRange(IEnumerable<T> items)
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowInvalidOperationIfNotInitialized();
			return immutableArray.AddRange(items);
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00003C98 File Offset: 0x00001E98
		[ExcludeFromCodeCoverage]
		IImmutableList<T> IImmutableList<!0>.Insert(int index, T element)
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowInvalidOperationIfNotInitialized();
			return immutableArray.Insert(index, element);
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00003CC4 File Offset: 0x00001EC4
		[ExcludeFromCodeCoverage]
		IImmutableList<T> IImmutableList<!0>.InsertRange(int index, IEnumerable<T> items)
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowInvalidOperationIfNotInitialized();
			return immutableArray.InsertRange(index, items);
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00003CF0 File Offset: 0x00001EF0
		[ExcludeFromCodeCoverage]
		IImmutableList<T> IImmutableList<!0>.Remove(T value, IEqualityComparer<T> equalityComparer)
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowInvalidOperationIfNotInitialized();
			return immutableArray.Remove(value, equalityComparer);
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00003D1C File Offset: 0x00001F1C
		[ExcludeFromCodeCoverage]
		IImmutableList<T> IImmutableList<!0>.RemoveAll(Predicate<T> match)
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowInvalidOperationIfNotInitialized();
			return immutableArray.RemoveAll(match);
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00003D44 File Offset: 0x00001F44
		[ExcludeFromCodeCoverage]
		IImmutableList<T> IImmutableList<!0>.RemoveRange(IEnumerable<T> items, IEqualityComparer<T> equalityComparer)
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowInvalidOperationIfNotInitialized();
			return immutableArray.RemoveRange(items, equalityComparer);
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00003D70 File Offset: 0x00001F70
		[ExcludeFromCodeCoverage]
		IImmutableList<T> IImmutableList<!0>.RemoveRange(int index, int count)
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowInvalidOperationIfNotInitialized();
			return immutableArray.RemoveRange(index, count);
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00003D9C File Offset: 0x00001F9C
		[ExcludeFromCodeCoverage]
		IImmutableList<T> IImmutableList<!0>.RemoveAt(int index)
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowInvalidOperationIfNotInitialized();
			return immutableArray.RemoveAt(index);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00003DC4 File Offset: 0x00001FC4
		[ExcludeFromCodeCoverage]
		IImmutableList<T> IImmutableList<!0>.SetItem(int index, T value)
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowInvalidOperationIfNotInitialized();
			return immutableArray.SetItem(index, value);
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00003DF0 File Offset: 0x00001FF0
		IImmutableList<T> IImmutableList<!0>.Replace(T oldValue, T newValue, IEqualityComparer<T> equalityComparer)
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowInvalidOperationIfNotInitialized();
			return immutableArray.Replace(oldValue, newValue, equalityComparer);
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0000317B File Offset: 0x0000137B
		[ExcludeFromCodeCoverage]
		int IList.Add(object value)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0000317B File Offset: 0x0000137B
		[ExcludeFromCodeCoverage]
		void IList.Clear()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00003E1C File Offset: 0x0000201C
		[ExcludeFromCodeCoverage]
		bool IList.Contains(object value)
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowInvalidOperationIfNotInitialized();
			return immutableArray.Contains((T)((object)value));
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00003E44 File Offset: 0x00002044
		[ExcludeFromCodeCoverage]
		int IList.IndexOf(object value)
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowInvalidOperationIfNotInitialized();
			return immutableArray.IndexOf((T)((object)value));
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0000317B File Offset: 0x0000137B
		[ExcludeFromCodeCoverage]
		void IList.Insert(int index, object value)
		{
			throw new NotSupportedException();
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000F2 RID: 242 RVA: 0x00003182 File Offset: 0x00001382
		[ExcludeFromCodeCoverage]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		bool IList.IsFixedSize
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000F3 RID: 243 RVA: 0x00003182 File Offset: 0x00001382
		[ExcludeFromCodeCoverage]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		bool IList.IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000F4 RID: 244 RVA: 0x00003E6C File Offset: 0x0000206C
		[ExcludeFromCodeCoverage]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		int ICollection.Count
		{
			get
			{
				ImmutableArray<T> immutableArray = this;
				immutableArray.ThrowInvalidOperationIfNotInitialized();
				return immutableArray.Length;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000F5 RID: 245 RVA: 0x00003182 File Offset: 0x00001382
		[ExcludeFromCodeCoverage]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		bool ICollection.IsSynchronized
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000F6 RID: 246 RVA: 0x0000317B File Offset: 0x0000137B
		[ExcludeFromCodeCoverage]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		object ICollection.SyncRoot
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x0000317B File Offset: 0x0000137B
		[ExcludeFromCodeCoverage]
		void IList.Remove(object value)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x0000317B File Offset: 0x0000137B
		[ExcludeFromCodeCoverage]
		void IList.RemoveAt(int index)
		{
			throw new NotSupportedException();
		}

		// Token: 0x1700002A RID: 42
		[ExcludeFromCodeCoverage]
		object IList.this[int index]
		{
			get
			{
				ImmutableArray<T> immutableArray = this;
				immutableArray.ThrowInvalidOperationIfNotInitialized();
				return immutableArray[index];
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00003EB8 File Offset: 0x000020B8
		[ExcludeFromCodeCoverage]
		void ICollection.CopyTo(Array array, int index)
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowInvalidOperationIfNotInitialized();
			Array.Copy(immutableArray.array, 0, array, index, immutableArray.Length);
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00003EE8 File Offset: 0x000020E8
		bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
		{
			ImmutableArray<T> immutableArray = this;
			Array array = other as Array;
			if (array == null)
			{
				IImmutableArray immutableArray2 = other as IImmutableArray;
				if (immutableArray2 != null)
				{
					array = immutableArray2.Array;
					if (immutableArray.array == null && array == null)
					{
						return true;
					}
					if (immutableArray.array == null)
					{
						return false;
					}
				}
			}
			IStructuralEquatable structuralEquatable = immutableArray.array;
			return structuralEquatable.Equals(array, comparer);
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00003F40 File Offset: 0x00002140
		int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
		{
			ImmutableArray<T> immutableArray = this;
			IStructuralEquatable structuralEquatable = immutableArray.array;
			if (structuralEquatable == null)
			{
				return immutableArray.GetHashCode();
			}
			return structuralEquatable.GetHashCode(comparer);
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00003F74 File Offset: 0x00002174
		int IStructuralComparable.CompareTo(object other, IComparer comparer)
		{
			ImmutableArray<T> immutableArray = this;
			Array array = other as Array;
			if (array == null)
			{
				IImmutableArray immutableArray2 = other as IImmutableArray;
				if (immutableArray2 != null)
				{
					array = immutableArray2.Array;
					if (immutableArray.array == null && array == null)
					{
						return 0;
					}
					if (immutableArray.array == null ^ array == null)
					{
						throw new ArgumentException(SR.ArrayInitializedStateNotEqual, "other");
					}
				}
			}
			if (array != null)
			{
				IStructuralComparable structuralComparable = immutableArray.array;
				return structuralComparable.CompareTo(array, comparer);
			}
			throw new ArgumentException(SR.ArrayLengthsNotEqual, "other");
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00003FF4 File Offset: 0x000021F4
		private ImmutableArray<T> RemoveAtRange(ICollection<int> indicesToRemove)
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowNullRefIfNotInitialized();
			Requires.NotNull<ICollection<int>>(indicesToRemove, "indicesToRemove");
			if (indicesToRemove.Count == 0)
			{
				return immutableArray;
			}
			T[] array = new T[immutableArray.Length - indicesToRemove.Count];
			int num = 0;
			int num2 = 0;
			int num3 = -1;
			foreach (int num4 in indicesToRemove)
			{
				int num5 = (num3 == -1) ? num4 : (num4 - num3 - 1);
				Array.Copy(immutableArray.array, num + num2, array, num, num5);
				num2++;
				num += num5;
				num3 = num4;
			}
			Array.Copy(immutableArray.array, num + num2, array, num, immutableArray.Length - (num + num2));
			return new ImmutableArray<T>(array);
		}

		// Token: 0x06000100 RID: 256 RVA: 0x000040CC File Offset: 0x000022CC
		internal ImmutableArray(T[] items)
		{
			this.array = items;
		}

		// Token: 0x06000101 RID: 257 RVA: 0x000040D5 File Offset: 0x000022D5
		[NonVersionable]
		public static bool operator ==(ImmutableArray<T> left, ImmutableArray<T> right)
		{
			return left.Equals(right);
		}

		// Token: 0x06000102 RID: 258 RVA: 0x000040DF File Offset: 0x000022DF
		[NonVersionable]
		public static bool operator !=(ImmutableArray<T> left, ImmutableArray<T> right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06000103 RID: 259 RVA: 0x000040EC File Offset: 0x000022EC
		public static bool operator ==(ImmutableArray<T>? left, ImmutableArray<T>? right)
		{
			return left.GetValueOrDefault().Equals(right.GetValueOrDefault());
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00004110 File Offset: 0x00002310
		public static bool operator !=(ImmutableArray<T>? left, ImmutableArray<T>? right)
		{
			return !left.GetValueOrDefault().Equals(right.GetValueOrDefault());
		}

		// Token: 0x1700002B RID: 43
		public T this[int index]
		{
			[NonVersionable]
			get
			{
				return this.array[index];
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000106 RID: 262 RVA: 0x00004144 File Offset: 0x00002344
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool IsEmpty
		{
			[NonVersionable]
			get
			{
				return this.Length == 0;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000107 RID: 263 RVA: 0x0000414F File Offset: 0x0000234F
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int Length
		{
			[NonVersionable]
			get
			{
				return this.array.Length;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000108 RID: 264 RVA: 0x00004159 File Offset: 0x00002359
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool IsDefault
		{
			get
			{
				return this.array == null;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000109 RID: 265 RVA: 0x00004164 File Offset: 0x00002364
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool IsDefaultOrEmpty
		{
			get
			{
				ImmutableArray<T> immutableArray = this;
				return immutableArray.array == null || immutableArray.array.Length == 0;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x0600010A RID: 266 RVA: 0x0000418C File Offset: 0x0000238C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		Array IImmutableArray.Array
		{
			get
			{
				return this.array;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x0600010B RID: 267 RVA: 0x00004194 File Offset: 0x00002394
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string DebuggerDisplay
		{
			get
			{
				ImmutableArray<T> immutableArray = this;
				if (!immutableArray.IsDefault)
				{
					return string.Format(CultureInfo.CurrentCulture, "Length = {0}", new object[]
					{
						immutableArray.Length
					});
				}
				return "Uninitialized";
			}
		}

		// Token: 0x0600010C RID: 268 RVA: 0x000041DC File Offset: 0x000023DC
		public void CopyTo(T[] destination)
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowNullRefIfNotInitialized();
			Array.Copy(immutableArray.array, 0, destination, 0, immutableArray.Length);
		}

		// Token: 0x0600010D RID: 269 RVA: 0x0000420C File Offset: 0x0000240C
		public void CopyTo(T[] destination, int destinationIndex)
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowNullRefIfNotInitialized();
			Array.Copy(immutableArray.array, 0, destination, destinationIndex, immutableArray.Length);
		}

		// Token: 0x0600010E RID: 270 RVA: 0x0000423C File Offset: 0x0000243C
		public void CopyTo(int sourceIndex, T[] destination, int destinationIndex, int length)
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowNullRefIfNotInitialized();
			Array.Copy(immutableArray.array, sourceIndex, destination, destinationIndex, length);
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00004268 File Offset: 0x00002468
		public ImmutableArray<T>.Builder ToBuilder()
		{
			ImmutableArray<T> items = this;
			if (items.Length == 0)
			{
				return new ImmutableArray<T>.Builder();
			}
			ImmutableArray<T>.Builder builder = new ImmutableArray<T>.Builder(items.Length);
			builder.AddRange(items);
			return builder;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x000042A0 File Offset: 0x000024A0
		public ImmutableArray<T>.Enumerator GetEnumerator()
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowNullRefIfNotInitialized();
			return new ImmutableArray<T>.Enumerator(immutableArray.array);
		}

		// Token: 0x06000111 RID: 273 RVA: 0x000042C8 File Offset: 0x000024C8
		public override int GetHashCode()
		{
			ImmutableArray<T> immutableArray = this;
			if (immutableArray.array != null)
			{
				return immutableArray.array.GetHashCode();
			}
			return 0;
		}

		// Token: 0x06000112 RID: 274 RVA: 0x000042F4 File Offset: 0x000024F4
		public override bool Equals(object obj)
		{
			IImmutableArray immutableArray = obj as IImmutableArray;
			return immutableArray != null && this.array == immutableArray.Array;
		}

		// Token: 0x06000113 RID: 275 RVA: 0x0000431B File Offset: 0x0000251B
		[NonVersionable]
		public bool Equals(ImmutableArray<T> other)
		{
			return this.array == other.array;
		}

		// Token: 0x06000114 RID: 276 RVA: 0x0000432B File Offset: 0x0000252B
		public static ImmutableArray<T> CastUp<TDerived>(ImmutableArray<TDerived> items) where TDerived : class, T
		{
			return new ImmutableArray<T>(items.array);
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00004338 File Offset: 0x00002538
		public ImmutableArray<TOther> CastArray<TOther>() where TOther : class
		{
			return new ImmutableArray<TOther>((TOther[])this.array);
		}

		// Token: 0x06000116 RID: 278 RVA: 0x0000434A File Offset: 0x0000254A
		public ImmutableArray<TOther> As<TOther>() where TOther : class
		{
			return new ImmutableArray<TOther>(this.array as TOther[]);
		}

		// Token: 0x06000117 RID: 279 RVA: 0x0000435C File Offset: 0x0000255C
		IEnumerator<T> IEnumerable<!0>.GetEnumerator()
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowInvalidOperationIfNotInitialized();
			return ImmutableArray<T>.EnumeratorObject.Create(immutableArray.array);
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00004384 File Offset: 0x00002584
		IEnumerator IEnumerable.GetEnumerator()
		{
			ImmutableArray<T> immutableArray = this;
			immutableArray.ThrowInvalidOperationIfNotInitialized();
			return ImmutableArray<T>.EnumeratorObject.Create(immutableArray.array);
		}

		// Token: 0x06000119 RID: 281 RVA: 0x000043AC File Offset: 0x000025AC
		internal void ThrowNullRefIfNotInitialized()
		{
			int num = this.array.Length;
		}

		// Token: 0x0600011A RID: 282 RVA: 0x000043C2 File Offset: 0x000025C2
		private void ThrowInvalidOperationIfNotInitialized()
		{
			if (this.IsDefault)
			{
				throw new InvalidOperationException(SR.InvalidOperationOnDefaultArray);
			}
		}

		// Token: 0x0400000A RID: 10
		public static readonly ImmutableArray<T> Empty = new ImmutableArray<T>(new T[0]);

		// Token: 0x0400000B RID: 11
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		internal T[] array;

		// Token: 0x02000041 RID: 65
		[DebuggerDisplay("Count = {Count}")]
		[DebuggerTypeProxy(typeof(ImmutableArrayBuilderDebuggerProxy<>))]
		public sealed class Builder : IList<!0>, ICollection<!0>, IEnumerable<!0>, IEnumerable, IReadOnlyList<!0>, IReadOnlyCollection<!0>
		{
			// Token: 0x06000384 RID: 900 RVA: 0x0000966F File Offset: 0x0000786F
			internal Builder(int capacity)
			{
				Requires.Range(capacity >= 0, "capacity", null);
				this._elements = new T[capacity];
				this._count = 0;
			}

			// Token: 0x06000385 RID: 901 RVA: 0x0000969C File Offset: 0x0000789C
			internal Builder() : this(8)
			{
			}

			// Token: 0x1700009B RID: 155
			// (get) Token: 0x06000386 RID: 902 RVA: 0x000096A5 File Offset: 0x000078A5
			// (set) Token: 0x06000387 RID: 903 RVA: 0x000096B0 File Offset: 0x000078B0
			public int Capacity
			{
				get
				{
					return this._elements.Length;
				}
				set
				{
					if (value < this._count)
					{
						throw new ArgumentException(SR.CapacityMustBeGreaterThanOrEqualToCount, "value");
					}
					if (value != this._elements.Length)
					{
						if (value > 0)
						{
							T[] array = new T[value];
							if (this._count > 0)
							{
								Array.Copy(this._elements, 0, array, 0, this._count);
							}
							this._elements = array;
							return;
						}
						this._elements = ImmutableArray<T>.Empty.array;
					}
				}
			}

			// Token: 0x1700009C RID: 156
			// (get) Token: 0x06000388 RID: 904 RVA: 0x00009721 File Offset: 0x00007921
			// (set) Token: 0x06000389 RID: 905 RVA: 0x0000972C File Offset: 0x0000792C
			public int Count
			{
				get
				{
					return this._count;
				}
				set
				{
					Requires.Range(value >= 0, "value", null);
					if (value < this._count)
					{
						if (this._count - value > 64)
						{
							Array.Clear(this._elements, value, this._count - value);
						}
						else
						{
							for (int i = value; i < this.Count; i++)
							{
								this._elements[i] = default(T);
							}
						}
					}
					else if (value > this._count)
					{
						this.EnsureCapacity(value);
					}
					this._count = value;
				}
			}

			// Token: 0x1700009D RID: 157
			public T this[int index]
			{
				get
				{
					if (index >= this.Count)
					{
						throw new IndexOutOfRangeException();
					}
					return this._elements[index];
				}
				set
				{
					if (index >= this.Count)
					{
						throw new IndexOutOfRangeException();
					}
					this._elements[index] = value;
				}
			}

			// Token: 0x1700009E RID: 158
			// (get) Token: 0x0600038C RID: 908 RVA: 0x0000206B File Offset: 0x0000026B
			bool ICollection<!0>.IsReadOnly
			{
				get
				{
					return false;
				}
			}

			// Token: 0x0600038D RID: 909 RVA: 0x000097F0 File Offset: 0x000079F0
			public ImmutableArray<T> ToImmutable()
			{
				return new ImmutableArray<T>(this.ToArray());
			}

			// Token: 0x0600038E RID: 910 RVA: 0x00009800 File Offset: 0x00007A00
			public ImmutableArray<T> MoveToImmutable()
			{
				if (this.Capacity != this.Count)
				{
					throw new InvalidOperationException(SR.CapacityMustEqualCountOnMove);
				}
				T[] elements = this._elements;
				this._elements = ImmutableArray<T>.Empty.array;
				this._count = 0;
				return new ImmutableArray<T>(elements);
			}

			// Token: 0x0600038F RID: 911 RVA: 0x0000984A File Offset: 0x00007A4A
			public void Clear()
			{
				this.Count = 0;
			}

			// Token: 0x06000390 RID: 912 RVA: 0x00009854 File Offset: 0x00007A54
			public void Insert(int index, T item)
			{
				Requires.Range(index >= 0 && index <= this.Count, "index", null);
				this.EnsureCapacity(this.Count + 1);
				if (index < this.Count)
				{
					Array.Copy(this._elements, index, this._elements, index + 1, this.Count - index);
				}
				this._count++;
				this._elements[index] = item;
			}

			// Token: 0x06000391 RID: 913 RVA: 0x000098D0 File Offset: 0x00007AD0
			public void Add(T item)
			{
				this.EnsureCapacity(this.Count + 1);
				T[] elements = this._elements;
				int count = this._count;
				this._count = count + 1;
				elements[count] = item;
			}

			// Token: 0x06000392 RID: 914 RVA: 0x00009908 File Offset: 0x00007B08
			public void AddRange(IEnumerable<T> items)
			{
				Requires.NotNull<IEnumerable<T>>(items, "items");
				int num;
				if (items.TryGetCount(out num))
				{
					this.EnsureCapacity(this.Count + num);
					if (items.TryCopyTo(this._elements, this._count))
					{
						this._count += num;
						return;
					}
				}
				foreach (T item in items)
				{
					this.Add(item);
				}
			}

			// Token: 0x06000393 RID: 915 RVA: 0x00009998 File Offset: 0x00007B98
			public void AddRange(params T[] items)
			{
				Requires.NotNull<T[]>(items, "items");
				int count = this.Count;
				this.Count += items.Length;
				Array.Copy(items, 0, this._elements, count, items.Length);
			}

			// Token: 0x06000394 RID: 916 RVA: 0x000099D8 File Offset: 0x00007BD8
			public void AddRange<TDerived>(TDerived[] items) where TDerived : T
			{
				Requires.NotNull<TDerived[]>(items, "items");
				int count = this.Count;
				this.Count += items.Length;
				Array.Copy(items, 0, this._elements, count, items.Length);
			}

			// Token: 0x06000395 RID: 917 RVA: 0x00009A18 File Offset: 0x00007C18
			public void AddRange(T[] items, int length)
			{
				Requires.NotNull<T[]>(items, "items");
				Requires.Range(length >= 0 && length <= items.Length, "length", null);
				int count = this.Count;
				this.Count += length;
				Array.Copy(items, 0, this._elements, count, length);
			}

			// Token: 0x06000396 RID: 918 RVA: 0x00009A6F File Offset: 0x00007C6F
			public void AddRange(ImmutableArray<T> items)
			{
				this.AddRange(items, items.Length);
			}

			// Token: 0x06000397 RID: 919 RVA: 0x00009A7F File Offset: 0x00007C7F
			public void AddRange(ImmutableArray<T> items, int length)
			{
				Requires.Range(length >= 0, "length", null);
				if (items.array != null)
				{
					this.AddRange(items.array, length);
				}
			}

			// Token: 0x06000398 RID: 920 RVA: 0x00009AA8 File Offset: 0x00007CA8
			public void AddRange<TDerived>(ImmutableArray<TDerived> items) where TDerived : T
			{
				if (items.array != null)
				{
					this.AddRange<TDerived>(items.array);
				}
			}

			// Token: 0x06000399 RID: 921 RVA: 0x00009ABE File Offset: 0x00007CBE
			public void AddRange(ImmutableArray<T>.Builder items)
			{
				Requires.NotNull<ImmutableArray<T>.Builder>(items, "items");
				this.AddRange(items._elements, items.Count);
			}

			// Token: 0x0600039A RID: 922 RVA: 0x00009ADD File Offset: 0x00007CDD
			public void AddRange<TDerived>(ImmutableArray<TDerived>.Builder items) where TDerived : T
			{
				Requires.NotNull<ImmutableArray<TDerived>.Builder>(items, "items");
				this.AddRange<TDerived>(items._elements, items.Count);
			}

			// Token: 0x0600039B RID: 923 RVA: 0x00009AFC File Offset: 0x00007CFC
			public bool Remove(T element)
			{
				int num = this.IndexOf(element);
				if (num >= 0)
				{
					this.RemoveAt(num);
					return true;
				}
				return false;
			}

			// Token: 0x0600039C RID: 924 RVA: 0x00009B20 File Offset: 0x00007D20
			public void RemoveAt(int index)
			{
				Requires.Range(index >= 0 && index < this.Count, "index", null);
				if (index < this.Count - 1)
				{
					Array.Copy(this._elements, index + 1, this._elements, index, this.Count - index - 1);
				}
				int count = this.Count;
				this.Count = count - 1;
			}

			// Token: 0x0600039D RID: 925 RVA: 0x00009B82 File Offset: 0x00007D82
			public bool Contains(T item)
			{
				return this.IndexOf(item) >= 0;
			}

			// Token: 0x0600039E RID: 926 RVA: 0x00009B94 File Offset: 0x00007D94
			public T[] ToArray()
			{
				if (this.Count == 0)
				{
					return ImmutableArray<T>.Empty.array;
				}
				T[] array = new T[this.Count];
				Array.Copy(this._elements, 0, array, 0, this.Count);
				return array;
			}

			// Token: 0x0600039F RID: 927 RVA: 0x00009BD8 File Offset: 0x00007DD8
			public void CopyTo(T[] array, int index)
			{
				Requires.NotNull<T[]>(array, "array");
				Requires.Range(index >= 0 && index + this.Count <= array.Length, "index", null);
				Array.Copy(this._elements, 0, array, index, this.Count);
			}

			// Token: 0x060003A0 RID: 928 RVA: 0x00009C28 File Offset: 0x00007E28
			private void EnsureCapacity(int capacity)
			{
				if (this._elements.Length < capacity)
				{
					int newSize = Math.Max(this._elements.Length * 2, capacity);
					Array.Resize<T>(ref this._elements, newSize);
				}
			}

			// Token: 0x060003A1 RID: 929 RVA: 0x00009C5D File Offset: 0x00007E5D
			public int IndexOf(T item)
			{
				return this.IndexOf(item, 0, this._count, EqualityComparer<T>.Default);
			}

			// Token: 0x060003A2 RID: 930 RVA: 0x00009C72 File Offset: 0x00007E72
			public int IndexOf(T item, int startIndex)
			{
				return this.IndexOf(item, startIndex, this.Count - startIndex, EqualityComparer<T>.Default);
			}

			// Token: 0x060003A3 RID: 931 RVA: 0x00009C89 File Offset: 0x00007E89
			public int IndexOf(T item, int startIndex, int count)
			{
				return this.IndexOf(item, startIndex, count, EqualityComparer<T>.Default);
			}

			// Token: 0x060003A4 RID: 932 RVA: 0x00009C9C File Offset: 0x00007E9C
			public int IndexOf(T item, int startIndex, int count, IEqualityComparer<T> equalityComparer)
			{
				if (count == 0 && startIndex == 0)
				{
					return -1;
				}
				Requires.Range(startIndex >= 0 && startIndex < this.Count, "startIndex", null);
				Requires.Range(count >= 0 && startIndex + count <= this.Count, "count", null);
				equalityComparer = (equalityComparer ?? EqualityComparer<T>.Default);
				if (equalityComparer == EqualityComparer<T>.Default)
				{
					return Array.IndexOf<T>(this._elements, item, startIndex, count);
				}
				for (int i = startIndex; i < startIndex + count; i++)
				{
					if (equalityComparer.Equals(this._elements[i], item))
					{
						return i;
					}
				}
				return -1;
			}

			// Token: 0x060003A5 RID: 933 RVA: 0x00009D38 File Offset: 0x00007F38
			public int LastIndexOf(T item)
			{
				if (this.Count == 0)
				{
					return -1;
				}
				return this.LastIndexOf(item, this.Count - 1, this.Count, EqualityComparer<T>.Default);
			}

			// Token: 0x060003A6 RID: 934 RVA: 0x00009D5E File Offset: 0x00007F5E
			public int LastIndexOf(T item, int startIndex)
			{
				if (this.Count == 0 && startIndex == 0)
				{
					return -1;
				}
				Requires.Range(startIndex >= 0 && startIndex < this.Count, "startIndex", null);
				return this.LastIndexOf(item, startIndex, startIndex + 1, EqualityComparer<T>.Default);
			}

			// Token: 0x060003A7 RID: 935 RVA: 0x00009D98 File Offset: 0x00007F98
			public int LastIndexOf(T item, int startIndex, int count)
			{
				return this.LastIndexOf(item, startIndex, count, EqualityComparer<T>.Default);
			}

			// Token: 0x060003A8 RID: 936 RVA: 0x00009DA8 File Offset: 0x00007FA8
			public int LastIndexOf(T item, int startIndex, int count, IEqualityComparer<T> equalityComparer)
			{
				if (count == 0 && startIndex == 0)
				{
					return -1;
				}
				Requires.Range(startIndex >= 0 && startIndex < this.Count, "startIndex", null);
				Requires.Range(count >= 0 && startIndex - count + 1 >= 0, "count", null);
				equalityComparer = (equalityComparer ?? EqualityComparer<T>.Default);
				if (equalityComparer == EqualityComparer<T>.Default)
				{
					return Array.LastIndexOf<T>(this._elements, item, startIndex, count);
				}
				for (int i = startIndex; i >= startIndex - count + 1; i--)
				{
					if (equalityComparer.Equals(item, this._elements[i]))
					{
						return i;
					}
				}
				return -1;
			}

			// Token: 0x060003A9 RID: 937 RVA: 0x00009E44 File Offset: 0x00008044
			public void Reverse()
			{
				int i = 0;
				int num = this._count - 1;
				T[] elements = this._elements;
				while (i < num)
				{
					T t = elements[i];
					elements[i] = elements[num];
					elements[num] = t;
					i++;
					num--;
				}
			}

			// Token: 0x060003AA RID: 938 RVA: 0x00009E8F File Offset: 0x0000808F
			public void Sort()
			{
				if (this.Count > 1)
				{
					Array.Sort<T>(this._elements, 0, this.Count, Comparer<T>.Default);
				}
			}

			// Token: 0x060003AB RID: 939 RVA: 0x00009EB1 File Offset: 0x000080B1
			public void Sort(Comparison<T> comparison)
			{
				Requires.NotNull<Comparison<T>>(comparison, "comparison");
				if (this.Count > 1)
				{
					Array.Sort<T>(this._elements, 0, this._count, Comparer<T>.Create(comparison));
				}
			}

			// Token: 0x060003AC RID: 940 RVA: 0x00009EDF File Offset: 0x000080DF
			public void Sort(IComparer<T> comparer)
			{
				if (this.Count > 1)
				{
					Array.Sort<T>(this._elements, 0, this._count, comparer);
				}
			}

			// Token: 0x060003AD RID: 941 RVA: 0x00009F00 File Offset: 0x00008100
			public void Sort(int index, int count, IComparer<T> comparer)
			{
				Requires.Range(index >= 0, "index", null);
				Requires.Range(count >= 0 && index + count <= this.Count, "count", null);
				if (count > 1)
				{
					Array.Sort<T>(this._elements, index, count, comparer);
				}
			}

			// Token: 0x060003AE RID: 942 RVA: 0x00009F51 File Offset: 0x00008151
			public IEnumerator<T> GetEnumerator()
			{
				int num;
				for (int i = 0; i < this.Count; i = num + 1)
				{
					yield return this[i];
					num = i;
				}
				yield break;
			}

			// Token: 0x060003AF RID: 943 RVA: 0x00009F60 File Offset: 0x00008160
			IEnumerator<T> IEnumerable<!0>.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x060003B0 RID: 944 RVA: 0x00009F60 File Offset: 0x00008160
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x060003B1 RID: 945 RVA: 0x00009F68 File Offset: 0x00008168
			private void AddRange<TDerived>(TDerived[] items, int length) where TDerived : T
			{
				this.EnsureCapacity(this.Count + length);
				int count = this.Count;
				this.Count += length;
				T[] elements = this._elements;
				for (int i = 0; i < length; i++)
				{
					elements[count + i] = (T)((object)items[i]);
				}
			}

			// Token: 0x04000050 RID: 80
			private T[] _elements;

			// Token: 0x04000051 RID: 81
			private int _count;
		}

		// Token: 0x02000042 RID: 66
		public struct Enumerator
		{
			// Token: 0x060003B2 RID: 946 RVA: 0x00009FC5 File Offset: 0x000081C5
			internal Enumerator(T[] array)
			{
				this._array = array;
				this._index = -1;
			}

			// Token: 0x1700009F RID: 159
			// (get) Token: 0x060003B3 RID: 947 RVA: 0x00009FD5 File Offset: 0x000081D5
			public T Current
			{
				get
				{
					return this._array[this._index];
				}
			}

			// Token: 0x060003B4 RID: 948 RVA: 0x00009FE8 File Offset: 0x000081E8
			public bool MoveNext()
			{
				int num = this._index + 1;
				this._index = num;
				return num < this._array.Length;
			}

			// Token: 0x04000052 RID: 82
			private readonly T[] _array;

			// Token: 0x04000053 RID: 83
			private int _index;
		}

		// Token: 0x02000043 RID: 67
		private class EnumeratorObject : IEnumerator<!0>, IEnumerator, IDisposable
		{
			// Token: 0x060003B5 RID: 949 RVA: 0x0000A010 File Offset: 0x00008210
			private EnumeratorObject(T[] array)
			{
				this._index = -1;
				this._array = array;
			}

			// Token: 0x170000A0 RID: 160
			// (get) Token: 0x060003B6 RID: 950 RVA: 0x0000A026 File Offset: 0x00008226
			public T Current
			{
				get
				{
					if (this._index < this._array.Length)
					{
						return this._array[this._index];
					}
					throw new InvalidOperationException();
				}
			}

			// Token: 0x170000A1 RID: 161
			// (get) Token: 0x060003B7 RID: 951 RVA: 0x0000A04F File Offset: 0x0000824F
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x060003B8 RID: 952 RVA: 0x0000A05C File Offset: 0x0000825C
			public bool MoveNext()
			{
				int num = this._index + 1;
				int num2 = this._array.Length;
				if (num <= num2)
				{
					this._index = num;
					return num < num2;
				}
				return false;
			}

			// Token: 0x060003B9 RID: 953 RVA: 0x0000A08C File Offset: 0x0000828C
			void IEnumerator.Reset()
			{
				this._index = -1;
			}

			// Token: 0x060003BA RID: 954 RVA: 0x0000A095 File Offset: 0x00008295
			public void Dispose()
			{
			}

			// Token: 0x060003BB RID: 955 RVA: 0x0000A097 File Offset: 0x00008297
			internal static IEnumerator<T> Create(T[] array)
			{
				if (array.Length != 0)
				{
					return new ImmutableArray<T>.EnumeratorObject(array);
				}
				return ImmutableArray<T>.EnumeratorObject.s_EmptyEnumerator;
			}

			// Token: 0x04000054 RID: 84
			private static readonly IEnumerator<T> s_EmptyEnumerator = new ImmutableArray<T>.EnumeratorObject(ImmutableArray<T>.Empty.array);

			// Token: 0x04000055 RID: 85
			private readonly T[] _array;

			// Token: 0x04000056 RID: 86
			private int _index;
		}
	}
}
