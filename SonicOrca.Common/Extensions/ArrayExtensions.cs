using System;
using System.Collections.Generic;

namespace SonicOrca.Extensions
{
	// Token: 0x02000007 RID: 7
	public static class ArrayExtensions
	{
		// Token: 0x0600000C RID: 12 RVA: 0x00002163 File Offset: 0x00000363
		public static IEnumerator<T> GetEnumeratorGeneric<T>(this T[] array)
		{
			return array.GetEnumerator();
		}

		// Token: 0x0600000D RID: 13 RVA: 0x0000216C File Offset: 0x0000036C
		public static T[] GetRange<T>(this T[] data, int index, int length)
		{
			T[] array = new T[length];
			Array.Copy(data, index, array, 0, length);
			return array;
		}
	}
}
