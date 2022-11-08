using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using SonicOrca.Resources;

namespace SonicOrca.HelperLibraries.OggVorbis
{
	// Token: 0x020000B5 RID: 181
	public class OggResourceType : ResourceType
	{
		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x06000615 RID: 1557 RVA: 0x0001CADF File Offset: 0x0001ACDF
		public override string Name
		{
			get
			{
				return "ogg";
			}
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000616 RID: 1558 RVA: 0x0001CAE6 File Offset: 0x0001ACE6
		public override string DefaultExtension
		{
			get
			{
				return ".ogg";
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000617 RID: 1559 RVA: 0x0000225B File Offset: 0x0000045B
		public override bool CompressByDefault
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x0001CAED File Offset: 0x0001ACED
		public OggResourceType() : base(ResourceTypeIdentifier.SampleOGG)
		{
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x0001CAFC File Offset: 0x0001ACFC
		public override async Task<ILoadedResource> LoadAsync(ResourceLoadArgs e, CancellationToken ct = default(CancellationToken))
		{
			Stream inputStream = await this.GetSlowStream(e.InputStream);
			return await ResourceType.FromIdentifier(ResourceTypeIdentifier.SampleWAV).LoadAsync(new ResourceLoadArgs(e.ResourceTree, e.Resource, inputStream), ct);
		}

		// Token: 0x0600061A RID: 1562 RVA: 0x0001CB51 File Offset: 0x0001AD51
		private Task<Stream> GetSlowStream(Stream inputStream)
		{
			return Task.Run<Stream>(() => new OggDecodeStream(inputStream, false));
		}

		// Token: 0x0600061B RID: 1563
		[DllImport("SonicOrcaFastUtil.dll")]
		private static extern int BeginReadVorbis(IntPtr input, int inputSize, out IntPtr output, out int outputLength);

		// Token: 0x0600061C RID: 1564
		[DllImport("SonicOrcaFastUtil.dll")]
		private static extern void EndReadVorbis(IntPtr output);

		// Token: 0x0600061D RID: 1565 RVA: 0x0001CB70 File Offset: 0x0001AD70
		private async Task<Stream> GetFastStream(Stream inputStream)
		{
			byte[] array;
			using (MemoryStream ms = new MemoryStream())
			{
				await inputStream.CopyToAsync(ms);
				array = ms.ToArray();
			}
			MemoryStream ms = null;
			IntPtr intPtr;
			int num;
			if (OggResourceType.BeginReadVorbis(Marshal.UnsafeAddrOfPinnedArrayElement(array, 0), array.Length, out intPtr, out num) == 0)
			{
				throw new ResourceException("Unable to read OGG Vorbis data");
			}
			byte[] array2 = new byte[num];
			Marshal.Copy(intPtr, array2, 0, num);
			OggResourceType.EndReadVorbis(intPtr);
			return new MemoryStream(array2);
		}
	}
}
