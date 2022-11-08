using System;
using System.Collections.Generic;

namespace System.Collections.Immutable
{
	// Token: 0x02000014 RID: 20
	public interface IImmutableSet<T> : IReadOnlyCollection<T>, IEnumerable<T>, IEnumerable
	{
		// Token: 0x06000085 RID: 133
		IImmutableSet<T> Clear();

		// Token: 0x06000086 RID: 134
		bool Contains(T value);

		// Token: 0x06000087 RID: 135
		IImmutableSet<T> Add(T value);

		// Token: 0x06000088 RID: 136
		IImmutableSet<T> Remove(T value);

		// Token: 0x06000089 RID: 137
		bool TryGetValue(T equalValue, out T actualValue);

		// Token: 0x0600008A RID: 138
		IImmutableSet<T> Intersect(IEnumerable<T> other);

		// Token: 0x0600008B RID: 139
		IImmutableSet<T> Except(IEnumerable<T> other);

		// Token: 0x0600008C RID: 140
		IImmutableSet<T> SymmetricExcept(IEnumerable<T> other);

		// Token: 0x0600008D RID: 141
		IImmutableSet<T> Union(IEnumerable<T> other);

		// Token: 0x0600008E RID: 142
		bool SetEquals(IEnumerable<T> other);

		// Token: 0x0600008F RID: 143
		bool IsProperSubsetOf(IEnumerable<T> other);

		// Token: 0x06000090 RID: 144
		bool IsProperSupersetOf(IEnumerable<T> other);

		// Token: 0x06000091 RID: 145
		bool IsSubsetOf(IEnumerable<T> other);

		// Token: 0x06000092 RID: 146
		bool IsSupersetOf(IEnumerable<T> other);

		// Token: 0x06000093 RID: 147
		bool Overlaps(IEnumerable<T> other);
	}
}
