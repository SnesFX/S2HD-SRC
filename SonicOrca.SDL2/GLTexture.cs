using System;
using OpenTK.Graphics.OpenGL;
using SonicOrca.Graphics;
using SonicOrca.Resources;

namespace SonicOrca.SDL2
{
	// Token: 0x02000006 RID: 6
	internal class GLTexture : ITexture, IDisposable, ILoadedResource
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000035 RID: 53 RVA: 0x0000279D File Offset: 0x0000099D
		// (set) Token: 0x06000036 RID: 54 RVA: 0x000027A5 File Offset: 0x000009A5
		public Resource Resource { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000037 RID: 55 RVA: 0x000027AE File Offset: 0x000009AE
		// (set) Token: 0x06000038 RID: 56 RVA: 0x000027B6 File Offset: 0x000009B6
		public int Width { get; private set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000039 RID: 57 RVA: 0x000027BF File Offset: 0x000009BF
		// (set) Token: 0x0600003A RID: 58 RVA: 0x000027C7 File Offset: 0x000009C7
		public int Height { get; private set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600003B RID: 59 RVA: 0x000027D0 File Offset: 0x000009D0
		// (set) Token: 0x0600003C RID: 60 RVA: 0x000027D8 File Offset: 0x000009D8
		public TextureFiltering Filtering
		{
			get
			{
				return this._filtering;
			}
			set
			{
				if (value == this._filtering)
				{
					return;
				}
				TextureMinFilter param = TextureMinFilter.Linear;
				TextureMagFilter param2 = TextureMagFilter.Linear;
				this._filtering = value;
				if (value == TextureFiltering.NearestNeighbour)
				{
					param = TextureMinFilter.Nearest;
					param2 = TextureMagFilter.Nearest;
				}
				GL.BindTexture(TextureTarget.Texture2D, this._glId);
				GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)param);
				GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)param2);
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00002843 File Offset: 0x00000A43
		// (set) Token: 0x0600003E RID: 62 RVA: 0x0000284C File Offset: 0x00000A4C
		public TextureWrapping Wrapping
		{
			get
			{
				return this._wrapping;
			}
			set
			{
				if (value == this._wrapping)
				{
					return;
				}
				this._wrapping = value;
				TextureWrapMode param;
				switch (value)
				{
				case TextureWrapping.Clamp:
					param = TextureWrapMode.Clamp;
					goto IL_3B;
				case TextureWrapping.RepeatMirrored:
					param = TextureWrapMode.MirroredRepeat;
					goto IL_3B;
				}
				param = TextureWrapMode.Repeat;
				IL_3B:
				GL.BindTexture(TextureTarget.Texture2D, this._glId);
				GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)param);
				GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)param);
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600003F RID: 63 RVA: 0x000028C4 File Offset: 0x00000AC4
		public int Id
		{
			get
			{
				return this._glId;
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x000028CC File Offset: 0x00000ACC
		public GLTexture(GLGraphicsContext context, int width, int height, int channels, byte[] argb, bool toCompress = false)
		{
			this._context = context;
			this.Width = width;
			this.Height = height;
			this._glId = GL.GenTexture();
			GL.BindTexture(TextureTarget.Texture2D, this._glId);
			if (toCompress)
			{
				GL.TexImage2D<byte>(TextureTarget.Texture2D, 0, PixelInternalFormat.CompressedRgbaS3tcDxt1Ext, width, height, 0, (channels == 3) ? PixelFormat.Rgb : PixelFormat.Rgba, PixelType.UnsignedByte, argb);
			}
			else
			{
				GL.TexImage2D<byte>(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, width, height, 0, (channels == 3) ? PixelFormat.Rgb : PixelFormat.Rgba, PixelType.UnsignedByte, argb);
			}
			this._filtering = TextureFiltering.Linear;
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, 9729);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, 9729);
			this._wrapping = TextureWrapping.Clamp;
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, 10496);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, 10496);
			this._context.Textures.Add(this);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x000029DA File Offset: 0x00000BDA
		public void Dispose()
		{
			GL.DeleteTexture(this._glId);
			this._context.Textures.Remove(this);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x0000247B File Offset: 0x0000067B
		public void OnLoaded()
		{
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000029FC File Offset: 0x00000BFC
		public byte[] GetArgbData()
		{
			byte[] array = new byte[this.Width * this.Height * 4];
			GL.GetTexImage<byte>(TextureTarget.Texture2D, 0, PixelFormat.Rgba, PixelType.UnsignedByte, array);
			int num = this.Width * 4;
			for (int i = 0; i < this.Height / 2; i++)
			{
				for (int j = 0; j < this.Width; j++)
				{
					int num2 = i * num + j * 4;
					int num3 = (this.Height - i - 1) * num + j * 4;
					byte b = array[num2];
					byte b2 = array[num2 + 1];
					byte b3 = array[num2 + 2];
					byte b4 = array[num2 + 3];
					array[num2] = array[num3];
					array[num2 + 1] = array[num3 + 1];
					array[num2 + 2] = array[num3 + 2];
					array[num2 + 3] = array[num3 + 3];
					array[num3] = b;
					array[num3 + 1] = b2;
					array[num3 + 2] = b3;
					array[num3 + 3] = b4;
				}
			}
			for (int k = 0; k < array.Length; k += 4)
			{
				byte b5 = array[k];
				byte b6 = array[k + 1];
				byte b7 = array[k + 2];
				byte b8 = array[k + 3];
				array[k] = b7;
				array[k + 1] = b6;
				array[k + 2] = b5;
				array[k + 3] = b8;
			}
			return array;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002B40 File Offset: 0x00000D40
		public void SetArgbData(int width, int height, byte[] data)
		{
			PixelFormat format = PixelFormat.Bgra;
			if (data.Length < width * height * 4)
			{
				format = PixelFormat.Bgr;
			}
			GL.BindTexture(TextureTarget.Texture2D, this._glId);
			GL.TexImage2D<byte>(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, width, height, 0, format, PixelType.UnsignedByte, data);
		}

		// Token: 0x04000014 RID: 20
		private readonly GLGraphicsContext _context;

		// Token: 0x04000015 RID: 21
		private int _glId;

		// Token: 0x04000016 RID: 22
		private TextureFiltering _filtering;

		// Token: 0x04000017 RID: 23
		private TextureWrapping _wrapping;
	}
}
