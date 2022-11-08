using System;
using System.Collections.Generic;

namespace OpenTK
{
	// Token: 0x0200052C RID: 1324
	[Serializable]
	public struct BezierCurve
	{
		// Token: 0x17000316 RID: 790
		// (get) Token: 0x06003F34 RID: 16180 RVA: 0x000A7410 File Offset: 0x000A5610
		public IList<Vector2> Points
		{
			get
			{
				return this.points;
			}
		}

		// Token: 0x06003F35 RID: 16181 RVA: 0x000A7418 File Offset: 0x000A5618
		public BezierCurve(IEnumerable<Vector2> points)
		{
			if (points == null)
			{
				throw new ArgumentNullException("points", "Must point to a valid list of Vector2 structures.");
			}
			this.points = new List<Vector2>(points);
			this.Parallel = 0f;
		}

		// Token: 0x06003F36 RID: 16182 RVA: 0x000A7444 File Offset: 0x000A5644
		public BezierCurve(params Vector2[] points)
		{
			if (points == null)
			{
				throw new ArgumentNullException("points", "Must point to a valid list of Vector2 structures.");
			}
			this.points = new List<Vector2>(points);
			this.Parallel = 0f;
		}

		// Token: 0x06003F37 RID: 16183 RVA: 0x000A7470 File Offset: 0x000A5670
		public BezierCurve(float parallel, params Vector2[] points)
		{
			if (points == null)
			{
				throw new ArgumentNullException("points", "Must point to a valid list of Vector2 structures.");
			}
			this.Parallel = parallel;
			this.points = new List<Vector2>(points);
		}

		// Token: 0x06003F38 RID: 16184 RVA: 0x000A7498 File Offset: 0x000A5698
		public BezierCurve(float parallel, IEnumerable<Vector2> points)
		{
			if (points == null)
			{
				throw new ArgumentNullException("points", "Must point to a valid list of Vector2 structures.");
			}
			this.Parallel = parallel;
			this.points = new List<Vector2>(points);
		}

		// Token: 0x06003F39 RID: 16185 RVA: 0x000A74C0 File Offset: 0x000A56C0
		public Vector2 CalculatePoint(float t)
		{
			return BezierCurve.CalculatePoint(this.points, t, this.Parallel);
		}

		// Token: 0x06003F3A RID: 16186 RVA: 0x000A74D4 File Offset: 0x000A56D4
		public float CalculateLength(float precision)
		{
			return BezierCurve.CalculateLength(this.points, precision, this.Parallel);
		}

		// Token: 0x06003F3B RID: 16187 RVA: 0x000A74E8 File Offset: 0x000A56E8
		public static float CalculateLength(IList<Vector2> points, float precision)
		{
			return BezierCurve.CalculateLength(points, precision, 0f);
		}

		// Token: 0x06003F3C RID: 16188 RVA: 0x000A74F8 File Offset: 0x000A56F8
		public static float CalculateLength(IList<Vector2> points, float precision, float parallel)
		{
			float num = 0f;
			Vector2 right = BezierCurve.CalculatePoint(points, 0f, parallel);
			for (float num2 = precision; num2 < 1f + precision; num2 += precision)
			{
				Vector2 vector = BezierCurve.CalculatePoint(points, num2, parallel);
				num += (vector - right).Length;
				right = vector;
			}
			return num;
		}

		// Token: 0x06003F3D RID: 16189 RVA: 0x000A754C File Offset: 0x000A574C
		public static Vector2 CalculatePoint(IList<Vector2> points, float t)
		{
			return BezierCurve.CalculatePoint(points, t, 0f);
		}

		// Token: 0x06003F3E RID: 16190 RVA: 0x000A755C File Offset: 0x000A575C
		public static Vector2 CalculatePoint(IList<Vector2> points, float t, float parallel)
		{
			Vector2 vector = default(Vector2);
			double x = 1.0 - (double)t;
			int num = 0;
			foreach (Vector2 vector2 in points)
			{
				float num2 = (float)MathHelper.BinomialCoefficient(points.Count - 1, num) * (float)(Math.Pow((double)t, (double)num) * Math.Pow(x, (double)(points.Count - 1 - num)));
				vector.X += num2 * vector2.X;
				vector.Y += num2 * vector2.Y;
				num++;
			}
			if (parallel == 0f)
			{
				return vector;
			}
			Vector2 vec = default(Vector2);
			if (t != 0f)
			{
				vec = vector - BezierCurve.CalculatePointOfDerivative(points, t);
			}
			else
			{
				vec = points[1] - points[0];
			}
			return vector + Vector2.Normalize(vec).PerpendicularRight * parallel;
		}

		// Token: 0x06003F3F RID: 16191 RVA: 0x000A7678 File Offset: 0x000A5878
		private static Vector2 CalculatePointOfDerivative(IList<Vector2> points, float t)
		{
			Vector2 result = default(Vector2);
			double x = 1.0 - (double)t;
			int num = 0;
			foreach (Vector2 vector in points)
			{
				float num2 = (float)MathHelper.BinomialCoefficient(points.Count - 2, num) * (float)(Math.Pow((double)t, (double)num) * Math.Pow(x, (double)(points.Count - 2 - num)));
				result.X += num2 * vector.X;
				result.Y += num2 * vector.Y;
				num++;
			}
			return result;
		}

		// Token: 0x04004DF8 RID: 19960
		private List<Vector2> points;

		// Token: 0x04004DF9 RID: 19961
		public float Parallel;
	}
}
