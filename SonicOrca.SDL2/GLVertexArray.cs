using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using OpenTK.Graphics.OpenGL;
using SonicOrca.Graphics;

namespace SonicOrca.SDL2
{
	// Token: 0x02000007 RID: 7
	internal class GLVertexArray : IVertexArray, IDisposable
	{
		// Token: 0x06000045 RID: 69 RVA: 0x00002B8D File Offset: 0x00000D8D
		public GLVertexArray(GLGraphicsContext context)
		{
			this._context = context;
			this._id = GL.GenVertexArray();
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00002BA7 File Offset: 0x00000DA7
		public void Dispose()
		{
			GL.DeleteVertexArray(this._id);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002BB4 File Offset: 0x00000DB4
		public void Bind()
		{
			GL.BindVertexArray(this._id);
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002BC1 File Offset: 0x00000DC1
		public void DefineAttribute(int attributeLocation, VertexAttributePointerType type, int size, int stride, int offset)
		{
			GL.VertexAttribPointer(attributeLocation, size, (VertexAttribPointerType)type, false, stride, offset);
			GL.EnableVertexAttribArray(attributeLocation);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00002BD6 File Offset: 0x00000DD6
		public void Render(SonicOrca.Graphics.PrimitiveType type, int index, int count)
		{
			this.Bind();
			GL.DrawArrays(GLVertexArray.BeginModesForPrimitiveTypes[(int)type], index, count);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002BF0 File Offset: 0x00000DF0
		// Note: this type is marked as 'beforefieldinit'.
		static GLVertexArray()
		{
			OpenTK.Graphics.OpenGL.PrimitiveType[] array = new OpenTK.Graphics.OpenGL.PrimitiveType[10];
			RuntimeHelpers.InitializeArray(array, fieldof(<PrivateImplementationDetails>.D12BEB9A11B341F408C41468985FFC5C95438CEA).FieldHandle);
			GLVertexArray.BeginModesForPrimitiveTypes = array;
		}

		// Token: 0x0400001B RID: 27
		private static readonly IReadOnlyList<OpenTK.Graphics.OpenGL.PrimitiveType> BeginModesForPrimitiveTypes;

		// Token: 0x0400001C RID: 28
		private readonly GLGraphicsContext _context;

		// Token: 0x0400001D RID: 29
		private readonly int _id;
	}
}
