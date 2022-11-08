using System;
using SonicOrca.Geometry;

namespace SonicOrca.Core.Lighting
{
	// Token: 0x0200018C RID: 396
	public class VectorLightSource : ILightSource
	{
		// Token: 0x17000486 RID: 1158
		// (get) Token: 0x06001130 RID: 4400 RVA: 0x00044029 File Offset: 0x00042229
		// (set) Token: 0x06001131 RID: 4401 RVA: 0x00044031 File Offset: 0x00042231
		public int Intensity { get; set; }

		// Token: 0x17000487 RID: 1159
		// (get) Token: 0x06001132 RID: 4402 RVA: 0x0004403A File Offset: 0x0004223A
		// (set) Token: 0x06001133 RID: 4403 RVA: 0x00044042 File Offset: 0x00042242
		public Vector2i A { get; set; }

		// Token: 0x17000488 RID: 1160
		// (get) Token: 0x06001134 RID: 4404 RVA: 0x0004404B File Offset: 0x0004224B
		// (set) Token: 0x06001135 RID: 4405 RVA: 0x00044053 File Offset: 0x00042253
		public Vector2i B { get; set; }

		// Token: 0x06001136 RID: 4406 RVA: 0x0004405C File Offset: 0x0004225C
		public VectorLightSource(int intensity, Vector2i a, Vector2i b)
		{
			this.Intensity = intensity;
			this.A = a;
			this.B = b;
		}

		// Token: 0x06001137 RID: 4407 RVA: 0x0004407C File Offset: 0x0004227C
		public Vector2i GetShadowOffset(Vector2i occlusionPosition, IShadowInfo shadowInfo)
		{
			Vector2i occlusionSize = shadowInfo.OcclusionSize;
			Rectanglei rectanglei = new Rectanglei(occlusionPosition.X - occlusionSize.X, occlusionPosition.Y - occlusionSize.Y, occlusionSize.X * 2, occlusionSize.Y * 2);
			if (rectanglei.Top > this.A.Y)
			{
				return default(Vector2i);
			}
			int num = 0;
			if (rectanglei.Right < this.A.X)
			{
				num += this.A.X - rectanglei.Right;
			}
			if (rectanglei.Left > this.B.X)
			{
				num += rectanglei.Left - this.B.X;
			}
			num /= 4;
			int num2 = Math.Max(0, this.A.Y - occlusionPosition.Y) / 16;
			int num3 = -Math.Max(0, 48 - num2);
			num3 = Math.Min(0, num3 + num);
			return new Vector2i(0, num3);
		}
	}
}
