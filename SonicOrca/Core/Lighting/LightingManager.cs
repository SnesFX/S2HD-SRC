using System;
using System.Collections.Generic;
using SonicOrca.Geometry;

namespace SonicOrca.Core.Lighting
{
	// Token: 0x0200018A RID: 394
	internal class LightingManager : ILightingManager
	{
		// Token: 0x06001123 RID: 4387 RVA: 0x00043C53 File Offset: 0x00041E53
		public void RegisterLightSource(ILightSource lightSource)
		{
			this._lightSources.AddLast(lightSource);
		}

		// Token: 0x06001124 RID: 4388 RVA: 0x00043C62 File Offset: 0x00041E62
		public void UnregisterLightSource(ILightSource lightSource)
		{
			this._lightSources.Remove(lightSource);
		}

		// Token: 0x06001125 RID: 4389 RVA: 0x00043C74 File Offset: 0x00041E74
		public Vector2i GetShadowOffset(Vector2i forPosition, IShadowInfo shadowInfo)
		{
			Vector2i vector2i = new Vector2i(int.MaxValue, int.MaxValue);
			Vector2i vector2i2 = new Vector2i(int.MinValue, int.MinValue);
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			foreach (ILightSource lightSource in this._lightSources)
			{
				Vector2i shadowOffset = lightSource.GetShadowOffset(forPosition, shadowInfo);
				if (shadowOffset.X < 0)
				{
					vector2i.X = Math.Min(vector2i.X, shadowOffset.X);
					flag = true;
				}
				else if (shadowOffset.X > 0)
				{
					vector2i2.X = Math.Max(vector2i2.X, shadowOffset.X);
					flag3 = true;
				}
				if (shadowOffset.Y < 0)
				{
					vector2i.Y = Math.Min(vector2i.Y, shadowOffset.Y);
					flag2 = true;
				}
				else if (shadowOffset.Y > 0)
				{
					vector2i2.Y = Math.Max(vector2i2.Y, shadowOffset.Y);
					flag4 = true;
				}
			}
			Vector2i result = default(Vector2i);
			if (flag)
			{
				result.X += vector2i.X;
			}
			if (flag3)
			{
				result.X += vector2i2.X;
			}
			if (flag && flag3)
			{
				result.X /= 2;
			}
			if (flag2)
			{
				result.Y += vector2i.Y;
			}
			if (flag4)
			{
				result.Y += vector2i2.Y;
			}
			if (flag2 && flag3)
			{
				result.Y /= 2;
			}
			Vector2i maxShadowOffset = shadowInfo.MaxShadowOffset;
			result.X = MathX.Clamp(-maxShadowOffset.X, result.X, maxShadowOffset.X);
			result.Y = MathX.Clamp(-maxShadowOffset.Y, result.Y, maxShadowOffset.Y);
			return result;
		}

		// Token: 0x06001126 RID: 4390 RVA: 0x00043E7C File Offset: 0x0004207C
		private static int UpdateShadowOffset(int globalOffset, int localOffset)
		{
			int num;
			if (globalOffset < 0)
			{
				num = Math.Min(globalOffset, localOffset);
				num = Math.Min(num, 0);
			}
			else
			{
				num = Math.Max(globalOffset, localOffset);
				num = Math.Max(num, 0);
			}
			return num;
		}

		// Token: 0x0400099F RID: 2463
		private readonly LinkedList<ILightSource> _lightSources = new LinkedList<ILightSource>();
	}
}
