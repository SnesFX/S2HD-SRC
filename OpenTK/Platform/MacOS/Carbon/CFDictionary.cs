using System;

namespace OpenTK.Platform.MacOS.Carbon
{
	// Token: 0x02000B49 RID: 2889
	internal struct CFDictionary
	{
		// Token: 0x06005AFC RID: 23292 RVA: 0x000F6924 File Offset: 0x000F4B24
		public CFDictionary(IntPtr reference)
		{
			this.dictionaryRef = reference;
		}

		// Token: 0x170004C2 RID: 1218
		// (get) Token: 0x06005AFD RID: 23293 RVA: 0x000F6930 File Offset: 0x000F4B30
		// (set) Token: 0x06005AFE RID: 23294 RVA: 0x000F6938 File Offset: 0x000F4B38
		public IntPtr Ref
		{
			get
			{
				return this.dictionaryRef;
			}
			set
			{
				this.dictionaryRef = value;
			}
		}

		// Token: 0x170004C3 RID: 1219
		// (get) Token: 0x06005AFF RID: 23295 RVA: 0x000F6944 File Offset: 0x000F4B44
		public int Count
		{
			get
			{
				return CF.CFDictionaryGetCount(this.dictionaryRef);
			}
		}

		// Token: 0x06005B00 RID: 23296 RVA: 0x000F6954 File Offset: 0x000F4B54
		public double GetNumberValue(string key)
		{
			IntPtr number = CF.CFDictionaryGetValue(this.dictionaryRef, CF.CFSTR(key));
			double result;
			CF.CFNumberGetValue(number, CF.CFNumberType.kCFNumberDoubleType, out result);
			return result;
		}

		// Token: 0x0400B717 RID: 46871
		private IntPtr dictionaryRef;
	}
}
