using System;
using System.IO;
using SonicOrca.Resources;

namespace SonicOrca.Core
{
	// Token: 0x02000112 RID: 274
	public class InputRecordingResource : ILoadedResource, IDisposable
	{
		// Token: 0x17000240 RID: 576
		// (get) Token: 0x06000A37 RID: 2615 RVA: 0x00028567 File Offset: 0x00026767
		public byte[] Data { get; }

		// Token: 0x17000241 RID: 577
		// (get) Token: 0x06000A38 RID: 2616 RVA: 0x0002856F File Offset: 0x0002676F
		// (set) Token: 0x06000A39 RID: 2617 RVA: 0x00028577 File Offset: 0x00026777
		public Resource Resource { get; set; }

		// Token: 0x06000A3A RID: 2618 RVA: 0x00028580 File Offset: 0x00026780
		public InputRecordingResource(byte[] data)
		{
			this.Data = data;
		}

		// Token: 0x06000A3B RID: 2619 RVA: 0x00006325 File Offset: 0x00004525
		public void Dispose()
		{
		}

		// Token: 0x06000A3C RID: 2620 RVA: 0x00006325 File Offset: 0x00004525
		public void OnLoaded()
		{
		}

		// Token: 0x06000A3D RID: 2621 RVA: 0x0002858F File Offset: 0x0002678F
		public Stream GetStream()
		{
			return new MemoryStream(this.Data);
		}
	}
}
