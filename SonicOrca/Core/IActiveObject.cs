using System;
using SonicOrca.Geometry;

namespace SonicOrca.Core
{
	// Token: 0x02000136 RID: 310
	public interface IActiveObject
	{
		// Token: 0x17000309 RID: 777
		// (get) Token: 0x06000C68 RID: 3176
		Level Level { get; }

		// Token: 0x1700030A RID: 778
		// (get) Token: 0x06000C69 RID: 3177
		ObjectType Type { get; }

		// Token: 0x1700030B RID: 779
		// (get) Token: 0x06000C6A RID: 3178
		ObjectEntry Entry { get; }

		// Token: 0x1700030C RID: 780
		// (get) Token: 0x06000C6B RID: 3179
		// (set) Token: 0x06000C6C RID: 3180
		LevelLayer Layer { get; set; }

		// Token: 0x1700030D RID: 781
		// (get) Token: 0x06000C6D RID: 3181
		// (set) Token: 0x06000C6E RID: 3182
		int Priority { get; set; }

		// Token: 0x1700030E RID: 782
		// (get) Token: 0x06000C6F RID: 3183
		// (set) Token: 0x06000C70 RID: 3184
		Vector2i Position { get; set; }

		// Token: 0x1700030F RID: 783
		// (get) Token: 0x06000C71 RID: 3185
		// (set) Token: 0x06000C72 RID: 3186
		Vector2 PositionPrecise { get; set; }

		// Token: 0x17000310 RID: 784
		// (get) Token: 0x06000C73 RID: 3187
		Vector2i LastPosition { get; }

		// Token: 0x17000311 RID: 785
		// (get) Token: 0x06000C74 RID: 3188
		Vector2 LastPositionPrecise { get; }

		// Token: 0x17000312 RID: 786
		// (get) Token: 0x06000C75 RID: 3189
		// (set) Token: 0x06000C76 RID: 3190
		float Brightness { get; set; }

		// Token: 0x06000C77 RID: 3191
		void Finish();

		// Token: 0x06000C78 RID: 3192
		void FinishForever();
	}
}
