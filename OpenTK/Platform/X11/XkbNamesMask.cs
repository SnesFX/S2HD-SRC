using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000B50 RID: 2896
	[Flags]
	internal enum XkbNamesMask
	{
		// Token: 0x0400B751 RID: 46929
		Keycodes = 1,
		// Token: 0x0400B752 RID: 46930
		Geometry = 2,
		// Token: 0x0400B753 RID: 46931
		Symbols = 4,
		// Token: 0x0400B754 RID: 46932
		PhysSymbols = 8,
		// Token: 0x0400B755 RID: 46933
		Types = 16,
		// Token: 0x0400B756 RID: 46934
		Compat = 32,
		// Token: 0x0400B757 RID: 46935
		KeyType = 64,
		// Token: 0x0400B758 RID: 46936
		KTLevel = 128,
		// Token: 0x0400B759 RID: 46937
		Indicator = 256,
		// Token: 0x0400B75A RID: 46938
		Key = 512,
		// Token: 0x0400B75B RID: 46939
		KeyAliasesMask = 1024,
		// Token: 0x0400B75C RID: 46940
		VirtualMod = 2048,
		// Token: 0x0400B75D RID: 46941
		Group = 4096,
		// Token: 0x0400B75E RID: 46942
		RG = 8192,
		// Token: 0x0400B75F RID: 46943
		Component = 63,
		// Token: 0x0400B760 RID: 46944
		All = 16383
	}
}
