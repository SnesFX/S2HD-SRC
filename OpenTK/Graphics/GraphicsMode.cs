using System;

namespace OpenTK.Graphics
{
	// Token: 0x020001B9 RID: 441
	public class GraphicsMode : IEquatable<GraphicsMode>
	{
		// Token: 0x06000BE2 RID: 3042 RVA: 0x000274AC File Offset: 0x000256AC
		internal GraphicsMode(GraphicsMode mode) : this(mode.ColorFormat, mode.Depth, mode.Stencil, mode.Samples, mode.AccumulatorFormat, mode.Buffers, mode.Stereo)
		{
		}

		// Token: 0x06000BE3 RID: 3043 RVA: 0x000274E0 File Offset: 0x000256E0
		internal GraphicsMode(IntPtr? index, ColorFormat color, int depth, int stencil, int samples, ColorFormat accum, int buffers, bool stereo)
		{
			if (depth < 0)
			{
				throw new ArgumentOutOfRangeException("depth", "Must be greater than, or equal to zero.");
			}
			if (stencil < 0)
			{
				throw new ArgumentOutOfRangeException("stencil", "Must be greater than, or equal to zero.");
			}
			if (buffers < 0)
			{
				throw new ArgumentOutOfRangeException("buffers", "Must be greater than, or equal to zero.");
			}
			if (samples < 0)
			{
				throw new ArgumentOutOfRangeException("samples", "Must be greater than, or equal to zero.");
			}
			this.Index = index;
			this.ColorFormat = color;
			this.Depth = depth;
			this.Stencil = stencil;
			this.Samples = samples;
			this.AccumulatorFormat = accum;
			this.Buffers = buffers;
			this.Stereo = stereo;
		}

		// Token: 0x06000BE4 RID: 3044 RVA: 0x00027590 File Offset: 0x00025790
		public GraphicsMode() : this(GraphicsMode.Default)
		{
		}

		// Token: 0x06000BE5 RID: 3045 RVA: 0x000275A0 File Offset: 0x000257A0
		public GraphicsMode(ColorFormat color) : this(color, GraphicsMode.Default.Depth, GraphicsMode.Default.Stencil, GraphicsMode.Default.Samples, GraphicsMode.Default.AccumulatorFormat, GraphicsMode.Default.Buffers, GraphicsMode.Default.Stereo)
		{
		}

		// Token: 0x06000BE6 RID: 3046 RVA: 0x000275F0 File Offset: 0x000257F0
		public GraphicsMode(ColorFormat color, int depth) : this(color, depth, GraphicsMode.Default.Stencil, GraphicsMode.Default.Samples, GraphicsMode.Default.AccumulatorFormat, GraphicsMode.Default.Buffers, GraphicsMode.Default.Stereo)
		{
		}

		// Token: 0x06000BE7 RID: 3047 RVA: 0x0002762C File Offset: 0x0002582C
		public GraphicsMode(ColorFormat color, int depth, int stencil) : this(color, depth, stencil, GraphicsMode.Default.Samples, GraphicsMode.Default.AccumulatorFormat, GraphicsMode.Default.Buffers, GraphicsMode.Default.Stereo)
		{
		}

		// Token: 0x06000BE8 RID: 3048 RVA: 0x00027660 File Offset: 0x00025860
		public GraphicsMode(ColorFormat color, int depth, int stencil, int samples) : this(color, depth, stencil, samples, GraphicsMode.Default.AccumulatorFormat, GraphicsMode.Default.Buffers, GraphicsMode.Default.Stereo)
		{
		}

		// Token: 0x06000BE9 RID: 3049 RVA: 0x0002768C File Offset: 0x0002588C
		public GraphicsMode(ColorFormat color, int depth, int stencil, int samples, ColorFormat accum) : this(color, depth, stencil, samples, accum, GraphicsMode.Default.Buffers, GraphicsMode.Default.Stereo)
		{
		}

		// Token: 0x06000BEA RID: 3050 RVA: 0x000276B0 File Offset: 0x000258B0
		public GraphicsMode(ColorFormat color, int depth, int stencil, int samples, ColorFormat accum, int buffers) : this(color, depth, stencil, samples, accum, buffers, GraphicsMode.Default.Stereo)
		{
		}

		// Token: 0x06000BEB RID: 3051 RVA: 0x000276CC File Offset: 0x000258CC
		public GraphicsMode(ColorFormat color, int depth, int stencil, int samples, ColorFormat accum, int buffers, bool stereo) : this(null, color, depth, stencil, samples, accum, buffers, stereo)
		{
		}

		// Token: 0x17000255 RID: 597
		// (get) Token: 0x06000BEC RID: 3052 RVA: 0x000276F4 File Offset: 0x000258F4
		// (set) Token: 0x06000BED RID: 3053 RVA: 0x000276FC File Offset: 0x000258FC
		public IntPtr? Index
		{
			get
			{
				return this.index;
			}
			set
			{
				this.index = value;
			}
		}

		// Token: 0x17000256 RID: 598
		// (get) Token: 0x06000BEE RID: 3054 RVA: 0x00027708 File Offset: 0x00025908
		// (set) Token: 0x06000BEF RID: 3055 RVA: 0x00027710 File Offset: 0x00025910
		public ColorFormat ColorFormat
		{
			get
			{
				return this.color_format;
			}
			private set
			{
				this.color_format = value;
			}
		}

