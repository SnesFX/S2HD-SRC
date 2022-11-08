using System;

namespace OpenTK
{
	// Token: 0x02000538 RID: 1336
	[Serializable]
	public struct BezierCurveQuadric
	{
		// Token: 0x0600428E RID: 17038 RVA: 0x000B3F4C File Offset: 0x000B214C
		public BezierCurveQuadric(Vector2 startAnchor, Vector2 endAnchor, Vector2 controlPoint)
		{
			this.StartAnchor = startAnchor;
			this.EndAnchor = endAnchor;
			this.ControlPoint = controlPoint;
			this.Parallel = 0f;
		}

		// Token: 0x0600428F RID: 17039 RVA: 0x000B3F70 File Offset: 0x000B2170
		public BezierCurveQuadric(float parallel, Vector2 startAnchor, Vector2 endAnchor, Vector2 controlPoint)
		{
			this.Parallel = parallel;
			this.StartAnchor = startAnchor;
			this.EndAnchor = endAnchor;
			this.ControlPoint = controlPoint;
		}

		// Token: 0x06004290 RID: 17040 RVA: 0x000B3F90 File Offset: 0x000B2190
		public Vector2 CalculatePoint(float t)
		{
			Vector2 vector = default(Vector2);
			float num = 1f - t;
			vector.X = num * num * this.StartAnchor.X + 2f * t * num * this.ControlPoint.X + t * t * this.EndAnchor.X;
			vector.Y = num * num * this.StartAnchor.Y + 2f * t * num * this.ControlPoint.Y + t * t * this.EndAnchor.Y;
			if (this.Parallel == 0f)
			{
				return vector;
			}
			Vector2 vec = default(Vector2);
			if (t == 0f)
			{
				vec = this.ControlPoint - this.StartAnchor;
			}
			else
			{
				vec = vector - this.CalculatePointOfDerivative(t);
			}
			return vector + Vector2.Normalize(vec).PerpendicularRight * this.Parallel;
		}

		// Token: 0x06004291 RID: 17041 RVA: 0x000B4088 File Offset: 0x000B2288
		private Vector2 CalculatePointOfDerivative(float t)
		{
			return new Vector2
			{
				X = (1f - t) * this.StartAnchor.X + t * this.ControlPoint.X,
				Y = (1f - t) * this.StartAnchor.Y + t * this.ControlPoint.Y
			};
		}

		// Token: 0x06004292 RID: 17042 RVA: 0x000B40F0 File Offset: 0x000B22F0
		public float CalculateLength(float precision)
		{
			float num = 0f;
			Vector2 right = this.CalculatePoint(0f);
			for (float num2 = precision; num2 < 1f + precision; num2 += precision)
			{
				Vector2 vector = this.CalculatePoint(num2);
				num += (vector - right).Length;
				right = vector;
			}
			return num;
		}

		// Token: 0x04004E45 RID: 20037
		public Vector2 StartAnchor;

		// Token: 0x04004E46 RID: 20038
		public Vector2 EndAnchor;

		// Token: 0x04004E47 RID: 20039
		public Vector2 ControlPoint;

		// Token: 0x04004E48 RID: 20040
		public float Parallel;
	}
}
