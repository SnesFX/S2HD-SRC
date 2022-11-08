using System;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B94 RID: 2964
	internal struct Fixed24
	{
		// Token: 0x06005C3D RID: 23613 RVA: 0x000F9F3C File Offset: 0x000F813C
		public unsafe static implicit operator double(Fixed24 n)
		{
			long num = 4807592602218004480L + (long)n.Value;
			double num2 = *(double*)(&num);
			return num2 - 26388279066624.0;
		}

		// Token: 0x06005C3E RID: 23614 RVA: 0x000F9F6C File Offset: 0x000F816C
		public static implicit operator float(Fixed24 n)
		{
			return (float)n;
		}

		// Token: 0x06005C3F RID: 23615 RVA: 0x000F9F78 File Offset: 0x000F8178
		public static explicit operator int(Fixed24 n)
		{
			return n.Value >> 8;
		}

		// Token: 0x0400B8FA RID: 47354
		internal readonly int Value;
	}
}
