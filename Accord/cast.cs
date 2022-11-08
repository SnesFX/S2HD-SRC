using System;

namespace Accord
{
	// Token: 0x02000021 RID: 33
	internal struct cast<T, U>
	{
		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060000DC RID: 220 RVA: 0x000036D6 File Offset: 0x000026D6
		public T Value
		{
			get
			{
				return this.value;
			}
		}

		// Token: 0x060000DD RID: 221 RVA: 0x000036DE File Offset: 0x000026DE
		public cast(U value)
		{
			this.value = (T)((object)Convert.ChangeType(value, typeof(T)));
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00003700 File Offset: 0x00002700
		public static implicit operator cast<T, U>(U value)
		{
			return new cast<T, U>(value);
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00003708 File Offset: 0x00002708
		public static implicit operator T(cast<T, U> value)
		{
			return value.Value;
		}

		// Token: 0x04000015 RID: 21
		private T value;
	}
}
