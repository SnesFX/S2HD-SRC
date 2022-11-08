using System;
using System.Collections.Generic;

namespace SonicOrca.Graphics.V2.Animation
{
	// Token: 0x020000F4 RID: 244
	public class CompositionLayerTween
	{
		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x06000860 RID: 2144 RVA: 0x00021148 File Offset: 0x0001F348
		// (set) Token: 0x06000861 RID: 2145 RVA: 0x00021150 File Offset: 0x0001F350
		public CompositionLayerTween.Type TweenType { get; set; }

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x06000862 RID: 2146 RVA: 0x00021159 File Offset: 0x0001F359
		public Dictionary<string, double> StartValues
		{
			get
			{
				return this._startValues;
			}
		}

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x06000863 RID: 2147 RVA: 0x00021161 File Offset: 0x0001F361
		public Dictionary<string, double> EndValues
		{
			get
			{
				return this._endValues;
			}
		}

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x06000864 RID: 2148 RVA: 0x00021169 File Offset: 0x0001F369
		public List<string> ValueKeys
		{
			get
			{
				return this._valueKeys;
			}
		}

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x06000865 RID: 2149 RVA: 0x00021171 File Offset: 0x0001F371
		public uint Duration
		{
			get
			{
				return this._duration;
			}
		}

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x06000866 RID: 2150 RVA: 0x00021179 File Offset: 0x0001F379
		// (set) Token: 0x06000867 RID: 2151 RVA: 0x00021181 File Offset: 0x0001F381
		public uint CurrentFrame
		{
			get
			{
				return this._currentFrame;
			}
			protected set
			{
				this._currentFrame = value;
			}
		}

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x06000868 RID: 2152 RVA: 0x0002118A File Offset: 0x0001F38A
		public uint StartFrame
		{
			get
			{
				return this._startFrame;
			}
		}

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x06000869 RID: 2153 RVA: 0x00021192 File Offset: 0x0001F392
		public uint EndFrame
		{
			get
			{
				return this._endFrame;
			}
		}

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x0600086A RID: 2154 RVA: 0x0002119A File Offset: 0x0001F39A
		// (set) Token: 0x0600086B RID: 2155 RVA: 0x000211A2 File Offset: 0x0001F3A2
		public bool HasKeyFrames
		{
			get
			{
				return this._hasKeyframes;
			}
			set
			{
				this._hasKeyframes = value;
			}
		}

		// Token: 0x0600086C RID: 2156 RVA: 0x000211AC File Offset: 0x0001F3AC
		public CompositionLayerTween(uint startFrame, uint endFrame)
		{
			this._startFrame = startFrame;
			this._endFrame = endFrame;
			this._currentFrame = 0U;
			this._duration = 1U + (this._endFrame - this._startFrame);
		}

		// Token: 0x0600086D RID: 2157 RVA: 0x00021211 File Offset: 0x0001F411
		public void ResetFrame()
		{
			this._ellapsedFrames = 0U;
			this._currentFrame = 0U;
		}

		// Token: 0x0600086E RID: 2158 RVA: 0x00021224 File Offset: 0x0001F424
		public void Animate()
		{
			if (this._ellapsedFrames < this._endFrame)
			{
				this._ellapsedFrames += 1U;
			}
			if (this._ellapsedFrames >= this._startFrame && this._currentFrame < this._duration)
			{
				this._currentFrame += 1U;
			}
		}

		// Token: 0x0600086F RID: 2159 RVA: 0x00021278 File Offset: 0x0001F478
		public Dictionary<string, double> GetValueSet()
		{
			Dictionary<string, double> dictionary = new Dictionary<string, double>();
			foreach (string key in this.ValueKeys)
			{
				double num = this.EndValues[key] - this.StartValues[key];
				if (num != 0.0)
				{
					dictionary[key] = this.StartValues[key] + num / this._duration * this._currentFrame;
				}
				else
				{
					dictionary[key] = this.StartValues[key];
				}
			}
			return dictionary;
		}

		// Token: 0x0400051B RID: 1307
		private bool _hasKeyframes = true;

		// Token: 0x0400051C RID: 1308
		private uint _duration;

		// Token: 0x0400051D RID: 1309
		private uint _startFrame;

		// Token: 0x0400051E RID: 1310
		private uint _endFrame;

		// Token: 0x0400051F RID: 1311
		private uint _currentFrame;

		// Token: 0x04000520 RID: 1312
		private uint _ellapsedFrames;

		// Token: 0x04000521 RID: 1313
		private Dictionary<string, double> _startValues = new Dictionary<string, double>();

		// Token: 0x04000522 RID: 1314
		private Dictionary<string, double> _endValues = new Dictionary<string, double>();

		// Token: 0x04000523 RID: 1315
		protected List<string> _valueKeys = new List<string>();

		// Token: 0x020001E5 RID: 485
		public enum Type
		{
			// Token: 0x04000AFF RID: 2815
			OPACITY,
			// Token: 0x04000B00 RID: 2816
			POSITION,
			// Token: 0x04000B01 RID: 2817
			ROTATION,
			// Token: 0x04000B02 RID: 2818
			SCALE
		}
	}
}
