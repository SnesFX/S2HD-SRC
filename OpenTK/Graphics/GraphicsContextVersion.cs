using System;

namespace OpenTK.Graphics
{
	// Token: 0x020001B8 RID: 440
	public sealed class GraphicsContextVersion
	{
		// Token: 0x06000BD8 RID: 3032 RVA: 0x00027414 File Offset: 0x00025614
		internal GraphicsContextVersion(int minor, int major, string vendor, string renderer)
		{
			this.Minor = minor;
			this.Major = major;
			this.Vendor = vendor;
			this.Renderer = renderer;
		}

		// Token: 0x17000251 RID: 593
		// (get) Token: 0x06000BD9 RID: 3033 RVA: 0x00027450 File Offset: 0x00025650
		// (set) Token: 0x06000BDA RID: 3034 RVA: 0x00027458 File Offset: 0x00025658
		public int Minor
		{
			get
			{
				return this.minor;
			}
			private set
			{
				this.minor = value;
			}
		}

		// Token: 0x17000252 RID: 594
		// (get) Token: 0x06000BDB RID: 3035 RVA: 0x00027464 File Offset: 0x00025664
		// (set) Token: 0x06000BDC RID: 3036 RVA: 0x0002746C File Offset: 0x0002566C
		public int Major
		{
			get
			{
				return this.major;
			}
			private set
			{
				this.major = value;
			}
		}

		// Token: 0x17000253 RID: 595
		// (get) Token: 0x06000BDD RID: 3037 RVA: 0x00027478 File Offset: 0x00025678
		// (set) Token: 0x06000BDE RID: 3038 RVA: 0x00027480 File Offset: 0x00025680
		public string Vendor
		{
			get
			{
				return this.vendor;
			}
			private set
			{
				this.vendor = value;
			}
		}

		// Token: 0x17000254 RID: 596
		// (get) Token: 0x06000BDF RID: 3039 RVA: 0x0002748C File Offset: 0x0002568C
		// (set) Token: 0x06000BE0 RID: 3040 RVA: 0x00027494 File Offset: 0x00025694
		public string Renderer
		{
			get
			{
				return this.renderer;
			}
			private set
			{
				this.renderer = value;
			}
		}

		// Token: 0x0400120B RID: 4619
		private int minor;

		// Token: 0x0400120C RID: 4620
		private int major;

		// Token: 0x0400120D RID: 4621
		private string vendor = string.Empty;

		// Token: 0x0400120E RID: 4622
		private string renderer = string.Empty;
	}
}
