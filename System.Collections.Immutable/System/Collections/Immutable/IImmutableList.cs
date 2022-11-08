using System;
using System.Collections.Generic;

namespace System.Collections.Immutable
{
	// Token: 0x02000011 RID: 17
	public interface IImmutableList<T> : IReadOnlyList<T>, IReadOnlyCollection<T>, IEnumerable<T>, IEnumerable
	{
		// Token: 0x0600005E RID: 94
		IImmutableList<T> Clear();

		// Token: 0x0600005F RID: 95
		int IndexOf(T item, int index, int count, IEqualityComparer<T> equalityComparer);

		// Token: 0x06000060 RID: 96
		int LastIndexOf(T item, int index, int count, IEqualityComparer<T> equalityComparer);

		// Token: 0x06000061 RID: 97
		IImmutableList<T> Add(T value);

		// Token: 0x06000062 RID: 98
		IImmutableList<T> AddRange(IEnumerable<T> items);

		// Token: 0x06000063 RID: 99
		IImmutableList<T> Insert(int index, T element);

		// Token: 0x06000064 RID: 100
		IImmutableList<T> InsertRange(int index, IEnumerable<T> items);

		// Token: 0x06000065 RID: 101
		IImmutableList<T> Remove(T value, IEqualityComparer<T> equalityComparer);

		// Token: 0x06000066 RID: 102
		IImmutableList<T> RemoveAll(Predicate<T> match);

		// Token: 0x06000067 RID: 103
		IImmutableList<T> RemoveRange(IEnumerable<T> items, IEqualityComparer<T> equalityComparer);

		// Token: 0x06000068 RID: 104
		IImmutableList<T> RemoveRange(int index, int count);

		// Token: 0x06000069 RID: 105
		IImmutableList<T> RemoveAt(int index);

		// Token: 0x0600006A RID: 106
		IImmutableList<T> SetItem(int index, T value);

		// Token: 0x0600006B RID: 107
		IImmutableList<T> Replace(T oldValue, T newValue, IEqualityComparer<T> equalityComparer);
	}
}
