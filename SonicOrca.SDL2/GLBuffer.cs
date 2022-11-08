using System;
using System.Runtime.InteropServices;
using OpenTK.Graphics.OpenGL;
using SonicOrca.Graphics;

namespace SonicOrca.SDL2
{
	// Token: 0x02000002 RID: 2
	internal class GLBuffer : IBuffer, IDisposable
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public GLBuffer(GLGraphicsContext context)
		{
			this._context = context;
			this._id = GL.GenBuffer();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x0000206A File Offset: 0x0000026A
		public void Dispose()
		{
			GL.DeleteBuffer(this._id);
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002077 File Offset: 0x00000277
		public void Bind()
		{
			GL.BindBuffer(BufferTarget.ArrayBuffer, this._id);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x0000208C File Offset: 0x0000028C
		public void SetData<T>(T[] data, int offset, int length)
		{
			IntPtr data2 = Marshal.UnsafeAddrOfPinnedArrayElement(data, offset);
			IntPtr size = new IntPtr(Marshal.SizeOf(typeof(T)) * length);
			this.Bind();
			GL.BufferData(BufferTarget.ArrayBuffer, size, data2, BufferUsageHint.StreamDraw);
		}

		// Token: 0x04000001 RID: 1
		private readonly GLGraphicsContext _context;

		// Token: 0x04000002 RID: 2
		private readonly int _id;
	}
}
