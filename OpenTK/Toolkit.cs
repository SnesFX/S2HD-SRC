using System;
using OpenTK.Platform;

namespace OpenTK
{
	// Token: 0x02000054 RID: 84
	public sealed class Toolkit : IDisposable
	{
		// Token: 0x0600061C RID: 1564 RVA: 0x00016714 File Offset: 0x00014914
		private Toolkit(Factory factory)
		{
			if (factory == null)
			{
				throw new ArgumentNullException("factory");
			}
			this.platform_factory = factory;
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x00016734 File Offset: 0x00014934
		public static Toolkit Init()
		{
			return Toolkit.Init(ToolkitOptions.Default);
		}

		// Token: 0x0600061E RID: 1566 RVA: 0x00016740 File Offset: 0x00014940
		public static Toolkit Init(ToolkitOptions options)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			Toolkit result;
			lock (Toolkit.InitLock)
			{
				if (!Toolkit.initialized)
				{
					Toolkit.initialized = true;
					Configuration.Init(options);
					Toolkit.Options = options;
					Toolkit.toolkit = new Toolkit(new Factory());
				}
				result = Toolkit.toolkit;
			}
			return result;
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x0600061F RID: 1567 RVA: 0x000167B4 File Offset: 0x000149B4
		// (set) Token: 0x06000620 RID: 1568 RVA: 0x000167BC File Offset: 0x000149BC
		internal static ToolkitOptions Options { get; private set; }

		// Token: 0x06000621 RID: 1569 RVA: 0x000167C4 File Offset: 0x000149C4
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x000167D4 File Offset: 0x000149D4
		private void Dispose(bool manual)
		{
			if (manual)
			{
				lock (Toolkit.InitLock)
				{
					if (Toolkit.initialized)
					{
						this.platform_factory.Dispose();
						this.platform_factory = null;
						Toolkit.toolkit = null;
						Toolkit.initialized = false;
					}
					return;
				}
			}
			this.platform_factory = null;
			Toolkit.toolkit = null;
			Toolkit.initialized = false;
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x00016848 File Offset: 0x00014A48
		~Toolkit()
		{
			this.Dispose(false);
		}

		// Token: 0x0400018F RID: 399
		private Factory platform_factory;

		// Token: 0x04000190 RID: 400
		private static Toolkit toolkit;

		// Token: 0x04000191 RID: 401
		private static volatile bool initialized;

		// Token: 0x04000192 RID: 402
		private static readonly object InitLock = new object();
	}
}
