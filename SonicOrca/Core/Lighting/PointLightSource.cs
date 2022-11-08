using System;
using SonicOrca.Geometry;

namespace SonicOrca.Core.Lighting
{
	// Token: 0x0200018B RID: 395
	public class PointLightSource : ILightSource
	{
		// Token: 0x17000484 RID: 1156
		// (get) Token: 0x06001128 RID: 4392 RVA: 0x00043EC5 File Offset: 0x000420C5
		// (set) Token: 0x06001129 RID: 4393 RVA: 0x00043ECD File Offset: 0x000420CD
		public int Intensity { get; set; }

		// Token: 0x17000485 RID: 1157
		// (get) Token: 0x0600112A RID: 4394 RVA: 0x00043ED6 File Offset: 0x000420D6
		// (set) Token: 0x0600112B RID: 4395 RVA: 0x00043EDE File Offset: 0x000420DE
		public Vector2i Position { get; set; }

		// Token: 0x0600112C RID: 4396 RVA: 0x00043EE7 File Offset: 0x000420E7
		public PointLightSource(int intensity, Vector2i position)
		{
			this.Intensity = intensity;
			this.Position = position;
		}

		// Token: 0x0600112D RID: 4397 RVA: 0x00043F00 File Offset: 0x00042100
		public Vector2i GetShadowOffset(Vector2i occlusionPosition, IShadowInfo shadowInfo)
		{
			int num = 25;
			int num2 = 16;
			int num3 = num;
			int num4 = num * num2;
			Vector2i vector2i = occlusionPosition - this.Position;
			int length = vector2i.Length;
			Vector2i result = default(Vector2i);
			if (length != 0)
			{
				if (length <= num3)
				{
					int num5 = num * length / num3;
					result.X = vector2i.X * num5 / length;
					result.Y = vector2i.Y * num5 / length;
				}
				else if (length < num4)
				{
					int num6 = (num4 - length) / num2;
					result.X = vector2i.X * num6 / length;
					result.Y = vector2i.Y * num6 / length;
				}
			}
			return result;
		}

		// Token: 0x0600112E RID: 4398 RVA: 0x00043FAC File Offset: 0x000421AC
		private static int ScaleOffset(int distance, int delta, int max)
		{
			if (delta > 0)
			{
				delta = Math.Max(delta, distance);
				int num = delta / 8;
				return Math.Max(max - num, 0);
			}
			delta = Math.Min(delta, -distance);
			int num2 = delta / 8;
			return Math.Min(-max - num2, 0);
		}

		// Token: 0x0600112F RID: 4399 RVA: 0x00043FEC File Offset: 0x000421EC
		public override string ToString()
		{
			return string.Format("PointLight ({0}, {1})", this.Position.X, this.Position.Y);
		}
	}
}
