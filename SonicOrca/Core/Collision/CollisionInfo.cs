using System;
using SonicOrca.Geometry;

namespace SonicOrca.Core.Collision
{
	// Token: 0x02000198 RID: 408
	public class CollisionInfo
	{
		// Token: 0x17000499 RID: 1177
		// (get) Token: 0x0600117B RID: 4475 RVA: 0x0004522E File Offset: 0x0004342E
		public CollisionVector Vector
		{
			get
			{
				return this._vector;
			}
		}

		// Token: 0x1700049A RID: 1178
		// (get) Token: 0x0600117C RID: 4476 RVA: 0x00045236 File Offset: 0x00043436
		public Vector2 Touch
		{
			get
			{
				return this._touch;
			}
		}

		// Token: 0x1700049B RID: 1179
		// (get) Token: 0x0600117D RID: 4477 RVA: 0x0004523E File Offset: 0x0004343E
		public double Shift
		{
			get
			{
				return this._shift;
			}
		}

		// Token: 0x1700049C RID: 1180
		// (get) Token: 0x0600117E RID: 4478 RVA: 0x00045246 File Offset: 0x00043446
		public double Angle
		{
			get
			{
				return this._angle;
			}
		}

		// Token: 0x0600117F RID: 4479 RVA: 0x0004524E File Offset: 0x0004344E
		public CollisionInfo(CollisionVector vector, Vector2 touch, double shift, double angle)
		{
			this._vector = vector;
			this._touch = touch;
			this._shift = shift;
			this._angle = angle;
		}

		// Token: 0x040009DB RID: 2523
		private readonly CollisionVector _vector;

		// Token: 0x040009DC RID: 2524
		private readonly Vector2 _touch;

		// Token: 0x040009DD RID: 2525
		private readonly double _shift;

		// Token: 0x040009DE RID: 2526
		private readonly double _angle;
	}
}
