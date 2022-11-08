using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca.Geometry;

namespace SonicOrca.Graphics.V2.Animation
{
	// Token: 0x020000F9 RID: 249
	public class Composition
	{
		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x06000893 RID: 2195 RVA: 0x00022175 File Offset: 0x00020375
		public uint StartFrame
		{
			get
			{
				return this._startFrame;
			}
		}

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x06000894 RID: 2196 RVA: 0x0002217D File Offset: 0x0002037D
		public uint EndFrame
		{
			get
			{
				return this._endFrame;
			}
		}

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x06000895 RID: 2197 RVA: 0x00022185 File Offset: 0x00020385
		// (set) Token: 0x06000896 RID: 2198 RVA: 0x0002218D File Offset: 0x0002038D
		public IReadOnlyList<CompositionLayer> Layers
		{
			get
			{
				return this._layers;
			}
			set
			{
				this._layers = value.ToArray<CompositionLayer>();
			}
		}

		// Token: 0x06000897 RID: 2199 RVA: 0x0002219C File Offset: 0x0002039C
		public Composition(string version, uint frameRate, uint startFrame, uint endFrame, uint width, uint height, string name, IEnumerable<CompositionLayer> layers)
		{
			this._version = version;
			this._frameRate = frameRate;
			this._startFrame = startFrame;
			this._endFrame = endFrame;
			this._width = width;
			this._height = height;
			this._name = name;
			this._layers = layers.ToArray<CompositionLayer>();
		}

		// Token: 0x04000531 RID: 1329
		private string _version;

		// Token: 0x04000532 RID: 1330
		private uint _frameRate;

		// Token: 0x04000533 RID: 1331
		private uint _startFrame;

		// Token: 0x04000534 RID: 1332
		private uint _endFrame;

		// Token: 0x04000535 RID: 1333
		private uint _width;

		// Token: 0x04000536 RID: 1334
		private uint _height;

		// Token: 0x04000537 RID: 1335
		private string _name;

		// Token: 0x04000538 RID: 1336
		private const uint _ddd = 0U;

		// Token: 0x04000539 RID: 1337
		private CompositionLayer[] _layers = new CompositionLayer[0];

		// Token: 0x020001E9 RID: 489
		public struct Frame
		{
			// Token: 0x17000516 RID: 1302
			// (get) Token: 0x06001329 RID: 4905 RVA: 0x0004A0C2 File Offset: 0x000482C2
			// (set) Token: 0x0600132A RID: 4906 RVA: 0x0004A0CA File Offset: 0x000482CA
			public int TextureIndex { get; set; }

			// Token: 0x17000517 RID: 1303
			// (get) Token: 0x0600132B RID: 4907 RVA: 0x0004A0D3 File Offset: 0x000482D3
			// (set) Token: 0x0600132C RID: 4908 RVA: 0x0004A0DB File Offset: 0x000482DB
			public Rectanglei Source { get; set; }

			// Token: 0x17000518 RID: 1304
			// (get) Token: 0x0600132D RID: 4909 RVA: 0x0004A0E4 File Offset: 0x000482E4
			// (set) Token: 0x0600132E RID: 4910 RVA: 0x0004A0EC File Offset: 0x000482EC
			public double Opacity { get; set; }

			// Token: 0x17000519 RID: 1305
			// (get) Token: 0x0600132F RID: 4911 RVA: 0x0004A0F5 File Offset: 0x000482F5
			// (set) Token: 0x06001330 RID: 4912 RVA: 0x0004A0FD File Offset: 0x000482FD
			public Vector2 Position { get; set; }

			// Token: 0x1700051A RID: 1306
			// (get) Token: 0x06001331 RID: 4913 RVA: 0x0004A106 File Offset: 0x00048306
			// (set) Token: 0x06001332 RID: 4914 RVA: 0x0004A10E File Offset: 0x0004830E
			public double Rotation { get; set; }

			// Token: 0x1700051B RID: 1307
			// (get) Token: 0x06001333 RID: 4915 RVA: 0x0004A117 File Offset: 0x00048317
			// (set) Token: 0x06001334 RID: 4916 RVA: 0x0004A11F File Offset: 0x0004831F
			public Vector2 Scale { get; set; }
		}
	}
}
