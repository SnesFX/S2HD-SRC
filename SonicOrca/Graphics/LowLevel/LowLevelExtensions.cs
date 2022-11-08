using System;
using SonicOrca.Geometry;

namespace SonicOrca.Graphics.LowLevel
{
	// Token: 0x020000FA RID: 250
	public static class LowLevelExtensions
	{
		// Token: 0x06000898 RID: 2200 RVA: 0x00022200 File Offset: 0x00020400
		public static vec2 ToVec2(this Vector2 v)
		{
			return new vec2
			{
				x = (float)v.X,
				y = (float)v.Y
			};
		}
	}
}
