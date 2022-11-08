using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Accord.Properties
{
	// Token: 0x0200002C RID: 44
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x06000131 RID: 305 RVA: 0x00002327 File Offset: 0x00001327
		internal Resources()
		{
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000132 RID: 306 RVA: 0x00004318 File Offset: 0x00003318
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					ResourceManager resourceManager = new ResourceManager("Accord.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000133 RID: 307 RVA: 0x00004351 File Offset: 0x00003351
		// (set) Token: 0x06000134 RID: 308 RVA: 0x00004358 File Offset: 0x00003358
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000135 RID: 309 RVA: 0x00004360 File Offset: 0x00003360
		internal static string NotSupportedWeights
		{
			get
			{
				return Resources.ResourceManager.GetString("NotSupportedWeights", Resources.resourceCulture);
			}
		}

		// Token: 0x0400001C RID: 28
		private static ResourceManager resourceMan;

		// Token: 0x0400001D RID: 29
		private static CultureInfo resourceCulture;
	}
}