		// Token: 0x17000257 RID: 599
		// (get) Token: 0x06000BF0 RID: 3056 RVA: 0x0002771C File Offset: 0x0002591C
		// (set) Token: 0x06000BF1 RID: 3057 RVA: 0x00027724 File Offset: 0x00025924
		public ColorFormat AccumulatorFormat
		{
			get
			{
				return this.accumulator_format;
			}
			private set
			{
				this.accumulator_format = value;
			}
		}

		// Token: 0x17000258 RID: 600
		// (get) Token: 0x06000BF2 RID: 3058 RVA: 0x00027730 File Offset: 0x00025930
		// (set) Token: 0x06000BF3 RID: 3059 RVA: 0x00027738 File Offset: 0x00025938
		public int Depth
		{
			get
			{
				return this.depth;
			}
			private set
			{
				this.depth = value;
			}
		}

		// Token: 0x17000259 RID: 601
		// (get) Token: 0x06000BF4 RID: 3060 RVA: 0x00027744 File Offset: 0x00025944
		// (set) Token: 0x06000BF5 RID: 3061 RVA: 0x0002774C File Offset: 0x0002594C
		public int Stencil
		{
			get
			{
				return this.stencil;
			}
			private set
			{
				this.stencil = value;
			}
		}

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x06000BF6 RID: 3062 RVA: 0x00027758 File Offset: 0x00025958
		// (set) Token: 0x06000BF7 RID: 3063 RVA: 0x00027760 File Offset: 0x00025960
		public int Samples
		{
			get
			{
				return this.samples;
			}
			private set
			{
				this.samples = MathHelper.Clamp(value, 0, 64);
			}
		}

		// Token: 0x1700025B RID: 603
		// (get) Token: 0x06000BF8 RID: 3064 RVA: 0x00027774 File Offset: 0x00025974
		// (set) Token: 0x06000BF9 RID: 3065 RVA: 0x0002777C File Offset: 0x0002597C
		public bool Stereo
		{
			get
			{
				return this.stereo;
			}
			private set
			{
				this.stereo = value;
			}
		}

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x06000BFA RID: 3066 RVA: 0x00027788 File Offset: 0x00025988
		// (set) Token: 0x06000BFB RID: 3067 RVA: 0x00027790 File Offset: 0x00025990
		public int Buffers
		{
			get
			{
				return this.buffers;
			}
			private set
			{
				this.buffers = value;
			}
		}

		// Token: 0x1700025D RID: 605
		// (get) Token: 0x06000BFC RID: 3068 RVA: 0x0002779C File Offset: 0x0002599C
		public static GraphicsMode Default
		{
			get
			{
				GraphicsMode result;
				lock (GraphicsMode.SyncRoot)
				{
					if (GraphicsMode.defaultMode == null)
					{
						GraphicsMode.defaultMode = new GraphicsMode(null, 32, 16, 0, 0, 0, 2, false);
					}
					result = GraphicsMode.defaultMode;
				}
				return result;
			}
		}

		// Token: 0x06000BFD RID: 3069 RVA: 0x00027804 File Offset: 0x00025A04
		public override string ToString()
		{
			return string.Format("Index: {0}, Color: {1}, Depth: {2}, Stencil: {3}, Samples: {4}, Accum: {5}, Buffers: {6}, Stereo: {7}", new object[]
			{
				this.Index,
				this.ColorFormat,
				this.Depth,
				this.Stencil,
				this.Samples,
				this.AccumulatorFormat,
				this.Buffers,
				this.Stereo
			});
		}

		// Token: 0x06000BFE RID: 3070 RVA: 0x00027894 File Offset: 0x00025A94
		public override int GetHashCode()
		{
			return this.Index.GetHashCode();
		}

		// Token: 0x06000BFF RID: 3071 RVA: 0x000278B8 File Offset: 0x00025AB8
		public override bool Equals(object obj)
		{
			return obj is GraphicsMode && this.Equals((GraphicsMode)obj);
		}

		// Token: 0x06000C00 RID: 3072 RVA: 0x000278D0 File Offset: 0x00025AD0
		public bool Equals(GraphicsMode other)
		{
			return this.Index != null && this.Index == other.Index;
		}

		// Token: 0x0400120F RID: 4623
		private ColorFormat color_format;

		// Token: 0x04001210 RID: 4624
		private ColorFormat accumulator_format;

		// Token: 0x04001211 RID: 4625
		private int depth;

		// Token: 0x04001212 RID: 4626
		private int stencil;

		// Token: 0x04001213 RID: 4627
		private int buffers;

		// Token: 0x04001214 RID: 4628
		private int samples;

		// Token: 0x04001215 RID: 4629
		private bool stereo;

		// Token: 0x04001216 RID: 4630
		private IntPtr? index = null;

		// Token: 0x04001217 RID: 4631
		private static GraphicsMode defaultMode;

		// Token: 0x04001218 RID: 4632
		private static readonly object SyncRoot = new object();
	}
}
