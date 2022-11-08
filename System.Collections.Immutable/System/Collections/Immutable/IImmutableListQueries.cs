using System;
using System.Collections.Generic;

namespace System.Collections.Immutable
{
	// Token: 0x02000012 RID: 18
	internal interface IImmutableListQueries<T> : IReadOnlyList<T>, IReadOnlyCollection<T>, IEnumerable<T>, IEnumerable
	{
		// Token: 0x0600006C RID: 108
		ImmutableList<TOutput> ConvertAll<TOutput>(Func<T, TOutput> converter);

		// Token: 0x0600006D RID: 109
		void ForEach(Action<T> action);

		// Token: 0x0600006E RID: 110
		ImmutableList<T> GetRange(int index, int count);

		// Token: 0x0600006F RID: 111
		void CopyTo(T[] array);

		// Token: 0x06000070 RID: 112
		void CopyTo(T[] array, int arrayIndex);

		// Token: 0x06000071 RID: 113
		void CopyTo(int index, T[] array, int arrayIndex, int count);

		// Token: 0x06000072 RID: 114
		bool Exists(Predicate<T> match);

		// Token: 0x06000073 RID: 115
		T Find(Predicate<T> match);

		// Token: 0x06000074 RID: 116
		ImmutableList<T> FindAll(Predicate<T> match);

		// Token: 0x06000075 RID: 117
		int FindIndex(Predicate<T> match);

		// Token: 0x06000076 RID: 118
		int FindIndex(int startIndex, Predicate<T> match);

		// Token: 0x06000077 RID: 119
		int FindIndex(int startIndex, int count, Predicate<T> match);

		// Token: 0x06000078 RID: 120
		T FindLast(Predicate<T> match);

		// Token: 0x06000079 RID: 121
		int FindLastIndex(Predicate<T> match);

		// Token: 0x0600007A RID: 122
		int FindLastIndex(int startIndex, Predicate<T> match);

		// Token: 0x0600007B RID: 123
		int FindLastIndex(int startIndex, int count, Predicate<T> match);

		// Token: 0x0600007C RID: 124
		bool TrueForAll(Predicate<T> match);

		// Token: 0x0600007D RID: 125
		int BinarySearch(T item);

		// Token: 0x0600007E RID: 126
		int BinarySearch(T item, IComparer<T> comparer);

		// Token: 0x0600007F RID: 127
		int BinarySearch(int index, int count, T item, IComparer<T> comparer);
	}
}
