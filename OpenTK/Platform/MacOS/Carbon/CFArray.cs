using System;

namespace OpenTK.Platform.MacOS.Carbon
{
	// Token: 0x02000B48 RID: 2888
	internal struct CFArray
	{
		// Token: 0x170004BF RID: 1215
		// (get) Token: 0x06005AF7 RID: 23287 RVA: 0x000F68D0 File Offset: 0x000F4AD0
		// (set) Token: 0x06005AF8 RID: 23288 RVA: 0x000F68D8 File Offset: 0x000F4AD8
		public IntPtr Ref
		{
			get
			{
				return this.arrayRef;
			}
			set
			{
				this.arrayRef = value;
			}
		}

		// Token: 0x06005AF9 RID: 23289 RVA: 0x000F68E4 File Offset: 0x000F4AE4
		public CFArray(IntPtr reference)
		{
			this.arrayRef = reference;
		}

		// Token: 0x170004C0 RID: 1216
		// (get) Token: 0x06005AFA RID: 23290 RVA: 0x000F68F0 File Offset: 0x000F4AF0
		public int Count
		{
			get
			{
				return CF.CFArrayGetCount(this.arrayRef);
			}
		}

		// Token: 0x170004C1 RID: 1217
		public IntPtr this[int index]
		{
			get
			{
				if (index >= this.Count || index < 0)
				{
					throw new IndexOutOfRangeException();
				}
				return CF.CFArrayGetValueAtIndex(this.arrayRef, index);
			}
		}

		// Token: 0x0400B716 RID: 46870
		private IntPtr arrayRef;
	}
}
