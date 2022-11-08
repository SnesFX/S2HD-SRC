using System;

namespace OpenTK
{
	// Token: 0x0200053D RID: 1341
	[Serializable]
	public struct BezierCurveCubic
	{
		// Token: 0x060043E7 RID: 17383 RVA: 0x000B8534 File Offset: 0x000B6734
		public BezierCurveCubic(Vector2 startAnchor, Vector2 endAnchor, Vector2 firstControlPoint, Vector2 secondControlPoint)
		{
			this.StartAnchor = startAnchor;
			this.EndAnchor = endAnchor;
			this.FirstControlPoint = firstControlPoint;
			this.SecondControlPoint = secondControlPoint;
			this.Parallel = 0f;
		}

		// Token: 0x060043E8 RID: 17384 RVA: 0x000B8560 File Offset: 0x000B6760
		public BezierCurveCubic(float parallel, Vector2 startAnchor, Vector2 endAnchor, Vector2 firstControlPoint, Vector2 secondControlPoint)
		{
			this.Parallel = parallel;
			this.StartAnchor = startAnchor;
			this.EndAnchor = endAnchor;
			this.FirstControlPoint = firstControlPoint;
			this.SecondControlPoint = secondControlPoint;
		}

		// Token: 0x060043E9 RID: 17385 RVA: 0x000B8588 File Offset: 0x000B6788
		public Vector2 CalculatePoint(float t)
		{
			Vector2 vector = default(Vector2);
			float num = 1f - t;
			vector.X = this.StartAnchor.X * num * num * num + this.FirstControlPoint.X * 3f * t * num * num + this.SecondControlPoint.X * 3f * t * t * num + this.EndAnchor.X * t * t * t;
			vector.Y = this.StartAnchor.Y * num * num * num + this.FirstControlPoint.Y * 3f * t * num * num + this.SecondControlPoint.Y * 3f * t * t * num + this.EndAnchor.Y * t * t * t;
			if (this.Parallel == 0f)
			{
				return vector;
			}
			Vector2 vec = default(Vector2);
			if (t == 0f)
			{
				vec = this.FirstControlPoint - this.StartAnchor;
			}
			else
			{
				vec = vector - this.CalculatePointOfDerivative(t);
			}
			return vector + Vector2.Normalize(vec).PerpendicularRight * this.Parallel;
		}

		// Token: 0x060043EA RID: 17386 RVA: 0x000B86BC File Offset: 0x000B68BC
		private Vector2 CalculatePointOfDerivative(float t)
		{
			Vector2 result = default(Vector2);
			float num = 1f - t;
			result.X = num * num * this.StartAnchor.X + 2f * t * num * this.FirstControlPoint.X + t * t * this.SecondControlPoint.X;
			result.Y = num * num * this.StartAnchor.Y + 2f * t * num * this.FirstControlPoint.Y + t * t * this.SecondControlPoint.Y;
			return result;
		}

		// Token: 0x060043EB RID: 17387 RVA: 0x000B8754 File Offset: 0x000B6954
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

		// Token: 0x04004E66 RID: 20070
		public Vector2 StartAnchor;

		// Token: 0x04004E67 RID: 20071
		public Vector2 EndAnchor;

		// Token: 0x04004E68 RID: 20072
		public Vector2 FirstControlPoint;

		// Token: 0x04004E69 RID: 20073
		public Vector2 SecondControlPoint;

		// Token: 0x04004E6A RID: 20074
		public float Parallel;
	}
}
