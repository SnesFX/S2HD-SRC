using System;

namespace Accord.Video
{
	// Token: 0x02000003 RID: 3
	internal static class ByteArrayUtils
	{
		// Token: 0x0600001A RID: 26 RVA: 0x000024BC File Offset: 0x000014BC
		public static bool Compare(byte[] array, byte[] needle, int startIndex)
		{
			int num = needle.Length;
			int i = 0;
			int num2 = startIndex;
			while (i < num)
			{
				if (array[num2] != needle[i])
				{
					return false;
				}
				i++;
				num2++;
			}
			return true;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000024EC File Offset: 0x000014EC
		public static int Find(byte[] array, byte[] needle, int startIndex, int sourceLength)
		{
			int num = needle.Length;
			while (sourceLength >= num)
			{
				int num2 = Array.IndexOf<byte>(array, needle[0], startIndex, sourceLength - num + 1);
				if (num2 == -1)
				{
					return -1;
				}
				int num3 = 0;
				int num4 = num2;
				while (num3 < num && array[num4] == needle[num3])
				{
					num3++;
					num4++;
				}
				if (num3 == num)
				{
					return num2;
				}
				sourceLength -= num2 - startIndex + 1;
				startIndex = num2 + 1;
			}
			return -1;
		}
	}
}
