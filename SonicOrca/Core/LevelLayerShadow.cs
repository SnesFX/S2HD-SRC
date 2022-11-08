using System;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SonicOrca.Core
{
	// Token: 0x02000125 RID: 293
	public class LevelLayerShadow
	{
		// Token: 0x170002B5 RID: 693
		// (get) Token: 0x06000B77 RID: 2935 RVA: 0x0002C687 File Offset: 0x0002A887
		// (set) Token: 0x06000B78 RID: 2936 RVA: 0x0002C68F File Offset: 0x0002A88F
		public bool Tiles { get; set; }

		// Token: 0x170002B6 RID: 694
		// (get) Token: 0x06000B79 RID: 2937 RVA: 0x0002C698 File Offset: 0x0002A898
		// (set) Token: 0x06000B7A RID: 2938 RVA: 0x0002C6A0 File Offset: 0x0002A8A0
		public bool Objects { get; set; }

		// Token: 0x170002B7 RID: 695
		// (get) Token: 0x06000B7B RID: 2939 RVA: 0x0002C6A9 File Offset: 0x0002A8A9
		// (set) Token: 0x06000B7C RID: 2940 RVA: 0x0002C6B1 File Offset: 0x0002A8B1
		public int LayerIndexOffset { get; set; }

		// Token: 0x170002B8 RID: 696
		// (get) Token: 0x06000B7D RID: 2941 RVA: 0x0002C6BA File Offset: 0x0002A8BA
		// (set) Token: 0x06000B7E RID: 2942 RVA: 0x0002C6C2 File Offset: 0x0002A8C2
		public Vector2i Displacement { get; set; }

		// Token: 0x170002B9 RID: 697
		// (get) Token: 0x06000B7F RID: 2943 RVA: 0x0002C6CB File Offset: 0x0002A8CB
		// (set) Token: 0x06000B80 RID: 2944 RVA: 0x0002C6D3 File Offset: 0x0002A8D3
		public int Softness { get; set; }

		// Token: 0x170002BA RID: 698
		// (get) Token: 0x06000B81 RID: 2945 RVA: 0x0002C6DC File Offset: 0x0002A8DC
		// (set) Token: 0x06000B82 RID: 2946 RVA: 0x0002C6E4 File Offset: 0x0002A8E4
		public Colour Colour { get; set; }

		// Token: 0x06000B83 RID: 2947 RVA: 0x0002C6ED File Offset: 0x0002A8ED
		public LevelLayerShadow()
		{
			this.Tiles = true;
			this.Objects = true;
			this.Colour = LevelLayerShadow.DefaultShadowColour;
		}

		// Token: 0x06000B84 RID: 2948 RVA: 0x0002C710 File Offset: 0x0002A910
		public override string ToString()
		{
			return string.Format("[{0}{1}] {2:+#;-#;0} {3:+#;-#;0},{4:+#;-#;0} {5} @{6}", new object[]
			{
				this.Tiles ? 'T' : ' ',
				this.Objects ? 'O' : ' ',
				this.LayerIndexOffset,
				this.Displacement.X,
				this.Displacement.Y,
				this.Colour.ToHexString(),
				this.Softness
			});
		}

		// Token: 0x0400069E RID: 1694
		public static readonly Colour DefaultShadowColour = new Colour(128, 0, 0, 0);
	}
}
