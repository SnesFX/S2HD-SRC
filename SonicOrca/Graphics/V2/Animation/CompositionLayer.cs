using System;

namespace SonicOrca.Graphics.V2.Animation
{
	// Token: 0x020000EF RID: 239
	public class CompositionLayer
	{
		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x0600084F RID: 2127 RVA: 0x00020C75 File Offset: 0x0001EE75
		public string TextureReference
		{
			get
			{
				return this._textureReference;
			}
		}

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x06000850 RID: 2128 RVA: 0x00020C7D File Offset: 0x0001EE7D
		public uint StartFrame
		{
			get
			{
				return this._startFrame;
			}
		}

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x06000851 RID: 2129 RVA: 0x00020C85 File Offset: 0x0001EE85
		public uint EndFrame
		{
			get
			{
				return this._endFrame;
			}
		}

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x06000852 RID: 2130 RVA: 0x00020C8D File Offset: 0x0001EE8D
		public uint Index
		{
			get
			{
				return this._index;
			}
		}

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x06000853 RID: 2131 RVA: 0x00020C95 File Offset: 0x0001EE95
		public CompositionLayer.LayerKind Kind
		{
			get
			{
				return this._layerType;
			}
		}

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x06000854 RID: 2132 RVA: 0x00020C9D File Offset: 0x0001EE9D
		public CompositionLayer.LayerSubKind SubKind
		{
			get
			{
				return this._layerSubType;
			}
		}

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x06000855 RID: 2133 RVA: 0x00020CA5 File Offset: 0x0001EEA5
		public BlendMode BlendMode
		{
			get
			{
				return this._layerBlendMode;
			}
		}

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x06000856 RID: 2134 RVA: 0x00020CAD File Offset: 0x0001EEAD
		public CompositionLayerAnimatableTransform Transform
		{
			get
			{
				return this._transform;
			}
		}

		// Token: 0x06000857 RID: 2135 RVA: 0x00020CB8 File Offset: 0x0001EEB8
		public CompositionLayer(uint index, uint layerType, uint layerSubType, uint layerBlendMode, string name, string fileExtension, string textureReference, uint startFrame, uint endFrame, CompositionLayerAnimatableTransform transform)
		{
			this._index = index;
			if (layerType == 2U)
			{
				this._layerType = CompositionLayer.LayerKind.Image;
				if (layerSubType != 0U)
				{
					if (layerSubType != 1U)
					{
						throw new NotImplementedException();
					}
					this._layerSubType = CompositionLayer.LayerSubKind.Mask;
				}
				else
				{
					this._layerSubType = CompositionLayer.LayerSubKind.None;
				}
				switch (layerBlendMode)
				{
				case 0U:
					this._layerBlendMode = BlendMode.Alpha;
					break;
				case 1U:
					this._layerBlendMode = BlendMode.Additive;
					break;
				case 2U:
					this._layerBlendMode = BlendMode.Opaque;
					break;
				}
				this._name = name;
				this._fileExtension = fileExtension;
				this._textureReference = textureReference;
				this._startFrame = startFrame;
				this._endFrame = endFrame;
				this._transform = transform;
				return;
			}
			throw new NotImplementedException();
		}

		// Token: 0x06000858 RID: 2136 RVA: 0x00020D64 File Offset: 0x0001EF64
		public void ResetFrame()
		{
			this._ellapsedFrames = 0U;
			this._transform.ResetFrame();
		}

		// Token: 0x06000859 RID: 2137 RVA: 0x00020D78 File Offset: 0x0001EF78
		public void Animate()
		{
			if (this._ellapsedFrames <= this._endFrame)
			{
				this._transform.Animate();
			}
			if (this._ellapsedFrames <= this._endFrame)
			{
				this._ellapsedFrames += 1U;
			}
		}

		// Token: 0x0400050C RID: 1292
		private const uint _ddd = 0U;

		// Token: 0x0400050D RID: 1293
		private uint _index;

		// Token: 0x0400050E RID: 1294
		private CompositionLayer.LayerKind _layerType;

		// Token: 0x0400050F RID: 1295
		private CompositionLayer.LayerSubKind _layerSubType;

		// Token: 0x04000510 RID: 1296
		private BlendMode _layerBlendMode;

		// Token: 0x04000511 RID: 1297
		private string _name;

		// Token: 0x04000512 RID: 1298
		private string _fileExtension;

		// Token: 0x04000513 RID: 1299
		private string _textureReference;

		// Token: 0x04000514 RID: 1300
		private const double _sampleRate = 0.0;

		// Token: 0x04000515 RID: 1301
		private uint _startFrame;

		// Token: 0x04000516 RID: 1302
		private uint _endFrame;

		// Token: 0x04000517 RID: 1303
		private const uint _bm = 0U;

		// Token: 0x04000518 RID: 1304
		private uint _ellapsedFrames;

		// Token: 0x04000519 RID: 1305
		private CompositionLayerAnimatableTransform _transform;

		// Token: 0x020001E3 RID: 483
		public enum LayerKind
		{
			// Token: 0x04000AFA RID: 2810
			Image
		}

		// Token: 0x020001E4 RID: 484
		public enum LayerSubKind
		{
			// Token: 0x04000AFC RID: 2812
			None,
			// Token: 0x04000AFD RID: 2813
			Mask
		}
	}
}
