using System;
using SonicOrca.Graphics;

namespace S2HD
{
	// Token: 0x020000A3 RID: 163
	internal static class SharedRenderers
	{
		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060003BF RID: 959 RVA: 0x0001A54B File Offset: 0x0001874B
		// (set) Token: 0x060003C0 RID: 960 RVA: 0x0001A552 File Offset: 0x00018752
		public static bool Initialised { get; private set; }

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060003C1 RID: 961 RVA: 0x0001A55A File Offset: 0x0001875A
		// (set) Token: 0x060003C2 RID: 962 RVA: 0x0001A561 File Offset: 0x00018761
		public static I2dRenderer Standard2d { get; private set; }

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060003C3 RID: 963 RVA: 0x0001A569 File Offset: 0x00018769
		// (set) Token: 0x060003C4 RID: 964 RVA: 0x0001A570 File Offset: 0x00018770
		public static IFadeTransitionRenderer FadeTransition { get; private set; }

		// Token: 0x060003C5 RID: 965 RVA: 0x0001A578 File Offset: 0x00018778
		public static void Initialise(IRendererFactory rendererFactory)
		{
			object initialiseLock = SharedRenderers.InitialiseLock;
			lock (initialiseLock)
			{
				if (SharedRenderers.Initialised)
				{
					throw new InvalidOperationException("Shared renderers already initialised.");
				}
				SharedRenderers.Standard2d = rendererFactory.Create2dRenderer();
				SharedRenderers.FadeTransition = rendererFactory.CreateFadeTransitionRenderer();
				SharedRenderers.Initialised = true;
			}
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x0001A5E0 File Offset: 0x000187E0
		public static void Dispose()
		{
			object initialiseLock = SharedRenderers.InitialiseLock;
			lock (initialiseLock)
			{
				if (SharedRenderers.Standard2d != null)
				{
					SharedRenderers.Standard2d.Dispose();
					SharedRenderers.Standard2d = null;
				}
				if (SharedRenderers.FadeTransition != null)
				{
					SharedRenderers.FadeTransition.Dispose();
					SharedRenderers.FadeTransition = null;
				}
				SharedRenderers.Initialised = false;
			}
		}

		// Token: 0x0400045C RID: 1116
		private static readonly object InitialiseLock = new object();
	}
}
