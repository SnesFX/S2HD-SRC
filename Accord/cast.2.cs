using System;

namespace Accord
{
	// Token: 0x02000022 RID: 34
	internal struct cast<T>
	{
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x00003711 File Offset: 0x00002711
		public T Value
		{
			get
			{
				return this.value;
			}
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00003719 File Offset: 0x00002719
		public cast(object value)
		{
			this.value = (T)((object)Convert.ChangeType(value, typeof(T)));
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00003736 File Offset: 0x00002736
		public static implicit operator cast<T>(double value)
		{
			return new cast<T>(value);
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00003743 File Offset: 0x00002743
		public static implicit operator cast<T>(float value)
		{
			return new cast<T>(value);
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00003750 File Offset: 0x00002750
		public static implicit operator cast<T>(decimal value)
		{
			return new cast<T>(value);
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0000375D File Offset: 0x0000275D
		public static implicit operator cast<T>(byte value)
		{
			return new cast<T>(value);
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x0000376A File Offset: 0x0000276A
		public static implicit operator cast<T>(sbyte value)
		{
			return new cast<T>(value);
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00003777 File Offset: 0x00002777
		public static implicit operator cast<T>(short value)
		{
			return new cast<T>(value);
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00003784 File Offset: 0x00002784
		public static implicit operator cast<T>(ushort value)
		{
			return new cast<T>(value);
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00003791 File Offset: 0x00002791
		public static implicit operator cast<T>(int value)
		{
			return new cast<T>(value);
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000379E File Offset: 0x0000279E
		public static implicit operator cast<T>(uint value)
		{
			return new cast<T>(value);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x000037AB File Offset: 0x000027AB
		public static implicit operator cast<T>(long value)
		{
			return new cast<T>(value);
		}

		// Token: 0x060000EC RID: 236 RVA: 0x000037B8 File Offset: 0x000027B8
		public static implicit operator cast<T>(ulong value)
		{
			return new cast<T>(value);
		}

		// Token: 0x060000ED RID: 237 RVA: 0x000037C5 File Offset: 0x000027C5
		public static implicit operator T(cast<T> value)
		{
			return value.Value;
		}

		// Token: 0x04000016 RID: 22
		private T value;
	}
}
