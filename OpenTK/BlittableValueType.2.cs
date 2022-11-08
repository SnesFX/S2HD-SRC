using System;

namespace OpenTK
{
	// Token: 0x02000057 RID: 87
	public static class BlittableValueType
	{
		// Token: 0x0600062F RID: 1583 RVA: 0x000169D4 File Offset: 0x00014BD4
		public static bool Check<T>(T type)
		{
			return BlittableValueType<T>.Check();
		}

		// Token: 0x06000630 RID: 1584 RVA: 0x000169DC File Offset: 0x00014BDC
		[CLSCompliant(false)]
		public static bool Check<T>(T[] type)
		{
			return BlittableValueType<T>.Check();
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x000169E4 File Offset: 0x00014BE4
		[CLSCompliant(false)]
		public static bool Check<T>(T[,] type)
		{
			return BlittableValueType<T>.Check();
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x000169EC File Offset: 0x00014BEC
		[CLSCompliant(false)]
		public static bool Check<T>(T[,,] type)
		{
			return BlittableValueType<T>.Check();
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x000169F4 File Offset: 0x00014BF4
		[CLSCompliant(false)]
		public static bool Check<T>(T[][] type)
		{
			return BlittableValueType<T>.Check();
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x000169FC File Offset: 0x00014BFC
		public static int StrideOf<T>(T type)
		{
			if (!BlittableValueType.Check<T>(type))
			{
				throw new ArgumentException("type");
			}
			return BlittableValueType<T>.Stride;
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x00016A18 File Offset: 0x00014C18
		[CLSCompliant(false)]
		public static int StrideOf<T>(T[] type)
		{
			if (!BlittableValueType.Check<T>(type))
			{
				throw new ArgumentException("type");
			}
			return BlittableValueType<T>.Stride;
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x00016A34 File Offset: 0x00014C34
		[CLSCompliant(false)]
		public static int StrideOf<T>(T[,] type)
		{
			if (!BlittableValueType.Check<T>(type))
			{
				throw new ArgumentException("type");
			}
			return BlittableValueType<T>.Stride;
		}

		// Token: 0x06000637 RID: 1591 RVA: 0x00016A50 File Offset: 0x00014C50
		[CLSCompliant(false)]
		public static int StrideOf<T>(T[,,] type)
		{
			if (!BlittableValueType.Check<T>(type))
			{
				throw new ArgumentException("type");
			}
			return BlittableValueType<T>.Stride;
		}
	}
}
