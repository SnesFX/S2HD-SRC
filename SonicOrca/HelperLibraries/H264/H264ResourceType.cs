using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using SonicOrca.Graphics.V2.Video;
using SonicOrca.Resources;

namespace SonicOrca.HelperLibraries.H264
{
	// Token: 0x020000B6 RID: 182
	public class H264ResourceType : ResourceType
	{
		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x0600061E RID: 1566 RVA: 0x0001CBB5 File Offset: 0x0001ADB5
		public override string Name
		{
			get
			{
				return "h265";
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x0600061F RID: 1567 RVA: 0x0001CBBC File Offset: 0x0001ADBC
		public override string DefaultExtension
		{
			get
			{
				return ".mp4";
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06000620 RID: 1568 RVA: 0x0000225B File Offset: 0x0000045B
		public override bool CompressByDefault
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x0001CBC3 File Offset: 0x0001ADC3
		public H264ResourceType() : base(ResourceTypeIdentifier.VideoH264)
		{
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x0001CBD0 File Offset: 0x0001ADD0
		public override async Task<ILoadedResource> LoadAsync(ResourceLoadArgs e, CancellationToken ct = default(CancellationToken))
		{
			return await Task.Run<ILoadedResource>(() => new FilmBuffer(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\credits.film")
			{
				Resource = e.Resource
			});
		}

		// Token: 0x020001CA RID: 458
		private struct PixelData
		{
			// Token: 0x1700050A RID: 1290
			// (get) Token: 0x060012C3 RID: 4803 RVA: 0x00048DA6 File Offset: 0x00046FA6
			// (set) Token: 0x060012C4 RID: 4804 RVA: 0x00048DAE File Offset: 0x00046FAE
			public int Width { get; private set; }

			// Token: 0x1700050B RID: 1291
			// (get) Token: 0x060012C5 RID: 4805 RVA: 0x00048DB7 File Offset: 0x00046FB7
			// (set) Token: 0x060012C6 RID: 4806 RVA: 0x00048DBF File Offset: 0x00046FBF
			public int Height { get; private set; }

			// Token: 0x1700050C RID: 1292
			// (get) Token: 0x060012C7 RID: 4807 RVA: 0x00048DC8 File Offset: 0x00046FC8
			// (set) Token: 0x060012C8 RID: 4808 RVA: 0x00048DD0 File Offset: 0x00046FD0
			public byte[] Data { get; private set; }

			// Token: 0x1700050D RID: 1293
			// (get) Token: 0x060012C9 RID: 4809 RVA: 0x00048DD9 File Offset: 0x00046FD9
			// (set) Token: 0x060012CA RID: 4810 RVA: 0x00048DE1 File Offset: 0x00046FE1
			public int Channels { get; private set; }

			// Token: 0x060012CB RID: 4811 RVA: 0x00048DEA File Offset: 0x00046FEA
			public PixelData(int width, int height, int channels, byte[] data)
			{
				this = default(H264ResourceType.PixelData);
				this.Width = width;
				this.Height = height;
				this.Channels = channels;
				this.Data = data;
			}
		}
	}
}
