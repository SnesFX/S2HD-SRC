using System;

namespace OpenTK
{
	// Token: 0x02000AF4 RID: 2804
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
	public class SlotAttribute : Attribute
	{
		// Token: 0x0600590E RID: 22798 RVA: 0x000F24C8 File Offset: 0x000F06C8
		public SlotAttribute(int index)
		{
			this.Slot = index;
		}

		// Token: 0x0400B485 RID: 46213
		internal int Slot;
	}
}
