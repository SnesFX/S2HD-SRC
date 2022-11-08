using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using OpenTK.Graphics.OpenGL;
using SonicOrca.Graphics;

namespace SonicOrca.SDL2
{
	// Token: 0x0200000A RID: 10
	internal class GLVertexBuffer : VertexBuffer
	{
		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00002E54 File Offset: 0x00001054
		public override IReadOnlyList<int> VectorCounts
		{
			get
			{
				return this._vectorCounts;
			}
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00002E5C File Offset: 0x0000105C
		public GLVertexBuffer(GLGraphicsContext context, IEnumerable<int> vectorCounts)
		{
			this._context = context;
			this._vectorCounts = vectorCounts.ToArray<int>();
			this._numBuffers = this._vectorCounts.Length;
			GL.GenVertexArrays(1, out this._glId);
			GL.BindVertexArray(this._glId);
			this._glBufferIds = new int[this._numBuffers];
			this._data = new List<float>[this._numBuffers];
			GL.GenBuffers(this._numBuffers, this._glBufferIds);
			for (int i = 0; i < this._numBuffers; i++)
			{
				GL.EnableVertexAttribArray(i);
				GL.BindBuffer(BufferTarget.ArrayBuffer, this._glBufferIds[i]);
				GL.VertexAttribPointer(i, this._vectorCounts[i], VertexAttribPointerType.Float, false, 0, 0);
				this._data[i] = new List<float>();
			}
			this._context.VertexBuffers.Add(this);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00002F38 File Offset: 0x00001138
		public GLVertexBuffer(GLGraphicsContext context, IShaderProgram shaderProgram, IEnumerable<string> names, IEnumerable<int> vectorCounts)
		{
			this._context = context;
			this._vectorCounts = base.SetAttributeLocations(shaderProgram, names, vectorCounts).ToArray<int>();
			this._numBuffers = this._vectorCounts.Length;
			GL.GenVertexArrays(1, out this._glId);
			GL.BindVertexArray(this._glId);
			this._glBufferIds = new int[this._numBuffers];
			this._data = new List<float>[this._numBuffers];
			GL.GenBuffers(this._numBuffers, this._glBufferIds);
			for (int i = 0; i < this._numBuffers; i++)
			{
				GL.EnableVertexAttribArray(i);
				GL.BindBuffer(BufferTarget.ArrayBuffer, this._glBufferIds[i]);
				GL.VertexAttribPointer(i, this._vectorCounts[i], VertexAttribPointerType.Float, false, 0, 0);
				this._data[i] = new List<float>();
			}
			this._context.VertexBuffers.Add(this);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x0000301C File Offset: 0x0000121C
		public override void Dispose()
		{
			GL.DeleteVertexArrays(1, new int[]
			{
				this._glId
			});
			GL.DeleteBuffers(this._numBuffers, this._glBufferIds);
			this._context.VertexBuffers.Remove(this);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00003056 File Offset: 0x00001256
		public override void SetBufferData(int index, IEnumerable<double> data)
		{
			this.SetBufferData(index, from x in data
			select (float)x);
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00003084 File Offset: 0x00001284
		public void SetBufferData(int index, IEnumerable<float> data)
		{
			GL.BindBuffer(BufferTarget.ArrayBuffer, this._glBufferIds[index]);
			GL.BufferData<float>(BufferTarget.ArrayBuffer, (IntPtr)(data.Count<float>() * 4), (from x in data
			select x).ToArray<float>(), BufferUsageHint.StreamDraw);
		}

		// Token: 0x0600005C RID: 92 RVA: 0x000030E9 File Offset: 0x000012E9
		public override void AddValue(int index, double value)
		{
			this._data[index].Add((float)value);
		}

		// Token: 0x0600005D RID: 93 RVA: 0x000030FC File Offset: 0x000012FC
		public override void Begin()
		{
			for (int i = 0; i < this._numBuffers; i++)
			{
				this._data[i].Clear();
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00003128 File Offset: 0x00001328
		public override void End()
		{
			this._numPoints = 0;
			for (int i = 0; i < this._numBuffers; i++)
			{
				int numPoints = this._data[i].Count / this._vectorCounts[i];
				if (i == 0)
				{
					this._numPoints = numPoints;
				}
				else
				{
					int numPoints2 = this._numPoints;
				}
			}
			if (this._numPoints == 0)
			{
				this._noRender = true;
				return;
			}
			for (int j = 0; j < this._numBuffers; j++)
			{
				this.SetBufferData(j, this._data[j]);
			}
			this._noRender = false;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x000031B0 File Offset: 0x000013B0
		public override void Render(SonicOrca.Graphics.PrimitiveType type)
		{
			if (!this._noRender)
			{
				GL.BindVertexArray(this._glId);
				GL.DrawArrays(GLVertexBuffer.BeginModesForPrimitiveTypes[(int)type], 0, this._numPoints);
			}
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000031DC File Offset: 0x000013DC
		public override void Render(SonicOrca.Graphics.PrimitiveType type, int index, int count)
		{
			if (!this._noRender)
			{
				GL.BindVertexArray(this._glId);
				GL.DrawArrays(GLVertexBuffer.BeginModesForPrimitiveTypes[(int)type], index, count);
			}
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00003203 File Offset: 0x00001403
		// Note: this type is marked as 'beforefieldinit'.
		static GLVertexBuffer()
		{
			OpenTK.Graphics.OpenGL.PrimitiveType[] array = new OpenTK.Graphics.OpenGL.PrimitiveType[10];
			RuntimeHelpers.InitializeArray(array, fieldof(<PrivateImplementationDetails>.D12BEB9A11B341F408C41468985FFC5C95438CEA).FieldHandle);
			GLVertexBuffer.BeginModesForPrimitiveTypes = array;
		}

		// Token: 0x04000022 RID: 34
		private static readonly IReadOnlyList<OpenTK.Graphics.OpenGL.PrimitiveType> BeginModesForPrimitiveTypes;

		// Token: 0x04000023 RID: 35
		private readonly GLGraphicsContext _context;

		// Token: 0x04000024 RID: 36
		private readonly int _numBuffers;

		// Token: 0x04000025 RID: 37
		private readonly int[] _vectorCounts;

		// Token: 0x04000026 RID: 38
		private readonly int _glId;

		// Token: 0x04000027 RID: 39
		private readonly int[] _glBufferIds;

		// Token: 0x04000028 RID: 40
		private readonly List<float>[] _data;

		// Token: 0x04000029 RID: 41
		private int _numPoints;

		// Token: 0x0400002A RID: 42
		private bool _noRender;
	}
}
