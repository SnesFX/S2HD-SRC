using System;
using System.Collections.Generic;
using System.Linq;
using OpenTK.Graphics.OpenGL;
using SonicOrca.Graphics;

namespace SonicOrca.SDL2
{
	// Token: 0x02000004 RID: 4
	internal class GLFramebuffer : IFramebuffer, IDisposable
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000029 RID: 41 RVA: 0x000024B8 File Offset: 0x000006B8
		public int Width
		{
			get
			{
				return this._width;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600002A RID: 42 RVA: 0x000024C0 File Offset: 0x000006C0
		public int Height
		{
			get
			{
				return this._height;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600002B RID: 43 RVA: 0x000024C8 File Offset: 0x000006C8
		public IReadOnlyList<ITexture> Textures
		{
			get
			{
				return this._textures;
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000024D0 File Offset: 0x000006D0
		public static GLFramebuffer FromBackBuffer(GLGraphicsContext context, int width, int height)
		{
			return new GLFramebuffer(context, width, height, 0U);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000024DB File Offset: 0x000006DB
		private GLFramebuffer(GLGraphicsContext context, int width, int height, uint name)
		{
			this._context = context;
			this._width = width;
			this._height = height;
			this._name = name;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002500 File Offset: 0x00000700
		public GLFramebuffer(GLGraphicsContext context, int width, int height, int numTextures = 1)
		{
			this._context = context;
			this._width = width;
			this._height = height;
			GL.GenFramebuffers(1, out this._name);
			GL.BindFramebuffer(FramebufferTarget.Framebuffer, this._name);
			this._textures = new GLTexture[numTextures];
			for (int j = 0; j < numTextures; j++)
			{
				GLTexture gltexture = this._textures[j] = (GLTexture)context.CreateTexture(width, height);
				GL.FramebufferTexture(FramebufferTarget.Framebuffer, FramebufferAttachment.ColorAttachment0 + j, gltexture.Id, 0);
			}
			GL.DrawBuffers(numTextures, (from i in Enumerable.Range(0, numTextures)
			select DrawBuffersEnum.ColorAttachment0 + i).ToArray<DrawBuffersEnum>());
			this._depthBufferName = GL.GenRenderbuffer();
			GL.BindRenderbuffer(RenderbufferTarget.Renderbuffer, this._depthBufferName);
			GL.RenderbufferStorage(RenderbufferTarget.Renderbuffer, RenderbufferStorage.Depth24Stencil8, width, height);
			GL.FramebufferRenderbuffer(FramebufferTarget.Framebuffer, FramebufferAttachment.DepthStencilAttachment, RenderbufferTarget.Renderbuffer, this._depthBufferName);
			if (GL.CheckFramebufferStatus(FramebufferTarget.Framebuffer) != FramebufferErrorCode.FramebufferComplete)
			{
				throw new SDL2Exception("Unable to create framebuffer.");
			}
			this._context.Framebuffers.Add(this);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x0000263C File Offset: 0x0000083C
		public void Dispose()
		{
			GLTexture[] textures = this._textures;
			for (int i = 0; i < textures.Length; i++)
			{
				textures[i].Dispose();
			}
			GL.DeleteFramebuffer(this._name);
			if (this._context != null)
			{
				this._context.Framebuffers.Remove(this);
			}
		}

		// Token: 0x06000030 RID: 48 RVA: 0x0000268B File Offset: 0x0000088B
		public void Activate()
		{
			GL.BindFramebuffer(FramebufferTarget.Framebuffer, this._name);
			GL.Viewport(0, 0, this._width, this._height);
			this._context.CurrentFramebuffer = this;
		}

		// Token: 0x0400000A RID: 10
		private readonly GLGraphicsContext _context;

		// Token: 0x0400000B RID: 11
		private readonly int _width;

		// Token: 0x0400000C RID: 12
		private readonly int _height;

		// Token: 0x0400000D RID: 13
		private readonly uint _name;

		// Token: 0x0400000E RID: 14
		private readonly GLTexture[] _textures;

		// Token: 0x0400000F RID: 15
		private readonly int _depthBufferName;
	}
}
