using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Hjg.Pngcs;
using SonicOrca.Graphics;
using SonicOrca.Resources;

namespace SonicOrca.HelperLibraries.Png
{
	// Token: 0x020000B3 RID: 179
	public class PngResourceType : ResourceType
	{
		// Token: 0x170000EE RID: 238
		// (get) Token: 0x060005FD RID: 1533 RVA: 0x0001C398 File Offset: 0x0001A598
		public override string Name
		{
			get
			{
				return "png";
			}
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x060005FE RID: 1534 RVA: 0x0001C39F File Offset: 0x0001A59F
		public override string DefaultExtension
		{
			get
			{
				return ".png";
			}
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x060005FF RID: 1535 RVA: 0x0000225B File Offset: 0x0000045B
		public override bool CompressByDefault
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x0001C3A6 File Offset: 0x0001A5A6
		public PngResourceType() : base(ResourceTypeIdentifier.TexturePNG)
		{
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x0001C3B4 File Offset: 0x0001A5B4
		public override async Task<ILoadedResource> LoadAsync(ResourceLoadArgs e, CancellationToken ct = default(CancellationToken))
		{
			PngResourceType.PixelData pixelData = await this.GetSlowStream(e.InputStream);
			ITexture texture = SonicOrcaGameContext.Singleton.Window.GraphicsContext.CreateTexture(pixelData.Width, pixelData.Height, pixelData.Channels, pixelData.Data, false);
			texture.Resource = e.Resource;
			return texture;
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x0001C404 File Offset: 0x0001A604
		private async Task<PngResourceType.PixelData> GetSlowStream(Stream inputStream)
		{
			PngReader reader = null;
			PngResourceType.PixelData result;
			try
			{
				reader = new PngReader(inputStream);
				int width = reader.ImgInfo.Cols;
				int height = reader.ImgInfo.Rows;
				int channels = reader.ImgInfo.Channels;
				byte[] argb = new byte[width * height * 4];
				await Task.Run(delegate()
				{
					for (int i = 0; i < height; i++)
					{
						ImageLine imageLine = reader.ReadRowByte(i);
						Buffer.BlockCopy(imageLine.ScanlineB, 0, argb, i * width * imageLine.channels, width * imageLine.channels);
					}
				});
				reader.End();
				result = new PngResourceType.PixelData(width, height, channels, argb);
			}
			finally
			{
				if (reader != null)
				{
					reader.End();
				}
			}
			return result;
		}

		// Token: 0x06000603 RID: 1539
		[DllImport("SonicOrcaFastUtil.dll")]
		private static extern int BeginReadPNG(IntPtr input, int inputSize, out int width, out int height, out IntPtr output);

		// Token: 0x06000604 RID: 1540
		[DllImport("SonicOrcaFastUtil.dll")]
		private static extern void EndReadPNG(IntPtr output);

		// Token: 0x06000605 RID: 1541 RVA: 0x0001C44C File Offset: 0x0001A64C
		private async Task<PngResourceType.PixelData> GetFastStream(Stream inputStream)
		{
			byte[] array;
			using (MemoryStream ms = new MemoryStream())
			{
				await inputStream.CopyToAsync(ms);
				array = ms.ToArray();
			}
			MemoryStream ms = null;
			int num;
			int num2;
			IntPtr intPtr;
			if (PngResourceType.BeginReadPNG(Marshal.UnsafeAddrOfPinnedArrayElement(array, 0), array.Length, out num, out num2, out intPtr) == 0)
			{
				throw new ResourceException("Unable to load PNG.");
			}
			byte[] array2 = new byte[num * num2 * 4];
			Marshal.Copy(intPtr, array2, 0, array2.Length);
			PngResourceType.EndReadPNG(intPtr);
			return new PngResourceType.PixelData(num, num2, 4, array2);
		}

		// Token: 0x020001C1 RID: 449
		private struct PixelData
		{
			// Token: 0x17000506 RID: 1286
			// (get) Token: 0x060012AB RID: 4779 RVA: 0x000484F3 File Offset: 0x000466F3
			// (set) Token: 0x060012AC RID: 4780 RVA: 0x000484FB File Offset: 0x000466FB
			public int Width { get; private set; }

			// Token: 0x17000507 RID: 1287
			// (get) Token: 0x060012AD RID: 4781 RVA: 0x00048504 File Offset: 0x00046704
			// (set) Token: 0x060012AE RID: 4782 RVA: 0x0004850C File Offset: 0x0004670C
			public int Height { get; private set; }

			// Token: 0x17000508 RID: 1288
			// (get) Token: 0x060012AF RID: 4783 RVA: 0x00048515 File Offset: 0x00046715
			// (set) Token: 0x060012B0 RID: 4784 RVA: 0x0004851D File Offset: 0x0004671D
			public byte[] Data { get; private set; }

			// Token: 0x17000509 RID: 1289
			// (get) Token: 0x060012B1 RID: 4785 RVA: 0x00048526 File Offset: 0x00046726
			// (set) Token: 0x060012B2 RID: 4786 RVA: 0x0004852E File Offset: 0x0004672E
			public int Channels { get; private set; }

			// Token: 0x060012B3 RID: 4787 RVA: 0x00048537 File Offset: 0x00046737
			public PixelData(int width, int height, int channels, byte[] data)
			{
				this = default(PngResourceType.PixelData);
				this.Width = width;
				this.Height = height;
				this.Channels = channels;
				this.Data = data;
			}
		}
	}
}
