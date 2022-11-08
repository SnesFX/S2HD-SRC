using System;

namespace OpenTK
{
	// Token: 0x02000048 RID: 72
	public class ToolkitOptions
	{
		// Token: 0x060004F8 RID: 1272 RVA: 0x00014A9C File Offset: 0x00012C9C
		static ToolkitOptions()
		{
			ToolkitOptions.Default.EnableHighResolution = true;
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x060004F9 RID: 1273 RVA: 0x00014AB4 File Offset: 0x00012CB4
		// (set) Token: 0x060004FA RID: 1274 RVA: 0x00014ABC File Offset: 0x00012CBC
		public PlatformBackend Backend { get; set; }

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x060004FB RID: 1275 RVA: 0x00014AC8 File Offset: 0x00012CC8
		// (set) Token: 0x060004FC RID: 1276 RVA: 0x00014AD0 File Offset: 0x00012CD0
		public bool EnableHighResolution { get; set; }

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x060004FD RID: 1277 RVA: 0x00014ADC File Offset: 0x00012CDC
		// (set) Token: 0x060004FE RID: 1278 RVA: 0x00014AE4 File Offset: 0x00012CE4
		public static ToolkitOptions Default { get; private set; } = new ToolkitOptions();
	}
}
