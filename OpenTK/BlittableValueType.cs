using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace OpenTK
{
	// Token: 0x02000056 RID: 86
	public static class BlittableValueType<T>
	{
		// Token: 0x06000629 RID: 1577 RVA: 0x000168C0 File Offset: 0x00014AC0
		static BlittableValueType()
		{
			if (BlittableValueType<T>.Type.IsValueType && !BlittableValueType<T>.Type.IsGenericType)
			{
				BlittableValueType<T>.stride = Marshal.SizeOf(typeof(T));
			}
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x0600062A RID: 1578 RVA: 0x00016900 File Offset: 0x00014B00
		public static int Stride
		{
			get
			{
				return BlittableValueType<T>.stride;
			}
		}

		// Token: 0x0600062B RID: 1579 RVA: 0x00016908 File Offset: 0x00014B08
		public static bool Check()
		{
			return BlittableValueType<T>.Check(BlittableValueType<T>.Type);
		}

		// Token: 0x0600062C RID: 1580 RVA: 0x00016914 File Offset: 0x00014B14
		public static bool Check(Type type)
		{
			BlittableValueType<T>.CheckStructLayoutAttribute(type);
			return BlittableValueType<T>.CheckType(type);
		}

		// Token: 0x0600062D RID: 1581 RVA: 0x00016924 File Offset: 0x00014B24
		private static bool CheckType(Type type)
		{
			if (type.IsPrimitive)
			{
				return true;
			}
			if (!type.IsValueType)
			{
				return false;
			}
			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (FieldInfo fieldInfo in fields)
			{
				if (!BlittableValueType<T>.CheckType(fieldInfo.FieldType))
				{
					return false;
				}
			}
			return BlittableValueType<T>.Stride != 0;
		}

		// Token: 0x0600062E RID: 1582 RVA: 0x00016988 File Offset: 0x00014B88
		private static bool CheckStructLayoutAttribute(Type type)
		{
			StructLayoutAttribute[] array = (StructLayoutAttribute[])type.GetCustomAttributes(typeof(StructLayoutAttribute), true);
			return array != null && (array == null || array.Length <= 0 || array[0].Value == LayoutKind.Explicit || array[0].Pack == 1);
		}

		// Token: 0x04000195 RID: 405
		private static readonly Type Type = typeof(T);

		// Token: 0x04000196 RID: 406
		private static readonly int stride;
	}
}
