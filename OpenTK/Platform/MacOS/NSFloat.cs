using System;

namespace OpenTK.Platform.MacOS
{
	// Token: 0x02000B61 RID: 2913
	internal struct NSFloat
	{
		// Token: 0x06005B55 RID: 23381 RVA: 0x000F7C84 File Offset: 0x000F5E84
		public unsafe static implicit operator NSFloat(float v)
		{
			NSFloat result;
			if (IntPtr.Size == 4)
			{
				result.value = *(IntPtr*)(&v);
			}
			else
			{
				double num = (double)v;
				result.value = *(IntPtr*)(&num);
			}
			return result;
		}

		// Token: 0x06005B56 RID: 23382 RVA: 0x000F7CC0 File Offset: 0x000F5EC0
		public unsafe static implicit operator NSFloat(double v)
		{
			NSFloat result;
			if (IntPtr.Size == 4)
			{
				float num = (float)v;
				result.value = *(IntPtr*)(&num);
			}
			else
			{
				result.value = *(IntPtr*)(&v);
			}
			return result;
		}

		// Token: 0x06005B57 RID: 23383 RVA: 0x000F7CFC File Offset: 0x000F5EFC
		public unsafe static implicit operator float(NSFloat f)
		{
			if (IntPtr.Size == 4)
			{
				return *(float*)(&f.value);
			}
			return (float)(*(double*)(&f.value));
		}

		// Token: 0x06005B58 RID: 23384 RVA: 0x000F7D1C File Offset: 0x000F5F1C
		public unsafe static implicit operator double(NSFloat f)
		{
			if (IntPtr.Size == 4)
			{
				return (double)(*(float*)(&f.value));
			}
			return (double)(*(float*)(&f.value));
		}

		// Token: 0x0400B7DB RID: 47067
		private IntPtr value;
	}
}
