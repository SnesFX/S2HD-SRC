using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using SonicOrca.Resources;

namespace SonicOrca.Core
{
	// Token: 0x02000113 RID: 275
	public class InputRecordingResourceType : ResourceType
	{
		// Token: 0x17000242 RID: 578
		// (get) Token: 0x06000A3E RID: 2622 RVA: 0x0002859C File Offset: 0x0002679C
		public override string Name
		{
			get
			{
				return "recording, rec";
			}
		}

		// Token: 0x17000243 RID: 579
		// (get) Token: 0x06000A3F RID: 2623 RVA: 0x000285A3 File Offset: 0x000267A3
		public override string DefaultExtension
		{
			get
			{
				return ".rec";
			}
		}

		// Token: 0x17000244 RID: 580
		// (get) Token: 0x06000A40 RID: 2624 RVA: 0x00006340 File Offset: 0x00004540
		public override bool CompressByDefault
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000A41 RID: 2625 RVA: 0x000285AA File Offset: 0x000267AA
		public InputRecordingResourceType() : base(ResourceTypeIdentifier.InputRecording)
		{
		}

		// Token: 0x06000A42 RID: 2626 RVA: 0x000285B8 File Offset: 0x000267B8
		public override async Task<ILoadedResource> LoadAsync(ResourceLoadArgs e, CancellationToken ct = default(CancellationToken))
		{
			byte[] data;
			using (MemoryStream ms = new MemoryStream())
			{
				await e.InputStream.CopyToAsync(ms);
				data = ms.ToArray();
			}
			MemoryStream ms = null;
			return new InputRecordingResource(data);
		}
	}
}
