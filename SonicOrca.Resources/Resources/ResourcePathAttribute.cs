using System;

namespace SonicOrca.Resources
{
	// Token: 0x0200000B RID: 11
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class ResourcePathAttribute : Attribute
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600003A RID: 58 RVA: 0x00002ED5 File Offset: 0x000010D5
		public string Path { get; }

		// Token: 0x0600003B RID: 59 RVA: 0x00002EDD File Offset: 0x000010DD
		public ResourcePathAttribute(string path)
		{
			this.Path = path;
		}
	}
}
