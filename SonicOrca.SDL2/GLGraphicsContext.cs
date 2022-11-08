using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenTK.Graphics.OpenGL;
using SonicOrca.Graphics;

namespace SonicOrca.SDL2
{
	// Token: 0x02000003 RID: 3
	internal class GLGraphicsContext : IGraphicsContext
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000005 RID: 5 RVA: 0x000020D0 File Offset: 0x000002D0
		internal ICollection<ITexture> Textures
		{
			get
			{
				return this._textures;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000006 RID: 6 RVA: 0x000020D8 File Offset: 0x000002D8
		internal ICollection<IShaderProgram> ShaderPrograms
		{
			get
			{
				return this._shaderPrograms;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000007 RID: 7 RVA: 0x000020E0 File Offset: 0x000002E0
		internal ICollection<VertexBuffer> VertexBuffers
		{
			get
			{
				return this._vertexBuffers;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000008 RID: 8 RVA: 0x000020E8 File Offset: 0x000002E8
		internal ICollection<IFramebuffer> Framebuffers
		{
			get
			{
				return this._renderTargets;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000009 RID: 9 RVA: 0x000020D0 File Offset: 0x000002D0
		IReadOnlyCollection<ITexture> IGraphicsContext.Textures
		{
			get
			{
				return this._textures;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000A RID: 10 RVA: 0x000020D8 File Offset: 0x000002D8
		IReadOnlyCollection<IShaderProgram> IGraphicsContext.ShaderPrograms
		{
			get
			{
				return this._shaderPrograms;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000B RID: 11 RVA: 0x000020E0 File Offset: 0x000002E0
		IReadOnlyCollection<VertexBuffer> IGraphicsContext.VertexBuffers
		{
			get
			{
				return this._vertexBuffers;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600000C RID: 12 RVA: 0x000020E8 File Offset: 0x000002E8
		IReadOnlyCollection<IFramebuffer> IGraphicsContext.RenderTargets
		{
			get
			{
				return this._renderTargets;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000020F0 File Offset: 0x000002F0
		// (set) Token: 0x0600000E RID: 14 RVA: 0x000020FC File Offset: 0x000002FC
		public bool DepthTesting
		{
			get
			{
				return GL.IsEnabled(EnableCap.DepthTest);
			}
			set
			{
				if (value)
				{
					GL.Enable(EnableCap.DepthTest);
					return;
				}
				GL.Disable(EnableCap.DepthTest);
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600000F RID: 15 RVA: 0x00002116 File Offset: 0x00000316
		// (set) Token: 0x06000010 RID: 16 RVA: 0x00002120 File Offset: 0x00000320
		public BlendMode BlendMode
		{
			get
			{
				return this._blendMode;
			}
			set
			{
				if (this._blendMode == value)
				{
					return;
				}
				this._blendMode = value;
				switch (value)
				{
				default:
					GL.Disable(EnableCap.Blend);
					return;
				case BlendMode.Alpha:
					GL.Enable(EnableCap.Blend);
					GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
					return;
				case BlendMode.Additive:
					GL.Enable(EnableCap.Blend);
					GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.One);
					return;
				}
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000011 RID: 17 RVA: 0x0000218C File Offset: 0x0000038C
		// (set) Token: 0x06000012 RID: 18 RVA: 0x000021AC File Offset: 0x000003AC
		public SonicOrca.Graphics.PolygonMode PolygonMode
		{
			get
			{
				int num;
				GL.GetInteger(GetPName.PolygonMode, out num);
				return (SonicOrca.Graphics.PolygonMode)(num - 6912);
			}
			set
			{
				GL.PolygonMode(MaterialFace.FrontAndBack, OpenTK.Graphics.OpenGL.PolygonMode.Point + (int)value);
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000013 RID: 19 RVA: 0x000021BF File Offset: 0x000003BF
		// (set) Token: 0x06000014 RID: 20 RVA: 0x000021C7 File Offset: 0x000003C7
		public IFramebuffer CurrentFramebuffer { get; internal set; }

		// Token: 0x06000015 RID: 21 RVA: 0x000021D0 File Offset: 0x000003D0
		public GLGraphicsContext(SDL2WindowContext videoAdapter)
		{
			this._videoAdapter = videoAdapter;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x0000220B File Offset: 0x0000040B
		public IShader CreateShader(SonicOrca.Graphics.ShaderType type, string sourceCode)
		{
			return new GLShader(type, sourceCode);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002214 File Offset: 0x00000414
		public IShaderProgram CreateShaderProgram(params IShader[] shaders)
		{
			return this.CreateShaderProgram(shaders);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000221D File Offset: 0x0000041D
		public IShaderProgram CreateShaderProgram(IEnumerable<IShader> shaders)
		{
			return new GLShaderProgram(this, from x in shaders
			select (GLShader)x);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000224A File Offset: 0x0000044A
		public VertexBuffer CreateVertexBuffer(params int[] vectorCounts)
		{
			return this.CreateVertexBuffer(vectorCounts);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002253 File Offset: 0x00000453
		public VertexBuffer CreateVertexBuffer(IEnumerable<int> vectorCounts)
		{
			return new GLVertexBuffer(this, vectorCounts);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x0000225C File Offset: 0x0000045C
		public VertexBuffer CreateVertexBuffer(IShaderProgram shaderProgram, IEnumerable<string> names, IEnumerable<int> vectorCounts)
		{
			return new GLVertexBuffer(this, shaderProgram, names, vectorCounts);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002267 File Offset: 0x00000467
		public ITexture CreateTexture(int width, int height)
		{
			return this.CreateTexture(width, height, 4, new byte[width * height * 4], false);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002280 File Offset: 0x00000480
		public ITexture CreateTexture(int width, int height, int channels, byte[] pixels, bool toCompress = false)
		{
			GLGraphicsContext.<>c__DisplayClass43_0 CS$<>8__locals1 = new GLGraphicsContext.<>c__DisplayClass43_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.width = width;
			CS$<>8__locals1.height = height;
			CS$<>8__locals1.channels = channels;
			CS$<>8__locals1.pixels = pixels;
			CS$<>8__locals1.toCompress = toCompress;
			if (Thread.CurrentThread == this._videoAdapter.ContextThread)
			{
				return new GLTexture(this, CS$<>8__locals1.width, CS$<>8__locals1.height, CS$<>8__locals1.channels, CS$<>8__locals1.pixels, CS$<>8__locals1.toCompress);
			}
			CS$<>8__locals1.texture = null;
			using (AutoResetEvent autoResetEvent = new AutoResetEvent(false))
			{
				this._videoAdapter.Dispatch(delegate
				{
					CS$<>8__locals1.texture = new GLTexture(CS$<>8__locals1.<>4__this, CS$<>8__locals1.width, CS$<>8__locals1.height, CS$<>8__locals1.channels, CS$<>8__locals1.pixels, CS$<>8__locals1.toCompress);
					autoResetEvent.Set();
				});
				if (!autoResetEvent.WaitOne(5000))
				{
					throw new TimeoutException("OpenGL texture creation timed out.");
				}
			}
			return CS$<>8__locals1.texture;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002378 File Offset: 0x00000578
		public void SetTexture(ITexture texture)
		{
			this.SetTexture(0, texture);
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002382 File Offset: 0x00000582
		public void SetTexture(int index, ITexture texture)
		{
			if (texture != null)
			{
				GL.ActiveTexture(TextureUnit.Texture0 + index);
				GL.BindTexture(TextureTarget.Texture2D, ((GLTexture)texture).Id);
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000023A8 File Offset: 0x000005A8
		public void SetTextures(IEnumerable<ITexture> textures)
		{
			int num = 0;
			foreach (ITexture texture in textures)
			{
				this.SetTexture(num++, texture);
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000023F8 File Offset: 0x000005F8
		public IFramebuffer CreateFrameBuffer(int width, int height, int numTextures = 1)
		{
			return new GLFramebuffer(this, width, height, numTextures);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002404 File Offset: 0x00000604
		public void RenderToBackBuffer()
		{
			this.CurrentFramebuffer = GLFramebuffer.FromBackBuffer(this, this._videoAdapter.ClientSize.X, this._videoAdapter.ClientSize.Y);
			GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
			GL.Viewport(0, 0, this._videoAdapter.ClientSize.X, this._videoAdapter.ClientSize.Y);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x0000247B File Offset: 0x0000067B
		public void Update()
		{
		}

		// Token: 0x06000024 RID: 36 RVA: 0x0000247D File Offset: 0x0000067D
		public void ClearBuffer()
		{
			GL.Clear(ClearBufferMask.StencilBufferBit | ClearBufferMask.ColorBufferBit);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002489 File Offset: 0x00000689
		public void ClearDepthBuffer()
		{
			GL.Clear(ClearBufferMask.DepthBufferBit);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002495 File Offset: 0x00000695
		public void ClearColourBuffer(int index)
		{
			GL.ClearBuffer(OpenTK.Graphics.OpenGL.ClearBuffer.Color, index, new int[4]);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000024A8 File Offset: 0x000006A8
		public IBuffer CreateBuffer()
		{
			return new GLBuffer(this);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000024B0 File Offset: 0x000006B0
		public IVertexArray CreateVertexArray()
		{
			return new GLVertexArray(this);
		}

		// Token: 0x04000003 RID: 3
		private readonly SDL2WindowContext _videoAdapter;

		// Token: 0x04000004 RID: 4
		private BlendMode _blendMode;

		// Token: 0x04000005 RID: 5
		private readonly List<ITexture> _textures = new List<ITexture>();

		// Token: 0x04000006 RID: 6
		private readonly List<IShaderProgram> _shaderPrograms = new List<IShaderProgram>();

		// Token: 0x04000007 RID: 7
		private readonly List<VertexBuffer> _vertexBuffers = new List<VertexBuffer>();

		// Token: 0x04000008 RID: 8
		private readonly List<IFramebuffer> _renderTargets = new List<IFramebuffer>();
	}
}
