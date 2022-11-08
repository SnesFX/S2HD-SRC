using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca.Geometry;

namespace SonicOrca.Graphics
{
	// Token: 0x020000D7 RID: 215
	public class Animation
	{
		// Token: 0x17000150 RID: 336
		// (get) Token: 0x06000723 RID: 1827 RVA: 0x0001DE2F File Offset: 0x0001C02F
		// (set) Token: 0x06000724 RID: 1828 RVA: 0x0001DE37 File Offset: 0x0001C037
		public IReadOnlyList<Animation.Frame> Frames
		{
			get
			{
				return this._frames;
			}
			set
			{
				this._frames = value.ToArray<Animation.Frame>();
			}
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x06000725 RID: 1829 RVA: 0x0001DE45 File Offset: 0x0001C045
		// (set) Token: 0x06000726 RID: 1830 RVA: 0x0001DE4D File Offset: 0x0001C04D
		public int? NextFrameIndex { get; set; }

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x06000727 RID: 1831 RVA: 0x0001DE56 File Offset: 0x0001C056
		// (set) Token: 0x06000728 RID: 1832 RVA: 0x0001DE5E File Offset: 0x0001C05E
		public int? LoopFrameIndex { get; set; }

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06000729 RID: 1833 RVA: 0x0001DE67 File Offset: 0x0001C067
		public int Duration
		{
			get
			{
				return this._frames.Sum((Animation.Frame x) => x.Delay + 1);
			}
		}

		// Token: 0x0600072A RID: 1834 RVA: 0x0001DE93 File Offset: 0x0001C093
		public Animation()
		{
		}

		// Token: 0x0600072B RID: 1835 RVA: 0x0001DEA7 File Offset: 0x0001C0A7
		public Animation(IEnumerable<Animation.Frame> frames)
		{
			this._frames = frames.ToArray<Animation.Frame>();
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x0001DEC7 File Offset: 0x0001C0C7
		public Animation(IEnumerable<Animation.Frame> frames, int? nextFrameIndex, int? loopFrameIndex)
		{
			this._frames = frames.ToArray<Animation.Frame>();
			this.NextFrameIndex = nextFrameIndex;
			this.LoopFrameIndex = loopFrameIndex;
		}

		// Token: 0x040004C9 RID: 1225
		private Animation.Frame[] _frames = new Animation.Frame[0];

		// Token: 0x020001D2 RID: 466
		public struct Frame
		{
			// Token: 0x17000512 RID: 1298
			// (get) Token: 0x060012E4 RID: 4836 RVA: 0x00049296 File Offset: 0x00047496
			// (set) Token: 0x060012E5 RID: 4837 RVA: 0x0004929E File Offset: 0x0004749E
			public int TextureIndex { get; set; }

			// Token: 0x17000513 RID: 1299
			// (get) Token: 0x060012E6 RID: 4838 RVA: 0x000492A7 File Offset: 0x000474A7
			// (set) Token: 0x060012E7 RID: 4839 RVA: 0x000492AF File Offset: 0x000474AF
			public Rectanglei Source { get; set; }

			// Token: 0x17000514 RID: 1300
			// (get) Token: 0x060012E8 RID: 4840 RVA: 0x000492B8 File Offset: 0x000474B8
			// (set) Token: 0x060012E9 RID: 4841 RVA: 0x000492C0 File Offset: 0x000474C0
			public Vector2i Offset { get; set; }

			// Token: 0x17000515 RID: 1301
			// (get) Token: 0x060012EA RID: 4842 RVA: 0x000492C9 File Offset: 0x000474C9
			// (set) Token: 0x060012EB RID: 4843 RVA: 0x000492D1 File Offset: 0x000474D1
			public int Delay { get; set; }
		}
	}
}
